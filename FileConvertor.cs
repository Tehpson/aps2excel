using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aps2excel
{
    internal static class FileConvertor
    {
        public static void Convert(string selectedFilePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            List<ExportData> exportData = new();
            List<RadData> radData = new();

            string[] lines = File.ReadAllLines(selectedFilePath);

            foreach (string line in lines)
            {
                Match match = Regex.Match(line, "<Var\\s+Name=\"([^\"]*)\"\\s+Value=\"([^\"]*)\"(?:\\s+Unit=\"([^\"]*)\")?\\s+Text=\"([^\"]*)\".*");

                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    string value = match.Groups[2].Value;
                    string unit = match.Groups[3].Value;
                    string text = match.Groups[4].Value;

                    if (Regex.IsMatch(text, "^Rad\\s+(\\d+)"))
                    {
                        int radNumber = int.Parse(Regex.Match(text, "^Rad\\s+(\\d+)").Groups[1].Value);
                        string paddedRadNumber = radNumber.ToString("D3");

                        radData.Add(new RadData
                        {
                            Name = name,
                            Value = value,
                            Unit = unit,
                            Text = text,
                            RadNumber = paddedRadNumber
                        });
                    }
                    else
                    {
                        exportData.Add(new ExportData
                        {
                            Name = name,
                            Value = value,
                            Unit = unit,
                            Text = text
                        });
                    }
                }
            }

            // Sort the "Rad" rows numerically
            radData.Sort((a, b) => a.RadNumber.CompareTo(b.RadNumber));

            // Combine the "Rad" rows with the non-"Rad" rows
            exportData.AddRange(radData);

            // Create an Excel package
            using (ExcelPackage excelPackage = new())
            {
                // Add a new worksheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("MyTable");

                // Write headers
                worksheet.Cells[1, 1].Value = "Name";
                worksheet.Cells[1, 2].Value = "Value";
                worksheet.Cells[1, 3].Value = "Unit";
                worksheet.Cells[1, 4].Value = "Text";

                // Write data to the Excel worksheet
                for (int row = 0; row < exportData.Count; row++)
                {
                    worksheet.Cells[row + 2, 1].Value = exportData[row].Name;
                    worksheet.Cells[row + 2, 2].Value = exportData[row].Value;
                    worksheet.Cells[row + 2, 3].Value = exportData[row].Unit;
                    worksheet.Cells[row + 2, 4].Value = exportData[row].Text;
                }

                // Save the Excel file
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(selectedFilePath);
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string exportPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{fileNameWithoutExtension}_{timestamp}.xlsx");

                FileInfo excelFile = new(exportPath);
                excelPackage.SaveAs(excelFile);

                MessageBox.Show("File Have been Converted and exported to: " + exportPath);
            }
        }
    }

    public class ExportData
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? Unit { get; set; }
        public string? Text { get; set; }
    }

    public class RadData : ExportData
    {
        public string? RadNumber { get; set; }
    }
}
