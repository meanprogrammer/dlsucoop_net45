using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Specialized;
using System.Linq;
using System.Data.Linq;

namespace DataHelper
{
    public class DataAccess : IDisposable
    {
        //OFFICE
        //string conn = @"Data Source=DHDC597\SQL2012;Initial Catalog=Messages;Integrated Security=True;";

        //HOUSE
        //protected string conn = @"Data Source=GT683\SQL2012EXP;Initial Catalog=Messages;Integrated Security=true;";

        //PROD
        //protected string conn = @"workstation id=Messages.mssql.somee.com;packet size=4096;user id=jeduardo_SQLLogin_1;pwd=qe3f68sj67;data source=Messages.mssql.somee.com;persist security info=False;initial catalog=Messages;";
        //APPHARBOR-PROD
        protected string conn = @"Server=79488b62-49e5-4899-ba70-a47800a28f69.sqlserver.sequelizer.com;Database=db79488b6249e54899ba70a47800a28f69;User ID=nkjhrjfczbcjiuop;Password=jyD5KEToEtAEcUFv7QMvsLv7kaTvQSrLmaVrXXpBLEwE5Px8bpmMxusFdFSJUxFU;";

        //LAGUNA
        //protected string conn = @"Data Source=PROGRAMMERPC\SQL2012;Initial Catalog=Messages;Integrated Security=true;";

        protected SqlConnection MyConn;
        protected SqlDataReader dr;
        protected SqlCommand sqlCmd;
        protected DataTable dt;
        protected SqlDataAdapter da;
        private bool _disposed;
        private string cmd;
        public static string empNum;
        private static Rijndael myRijndael = Rijndael.Create();
        public DataAccess()
        {
            this.cmd = "";
            this.MyConn = new SqlConnection(this.conn);
            this.sqlCmd = new SqlCommand(this.cmd, this.MyConn);
            this.dt = new DataTable();
        }

        public List<DownloadableForm> getAllDownloadables()
        {
            List<DownloadableForm> result = new List<DownloadableForm>();
            using (MessagesDataContext context = new MessagesDataContext())
            {
                result = context.DownloadableForms.OrderBy(c => c.RecordID).ToList();
            }
            return result;
        }

        public LoanApplication GetOneLoanApplication(int transId)
        {
            LoanApplication result = null;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                result = context.LoanApplications.FirstOrDefault(x => x.TransactionID == transId);
            }
            return result;
        }

