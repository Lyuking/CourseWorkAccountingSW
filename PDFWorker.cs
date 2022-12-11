using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Font;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accounting_sw
{
    class PDFWorker
    {
        SQLiteWorker sQLite;
        public PDFWorker(SQLiteWorker sQLite)
        {
            this.sQLite = sQLite;
        }
        public bool CreatePDFByAudience(string path)
        {
            try
            {
                Document document = CreateDocument(path);
                Paragraph header = new Paragraph("Отчёт установленного ПО по аудиториям.")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(18);
                   
                document.Add(header);

                Paragraph newline = new Paragraph(new Text("\n"));
                document.Add(newline);
                DataTable dtAudiences = sQLite.SelectFromDB(SQLiteWorker.dataTables.audience_full);
                for (int i = 0; i < dtAudiences.Rows.Count; i++)
                {
                    string audienceName = dtAudiences.Rows[i].ItemArray[0].ToString();

                    Paragraph headerAudience = new Paragraph(audienceName)
                   .SetTextAlignment(TextAlignment.LEFT)
                   .SetFontSize(14);
                    document.Add(headerAudience);

                    DataTable dtSoftware = sQLite.SelectSoftwareByAudFromDB(audienceName);
                    for (int j = 0; j < dtSoftware.Rows.Count; j++)
                    {
                        string softwareName = dtSoftware.Rows[j].ItemArray[0].ToString();

                        Paragraph headerSoftware = new Paragraph(softwareName)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .SetFontSize(14);
                        document.Add(headerSoftware);
                        DataTable dtLicences = sQLite.SelectLicenceByAudAndSoftFromDB(audienceName, softwareName);
                        for (int k = 0; k < dtLicences.Rows.Count; k++)
                        {
                            string licenceKey = dtLicences.Rows[k].ItemArray[1].ToString();
                            Paragraph headerLicence = new Paragraph(licenceKey)
                                                   .SetTextAlignment(TextAlignment.RIGHT)
                                                   .SetFontSize(14);
                            document.Add(headerLicence);
                        }
                    }
                    LineSeparator ls = new LineSeparator(new SolidLine());
                    document.Add(ls);
                }

                document.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CreatePDFBySubjectArea(string path)
        {
            try
            {
                Document document = CreateDocument(path);
                Paragraph header = new Paragraph("Отчёт имеющегося ПО по предметным областям.")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(18);

                document.Add(header);

                Paragraph newline = new Paragraph(new Text("\n"));
                document.Add(newline);
                DataTable dtSubjectAreas = sQLite.SelectFromDB(SQLiteWorker.dataTables.subject_area);
                for (int i = 0; i < dtSubjectAreas.Rows.Count; i++)
                {
                    string subjectAreasName = dtSubjectAreas.Rows[i].ItemArray[0].ToString();

                    Paragraph headerSubjectArea = new Paragraph(subjectAreasName)
                   .SetTextAlignment(TextAlignment.LEFT)
                   .SetFontSize(14);
                    document.Add(headerSubjectArea);

                    DataTable dtSoftware = sQLite.SelectSoftwareBySubjectArea(subjectAreasName);
                    for (int j = 0; j < dtSoftware.Rows.Count; j++)
                    {
                        string softwareName = dtSoftware.Rows[j].ItemArray[0].ToString();

                        Paragraph headerSoftware = new Paragraph(softwareName)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .SetFontSize(14);
                        document.Add(headerSoftware);
                        DataTable dtLicences = sQLite.SelectLicencesBySubjectAreaAndSoftware(subjectAreasName, softwareName);
                        for (int k = 0; k < dtLicences.Rows.Count; k++)
                        {
                            string licenceKey = dtLicences.Rows[k].ItemArray[1].ToString();
                            Paragraph headerLicence = new Paragraph(licenceKey)
                                                   .SetTextAlignment(TextAlignment.RIGHT)
                                                   .SetFontSize(14);
                            document.Add(headerLicence);
                        }
                    }
                    LineSeparator ls = new LineSeparator(new SolidLine());
                    document.Add(ls);
                }

                document.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CreatePDFByLicenceType(string path)
        {
            try
            {
                Document document = CreateDocument(path);
                Paragraph header = new Paragraph("Отчёт имеющегося ПО по типу распространения.")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(18);

                document.Add(header);

                Paragraph newline = new Paragraph(new Text("\n"));
                document.Add(newline);
                DataTable dtLicenceType = sQLite.SelectFromDB(SQLiteWorker.dataTables.licence_type);
                for (int i = 0; i < dtLicenceType.Rows.Count; i++)
                {
                    string licenceTypeName = dtLicenceType.Rows[i].ItemArray[0].ToString();

                    Paragraph headerLicenceType = new Paragraph(licenceTypeName)
                   .SetTextAlignment(TextAlignment.LEFT)
                   .SetFontSize(14);
                    document.Add(headerLicenceType);

                    DataTable dtSoftware = sQLite.SelectSoftwareByLicenceType(licenceTypeName);
                    for (int j = 0; j < dtSoftware.Rows.Count; j++)
                    {
                        string softwareName = dtSoftware.Rows[j].ItemArray[0].ToString();

                        Paragraph headerSoftware = new Paragraph(softwareName)
                       .SetTextAlignment(TextAlignment.CENTER)
                       .SetFontSize(14);
                        document.Add(headerSoftware);
                        DataTable dtLicences = sQLite.SelectLicencesByLicenceTypeAndSoftware(licenceTypeName, softwareName);
                        for (int k = 0; k < dtLicences.Rows.Count; k++)
                        {
                            string licenceKey = dtLicences.Rows[k].ItemArray[1].ToString();
                            Paragraph headerLicence = new Paragraph(licenceKey)
                                                   .SetTextAlignment(TextAlignment.RIGHT)
                                                   .SetFontSize(14);
                            document.Add(headerLicence);
                        }
                    }
                    LineSeparator ls = new LineSeparator(new SolidLine());
                    document.Add(ls);
                }

                document.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private static Document CreateDocument(string path)
        {
            Document document = new Document(new PdfDocument(new PdfWriter(path)));
            PdfFont font = PdfFontFactory.CreateFont(Properties.Resources.arial, PdfEncodings.IDENTITY_H);
            document.SetFont(font);
            return document;
        }
    }
}
