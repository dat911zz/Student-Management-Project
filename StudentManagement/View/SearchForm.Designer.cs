
namespace StudentManagement.View
{
    partial class SearchForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.maSV_SearchBox = new System.Windows.Forms.ComboBox();
            this.tenSV_SearchBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chooseFuncBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtConsole_SF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.searchBtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.maSV_SearchBox);
            this.panel1.Controls.Add(this.tenSV_SearchBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chooseFuncBox);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 193);
            this.panel1.TabIndex = 0;
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.Location = new System.Drawing.Point(368, 134);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(136, 43);
            this.searchBtn.TabIndex = 10;
            this.searchBtn.Text = "Tìm";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(170, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Mã sinh viên";
            // 
            // maSV_SearchBox
            // 
            this.maSV_SearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.maSV_SearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.maSV_SearchBox.DisplayMember = "MaSV";
            this.maSV_SearchBox.FormattingEnabled = true;
            this.maSV_SearchBox.Location = new System.Drawing.Point(173, 81);
            this.maSV_SearchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.maSV_SearchBox.Name = "maSV_SearchBox";
            this.maSV_SearchBox.Size = new System.Drawing.Size(219, 27);
            this.maSV_SearchBox.TabIndex = 8;
            this.maSV_SearchBox.ValueMember = "MaSV";
            this.maSV_SearchBox.SelectedIndexChanged += new System.EventHandler(this.maSV_SearchBox_SelectedIndexChanged);
            this.maSV_SearchBox.Click += new System.EventHandler(this.maSV_SearchBox_Click);
            // 
            // tenSV_SearchBox
            // 
            this.tenSV_SearchBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tenSV_SearchBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tenSV_SearchBox.DisplayMember = "TenSV";
            this.tenSV_SearchBox.FormattingEnabled = true;
            this.tenSV_SearchBox.Location = new System.Drawing.Point(484, 81);
            this.tenSV_SearchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tenSV_SearchBox.Name = "tenSV_SearchBox";
            this.tenSV_SearchBox.Size = new System.Drawing.Size(219, 27);
            this.tenSV_SearchBox.TabIndex = 6;
            this.tenSV_SearchBox.ValueMember = "TenSV";
            this.tenSV_SearchBox.SelectedIndexChanged += new System.EventHandler(this.tenSV_SearchBox_SelectedIndexChanged);
            this.tenSV_SearchBox.Click += new System.EventHandler(this.tenSV_SearchBox_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(480, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tên sinh viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(170, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn chức năng:";
            // 
            // chooseFuncBox
            // 
            this.chooseFuncBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseFuncBox.FormattingEnabled = true;
            this.chooseFuncBox.Items.AddRange(new object[] {
            "Xem thông tin của sinh viên",
            "Xem số môn học của sinh viên",
            "Xem số điểm của sinh viên"});
            this.chooseFuncBox.Location = new System.Drawing.Point(306, 11);
            this.chooseFuncBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chooseFuncBox.Name = "chooseFuncBox";
            this.chooseFuncBox.Size = new System.Drawing.Size(397, 27);
            this.chooseFuncBox.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtConsole_SF);
            this.panel2.Location = new System.Drawing.Point(14, 249);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(872, 270);
            this.panel2.TabIndex = 1;
            // 
            // txtConsole_SF
            // 
            this.txtConsole_SF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole_SF.BackColor = System.Drawing.SystemColors.Control;
            this.txtConsole_SF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsole_SF.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole_SF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConsole_SF.Location = new System.Drawing.Point(-1, -2);
            this.txtConsole_SF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConsole_SF.Multiline = true;
            this.txtConsole_SF.Name = "txtConsole_SF";
            this.txtConsole_SF.ReadOnly = true;
            this.txtConsole_SF.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole_SF.Size = new System.Drawing.Size(872, 271);
            this.txtConsole_SF.TabIndex = 24;
            this.txtConsole_SF.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kết quả";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 534);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SearchForm";
            this.Text = "Search Form";
            this.Activated += new System.EventHandler(this.SearchForm_Load);
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtConsole_SF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox chooseFuncBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox maSV_SearchBox;
        private System.Windows.Forms.ComboBox tenSV_SearchBox;
        private System.Windows.Forms.Label label3;
    }
}