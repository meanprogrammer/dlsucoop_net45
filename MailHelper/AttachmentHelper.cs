using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;

namespace Mail
{
    public class AttachmentHelper
    {
        public static void CreatePrommisoryDocument(object fileName, object SaveAs, List<string> details, List<string> names)
        {
            var document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            document.SetMargins(30, 30, 30, 30);

            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);

            document.Open();
            document.NewPage();

            PdfPTable mainTable = new PdfPTable(new float[] { 2.5f, 2.5f, 2.5f, 2.5f });

            mainTable.AddCell(PdfHelper2.CreateCellWithText("De La Salle University Dasmariñas Development Cooperative",
            alignment: 1, colspan: 4));
            mainTable.AddCell(PdfHelper2.CreateCellWithText("Dasmariñas, Cavite 4115",
            alignment: 1, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(" ",
            alignment: 1, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText("PROMISSORY NOTE",
            alignment: 1, colspan: 4, fonttype: 1));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(" ",
            alignment: 1, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(string.Format("Date: {0}", DateTime.Now.ToShortDateString()),
            alignment: 2, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(string.Format("Type Of Loan: {0}", details[1]),
            alignment: 0, colspan: 4));
            mainTable.AddCell(PdfHelper2.CreateCellWithText(string.Format("Amount: {0}", details[3]),
            alignment: 0, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(" ",
            alignment: 1, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(
                string.Format("For value received. I/we jointly and severally promise to pay DE LA SALLE UNIVERSITY DASMARIÑAS DEVELOPMENT  COOPERATIVE the sum of {0} (P {1} ) payable in {2}, in {3} equal installments. The first installment will start on {4} and every 15th and 30th day of the month thereafter until the full amount of the loan have been paid. ",
                            AttachmentHelper.NumberToWords(Convert.ToInt32(details[3].Replace(",", ""))),
                            details[3],
                            details[4],
                            (Convert.ToInt32(details[4]) * 2),
                            AttachmentHelper.GetNearestPayDay()),
            alignment: 0, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(" ",
          alignment: 1, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText("In case of any default in payment as herein agreed or should my employment with DE LA SALLE UNIVERSITY DASMARIÑAS be terminated or my membership with DE LA SALLE UNIVERSITY DASMARIÑAS DEVELOPMENT COOPERATIVE be terminated, the entire balance of this note shall immediately be due and payable without need for notice or demand. Further any default in payment of the scheduled installment, a surcharge of one percent (1%) per month on the installment due shall be collected.", alignment: 0, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(" ",
           alignment: 1, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText("Each Party whether maker or comakers shall be jointly and severally liable as herein agreed. The undersigned agree that in case payment shall not be made at maturity, I/we shall pay the cost of collection and attorney's fee in the amount equivalent to twenty percent (20%) of the principal and interest due on this note. In case of judicial execution of this obligation, or any part of it, the parties waive their rights under provisions of Rule 57 Sectons 7 and 8. Rule 39 Section 12 of the Rules of Court.",
           alignment: 0, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(" ", alignment: 1, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(" ",             alignment: 1, colspan: 4, bottomborder: 1));


            mainTable.AddCell(PdfHelper2.CreateCellWithText(" ", alignment: 1, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(" ", alignment: 1, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText("PLEDGE OF DEPOSITS AND/OR RETIREMENT PAY FROM", alignment: 1, colspan: 4, fonttype: 1));
            mainTable.AddCell(PdfHelper2.CreateCellWithText("DE LA SALLE UNIVERSITY – DASMARIÑAS", alignment: 1, colspan: 4, fonttype: 1));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(" ", alignment: 1, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText("I/We, the undersigned hereby pledge all the share capital and savings deposit with the DE LA SALLE UNIVERSITY DASMARIÑAS DEVELOPMENT COOPERATIVE and/or salary, retirement pay and any other amounts due us from DE LA SALLE UNIVERSITY-DASMARIÑAS as security for the loan plus interest or surcharges, and costs executed by the Maker payable to the DE LA SALLE UNIVERSITY-DASMARIÑAS DEVELOPMENT COOPERATIVE.", alignment: 0, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(" ", alignment: 1, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText("We also agree that should I (Maker)/We(Maker and Co Maker) fall any instalment of the loan due, or should our employment, Maker and/or Co-Maker with the DE LA SALLE UNIVERSITY-DASMARIÑAS be terminated, our pledges herein shall immediately be applied in payment of this note.", alignment: 0, colspan: 4));
            
            mainTable.AddCell(PdfHelper2.CreateCellWithText(" ", alignment: 1, colspan: 4));

            PdfPTable subtable = new PdfPTable(new float[] { 33.33f, 33.33f, 33.33f });
            subtable.AddCell(PdfHelper2.CreateCellWithText(names[0], alignment: 1));
            subtable.AddCell(PdfHelper2.CreateCellWithText(names[1], alignment: 1));
            subtable.AddCell(PdfHelper2.CreateCellWithText(names[2], alignment: 1));

            subtable.AddCell(PdfHelper2.CreateCellWithText("Maker", alignment: 1));
            subtable.AddCell(PdfHelper2.CreateCellWithText("CoMaker", alignment: 1));
            subtable.AddCell(PdfHelper2.CreateCellWithText("CoMaker", alignment: 1));


            mainTable.AddCell(
                new PdfPCell() {
                    Table = subtable,
                    Colspan = 4,
                    Border = 0
                }
                );


            document.Add(mainTable);
            document.Close();

            byte[] bytes = output.ToArray();

            File.WriteAllBytes(SaveAs.ToString(), bytes);
        }
        public static void CreateDeductionDocument(object fileName, object SaveAs, List<string> details, string name)
        {
            var document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            document.SetMargins(30, 30, 30, 30);

            var output = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, output);

            document.Open();
            document.NewPage();

            PdfPTable mainTable = new PdfPTable(new float[] { 2.5f, 2.5f, 2.5f, 2.5f });

            mainTable.AddCell(PdfHelper2.CreateCellWithText("AUTHORITY FOR SALARY DEDUCTION",
            alignment: 1, colspan: 4, fonttype: 1));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(" ",
            alignment: 1, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(
                string.Format("I hereby authorize the TREASURER of DE LA SALLE UNIVERSITY-DASMARIÑAS DEVELOPMENT COOPERATIVE to collect from the payroll master of DE LA SALLE UNIVERSITY-DASMARIÑAS out of my salary every payday the sum of {0} effective {1} plus interest if any, until this loan is fully paid in addition to my share capital and savings deposit.",
                ((double)(Convert.ToInt32(details[3].Replace(",", "")) / Convert.ToInt32(details[4]))).ToString("#.00"),
                AttachmentHelper.GetNearestPayDay()
                ),
            alignment: 0, colspan: 4));

            mainTable.AddCell(PdfHelper2.CreateCellWithText(" ",
            alignment: 1, colspan: 4));


            PdfPTable subtable = new PdfPTable(new float[] { 33.33f, 33.33f, 33.33f });
            subtable.AddCell(PdfHelper2.CreateCellWithText(" ", alignment: 1));
            subtable.AddCell(PdfHelper2.CreateCellWithText(" ", alignment: 1));
            subtable.AddCell(PdfHelper2.CreateCellWithText(name, alignment: 1));
            subtable.AddCell(PdfHelper2.CreateCellWithText(" ", alignment: 1));
            subtable.AddCell(PdfHelper2.CreateCellWithText(" ", alignment: 1));
            subtable.AddCell(PdfHelper2.CreateCellWithText("Maker", alignment: 1));


            mainTable.AddCell(
                new PdfPCell()
                {
                    Table = subtable,
                    Colspan = 4,
                    Border = 0
                }
                );

              document.Add(mainTable);
            document.Close();

            byte[] bytes = output.ToArray();

            File.WriteAllBytes(SaveAs.ToString(), bytes);

            //object value = Missing.Value;
            //Application application = new Application();
            //Document document = null;
            if (File.Exists((string)fileName))
            {
                DateTime now = DateTime.Now;
                //object obj = false;
                //object obj2 = false;
                //application.Visible = false;
                //document = application.Documents.Open(ref fileName, ref value, ref obj, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref obj2, ref value, ref value, ref value, ref value);
                //document.Activate();
                Document doc = new Document();
                //AttachmentHelper.FindAndReplace(application, "<startDate>", AttachmentHelper.GetNearestPayDay());
                //doc.Range.Replace("<startDate>", AttachmentHelper.GetNearestPayDay(), true, true);
                //AttachmentHelper.FindAndReplace(application, "<nameOfMaker>", name);
                //doc.Range.Replace("<nameOfMaker>", name, true, true);
                //AttachmentHelper.FindAndReplace(application, "<amount>", ((double)(Convert.ToInt32(details[3].Replace(",", "")) / Convert.ToInt32(details[4]))).ToString("#.00"));
                //doc.Range.Replace("<amount>", ((double)(Convert.ToInt32(details[3].Replace(",", "")) / Convert.ToInt32(details[4]))).ToString("#.00"), true, true);

                //doc.Save(SaveAs.ToString());
            }
            //object value2 = Missing.Value;
            //document.SaveAs2(ref SaveAs, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value, ref value2);
            //document.Close(ref value, ref value, ref value);
        }
        private static string GetNearestPayDay()
        {
            string result;
            if (DateTime.Now.Day >= 15 && DateTime.Now.Day < 30)
            {
                result = DateTime.Now.Month + "/30/" + DateTime.Now.Year;
            }
            else
            {
                result = DateTime.Now.Month + "/15/" + DateTime.Now.Year;
            }
            return result;
        }
        //private static void FindAndReplace(Application WordApp, object findText, object replaceWithText)
        //{
        //    object obj = true;
        //    object obj2 = true;
        //    object obj3 = false;
        //    object obj4 = false;
        //    object obj5 = false;
        //    object obj6 = true;
        //    object obj7 = false;
        //    object obj8 = false;
        //    object obj9 = false;
        //    object obj10 = false;
        //    object obj11 = false;
        //    object obj12 = false;
        //    object obj13 = true;
        //    object obj14 = 2;
        //    object obj15 = 1;
        //    WordApp.Selection.Find.Execute(ref findText, ref obj, ref obj2, ref obj3, ref obj4, ref obj5, ref obj6, ref obj15, ref obj7, ref replaceWithText, ref obj14, ref obj8, ref obj9, ref obj10, ref obj11);
        //}
        public static string NumberToWords(int number)
        {
            string result;
            if (number == 0)
            {
                result = "zero";
            }
            else
            {
                if (number < 0)
                {
                    result = "minus " + AttachmentHelper.NumberToWords(Math.Abs(number));
                }
                else
                {
                    string text = "";
                    if (number / 1000000 > 0)
                    {
                        text = text + AttachmentHelper.NumberToWords(number / 1000000) + " million ";
                        number %= 1000000;
                    }
                    if (number / 1000 > 0)
                    {
                        text = text + AttachmentHelper.NumberToWords(number / 1000) + " thousand ";
                        number %= 1000;
                    }
                    if (number / 100 > 0)
                    {
                        text = text + AttachmentHelper.NumberToWords(number / 100) + " hundred ";
                        number %= 100;
                    }
                    if (number > 0)
                    {
                        if (text != "")
                        {
                            text += "and ";
                        }
                        string[] array = new string[]
						{
							"zero",
							"one",
							"two",
							"three",
							"four",
							"five",
							"six",
							"seven",
							"eight",
							"nine",
							"ten",
							"eleven",
							"twelve",
							"thirteen",
							"fourteen",
							"fifteen",
							"sixteen",
							"seventeen",
							"eighteen",
							"nineteen"
						};
                        string[] array2 = new string[]
						{
							"zero",
							"ten",
							"twenty",
							"thirty",
							"forty",
							"fifty",
							"sixty",
							"seventy",
							"eighty",
							"ninety"
						};
                        if (number < 20)
                        {
                            text += array[number];
                        }
                        else
                        {
                            text += array2[number / 10];
                            if (number % 10 > 0)
                            {
                                text = text + "-" + array[number % 10];
                            }
                        }
                    }
                    result = text;
                }
            }
            return result;
        }
    }
}
