using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using DataHelper;
using System.Globalization;
using System.Data;

namespace WebsiteTrial
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataAccess da = new DataAccess();
            var id = Request.QueryString["id"];
            User empdetails = da.GetEmployeeDetailsLinq(id);
            
            var document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            document.SetMargins(30, 30, 30, 30);

            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);

            document.Open();
            document.NewPage();

            PdfPTable mainTable = new PdfPTable(new float[]{ 2.5f, 2.5f,2.5f, 2.5f });
            mainTable.WidthPercentage = 100;

            mainTable.AddCell(PdfHelper.CreateCellWithText(string.Format("SUBSIDIARY LEDGER - {0} {1}", DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture), DateTime.Now.Year), colspan: 4, fontSize: 10, fonttype: 0));

            mainTable.AddCell(PdfHelper.CreateCellWithText(
                string.Format("Emp # : {0}", empdetails.EmpNo), colspan: 4, fontSize: 10, fonttype: 0));

            mainTable.AddCell(PdfHelper.CreateCellWithText(
                string.Format("Name : {0}", string.Format("{0} {1}, {2}", empdetails.LastName, empdetails.FirstName, empdetails.MiddleName)), colspan: 4, fontSize: 10, fonttype: 0));

            mainTable.AddCell(PdfHelper.CreateCellWithText(
                string.Format("College : {0}", empdetails.College), colspan: 2, fontSize: 10, fonttype: 0));

            mainTable.AddCell(PdfHelper.CreateCellWithText(
                string.Format("Department : {0}", empdetails.Dept), colspan: 2, fontSize: 10, fonttype: 0));

            mainTable.AddCell(PdfHelper.CreateCellWithText(
                string.Format("Status : {0}", empdetails.MemberStatus), colspan: 4, fontSize: 10, fonttype: 0));
            mainTable.AddCell(PdfHelper.CreateCellWithText(" ", bottomborder: 1, colspan: 4));

            PdfPTable historyTable = new PdfPTable(new float[] { 2f, 2f, 2f, 2f, 2f });

            historyTable.AddCell(PdfHelper.CreateCellWithText("LOAN HISTORY", colspan: 5, alignment: 1, fontSize: 12));
            historyTable.AddCell(PdfHelper.CreateCellWithText("Trans. ID", fontSize: 10, fonttype: 0));
            historyTable.AddCell(PdfHelper.CreateCellWithText("Type of loan", fontSize: 10, fonttype: 0));
            historyTable.AddCell(PdfHelper.CreateCellWithText("Amount", fontSize: 10, fonttype: 0));
            historyTable.AddCell(PdfHelper.CreateCellWithText("Date Approved", fontSize: 10, fonttype: 0));
            historyTable.AddCell(PdfHelper.CreateCellWithText("Due Date", fontSize: 10, fonttype: 0));
            DataTable history = da.GetUserLoanDetails(id);

            foreach (DataRow row in history.Rows)
            {
                historyTable.AddCell(PdfHelper.CreateCellWithText(string.Format("{0}", row["TransactionID"]), fontSize: 10, fonttype: 0));
                historyTable.AddCell(PdfHelper.CreateCellWithText(string.Format("{0}", row["TypeOfLoan"]), fontSize: 10, fonttype: 0));
                historyTable.AddCell(PdfHelper.CreateCellWithText(string.Format("{0}", Convert.ToDecimal(row["Amount"]).ToString("n2")), fontSize: 10, fonttype: 0));
                historyTable.AddCell(PdfHelper.CreateCellWithText(string.Format("{0}", Convert.ToDateTime(row["DateApproved"]).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)), fontSize: 10, fonttype: 0));
                historyTable.AddCell(PdfHelper.CreateCellWithText(string.Format("{0}", Convert.ToDateTime(row["DateDue"]).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)), fontSize: 10, fonttype: 0));

                int transactionId = int.Parse(row["TransactionID"].ToString());
                DataTable paymentsDt = da.GetAllPaymentsForTransaction(transactionId);
                PdfPTable t = new PdfPTable(new float[] { 25f, 25f, 25f, 25f });
                t.AddCell(PdfHelper.CreateCellWithText(" "));
                t.AddCell(PdfHelper.CreateCellWithText("PayDate", fonttype: 1));
                t.AddCell(PdfHelper.CreateCellWithText("PayAmount"));
                t.AddCell(PdfHelper.CreateCellWithText("Note"));
                t.AddCell(PdfHelper.CreateCellWithText(" ", colspan: 4, bottomborder: 1));
                double totalPaid = 0;
                foreach (DataRow p in paymentsDt.Rows)
                {
                    t.AddCell(PdfHelper.CreateCellWithText(" "));
                    t.AddCell(PdfHelper.CreateCellWithText(p["PayDate"].ToString()));
                    totalPaid += Convert.ToDouble(p["PayAmount"].ToString());
                    t.AddCell(PdfHelper.CreateCellWithText(p["PayAmount"].ToString()));
                    t.AddCell(PdfHelper.CreateCellWithText(p["Note"].ToString()));
                }
                t.AddCell(PdfHelper.CreateCellWithText(" ", colspan: 4, bottomborder: 1));
                t.AddCell(PdfHelper.CreateCellWithText(" ", colspan: 2));
                t.AddCell(PdfHelper.CreateCellWithText(string.Format("Total Paid P{0:0.00}", totalPaid)));
                t.AddCell(PdfHelper.CreateCellWithText(string.Format("Balance P {0:0.00}", Convert.ToDecimal(row["Balance"]).ToString())));
                historyTable.AddCell(
                    new PdfPCell()
                    {
                        Table = t,
                        Colspan = 5,
                        Padding = 5,
                        Border = 0
                    }
                    );
            }

            mainTable.AddCell(new PdfPCell() { 
                Table = historyTable,
                Colspan = 5,
                Padding = 5,
                Border = 0
            });


            mainTable.AddCell(PdfHelper.CreateCellWithText(" ", bottomborder: 1, colspan: 4));



            document.Add(mainTable);
            document.Close();

            byte[] bytes = output.ToArray();

            Response.ContentType = "application/pdf";
            Response.BinaryWrite(bytes);
            
        }
    }
}