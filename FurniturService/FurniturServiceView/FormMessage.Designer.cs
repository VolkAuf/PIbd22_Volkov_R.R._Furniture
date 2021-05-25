
namespace FurniturServiceView
{
    partial class FormMessage
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.textBoxGetPage = new System.Windows.Forms.TextBox();
            this.buttonGetPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 49);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(775, 361);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(464, 416);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(118, 31);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "Следующая";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(187, 416);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(124, 31);
            this.buttonPrev.TabIndex = 2;
            this.buttonPrev.Text = "Предыдущая";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(360, 420);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(51, 22);
            this.textBoxPage.TabIndex = 3;
            // 
            // textBoxGetPage
            // 
            this.textBoxGetPage.Location = new System.Drawing.Point(156, 13);
            this.textBoxGetPage.Name = "textBoxGetPage";
            this.textBoxGetPage.Size = new System.Drawing.Size(48, 22);
            this.textBoxGetPage.TabIndex = 4;
            // 
            // buttonGetPage
            // 
            this.buttonGetPage.Location = new System.Drawing.Point(13, 12);
            this.buttonGetPage.Name = "buttonGetPage";
            this.buttonGetPage.Size = new System.Drawing.Size(111, 23);
            this.buttonGetPage.TabIndex = 5;
            this.buttonGetPage.Text = "Перейти";
            this.buttonGetPage.UseVisualStyleBackColor = true;
            this.buttonGetPage.Click += new System.EventHandler(this.buttonGetPage_Click);
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonGetPage);
            this.Controls.Add(this.textBoxGetPage);
            this.Controls.Add(this.textBoxPage);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormMessage";
            this.Text = "Сообщения";
            this.Load += new System.EventHandler(this.FormMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.TextBox textBoxGetPage;
        private System.Windows.Forms.Button buttonGetPage;
    }
}