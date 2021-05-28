
namespace FurniturServiceView
{
    partial class FormReportOrdersDate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ReportOrdersDateViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonToPdf = new System.Windows.Forms.Button();
            this.buttonMake = new System.Windows.Forms.Button();
            this.reportViewerOrders = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersDateViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportOrdersDateViewModelBindingSource
            // 
            this.ReportOrdersDateViewModelBindingSource.DataSource = typeof(FurnitureServiceBusinessLogic.ViewModels.ReportOrdersAllDatesViewModel);
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.Location = new System.Drawing.Point(583, 12);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(75, 27);
            this.buttonToPdf.TabIndex = 9;
            this.buttonToPdf.Text = "В Pdf";
            this.buttonToPdf.UseVisualStyleBackColor = true;
            this.buttonToPdf.Click += new System.EventHandler(this.buttonSaveToPDF_Click);
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(367, 12);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(136, 27);
            this.buttonMake.TabIndex = 8;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // reportViewerOrders
            // 
            this.reportViewerOrders.LocalReport.ReportEmbeddedResource = "FurniturServiceView.ReportOrders.rdlc";
            this.reportViewerOrders.Location = new System.Drawing.Point(46, 53);
            this.reportViewerOrders.Name = "reportViewerOrders";
            this.reportViewerOrders.ServerReport.BearerToken = null;
            this.reportViewerOrders.Size = new System.Drawing.Size(1055, 564);
            this.reportViewerOrders.TabIndex = 7;
            // 
            // FormReportOrdersDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 637);
            this.Controls.Add(this.buttonToPdf);
            this.Controls.Add(this.buttonMake);
            this.Controls.Add(this.reportViewerOrders);
            this.Name = "FormReportOrdersDate";
            this.Text = "Все заказы";
            this.Load += new System.EventHandler(this.FormReportOrdersDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersDateViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonToPdf;
        private System.Windows.Forms.Button buttonMake;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerOrders;
        private System.Windows.Forms.BindingSource ReportOrdersDateViewModelBindingSource;
    }
}