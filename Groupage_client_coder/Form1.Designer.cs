namespace Groupage_client_coder
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.butReadExcel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.butCalc = new System.Windows.Forms.Button();
            this.butSaveAs = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Groupage client list for 2013 & 2014.xlsx";
            this.openFileDialog1.Filter = "Excel Files|*.xlsx";
            this.openFileDialog1.ShowHelp = true;
            // 
            // butReadExcel
            // 
            this.butReadExcel.Location = new System.Drawing.Point(13, 13);
            this.butReadExcel.Name = "butReadExcel";
            this.butReadExcel.Size = new System.Drawing.Size(154, 23);
            this.butReadExcel.TabIndex = 0;
            this.butReadExcel.Text = "Read Excel";
            this.butReadExcel.UseVisualStyleBackColor = true;
            this.butReadExcel.Click += new System.EventHandler(this.butReadExcel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(849, 576);
            this.dataGridView1.TabIndex = 1;
            // 
            // butCalc
            // 
            this.butCalc.Location = new System.Drawing.Point(173, 13);
            this.butCalc.Name = "butCalc";
            this.butCalc.Size = new System.Drawing.Size(155, 23);
            this.butCalc.TabIndex = 2;
            this.butCalc.Text = "Calc new code";
            this.butCalc.UseVisualStyleBackColor = true;
            this.butCalc.Click += new System.EventHandler(this.butCalc_Click);
            // 
            // butSaveAs
            // 
            this.butSaveAs.Location = new System.Drawing.Point(334, 13);
            this.butSaveAs.Name = "butSaveAs";
            this.butSaveAs.Size = new System.Drawing.Size(155, 23);
            this.butSaveAs.TabIndex = 3;
            this.butSaveAs.Text = "Save as";
            this.butSaveAs.UseVisualStyleBackColor = true;
            this.butSaveAs.Click += new System.EventHandler(this.butSaveAs_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "YourFileName.xlsx";
            this.saveFileDialog1.Filter = "Excel Files|*.xlsx";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 643);
            this.Controls.Add(this.butSaveAs);
            this.Controls.Add(this.butCalc);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.butReadExcel);
            this.Name = "Form1";
            this.Text = "客戶編碼產生器";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button butReadExcel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button butCalc;
        private System.Windows.Forms.Button butSaveAs;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

