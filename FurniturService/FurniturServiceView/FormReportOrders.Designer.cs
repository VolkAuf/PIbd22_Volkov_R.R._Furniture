namespace FurniturServiceView
{
    partial class FormReportOrders
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
            this.buttonMake = new System.Windows.Forms.Button();
            this.buttonToPdf = new System.Windows.Forms.Button();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReportOrdersDateViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersDateViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(520, 12);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(136, 27);
            this.buttonMake.TabIndex = 1;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.ButtonMake_Click);
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.Location = new System.Drawing.Point(662, 12);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(75, 27);
            this.buttonToPdf.TabIndex = 2;
            this.buttonToPdf.Text = "В Pdf";
            this.buttonToPdf.UseVisualStyleBackColor = true;
            this.buttonToPdf.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(35, 12);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerFrom.TabIndex = 3;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(274, 12);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerTo.TabIndex = 4;
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(12, 15);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(17, 17);
            this.labelFrom.TabIndex = 5;
            this.labelFrom.Text = "С";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(242, 13);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(26, 17);
            this.labelTo.TabIndex = 6;
            this.labelTo.Text = "По";
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "FurniturServiceView.ReportFurniture.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(12, 51);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(1062, 447);
            this.reportViewer.TabIndex = 7;
            // 
            // ReportOrdersDateViewModelBindingSource
            // 
            this.ReportOrdersDateViewModelBindingSource.DataSource = typeof(FurnitureServiceBusinessLogic.ViewModels.ReportOrdersDateViewModel);
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 511);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.buttonToPdf);
            this.Controls.Add(this.buttonMake);
            this.Name = "FormReportOrders";
            this.Text = "Заказы клиентов";
            this.Load += new System.EventHandler(this.FormReportOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReportOrdersDateViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.Button buttonToPdf;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource ReportOrdersDateViewModelBindingSource;
    }
}