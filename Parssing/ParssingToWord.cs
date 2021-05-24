using System.IO;
using Syncfusion.XlsIO;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.Collections.Generic;
using System;

namespace Parssing
{
    public static class ParssingToWord
    {
        public static List<Forms> GetTablInForld()
        {

            FileStream fileStream = new FileStream(@"C:\Users\gabdu\source\repos\Parssing\Parssing\sertifikatsiýa_bölüm.docx", FileMode.Open);

            IWordDocument document = new WordDocument();
            document.Open(fileStream, FormatType.Docx);

            WSection section = document.Sections[0];
            WTable table = section.Tables[0] as WTable;

            List<Forms> forms = new List<Forms>();

            int lastrow = table.Rows.Count;

            for (int i = 1; i < lastrow; i++)
            {
                var form = new Forms();
                string[] fullName = table.Rows[i].Cells[1].Paragraphs[0].Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                form.Id = table.Rows[i].Cells[0].Paragraphs[0].Text;
                form.FirstName = fullName[0];
                form.LastName = fullName[1];
                form.MidleName = fullName[2];
                form.Role = table.Rows[i].Cells[2].Paragraphs[0].Text;


                forms.Add(form);
            }
            return forms;
        }

        //Iterates the rows of the table




    }
}
