using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataHelper
{
    public class Entities
    {

    }

    public class SelectLoanDTO
    {
        public string TransactionID { get; set; }
        public string Text { get; set; }
    }

    public class DateMonthDTO
    {
        public DateMonthDTO(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }

        public string Text { get; set; }
        public string Value { get; set; }
    }
}
