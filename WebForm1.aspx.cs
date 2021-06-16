using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // string pdfText = GetTextFromPDF();
            // lbl1.Text = pdfText;



        }

        /// <summary>
        /// Reading text from PDF
        /// </summary>
        /// <returns></returns>
        private string GetTextFromPDF()
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(@"F:\MCA\FYMCA\JAVA\JSP.pdf"))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }
            text.Replace(TextBox1.Text,TextBox2.Text);
            return text.ToString();
        }

        private void getPdf(string text)
        {
            try
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                Paragraph Text = new Paragraph(text);
                pdfDoc.Add(Text);
                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Example.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            catch (Exception ex)
            { Response.Write(ex.Message); }

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string text = GetTextFromPDF();
            getPdf(text);
        }
        }
}