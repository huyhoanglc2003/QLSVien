using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace QuanLySinhVien.Models
{
    internal class PDFGenerator
    {

        public static void ExportGradesToPDF(IEnumerable<Diem> grades, string filePath)
        {
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

            document.Open();

            // Add heading
            Font headingFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            Paragraph heading = new Paragraph("Diem sinh vien", headingFont);
            heading.Alignment = Element.ALIGN_CENTER;
            document.Add(heading);

            // Add table with grades
            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;

            PdfPCell cell = new PdfPCell(new Phrase("Ma sinh vien"));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Ma mon hoc"));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Diem"));
            table.AddCell(cell);

            foreach (Diem grade in grades)
            {
                table.AddCell(new Phrase(grade.Masv));
                table.AddCell(new Phrase(grade.Mamh));
                table.AddCell(new Phrase(grade.Diem1.ToString()));
            }

            document.Add(table);
            document.Close();
        }
    }
}