        public bool UpdateInterestRate(double interestRate, int loanType)
        {
            int result = 0;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                var records = context.LoanAmountMatrixes.Where(c => c.LoanType == loanType);
                foreach (var r in records)
                {
                    r.Interest = interestRate;
                }

                result = context.GetChangeSet().Updates.Count;
                context.SubmitChanges();
            }
            return result > 0;
        }

        public bool SaveDownloadableForm(string text, string url)
        {
            int result = 0;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                DownloadableForm df = new DownloadableForm();
                df.FormText = text;
                df.FormUrl = url;
                context.DownloadableForms.InsertOnSubmit(df);
                result = context.GetChangeSet().Inserts.Count;
                context.SubmitChanges();
            }
            return result > 0;
        }

        public List<LoanApplication> GetAllLoanApp()
        {
            List<LoanApplication> result = new List<LoanApplication>();
            using (MessagesDataContext c = new MessagesDataContext())
            {
                result = c.LoanApplications.ToList();
            }
            return result;
        }

        public List<LoanReportDTO> FilterLoanReport(DateTime startDate, DateTime endDate, bool employee, bool nonEmployee)
        {
            List<LoanReportDTO> result = new List<LoanReportDTO>();
            using(MessagesDataContext context = new MessagesDataContext())
            {
                string sDate = startDate.ToString("yyyy-MM-dd");
                string eDate = endDate.ToString("yyyy-MM-dd");
                
                StringBuilder builder = new StringBuilder();
                if(employee == true && nonEmployee == true) 
                {
                    builder.Append("\'Employee\',\'Non-Employee'");
                }
                else if(employee == true && nonEmployee == false)
                {
                    builder.Append("\'Employee\'");
                }
                else if(employee == false && nonEmployee == true)
                {
                    builder.Append("\'Non-Employee'");
                }
                else
                {
                    builder.Append("\'Employee\',\'Non-Employee'");
                }

                string query = string.Format("select la.TransactionID, la.EmpNo, u.UserType, u.LastName, u.FirstName, u.MiddleName, "+
                        " ul.DateFiled, lt.LoanType, la.Amount, la.Balance,la.DateDue from LoanApplication la "+
                        " inner join UnconfirmedLoan ul on la.TransactionID = ul.TransactionID "+
                        " left join LoanTypes lt on la.TypeOfLoan = lt.RecordID " +
                        " left join Users u on la.EmpNo = u.EmpNo "+
                        " where (ul.DateFiled >= '{0}' AND ul.DateFiled <= '{1}') AND u.UserType in ({2})", sDate, eDate, builder.ToString());
          

                this.sqlCmd.CommandText = query;
                OpenConnection();
                IDataReader reader = this.sqlCmd.ExecuteReader();
               
                while (reader.Read())
                {
                    LoanReportDTO dto = new LoanReportDTO();
                    dto.TransactionID = reader.GetInt32(0);
                    dto.EmpNo = reader.GetString(1);
                    dto.UserType = reader.GetString(2);
                    dto.Lastname = reader.GetString(3);
                    dto.Firstname = reader.GetString(4);
                    dto.MI = reader.GetString(5);
                    dto.DateFiled = reader.GetDateTime(6);
                    dto.LoanType = reader.GetString(7);
                    dto.LoanAmount = reader.GetDecimal(8);
                    dto.LoanBalance = reader.GetDecimal(9);
                    if (!reader.IsDBNull(10))
                    {
                        dto.LoanDueDate = (Nullable<DateTime>)reader.GetDateTime(10);
                    }
                    result.Add(dto);
                }

                reader.Close();
                reader.Dispose();

                this.MyConn.Close();
                this.EndProcess();


                //result = context.ExecuteQuery<LoanReportDTO>(query).ToList();
            }
            return result;
        }

        public bool UpdateDownloadableForm(int recordid, string text, string url)
        {
            int result = 0;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                DownloadableForm df = context.DownloadableForms.FirstOrDefault(c => c.RecordID == recordid);
                if (df != null)
                {
                    df.FormText = text;
                    df.FormUrl = url;
                    result = context.GetChangeSet().Updates.Count;
                    context.SubmitChanges();
                }
                else
                {
                    return false;
                }
            }
            return result > 0;
        }

        public DownloadableForm getOneDownloadableForm(int recordId)
        {
            DownloadableForm result = new DownloadableForm();
            using (MessagesDataContext context = new MessagesDataContext())
            {
                result = context.DownloadableForms.FirstOrDefault(c => c.RecordID == recordId);
            }
            return result;
        }

        public List<LoanType> GetLoanTypes()
        {
            List<LoanType> result = new List<LoanType>();
            using (MessagesDataContext context = new MessagesDataContext())
            {
                result = context.LoanTypes.ToList();
            }
            return result;
        }

        public string GetLoanType(int recordId)
        {
            string result = string.Empty;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                LoanType lt = context.LoanTypes.FirstOrDefault(c=>c.RecordID == recordId);
                if (lt != null)
                {
                    result = lt.LoanType1;
                }
            }
            return result;
        }

        public List<LoanAmountMatrix> GetLoanAmountMatrix(int loanType, string empNo)
        {
            List<LoanAmountMatrix> result = new List<LoanAmountMatrix>();
            using (MessagesDataContext context = new MessagesDataContext())
            {
                result = context.LoanAmountMatrixes.Where(c => c.LoanType == loanType).ToList();

                double totalShare = GetTotalShareCapitals(empNo);
                /*
                foreach (LoanAmountMatrix item in result)
                {
                    if (totalShare < item.RequiredShareCapital)
                    {
                        result.Remove(item);
                    }
                }*/

                result = (from r in result
                          where r.RequiredShareCapital <= totalShare
                          select r).ToList();
            }
            return result;
        }

        public IQueryable GetLoanAmountMatrix()
        {
            /*
             * private int _RecordID;
		
		private int _LoanType;
		
		private double _LoanAmount;
		
		private double _RequiredShareCapital;
		
		private double _Interest;
		
		private int _MonthsPayable;
		
		private System.Nullable<double> _ProcessingFee;
             */
            IQueryable result = null;
            MessagesDataContext context = new MessagesDataContext();
            
                


                var innerJoinQuery =
    from lam in context.LoanAmountMatrixes
    join lt in context.LoanTypes on lam.LoanType equals lt.RecordID
    select new { RecordId = lam.RecordID, LoanType = lam.LoanType, 
        LoanAmount = lam.LoanAmount, 
        RequiredShareCapital = lam.RequiredShareCapital,
        Interest = lam.Interest,
        MonthsPayable = lam.MonthsPayable,
        ProcessingFee = lam.ProcessingFee,
        LoanTypeText = lt.LoanType1}; //produces flat sequence

                result = innerJoinQuery;
           
            
            return result;
        }

        public string GetLoanTypeText(int recordId)
        {
            string  result = string.Empty;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                LoanType lt = context.LoanTypes.FirstOrDefault(x => x.RecordID == recordId);
                if (lt != null)
                {
                    result = lt.LoanType1;
                }
            }
            return result;
        }

        public LoanAmountMatrix GetOneLoanMatrixById(int recordId)
        {
            LoanAmountMatrix lm = null;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                lm = context.LoanAmountMatrixes.FirstOrDefault(c => c.RecordID == recordId);
            }
            return lm;
        }

        public LoanAmountMatrix GetOneLoanMatrixByType(int loanType)
        {
            LoanAmountMatrix lm = null;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                lm = context.LoanAmountMatrixes.FirstOrDefault(c => c.LoanType == loanType);
            }
            return lm;
        }

        public void InsertMessage(string pID, string pSource, string pMsg, string pUDH)
        {
            /*
            this.sqlCmd.CommandText = "Insert into MSGS values (@ID, @Source, @Msg, @UDH, @DateReceived)";
            this.sqlCmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = pID;
            this.sqlCmd.Parameters.Add("@Source", SqlDbType.NVarChar).Value = pSource;
            this.sqlCmd.Parameters.Add("@Msg", SqlDbType.NVarChar).Value = pMsg;
            this.sqlCmd.Parameters.Add("@UDH", SqlDbType.NVarChar).Value = pUDH;
            this.sqlCmd.Parameters.Add("@DateReceived", SqlDbType.DateTime).Value = DateTime.Now;
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
            */

            using (MessagesDataContext context = new MessagesDataContext())
            {
                MSG msg = new MSG();
                msg.ID = pID;
                msg.Source = pSource;
                msg.Msg1 = pMsg;
                msg.UDH = pUDH;
                msg.DateReceived = DateTime.Now;

                context.MSGs.InsertOnSubmit(msg);
                context.SubmitChanges();
            }
        }

        public bool HasShareCapital(string empNo)
        {
            bool result = false;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                ShareCapital sc = context.ShareCapitals.FirstOrDefault(c => c.EmpNo == empNo);
                result = sc != null;
            }
            return result;
        }

        public double GetTotalShareCapitals(string empNo)
        {
            double total = 0f;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                IQueryable<ShareCapitalPayment> all = context.ShareCapitalPayments.Where(c => c.EmpNo == empNo);
                if (all != null && all.Count() > 0)
                {
                    total = all.Sum(c => c.Amount);
                }
            }
            return total;
        }

        public bool SaveShareCapital2(string empNo, double amount)
        {
            int result = 0;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                ShareCapital sc = context.ShareCapitals.FirstOrDefault(c => c.EmpNo == empNo);
                if (sc == null)
                {
                    sc = new ShareCapital();
                    sc.EmpNo = empNo;
                    sc.ShareCapital1 = amount;
                    context.ShareCapitals.InsertOnSubmit(sc);
                    result = context.GetChangeSet().Inserts.Count;
                }
                else
                {
                    sc.ShareCapital1 = amount;
                    result = context.GetChangeSet().Updates.Count;
                }
                context.SubmitChanges();
            }
            return result > 0;
        }

        public ShareCapital GetShareCapital(string empNo)
        {
            ShareCapital sc = null;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                sc = context.ShareCapitals.FirstOrDefault(c => c.EmpNo == empNo);
            }
            return sc;
        }

        public string RelatedEmployee(string empNo)
        {
            string result = string.Empty;
            MessagesDataContext context = new MessagesDataContext();
            RelativeEmployee rEmp = context.RelativeEmployees.FirstOrDefault(c => c.EmpNo == empNo);
            return rEmp.RelativeEmpNo;
        }

        public DataTable GetAllUsers()
        {
            this.cmd = "Select EmpNo, (EmpNo + ' - ' + LastName+', '+FirstName+' '+MiddleName) as Name FROM Users";
            DataTable dt = this.GetTable(this.cmd);
            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { "0", "-- SELECT --" };
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        public void SaveDump(string dump)
        {
            using (MessagesDataContext context = new MessagesDataContext())
            {
                RegDump rd = new RegDump();
                rd.Data = dump;
                context.RegDumps.InsertOnSubmit(rd);
                context.SubmitChanges();
            }
        }

        public bool SaveAccessToken(string accessToken, string subcriberNumber)
        {
            int result = -1;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                User u = context.Users.FirstOrDefault(c => c.PhoneNumber == subcriberNumber);

                AccessToken at = new AccessToken();
                at.EmpNo = u.EmpNo;
                at.AccessToken1 = accessToken;

                context.AccessTokens.InsertOnSubmit(at);
                result = context.GetChangeSet().Inserts.Count;
                context.SubmitChanges();
            }
            return result > 0;
        }

        public DataTable GetAllUsersWithEmpty()
        {
            this.cmd = "Select EmpNo, (EmpNo + ' - ' + LastName+', '+FirstName+' '+MiddleName) as Name FROM Users";
            DataTable dt = this.GetTable(this.cmd);
            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { "", "-- SELECT --" };
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        public DataTable GetAllUsersWithEmptyExceptOne(string empNo)
        {
            this.cmd = "Select EmpNo, (EmpNo + ' - ' + LastName+', '+FirstName+' '+MiddleName) as Name FROM Users WHERE EmpNo <> '" + empNo + "' AND DateConfirmed IS NOT NULL";
            DataTable dt = this.GetTable(this.cmd);
            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { "", "-- SELECT --" };
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        public DataTable GetEligibleRelativeUsers()
        {
            this.cmd = "Select EmpNo, (EmpNo + ' - ' + LastName+', '+FirstName+' '+MiddleName) as Name FROM Users WHERE [UserType] = 'Employee'";
            DataTable dt = this.GetTable(this.cmd);
            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { "0", "-- SELECT --" };
            dt.Rows.InsertAt(dr, 0);
            return dt;
        }



        public void SMSRegistrationInsert(List<string> regDetails, string number)
        {
            this.sqlCmd.CommandText = "Insert into UnconfirmedUsers (EmpNo,DateRegistered) values (@EmpNo, @Date)";
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = regDetails[1];
            this.sqlCmd.Parameters.Add("@Date", SqlDbType.Date).Value = DateTime.Now.ToShortDateString();
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.MyConn.Close();
            if (regDetails.Count == 4)
            {
                this.cmd = "Insert into Users (EmpNo, Name, Email, Password) values (@EmpNo, @Name, @Email, @Pass)";
            }
            else
            {
                this.cmd = "Insert into Users (EmpNo, Email, Password, College, Dept, PhoneNumber, MemberStatus, DateHired, Birthday, Address, UserType, FirstName, LastName, MiddleName) values (@EmpNo, @Email, @Pass, @College, @Dept, @PhoneNumber, @MemberStatus, @DateHired, @Birthday, @Address, @UserType, @FirstName, @LastName, @MiddleName)";
            }
            this.sqlCmd.CommandText = this.cmd;
            //this.sqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = regDetails[0];
            this.sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = regDetails[2];
            this.sqlCmd.Parameters.Add("@Pass", SqlDbType.NVarChar).Value = regDetails[3];
            //if (regDetails.Count == 10)
            //{
            this.sqlCmd.Parameters.Add("@College", SqlDbType.NVarChar).Value = regDetails[4];
            this.sqlCmd.Parameters.Add("@Dept", SqlDbType.NVarChar).Value = regDetails[5];
            this.sqlCmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = number;
            this.sqlCmd.Parameters.Add("@MemberStatus", SqlDbType.NVarChar).Value = regDetails[6];
            this.sqlCmd.Parameters.Add("@DateHired", SqlDbType.NVarChar).Value = regDetails[7];
            this.sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = regDetails[8];
            this.sqlCmd.Parameters.Add("@Birthday", SqlDbType.Date).Value = Convert.ToDateTime(regDetails[9]);
            this.sqlCmd.Parameters.Add("@UserType", SqlDbType.NVarChar).Value = regDetails[13];
            this.sqlCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = regDetails[10];
            this.sqlCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = regDetails[11];
            this.sqlCmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar).Value = regDetails[12];
            //}
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
        }

        public string GetLastNonEmployeeID()
        {
            string prefix = "NE-";
            int startingId = 10000;

            this.sqlCmd.CommandText = "SELECT EmpNo FROM Users WHERE UserType='Non-Employee'";
            OpenConnection();
            IDataReader reader = this.sqlCmd.ExecuteReader();
            List<string> ids = new List<string>();
            while (reader.Read())
            {
                ids.Add(reader.GetString(0));
            }

            reader.Close();
            reader.Dispose();

            if (ids.Count > 0)
            {
                List<int> numericIds = new List<int>();
                foreach (string anId in ids)
                {
                    string[] splitted = anId.Split(new char[] { '-' });

                    if (splitted.Length != 2)
                        throw new ArgumentException("Invalid format of ID");

                    numericIds.Add(int.Parse(splitted[1]));
                }
                return string.Format("{0}{1}", prefix, numericIds.Max() + 1);
            }

            this.MyConn.Close();
            this.EndProcess();
            return string.Format("{0}{1}", prefix, startingId);
        }

        public void SaveEmployeeRegistrationLinq(Dictionary<string, string> values)
        {
            MessagesDataContext context = new MessagesDataContext();

            UnconfirmedUser unconfirmedUser = new UnconfirmedUser();
            unconfirmedUser.EmpNo = values[ColumnKeys.EMP_NO];
            unconfirmedUser.DateRegistered = DateTime.Now;
            context.UnconfirmedUsers.InsertOnSubmit(unconfirmedUser);
            context.SubmitChanges();

            User u = new User();
            u.EmpNo = values[ColumnKeys.EMP_NO];
            u.Email = values[ColumnKeys.EMAIL];
            u.Password = values[ColumnKeys.PASSWORD];
            u.College = values[ColumnKeys.COLLEGE];
            u.Dept = values[ColumnKeys.DEPARTMENT];
            u.MemberStatus = values[ColumnKeys.EMP_STATUS];
            u.DateHired = Convert.ToDateTime(values[ColumnKeys.DATE_HIRED]);
            u.Address = values[ColumnKeys.ADDRESS];
            u.Birthday = Convert.ToDateTime(values[ColumnKeys.BIRTHDATE]);
            u.FirstName = values[ColumnKeys.FIRSTNAME];
            u.LastName = values[ColumnKeys.LASTNAME];
            u.MiddleName = values[ColumnKeys.MIDDLENAME];
            u.UserType = values[ColumnKeys.REG_TYPE];
            u.PhoneNumber = values[ColumnKeys.MOBILE];
            u.ATMAccountNo = values[ColumnKeys.ATMNO];
            u.TINNo = values[ColumnKeys.TINNO];
            u.SSSNo = values[ColumnKeys.SSSNO];
            u.Gender = values[ColumnKeys.GENDER];
            u.CivilStatus = values[ColumnKeys.CIVILSTATUS];
            u.FatherName = values[ColumnKeys.FATHERNAME];
            u.FatherOccupation = values[ColumnKeys.FATHER_OCC];
            u.MotherName = values[ColumnKeys.MOTHERNAME];
            u.MotherOccupation = values[ColumnKeys.MOTHER_OCC];
            u.LegalSpouse = values[ColumnKeys.SPOUSE];
            u.SpouseEmployer = values[ColumnKeys.SPOUSE_EMP];
            u.BusinessName = values[ColumnKeys.BUSINESSNAME];
            u.BusinessAddress = values[ColumnKeys.BUSINESSADD];
            u.OtherSourceOfIncome = values[ColumnKeys.OTHERSOURCE];
            u.EmergencyName = values[ColumnKeys.EMERGENCYNAME];
            u.EmergencyAddress = values[ColumnKeys.EMERGENCYADD];
            u.EmergencyNumber = values[ColumnKeys.EMERGENCYNO];
            context.Users.InsertOnSubmit(u);
            context.SubmitChanges();

            context.Dispose();
        }

        public void SMSRegistrationInsertNonEmployee(List<string> regDetails, string number)
        {
            /*
            this.sqlCmd.CommandText = "Insert into UnconfirmedUsers (EmpNo,DateRegistered) values (@EmpNo, @Date)";
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = regDetails[0];
            this.sqlCmd.Parameters.Add("@Date", SqlDbType.Date).Value = DateTime.Now.ToShortDateString();
            */
            using (MessagesDataContext context = new MessagesDataContext())
            {
                UnconfirmedUser uc = new UnconfirmedUser();
                uc.EmpNo = regDetails[0];
                uc.DateRegistered = DateTime.Now;
                context.UnconfirmedUsers.InsertOnSubmit(uc);
                context.SubmitChanges();
            }

            OpenConnection();

            this.sqlCmd.ExecuteNonQuery();
            this.MyConn.Close();

            this.cmd = "Insert into Users (EmpNo, Email, Password, PhoneNumber, Birthday, Address, UserType, FirstName, LastName, MiddleName) " +
                                  "values (@EmpNo, @Email, @Pass, @PhoneNumber, @Birthday, @Address, @UserType, @FirstName, @LastName, @MiddleName)";

            this.sqlCmd.CommandText = this.cmd;
            this.sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = regDetails[1];
            this.sqlCmd.Parameters.Add("@Pass", SqlDbType.NVarChar).Value = regDetails[2];
            this.sqlCmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = number;

            this.sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = regDetails[3];
            this.sqlCmd.Parameters.Add("@Birthday", SqlDbType.Date).Value = Convert.ToDateTime(regDetails[4]);
            this.sqlCmd.Parameters.Add("@UserType", SqlDbType.NVarChar).Value = regDetails[8];
            this.sqlCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = regDetails[5];
            this.sqlCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = regDetails[6];
            this.sqlCmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar).Value = regDetails[7];

            using (MessagesDataContext context = new MessagesDataContext())
            {
                RelativeEmployee re = new RelativeEmployee();
                re.EmpNo = regDetails[0];
                re.RelativeEmpNo = regDetails[9];
                context.RelativeEmployees.InsertOnSubmit(re);
                context.SubmitChanges();
            }
            //}
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.MyConn.Close();
            this.EndProcess();
        }


        public void SMSRegistrationInsertNonEmployeeLinq(Dictionary<string, string> values)
        {
            MessagesDataContext context = new MessagesDataContext();

            UnconfirmedUser unconfirmed = new UnconfirmedUser();
            unconfirmed.EmpNo = values[ColumnKeys.EMP_NO];
            unconfirmed.DateRegistered = DateTime.Now;
            context.UnconfirmedUsers.InsertOnSubmit(unconfirmed);
            context.SubmitChanges();

            //this.sqlCmd.CommandText = "Insert into UnconfirmedUsers (EmpNo,DateRegistered) values (@EmpNo, @Date)";
            //this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = regDetails[0];
            //this.sqlCmd.Parameters.Add("@Date", SqlDbType.Date).Value = DateTime.Now.ToShortDateString();
            /*
                    if (this.MyConn.State == ConnectionState.Closed)
                    {
                        OpenConnection();
                    }
            

                    this.sqlCmd.ExecuteNonQuery();
                    this.MyConn.Close();

                    this.cmd = "Insert into Users (EmpNo, Email, Password, PhoneNumber, Birthday, Address, UserType, FirstName, LastName, MiddleName) " +
                                          "values (@EmpNo, @Email, @Pass, @PhoneNumber,
             * @Birthday, @Address, @UserType, @FirstName, @LastName, @MiddleName)";

                    this.sqlCmd.CommandText = this.cmd;
                    this.sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = regDetails[1];
                    this.sqlCmd.Parameters.Add("@Pass", SqlDbType.NVarChar).Value = regDetails[2];
                    this.sqlCmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = number;

                    this.sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = regDetails[3];
                    this.sqlCmd.Parameters.Add("@Birthday", SqlDbType.Date).Value = Convert.ToDateTime(regDetails[4]);
                    this.sqlCmd.Parameters.Add("@UserType", SqlDbType.NVarChar).Value = regDetails[8];
                    this.sqlCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = regDetails[5];
                    this.sqlCmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = regDetails[6];
                    this.sqlCmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar).Value = regDetails[7];
                    */

            User u = new User();
            u.EmpNo = values[ColumnKeys.EMP_NO];
            u.Email = values[ColumnKeys.EMAIL];
            u.Password = values[ColumnKeys.PASSWORD];
            u.PhoneNumber = values[ColumnKeys.MOBILE];
            u.Birthday = Convert.ToDateTime(values[ColumnKeys.BIRTHDATE]);
            u.Address = values[ColumnKeys.ADDRESS];
            u.UserType = values[ColumnKeys.REG_TYPE];
            u.FirstName = values[ColumnKeys.FIRSTNAME];
            u.LastName = values[ColumnKeys.LASTNAME];
            u.MiddleName = values[ColumnKeys.MIDDLENAME];
            context.Users.InsertOnSubmit(u);
            context.SubmitChanges();


            RelativeEmployee re = new RelativeEmployee();
            re.EmpNo = values[ColumnKeys.EMP_NO];
            re.RelativeEmpNo = values[ColumnKeys.RELATIVE_ID];
            context.RelativeEmployees.InsertOnSubmit(re);
            context.SubmitChanges();

            context.Dispose();

            //}
            //OpenConnection();
            //this.sqlCmd.ExecuteNonQuery();
            //this.MyConn.Close();
            //this.EndProcess();
        }

        public void SMSRegistrationUpdateMailPass(string empNo, string confirmCode)
        {
            this.sqlCmd.CommandText = "Update UnconfirmedUsers set ConfirmationCode = @ConfirmCode where EmpNo = @EmpNo";
            this.sqlCmd.Parameters.Add("@ConfirmCode", SqlDbType.NVarChar).Value = confirmCode;
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = empNo;
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
        }

        public bool CompleteDetail(string empNo)
        {
            bool result = true;
            if (!empNo.StartsWith("NE-"))
            {
                this.cmd = "Select EmpNo, LastName, FirstName, MiddleName, Email, Password, Address, Birthday, College, Dept, PhoneNumber, DateConfirmed, MemberStatus from Users where EmpNo = '" + empNo + "'";
                this.sqlCmd.CommandText = this.cmd;

                OpenConnection();
                using (this.dr = this.sqlCmd.ExecuteReader())
                {
                    this.dr.Read();
                    for (int i = 0; i < this.dr.FieldCount; i++)
                    {
                        if (this.dr.IsDBNull(i))
                        {
                            result = false;
                        }
                    }
                }
                this.EndProcess();
            }
            return result;
        }

        public bool SaveShareCapital(string empNo, double share)
        {
            int result = 0;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                ShareCapitalPayment scp = new ShareCapitalPayment();
                scp.EmpNo = empNo;
                scp.Amount = share;
                scp.DatePaid = DateTime.Now;
                context.ShareCapitalPayments.InsertOnSubmit(scp);
                result = context.GetChangeSet().Inserts.Count;
                context.SubmitChanges();
            }
            return result > 0;
        }

        public string GetPassword(string empNo)
        {
            this.cmd = "Select Password from Users where EmpNo = '" + empNo + "'";
            this.sqlCmd.CommandText = this.cmd;
            OpenConnection();
            string result = "";
            using (this.dr = this.sqlCmd.ExecuteReader())
            {
                this.dr.Read();
                result = this.dr.GetString(0);
            }
            this.EndProcess();
            return result;
        }
        public void ConfirmUser(string empNo, string confirmCode)
        {
            bool flag = false;
            this.sqlCmd.CommandText = "Select * from UnconfirmedUsers where EmpNo = @EmpNo AND ConfirmationCode = @CC";
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = empNo;
            this.sqlCmd.Parameters.Add("@CC", SqlDbType.NVarChar).Value = confirmCode;
            this.sqlCmd.Parameters.Add("@Date", SqlDbType.Date).Value = DateTime.Now.ToShortDateString();
            OpenConnection();
            this.dr = this.sqlCmd.ExecuteReader();
            if (this.dr.Read())
            {
                flag = true;
            }
            this.dr.Close();
            if (flag)
            {
                this.sqlCmd.CommandText = "Update Users set  DateConfirmed = @Date where EmpNo = @EmpNo";
                this.sqlCmd.ExecuteNonQuery();
                this.sqlCmd.CommandText = "Delete from UnconfirmedUsers where EmpNo = @EmpNo";
                this.sqlCmd.ExecuteNonQuery();
            }
            this.EndProcess();
        }

        public bool NewRegistrationExist(string empNo, string eMail, string number)
        {
            bool result = false;
            this.sqlCmd.CommandText = "Select * from Users where Email = @Email Or EmpNo = @EmpNo";
            this.sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = eMail;
            this.sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar).Value = number;
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = empNo;
            OpenConnection();
            this.dr = this.sqlCmd.ExecuteReader();
            while (this.dr.Read())
            {
                result = true;
            }
            this.dr.Close();
            this.sqlCmd.CommandText = "Select * from UnconfirmedUsers where EmpNo = @EmpNo";
            this.dr = this.sqlCmd.ExecuteReader();
            while (this.dr.Read())
            {
                result = true;
            }
            this.dr.Close();
            this.EndProcess();
            return result;
        }
        public bool EmployeeNumberExist(string empNo)
        {
            bool result = false;
            this.sqlCmd.CommandText = "Select * from Users where EmpNo = @EmpNo";
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = empNo;
            OpenConnection();

            this.dr = this.sqlCmd.ExecuteReader();
            while (this.dr.Read())
            {
                result = true;
            }
            this.dr.Close();
            this.EndProcess();
            return result;
        }
        public bool EmployeeNumberExistAndConfirmed(string empNo)
        {
            bool result = false;
            this.sqlCmd.CommandText = "Select * from Users where EmpNo = @EmpNo AND DateConfirmed IS NOT NULL";
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = empNo;
            OpenConnection();
            this.dr = this.sqlCmd.ExecuteReader();
            while (this.dr.Read())
            {
                result = true;
            }
            this.dr.Close();
            this.EndProcess();
            return result;
        }

        public bool InsertLoanApplicationLinq(UnconfirmedLoan uLoan, LoanApplication loan)
        {
            int result = 0;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                context.UnconfirmedLoans.InsertOnSubmit(uLoan);
                context.LoanApplications.InsertOnSubmit(loan);
                result = context.GetChangeSet().Inserts.Count;
                context.SubmitChanges();
            }
            return result > 0;
        }

        public void InsertLoanApplication(List<string> loanDetails, string makerSMS, string makerConfirm, string coMakerSMS, string coMakerConfirm, string coMaker2SMS, string coMaker2Confirm)
        {
            int lastTransactionID = this.GetLastTransactionID();
            this.sqlCmd.CommandText = "Insert into UnconfirmedLoan (TransactionID, ConfirmedByMaker, ConfirmedByCoMaker, ConfirmedByCoMaker2, DateFiled, ConfirmCodeMakerSMS, ConfirmCodeMakerEmail, ConfirmCodeCoMakerSMS, ConfirmCodeCoMakerEmail, ConfirmCodeCoMaker2SMS, ConfirmCodeCoMaker2Email) values (@TransID, 0, 0, 0, @Date, @mSMS, @mEmail, @cSMS, @cEmail, @c2SMS, @c2Email)";
            this.sqlCmd.Parameters.Add("@TransID", SqlDbType.Int).Value = lastTransactionID;
            this.sqlCmd.Parameters.Add("@Date", SqlDbType.Date).Value = DateTime.Now.ToShortDateString();
            this.sqlCmd.Parameters.Add("@mSMS", SqlDbType.NVarChar).Value = makerSMS;
            this.sqlCmd.Parameters.Add("@mEmail", SqlDbType.NVarChar).Value = makerConfirm;
            this.sqlCmd.Parameters.Add("@cSMS", SqlDbType.NVarChar).Value = coMakerSMS;
            this.sqlCmd.Parameters.Add("@cEmail", SqlDbType.NVarChar).Value = coMakerConfirm;
            this.sqlCmd.Parameters.Add("@c2SMS", SqlDbType.NVarChar).Value = coMaker2SMS;
            this.sqlCmd.Parameters.Add("@c2Email", SqlDbType.NVarChar).Value = coMaker2Confirm;
            
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            if (loanDetails.Count == 5)
            {
                this.cmd = "Insert into LoanApplication (TransactionID, EmpNo, TypeOfLoan, Reason, Amount, NoOfMonths, Confirmed, Done, Declined,Balance) values (@ID, @EmpNo, @Type, @Reason, @Amount, @NoOfMonths, 0,0,0,@Amount)";
            }
            else
            {
                if (loanDetails.Count == 7)
                {
                    this.cmd = "Insert into LoanApplication (TransactionID, EmpNo, TypeOfLoan, Reason, Amount, NoOfMonths, Confirmed, CoMakerEmpNo,Done,Declined,Balance, PayslipPath) values (@ID, @EmpNo, @Type, @Reason, @Amount, @NoOfMonths, 0, @CoMaker,0,0, @Amount, @PayslipPath)";
                }
                else
                {
                    this.cmd = "Insert into LoanApplication (TransactionID, EmpNo, TypeOfLoan, Reason, Amount, NoOfMonths, Confirmed, CoMakerEmpNo, CoMaker2EmpNo, Done, Declined,Balance, PayslipPath) values (@ID, @EmpNo, @Type, @Reason, @Amount, @NoOfMonths, 0, @CoMaker, @CoMaker2,0,0, @Amount, @PayslipPath)";
                }
            }
            this.sqlCmd.CommandText = this.cmd;
            this.sqlCmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = lastTransactionID;
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = loanDetails[0];
            this.sqlCmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = loanDetails[1];
            this.sqlCmd.Parameters.Add("@Reason", SqlDbType.Text).Value = loanDetails[2];
            this.sqlCmd.Parameters.Add("@Amount", SqlDbType.Money).Value = Convert.ToDecimal(loanDetails[3]);
            this.sqlCmd.Parameters.Add("@NoOfMonths", SqlDbType.Int).Value = Convert.ToInt32(loanDetails[4]);
            this.sqlCmd.Parameters.Add("@PayslipPath", SqlDbType.NVarChar).Value = loanDetails.Last();
            if (loanDetails.Count >= 7)
            {
                this.sqlCmd.Parameters.Add("@CoMaker", SqlDbType.NVarChar).Value = loanDetails[5];
            }
            if (loanDetails.Count == 8)
            {
                this.sqlCmd.Parameters.Add("@CoMaker2", SqlDbType.NVarChar).Value = loanDetails[6];
            }
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
        }
        public string GetEmployeeName(string empNo)
        {
            string result = "";
            this.sqlCmd.CommandText = "Select (LastName+', '+FirstName+' '+MiddleName) as Name from Users where EmpNo = @EmpNo";
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = empNo;
            OpenConnection();
            this.dr = this.sqlCmd.ExecuteReader();
            if (this.dr.Read())
            {
                result = this.dr.GetString(0);
            }
            this.dr.Close();
            this.EndProcess();
            return result;
        }
        public string GetPhoneNumber(string empNo)
        {
            string result = "";
            this.sqlCmd.CommandText = "Select PhoneNumber from Users where EmpNo = @EmpNo";
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = empNo;
            OpenConnection();
            this.dr = this.sqlCmd.ExecuteReader();
            if (this.dr.Read())
            {
                result = this.dr.GetString(0);
            }
            this.dr.Close();
            this.EndProcess();
            return result;
        }
        public int GetLastTransactionID()
        {
            this.sqlCmd.CommandText = "Select TransactionID from LoanApplication Order By TransactionID DESC";
            OpenConnection();
            this.dr = this.sqlCmd.ExecuteReader();

            if (!this.dr.HasRows)
            {
                this.dr.Close();
                this.MyConn.Close();
                return 1;
            }

            this.dr.Read();
            int @int = this.dr.GetInt32(0);
            this.dr.Close();
            this.MyConn.Close();
            return @int + 1;
        }
        public string GetEmployeeEmail(string empNo)
        {
            this.sqlCmd.CommandText = "Select Email from Users where EmpNo = '" + empNo + "'";
            OpenConnection();
            this.dr = this.sqlCmd.ExecuteReader();
            string result = "";
            while (this.dr.Read())
            {
                result = this.dr.GetString(0);
            }
            this.dr.Close();
            this.MyConn.Close();
            return result;
        }
        public bool HasLoanApplication(string empNo)
        {
            bool result = false;
            this.sqlCmd.CommandText = "Select * from LoanApplication where EmpNo = @EmpNo and Done = 0";
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = empNo;
            OpenConnection();
            this.dr = this.sqlCmd.ExecuteReader();
            while (this.dr.Read())
            {
                result = true;
            }
            this.dr.Close();
            this.EndProcess();
            return result;
        }
        public bool ConfirmLoan(string trans, string confirmationCode, bool comaker, bool maker2)
        {
            bool result = false;
            bool flag = true;
            this.sqlCmd.Parameters.Add("@Trans", SqlDbType.Int).Value = trans;
            this.sqlCmd.Parameters.Add("@CC", SqlDbType.NVarChar).Value = confirmationCode;
            this.sqlCmd.Parameters.Add("@value", SqlDbType.Bit).Value = true;
            OpenConnection();
            if (!comaker)
            {
                this.sqlCmd.CommandText = "Select * from UnconfirmedLoan where TransactionID = @Trans AND (ConfirmCodeMakerSMS = @CC OR ConfirmCodeMakerEmail = @CC)";
                this.cmd = "Update UnconfirmedLoan set ConfirmedByMaker = @value where TransactionID = @Trans";
            }
            else
            {
                if (maker2)
                {
                    this.sqlCmd.CommandText = "Select * from UnconfirmedLoan where TransactionID = @Trans AND (ConfirmCodeCoMaker2SMS = @CC OR ConfirmCodeCoMaker2Email = @CC)";
                    this.cmd = "Update UnconfirmedLoan set ConfirmedByCoMaker2 = @value where TransactionID = @Trans";
                }
                else
                {
                    this.sqlCmd.CommandText = "Select * from UnconfirmedLoan where TransactionID = @Trans AND (ConfirmCodeCoMakerSMS = @CC OR ConfirmCodeCoMakerEmail = @CC)";
                    this.cmd = "Update UnconfirmedLoan set ConfirmedByCoMaker = @value where TransactionID = @Trans";
                }
            }
            using (this.dr = this.sqlCmd.ExecuteReader())
            {
                while (this.dr.Read())
                {
                    flag = true;
                }
            }
            if (flag)
            {
                this.sqlCmd.CommandText = this.cmd;
                this.sqlCmd.ExecuteNonQuery();
                result = true;
            }
            this.EndProcess();

            this.FinalizeConfirm(trans);

            return result;
        }
        public void FinalizeConfirm(string trans)
        {
            bool flag = false;
            bool flag2 = false;
            this.sqlCmd = new SqlCommand();
            this.sqlCmd.CommandText = "Select * from UnconfirmedLoan where TransactionID = @Trans";
            this.sqlCmd.Parameters.Add("@Trans", SqlDbType.Int).Value = trans;
            if (this.sqlCmd.Connection == null)
            {
                this.sqlCmd.Connection = this.MyConn;
            }
            OpenConnection();
            this.dr = this.sqlCmd.ExecuteReader();
            this.dr.Read();
            bool boolean = this.dr.GetBoolean(1);
            bool flag3 = false;
            bool flag4 = false;
            if (this.dr.GetString(5) != "")
            {
                flag = true;
                flag3 = this.dr.GetBoolean(2);
            }
            if (this.dr.GetString(9) != "")
            {
                flag = true;
                flag4 = this.dr.GetBoolean(8);
            }
            this.dr.Dispose();
            bool flag5 = false;
            if (flag && !flag2)
            {
                if (flag3 && boolean)
                {
                    flag5 = true;
                }
            }
            else
            {
                if (flag && flag2)
                {
                    if (flag3 && boolean && flag4)
                    {
                        flag5 = true;
                    }
                }
                else
                {
                    if (boolean)
                    {
                        flag5 = true;
                    }
                }
            }
            if (flag5)
            {
                this.cmd = "Update LoanApplication set Confirmed = @value where TransactionID = @Trans";
                this.sqlCmd.CommandText = this.cmd;
                this.sqlCmd.Parameters.Add("@value", SqlDbType.Bit).Value = true;
                this.sqlCmd.ExecuteNonQuery();
                this.sqlCmd.CommandText = "Delete from UnconfirmedLoan where TransactionID = @Trans";
                this.sqlCmd.ExecuteNonQuery();
            }
            this.EndProcess();
        }
        public string GetRole(string emp, string trans)
        {
            this.sqlCmd.CommandText = "Select EmpNo, CoMakerEmpNo, CoMaker2EmpNo from LoanApplication where TransactionID = @TransID";
            this.sqlCmd.Parameters.Add("@TransID", SqlDbType.NVarChar).Value = trans;
            string result = "";
            OpenConnection();
            using (this.dr = this.sqlCmd.ExecuteReader())
            {
                if (this.dr.Read())
                {
                    try
                    {
                        if (this.dr.GetString(0) == emp)
                        {
                            result = "Maker";
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (this.dr.GetString(1) == emp)
                        {
                            result = "CoMaker";
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (this.dr.GetString(2) == emp)
                        {
                            result = "CoMaker2";
                        }
                    }
                    catch
                    {
                    }
                }
            }
            this.EndProcess();
            return result;
        }
        public bool ApplicationConfirmed(string trans)
        {
            this.sqlCmd.CommandText = "Select Confirmed from LoanApplication where TransactionID = @Trans";
            this.sqlCmd.Parameters.Add("Trans", SqlDbType.Int).Value = trans;
            bool result = false;
            OpenConnection();
            using (this.dr = this.sqlCmd.ExecuteReader())
            {
                if (this.dr.Read())
                {
                    result = this.dr.GetBoolean(0);
                }
            }
            this.EndProcess();
            return result;
        }

        public User GetEmployeeDetailsLinq(string empNo)
        {
            MessagesDataContext context = new MessagesDataContext();
            User u = context.Users.FirstOrDefault(c => c.EmpNo == empNo);
            context.Dispose();
            return u;
        }

        public List<string> GetEmployeeDetails(string empNo)
        {
            List<string> list = new List<string>();
            this.cmd = "Select u.EmpNo, u.Lastname, u.Email, u.College, u.Dept, u.MemberStatus, u.DateHired, " +
                "u.PhoneNumber, u.Picture, c.CollegeName, d.DepartmentName from Users u " +
                "INNER JOIN College c ON " +
                "c.CollegeID = u.College " +
                "INNER JOIN Department d ON " +
                "d.DepartmentID = u.Dept " +
                "where EmpNo = '" + empNo + "'";
            this.sqlCmd.CommandText = this.cmd;
            OpenConnection();
            using (this.dr = this.sqlCmd.ExecuteReader())
            {
                this.dr.Read();
                list.Add(this.dr.GetString(0));
                list.Add(this.dr.GetString(1));
                list.Add(this.dr.GetString(2));
                if (!this.dr.IsDBNull(3))
                {
                    list.Add(this.dr.GetString(3));
                }
                else
                {
                    list.Add("");
                }
                if (!this.dr.IsDBNull(4))
                {
                    list.Add(this.dr.GetString(4));
                }
                else
                {
                    list.Add("");
                }
                if (!this.dr.IsDBNull(5))
                {
                    list.Add(this.dr.GetString(5));
                }
                else
                {
                    list.Add("");
                }
                if (!this.dr.IsDBNull(6))
                {
                    list.Add(this.dr.GetString(6));
                }
                else
                {
                    list.Add("");
                }
                list.Add(this.dr.GetString(7));
                if (!this.dr.IsDBNull(8))
                {
                    list.Add(this.dr.GetString(8));
                }
                else
                {
                    list.Add("");
                }
                if (!this.dr.IsDBNull(9))
                {
                    list.Add(this.dr.GetString(9));
                }
                else
                {
                    list.Add("");
                }
                if (!this.dr.IsDBNull(10))
                {
                    list.Add(this.dr.GetString(10));
                }
                else
                {
                    list.Add("");
                }
            }
            this.EndProcess();
            return list;
        }
        public DataTable GetAllTransaction(string empNo)
        {
            this.cmd = "Select TransactionID from LoanApplication where EmpNo = @EmpNo OR CoMakerEmpNo = @EmpNo OR CoMaker2EmpNo = @EmpNo";
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = empNo;
            return this.GetTable(this.cmd);
        }
        public List<string> GetTransactionDetails(string transactionID)
        {
            List<string> list = new List<string>();
            this.cmd = "Select * from LoanApplication where TransactionID = '" + transactionID + "'";
            this.sqlCmd.CommandText = this.cmd;
            OpenConnection();
            using (this.dr = this.sqlCmd.ExecuteReader())
            {
                this.dr.Read();
                if (this.dr.IsDBNull(2))
                {
                    list.Add("");
                }
                else
                {
                    list.Add(this.dr.GetString(2));
                }
                if (this.dr.IsDBNull(10))
                {
                    list.Add("");
                }
                else
                {
                    list.Add(this.dr.GetString(10));
                }
                list.Add(this.dr.GetString(3));
                if (this.dr.IsDBNull(4))
                {
                    list.Add("");
                }
                else
                {
                    list.Add(this.dr.GetString(4));
                }
                list.Add(this.dr.GetDecimal(5).ToString());
                list.Add(this.dr.GetInt32(6).ToString());
                if (this.dr.IsDBNull(8))
                {
                    list.Add("");
                }
                else
                {
                    list.Add(this.dr.GetDateTime(8).ToShortDateString());
                }
                if (this.dr.IsDBNull(9))
                {
                    list.Add("");
                }
                else
                {
                    list.Add(this.dr.GetDateTime(9).ToShortDateString());
                }
                list.Add(this.dr.GetBoolean(7).ToString());
                list.Add(this.dr.GetString(1));
            }
            this.EndProcess();
            return list;
        }
        public DataTable GetUserLoanDetails(string empNo)
        {
            this.cmd = "Select * from LoanApplication where EmpNo = '" + empNo + "' " +
                        "and DateApproved is not null " +
                        "and Confirmed > 0 " +
                        "and (Done > 0 or Declined > 0)";
            return this.GetTable(this.cmd);
        }

        public List<SelectLoanDTO> GetUserActiveLoans(string empNo)
        {
            this.cmd = "Select la.*,lt.LoanType from LoanApplication la inner join LoanTypes lt on la.TypeOfLoan = lt.RecordID where EmpNo = '" + empNo + "' AND Balance > 0";
            DataTable dt = this.GetTable(this.cmd);
            List<SelectLoanDTO> ds = new List<SelectLoanDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                SelectLoanDTO sl = new SelectLoanDTO();
                sl.TransactionID = dr["TransactionID"].ToString();
                sl.Text = string.Format(
                    "<b>Type Of Loan:</b> {0} - <b>Reason:</b> {1} - <b>Amount:</b> {2} - <b>Payment:</b> {3} Months - <b>Date Due:</b> {4} - <b>Balance:</b> {5}",
                    dr["LoanType"].ToString(),
                    dr["Reason"].ToString(),
                    Convert.ToDecimal(dr["Amount"]).ToString("F"),
                    dr["NoOfMonths"].ToString(),
                    dr["DateDue"].ToString(),
                    Convert.ToDecimal(dr["Balance"]).ToString("F"));
                ds.Add(sl);
            }
            return ds;
        }

        public List<LoanPaymentReport> GetLoanPaymentReport(int transactionID)
        {
            List<LoanPaymentReport> result = new List<LoanPaymentReport>();
            this.sqlCmd.CommandText = "select p.TransactionID, lt.LoanType, u.LastName, u.FirstName, u.MiddleName, ul.DateFiled, "+
                                        "la.Amount, p.PayAmount, p.PayDate, p.Balance from Payments p "+
                                        "inner join LoanApplication la on p.TransactionID = la.TransactionID  "+
                                        "inner join LoanTypes lt on la.TypeOfLoan = lt.RecordID "+
                                        "inner join UnconfirmedLoan ul on la.TransactionID = ul.TransactionID "+
                                        "left join Users u on la.EmpNo = u.EmpNo "+
                                        "where p.TransactionID = @tid order by p.PayDate asc ";
            this.sqlCmd.Parameters.Add("@tid", SqlDbType.Int).Value = transactionID;
            OpenConnection();
            using (this.dr = this.sqlCmd.ExecuteReader())
            {
                while (this.dr.Read())
                {
                    LoanPaymentReport pr = new LoanPaymentReport();
                    pr.TransactionID = dr.GetInt32(0);
                    pr.LoanType = dr.GetString(1);
                    pr.Lastname = dr.GetString(2);
                    pr.Firstname = dr.GetString(3);
                    pr.MI = dr.GetString(4);
                    pr.LoanDate = dr.GetDateTime(5);
                    pr.LoanAmount = dr.GetDecimal(6);
                    pr.PayAmount = dr.GetDouble(7);
                    pr.PayDate = dr.GetDateTime(8);
                    pr.Balance = dr.IsDBNull(9) ? 0 : dr.GetDouble(9);
                    result.Add(pr);
                }
            }
            this.EndProcess();
            return result;
        }

        public List<SelectLoanDTO> GetUserLoans(string empNo)
        {
            this.cmd = "Select la.*,lt.LoanType from LoanApplication la inner join LoanTypes lt on la.TypeOfLoan = lt.RecordID where EmpNo = '" + empNo + "' AND Balance >= 0";
            DataTable dt = this.GetTable(this.cmd);
            List<SelectLoanDTO> ds = new List<SelectLoanDTO>();

            foreach (DataRow dr in dt.Rows)
            {
                SelectLoanDTO sl = new SelectLoanDTO();
                sl.TransactionID = dr["TransactionID"].ToString();
                sl.Text = string.Format(
                    "<b>Type Of Loan:</b> {0} - <b>Reason:</b> {1} - <b>Amount:</b> {2} - <b>Payment:</b> {3} Months - <b>Date Due:</b> {4} - <b>Balance:</b> {5}",
                    dr["LoanType"].ToString(),
                    dr["Reason"].ToString(),
                    Convert.ToDecimal(dr["Amount"]).ToString("F"),
                    dr["NoOfMonths"].ToString(),
                    dr["DateDue"].ToString(),
                    Convert.ToDecimal(dr["Balance"]).ToString("F"));
                ds.Add(sl);
            }
            return ds;
        }

        public bool Pay(string transactionID, double amount, string note, double currentBalance)
        {
            this.cmd = "INSERT INTO Payments(TransactionID,PayAmount,Note,PayDate,Balance) VALUES(@TransactionID, @PayAmount, @Note,@PayDate,@Balance)";
            this.sqlCmd.CommandText = this.cmd;
            //this.sqlCmd.Parameters.Add("@Pic", SqlDbType.NVarChar).Value = imagePath;
            this.sqlCmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = transactionID;
            this.sqlCmd.Parameters.Add("@PayAmount", SqlDbType.Money).Value = amount;
            this.sqlCmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = note;
            this.sqlCmd.Parameters.Add("@PayDate", SqlDbType.DateTime).Value = DateTime.Now;
            this.sqlCmd.Parameters.Add("@Balance", SqlDbType.Money).Value = (currentBalance - amount);
            OpenConnection();
            int result = this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
            return result > 0;
        }

        public double GetOutStandingBalance(string transactionId)
        {
            double result = 0f;
            using (MessagesDataContext context = new MessagesDataContext())
            {
                var record = context.LoanApplications.FirstOrDefault(c => c.TransactionID == int.Parse(transactionId));
                if (record != null)
                {
                    result = Convert.ToDouble(record.Balance);
                }
            }
            return result;
        }

        public DataTable GetAllEmployeeDetails(string empNo)
        {
            this.cmd = "Select * from Users where EmpNo = '" + empNo + "'";
            return this.GetTable(this.cmd);
        }
        public void SaveImage(string imagePath, string empNo)
        {
            this.cmd = "Update Users set Picture = @Pic where EmpNo = '" + empNo + "'";
            this.sqlCmd.CommandText = this.cmd;
            this.sqlCmd.Parameters.Add("@Pic", SqlDbType.NVarChar).Value = imagePath;
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
        }
        public string GetImage(string empNo)
        {
            string result = "";
            this.sqlCmd.CommandText = "Select Picture from Users where empno = @EmpNo";
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = empNo;
            OpenConnection();
            using (this.dr = this.sqlCmd.ExecuteReader())
            {
                while (this.dr.Read())
                {
                    if (!this.dr.IsDBNull(0))
                    {
                        result = this.dr.GetString(0);
                    }
                }
            }
            this.EndProcess();
            return result;
        }
        public string GetCollegeName(string ID)
        {
            this.cmd = "Select CollegeName from College where CollegeID = '" + ID + "'";
            return this.GetTable(this.cmd).Rows[0]["CollegeName"].ToString();
        }
        public string GetDepartmentName(string college, string ID)
        {
            this.cmd = string.Concat(new string[]
			{
				"Select DepartmentName from Department where CollegeID = '",
				college,
				"' AND DepartmentID = '",
				ID,
				"'"
			});
            return this.GetTable(this.cmd).Rows[0]["DepartmentName"].ToString();
        }
        public bool AdminLogin(string user, string pass)
        {
            bool result = false;
            this.cmd = string.Concat(new string[]
			{
				"Select * from AdminAccount where Username = '",
				user,
				"' AND Password = '",
				pass,
				"'"
			});
            this.sqlCmd.CommandText = this.cmd;
            try
            {
                OpenConnection();
                using (this.dr = this.sqlCmd.ExecuteReader())
                {
                    if (this.dr.Read())
                    {
                        result = true;
                    }
                }
                this.EndProcess();
            }
            finally
            {
            }
            return result;
        }
        public bool retrieveUserPass(string user, string pass)
        {
            bool result = false;
            this.sqlCmd.CommandText = "Select * from Users where empno = @EmpNo";
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = user;
            string a = "";
            OpenConnection();
            using (this.dr = this.sqlCmd.ExecuteReader())
            {
                if (this.dr.Read())
                {
                    a = this.dr.GetString(this.dr.GetOrdinal("Password"));
                }
                if (a == pass)
                {
                    result = true;
                    DataAccess.empNum = user;
                }
            }
            this.EndProcess();
            return result;
        }
        public void UpdatePass(string user, string pass)
        {
            this.cmd = "Update Users set Password = '" + pass + "'";
            this.sqlCmd.CommandText = this.cmd;
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
        }
        public void UpdateUserDetails(List<string> details)
        {
            this.cmd = "Update users set Name = @Name, Email = @Email, Address = @Address, Birthday = @Birthday, College = @College, Dept = @Dept, PhoneNumber = @PhoneNumber, MemberStatus = @MemberStatus, DateHired = @DateHired where EmpNo = @EmpNo";
            this.sqlCmd.CommandText = this.cmd;
            this.sqlCmd.Parameters.Add("@EmpNo", SqlDbType.NVarChar).Value = details[0];
            this.sqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = details[1];
            this.sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = details[2];
            this.sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = details[3];
            this.sqlCmd.Parameters.Add("@Birthday", SqlDbType.Date).Value = Convert.ToDateTime(details[4]);
            this.sqlCmd.Parameters.Add("@College", SqlDbType.NVarChar).Value = details[5];
            this.sqlCmd.Parameters.Add("@Dept", SqlDbType.NVarChar).Value = details[6];
            this.sqlCmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = details[7];
            this.sqlCmd.Parameters.Add("@MemberStatus", SqlDbType.NVarChar).Value = details[8];
            this.sqlCmd.Parameters.Add("@DateHired", SqlDbType.NVarChar).Value = details[9];
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
        }
        public DataTable getColleges()
        {
            this.cmd = "Select * from College";
            return this.GetTable(this.cmd);
        }
        public DataTable getDepartment(int z)
        {
            this.cmd = "SELECT * FROM [Department] WHERE ([CollegeID] = '" + z + "')";
            return this.GetTable(this.cmd);
        }
        public DataTable getLoanApplication()
        {
            this.cmd = "SELECT TransactionID, TypeOfLoan, Amount, NoOfMonths FROM LoanApplication where Confirmed = 1 and Declined = 0 and  DateApproved is Null";
            return this.GetTable(this.cmd);
        }
        public DataTable getLoanApplication(string search, string value)
        {
            this.cmd = string.Concat(new string[]
			{
				"SELECT TransactionID, TypeOfLoan, Amount, NoOfMonths FROM LoanApplication where Confirmed = 1 and Declined = 0 and  DateApproved is Null and ",
				search,
				" Like '%",
				value,
				"%'"
			});
            return this.GetTable(this.cmd);
        }
        public DataTable getLoanNumber()
        {
            this.cmd = "SELECT TransactionID,NoOfMonths FROM LoanApplication where Confirmed = 1 and  DateApproved is Null";
            return this.GetTable(this.cmd);
        }
        public DataTable getApproved()
        {
            this.cmd = "SELECT TransactionID, Amount, DateApproved, DateDue FROM LoanApplication where DateApproved is not Null and Done = 0  order by DateDue ASC";
            return this.GetTable(this.cmd);
        }
        public DataTable getApproved(string search, string value)
        {
            this.cmd = string.Concat(new string[]
			{
				"SELECT TransactionID, Amount, DateApproved, DateDue FROM LoanApplication where DateApproved is not Null and Done = 0 and ",
				search,
				" Like '%",
				value,
				"%' order by DateDue ASC"
			});
            return this.GetTable(this.cmd);
        }
        public DataTable getApproved(string search, DateTime value)
        {
            this.cmd = "SELECT TransactionID, Amount, DateApproved, DateDue FROM LoanApplication where DateApproved is not Null and Done = 0 and " + search + " = @Date order by DateDue ASC";
            this.sqlCmd.Parameters.Add("@Date", SqlDbType.Date).Value = value;
            return this.GetTable(this.cmd);
        }
        public void LoanDone(string TransID)
        {
            this.cmd = "Update LoanApplication set Done = 1 where TransactionID = '" + TransID + "'";
            this.sqlCmd.CommandText = this.cmd;
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
        }
        public void DeclineLoan(string TransID)
        {
            this.cmd = "Update LoanApplication set Declined = 1 where TransactionID = '" + TransID + "'";
            this.sqlCmd.CommandText = this.cmd;
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
        }

        private void OpenConnection()
        {
            if (this.MyConn.State == ConnectionState.Closed)
            {
                this.MyConn.Open();
            }
        }

        public void approve(int ID, DateTime DateApproved, DateTime DateDue)
        {
            this.cmd = "Update LoanApplication set DateApproved = @Date,DateDue = @Due  where TransactionID = @ID";
            this.sqlCmd.CommandText = this.cmd;
            this.sqlCmd.Parameters.Add("@Date", SqlDbType.Date).Value = DateApproved;
            this.sqlCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            this.sqlCmd.Parameters.Add("@Due", SqlDbType.Date).Value = DateDue;
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
        }
        protected DataTable GetTable(string cmd)
        {
            this.dt = new DataTable();
            this.sqlCmd.CommandText = cmd;
            this.da = new SqlDataAdapter(this.sqlCmd);
            this.da.Fill(this.dt);
            this.EndProcess();
            return this.dt;
        }
        public static string encrypt(string x)
        {
            Encoding unicode = Encoding.Unicode;
            byte[] bytes = unicode.GetBytes("HkC9Nwd2");
            byte[] bytes2 = unicode.GetBytes("HkC9Nwd2");
            return unicode.GetString(DataAccess.EncryptStringToBytes(x, bytes, bytes2));
        }
        private static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }
            if (Key == null || Key.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }
            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }
            byte[] result;
            using (Rijndael rijndael = Rijndael.Create())
            {
                rijndael.Key = Key;
                rijndael.IV = IV;
                ICryptoTransform transform = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                        result = memoryStream.ToArray();
                    }
                }
            }
            return result;
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.dr != null)
                {
                    this.dr.Dispose();
                }
                if (this.da != null)
                {
                    this.da.Dispose();
                }
                if (this.dt != null)
                {
                    this.dt.Dispose();
                }
                this.MyConn.Dispose();
                this.sqlCmd.Dispose();
                this.cmd = null;
                SqlConnection.ClearAllPools();
            }
            this._disposed = true;
        }
        private void EndProcess()
        {
            this.sqlCmd.Parameters.Clear();
            this.MyConn.Close();
        }

        public void UpdateLoanPayStatus(int transactionId)
        {
            using (MessagesDataContext context = new MessagesDataContext())
            {
                LoanApplication lap = context.LoanApplications.FirstOrDefault(c => c.TransactionID == transactionId);
                if (lap != null)
                {
                    if (lap.Balance == 0)
                    {
                        lap.Done = true;
                    }
                    context.SubmitChanges();
                }
            }
        }

        public bool UpdateBalance(string transactionID, double payamount)
        {
            this.cmd = "UPDATE LoanApplication SET Balance = (Balance - @Balance) WHERE TransactionID = @TransactionID";
            this.sqlCmd.CommandText = this.cmd;
            //this.sqlCmd.Parameters.Add("@Pic", SqlDbType.NVarChar).Value = imagePath;
            this.sqlCmd.Parameters.Add("@TransactionID", SqlDbType.Int).Value = transactionID;
            this.sqlCmd.Parameters.Add("@Balance", SqlDbType.Money).Value = payamount;
            OpenConnection();
            int result = this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
            return result > 0;
        }

        public DataTable GetAllUnapprovedLoan()
        {
            this.cmd = "Select TransactionID,EmpNo,TypeOfLoan,Reason,Amount,NoOfMonths,CoMakerEmpNo,CoMaker2EmpNo,PayslipPath from LoanApplication WHERE (Confirmed = 1) AND (DateApproved IS NULL) AND (Done = 0) AND (Declined = 0)";
            DataTable dt = this.GetTable(this.cmd);
            //DataRow dr = dt.NewRow();
            //dr.ItemArray = new object[] { "0", "-- SELECT --" };
            //dt.Rows.InsertAt(dr, 0);
            return dt;
        }

        public DataTable GetAllUnconfirmedUsers()
        {
            this.cmd = "Select EmpNo,DateRegistered from UnconfirmedUsers WHERE ConfirmationCode IS NULL";
            DataTable dt = this.GetTable(this.cmd);
            return dt;
        }

        public void TruncateLoanApplicationTable()
        {
            this.cmd = "TRUNCATE TABLE LoanApplication";
            this.sqlCmd.CommandText = this.cmd;
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
        }

        public void TruncateUnconfirmedLoanTable()
        {
            this.cmd = "TRUNCATE TABLE UnconfirmedLoan";
            this.sqlCmd.CommandText = this.cmd;
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
        }

        public void TruncateMSGSTable()
        {
            this.cmd = "TRUNCATE TABLE MSGS";
            this.sqlCmd.CommandText = this.cmd;
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
        }

        public void TruncatePaymentsTable()
        {
            this.cmd = "TRUNCATE TABLE Payments";
            this.sqlCmd.CommandText = this.cmd;
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
        }

        public void DeleteExceptMe()
        { 
              
            this.cmd = "delete from UnconfirmedUsers where EmpNo <> '100023';delete from Users where  EmpNo <> '100023';";
            this.sqlCmd.CommandText = this.cmd;
            OpenConnection();
            this.sqlCmd.ExecuteNonQuery();
            this.EndProcess();
        }

        public DataTable GetAllPaymentsForTransaction(int transactionId)
        {
            this.cmd = string.Format("Select * from Payments where TransactionID={0}", transactionId);
            DataTable dt = this.GetTable(this.cmd);
            return dt;
        }

        public bool IsEmployee(string empId)
        {
            User u = GetEmployeeDetailsLinq(empId);
            return u.UserType.ToUpper() == "EMPLOYEE";
        }

        public bool UpdateUserDetailsLinq(User u)
        {
            MessagesDataContext context = new MessagesDataContext();

            User updatedUser = context.Users.FirstOrDefault(c => c.EmpNo == u.EmpNo);
            updatedUser.Email = u.Email;
            updatedUser.College = u.College;
            updatedUser.Dept = u.Dept;
            updatedUser.MemberStatus = u.MemberStatus;
            updatedUser.DateHired = u.DateHired;
            updatedUser.Address = u.Address;
            updatedUser.Birthday = u.Birthday;

            updatedUser.FirstName = u.FirstName;
            updatedUser.LastName = u.LastName;
            updatedUser.MiddleName = u.MiddleName;
            updatedUser.PhoneNumber = u.PhoneNumber;
            updatedUser.ATMAccountNo = u.ATMAccountNo;
            updatedUser.TINNo = u.TINNo;
            updatedUser.SSSNo = u.SSSNo;
            updatedUser.Gender = u.Gender;
            updatedUser.CivilStatus = u.CivilStatus;
            updatedUser.FatherName = u.FatherName;
            updatedUser.FatherOccupation = u.FatherOccupation;
            updatedUser.MotherName = u.MotherName;
            updatedUser.MotherOccupation = u.MotherOccupation;
            updatedUser.LegalSpouse = u.LegalSpouse;
            updatedUser.SpouseEmployer = u.SpouseEmployer;
            updatedUser.BusinessName = u.BusinessName;
            updatedUser.BusinessAddress = u.BusinessAddress;
            updatedUser.OtherSourceOfIncome = u.OtherSourceOfIncome;
            updatedUser.EmergencyName = u.EmergencyName;
            updatedUser.EmergencyAddress = u.EmergencyAddress;
            updatedUser.EmergencyNumber = u.EmergencyNumber;

            int result = context.GetChangeSet().Updates.Count;
            context.SubmitChanges();
            context.Dispose();
            return result > 0;
        }
    }
}
