
namespace IspecGenerator
{
    partial class SpecControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioInch = new System.Windows.Forms.RadioButton();
            this.radioMM = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImportSpecName = new System.Windows.Forms.TextBox();
            this.lblCate = new System.Windows.Forms.Label();
            this.btnCate = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileExport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblExportIspec = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExportIspec = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(374, 200);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtImportSpecName);
            this.tabPage1.Controls.Add(this.lblCate);
            this.tabPage1.Controls.Add(this.btnCate);
            this.tabPage1.Controls.Add(this.btnImport);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(366, 174);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Import";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioInch);
            this.groupBox1.Controls.Add(this.radioMM);
            this.groupBox1.Location = new System.Drawing.Point(6, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 38);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Units";
            // 
            // radioInch
            // 
            this.radioInch.AutoSize = true;
            this.radioInch.Location = new System.Drawing.Point(49, 16);
            this.radioInch.Name = "radioInch";
            this.radioInch.Size = new System.Drawing.Size(45, 17);
            this.radioInch.TabIndex = 1;
            this.radioInch.Text = "inch";
            this.radioInch.UseVisualStyleBackColor = true;
            this.radioInch.CheckedChanged += new System.EventHandler(this.radioInch_CheckedChanged);
            // 
            // radioMM
            // 
            this.radioMM.AutoSize = true;
            this.radioMM.Checked = true;
            this.radioMM.Location = new System.Drawing.Point(3, 16);
            this.radioMM.Name = "radioMM";
            this.radioMM.Size = new System.Drawing.Size(41, 17);
            this.radioMM.TabIndex = 0;
            this.radioMM.TabStop = true;
            this.radioMM.Text = "mm";
            this.radioMM.UseVisualStyleBackColor = true;
            this.radioMM.CheckedChanged += new System.EventHandler(this.radioMM_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter new insu spec\'s name";
            // 
            // txtImportSpecName
            // 
            this.txtImportSpecName.Location = new System.Drawing.Point(6, 30);
            this.txtImportSpecName.Name = "txtImportSpecName";
            this.txtImportSpecName.Size = new System.Drawing.Size(354, 20);
            this.txtImportSpecName.TabIndex = 5;
            this.txtImportSpecName.Tag = "";
            this.txtImportSpecName.Leave += new System.EventHandler(this.txtImportSpecName_Leave);
            // 
            // lblCate
            // 
            this.lblCate.AutoSize = true;
            this.lblCate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCate.Location = new System.Drawing.Point(92, 57);
            this.lblCate.Name = "lblCate";
            this.lblCate.Size = new System.Drawing.Size(0, 21);
            this.lblCate.TabIndex = 4;
            // 
            // btnCate
            // 
            this.btnCate.Location = new System.Drawing.Point(6, 56);
            this.btnCate.Name = "btnCate";
            this.btnCate.Size = new System.Drawing.Size(80, 23);
            this.btnCate.TabIndex = 2;
            this.btnCate.Text = "Select CATE";
            this.btnCate.UseVisualStyleBackColor = true;
            this.btnCate.Click += new System.EventHandler(this.btnCate_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.Location = new System.Drawing.Point(6, 145);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(51, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnBrowse);
            this.tabPage2.Controls.Add(this.txtFileExport);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.lblExportIspec);
            this.tabPage2.Controls.Add(this.btnExport);
            this.tabPage2.Controls.Add(this.btnExportIspec);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(366, 174);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Export";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(310, 72);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(53, 20);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFileExport
            // 
            this.txtFileExport.Location = new System.Drawing.Point(6, 72);
            this.txtFileExport.Name = "txtFileExport";
            this.txtFileExport.Size = new System.Drawing.Size(298, 20);
            this.txtFileExport.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Directory";
            // 
            // lblExportIspec
            // 
            this.lblExportIspec.AutoSize = true;
            this.lblExportIspec.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportIspec.Location = new System.Drawing.Point(114, 13);
            this.lblExportIspec.Name = "lblExportIspec";
            this.lblExportIspec.Size = new System.Drawing.Size(0, 21);
            this.lblExportIspec.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.Location = new System.Drawing.Point(6, 145);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(58, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExportIspec
            // 
            this.btnExportIspec.Location = new System.Drawing.Point(6, 11);
            this.btnExportIspec.Name = "btnExportIspec";
            this.btnExportIspec.Size = new System.Drawing.Size(101, 23);
            this.btnExportIspec.TabIndex = 0;
            this.btnExportIspec.Text = "Choose Ispec";
            this.btnExportIspec.UseVisualStyleBackColor = true;
            this.btnExportIspec.Click += new System.EventHandler(this.btnExportIspec_Click);
            // 
            // SpecControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tabControl1);
            this.Name = "SpecControl";
            this.Size = new System.Drawing.Size(380, 206);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblCate;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblExportIspec;
        private System.Windows.Forms.Button btnExportIspec;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCate;
        private System.Windows.Forms.TextBox txtImportSpecName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioInch;
        private System.Windows.Forms.RadioButton radioMM;
    }
}
