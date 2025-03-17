using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHaven.Business.Interfaces;
using BookHaven.Business.Services;
using OfficeOpenXml; 
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using BookHaven.Business;

namespace BookHaven.Forms
{
    public partial class ReportsForm : Form
    {
        private readonly IReportService _reportService;

        public ReportsForm(IReportService reportService)
        {
            InitializeComponent();
            _reportService = reportService;
            dtpStartDate.Value = DateTime.Now.AddMonths(-1);
            dtpEndDate.Value = DateTime.Now;
            LoadSalesReport();
            LoadInventoryReport();
            LoadStaffPerformanceReport();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            if (Session.LoggedInUserRole != "Admin")
            {
                MessageBox.Show("Access Denied: Only Admins can access reports!", "Security Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        // Load Sales Report with Date Filtering
        private void LoadSalesReport()
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            var salesData = _reportService.GetSalesReport(startDate, endDate);
            dgvSalesReport.DataSource = salesData;
            dgvSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Load Inventory Report
        private void LoadInventoryReport()
        {
            var inventoryData = _reportService.GetInventoryReport();
            dgvInventoryReport.DataSource = inventoryData;
            dgvInventoryReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Load Staff Performance Report
        private void LoadStaffPerformanceReport()
        {
            var staffPerformanceData = _reportService.GetStaffPerformanceReport();
            dgvStaffPerformanceReport.DataSource = staffPerformanceData;
            dgvStaffPerformanceReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnFilterSalesReport_Click(object sender, EventArgs e)
        {
            LoadSalesReport();
        }

        private void btnExportSalesExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvSalesReport, "Sales_Report.xlsx");
        }

        private void btnExportInventoryExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvInventoryReport, "Inventory_Report.xlsx");
        }

        private void btnExportStaffPDF_Click(object sender, EventArgs e)
        {
            ExportToPDF(dgvStaffPerformanceReport, "Staff_Performance_Report.pdf");
        }

        private void btnExportStaffExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dgvStaffPerformanceReport, "Staff_Performance_Report.xlsx");
        }

        private void btnExportSalesPDF_Click(object sender, EventArgs e)
        {
            ExportToPDF(dgvSalesReport, "Sales_Report.pdf");
        }

        private void btnExportInventoryPDF_Click(object sender, EventArgs e)
        {
            ExportToPDF(dgvInventoryReport, "Inventory_Report.pdf");
        }

        // Export DataGridView to Excel
        private void ExportToExcel(DataGridView dgv, string fileName)
        {
            // Set License Context for EPPlus
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Report");

                // Write column headers
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dgv.Columns[i].HeaderText;
                }

                // Write data rows
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dgv.Rows[i].Cells[j].Value;
                    }
                }

                // Save file dialog
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Save Excel Report",
                    FileName = fileName
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(file);
                    MessageBox.Show("Export successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Export DataGridView to PDF
        private void ExportToPDF(DataGridView dgv, string fileName)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = fileName
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveDialog.FileName, FileMode.Create))
                {
                    Document document = new Document(PageSize.A4.Rotate());
                    PdfWriter.GetInstance(document, stream);
                    document.Open();

                    PdfPTable table = new PdfPTable(dgv.Columns.Count);

                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        table.AddCell(cell);
                    }

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            table.AddCell(cell.Value?.ToString() ?? "");
                        }
                    }

                    document.Add(table);
                    document.Close();
                    MessageBox.Show("Export successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            // Ensure the application exits if no other forms are open
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedItem == null)
            {
                MessageBox.Show("Please select a report type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string reportType = cmbReportType.SelectedItem.ToString();

            try
            {
                _reportService.GenerateAndSaveReport(reportType);
                MessageBox.Show($"{reportType} has been generated and saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving {reportType}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
