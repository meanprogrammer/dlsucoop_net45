using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelper
{
    public class LoanReportDTO
    {
        public int TransactionID { get; set; }
        public string EmpNo { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string MI { get; set; }
        public DateTime DateFiled { get; set; }
        public string LoanType { get; set; }
        public Decimal LoanAmount { get; set; }
        public Decimal LoanBalance { get; set; }
        public DateTime? LoanDueDate { get; set; }
        public string UserType { get; set; }
    }
}
