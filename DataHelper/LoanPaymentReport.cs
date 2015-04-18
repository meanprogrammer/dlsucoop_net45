using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelper
{
    public class LoanPaymentReport
    {
        public int TransactionID { get; set; }
        public string LoanType { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string MI { get; set; }
        public DateTime LoanDate { get; set; }
        public decimal LoanAmount { get; set; }
        public double PayAmount { get; set; }
        public DateTime PayDate { get; set; }
        public double Balance { get; set; }
    }
}
