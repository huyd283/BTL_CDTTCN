namespace Test_Queue
{
    partial class TestQueue
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
            label1 = new Label();
            panel1 = new Panel();
            btnNhapMang = new Button();
            luuFile = new Button();
            docFile = new Button();
            tbMax = new TextBox();
            tbMin = new TextBox();
            tbSoPT = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            rbNoibot = new RadioButton();
            rbChen = new RadioButton();
            rbChon = new RadioButton();
            label2 = new Label();
            panel3 = new Panel();
            btnXoa = new Button();
            btnGiam = new Button();
            btnTang = new Button();
            label3 = new Label();
            tbMang = new TextBox();
            tbKetqua = new TextBox();
            msg = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(133, 14);
            label1.Name = "label1";
            label1.Size = new Size(154, 20);
            label1.TabIndex = 0;
            label1.Text = "Tạo dữ liệu cho mảng";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnNhapMang);
            panel1.Controls.Add(luuFile);
            panel1.Controls.Add(docFile);
            panel1.Controls.Add(tbMax);
            panel1.Controls.Add(tbMin);
            panel1.Controls.Add(tbSoPT);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(26, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(441, 269);
            panel1.TabIndex = 1;
            // 
            // btnNhapMang
            // 
            btnNhapMang.Location = new Point(132, 222);
            btnNhapMang.Name = "btnNhapMang";
            btnNhapMang.Size = new Size(94, 29);
            btnNhapMang.TabIndex = 11;
            btnNhapMang.Text = "Nhập mảng";
            btnNhapMang.UseVisualStyleBackColor = true;
            btnNhapMang.Click += btnNhapMang_Click;
            // 
            // luuFile
            // 
            luuFile.Location = new Point(303, 154);
            luuFile.Name = "luuFile";
            luuFile.Size = new Size(94, 29);
            luuFile.TabIndex = 10;
            luuFile.Text = "Ghi File";
            luuFile.UseVisualStyleBackColor = true;
            luuFile.Click += luuFile_Click;
            // 
            // docFile
            // 
            docFile.Location = new Point(303, 101);
            docFile.Name = "docFile";
            docFile.Size = new Size(94, 29);
            docFile.TabIndex = 9;
            docFile.Text = "Đọc File";
            docFile.UseVisualStyleBackColor = true;
            docFile.Click += docFile_Click;
            // 
            // tbMax
            // 
            tbMax.Location = new Point(134, 169);
            tbMax.Name = "tbMax";
            tbMax.Size = new Size(99, 27);
            tbMax.TabIndex = 8;
            // 
            // tbMin
            // 
            tbMin.Location = new Point(133, 129);
            tbMin.Name = "tbMin";
            tbMin.Size = new Size(100, 27);
            tbMin.TabIndex = 7;
            // 
            // tbSoPT
            // 
            tbSoPT.Location = new Point(132, 93);
            tbSoPT.Name = "tbSoPT";
            tbSoPT.Size = new Size(101, 27);
            tbSoPT.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(25, 176);
            label8.Name = "label8";
            label8.Size = new Size(58, 20);
            label8.TabIndex = 5;
            label8.Text = "Số cuối";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 136);
            label7.Name = "label7";
            label7.Size = new Size(55, 20);
            label7.TabIndex = 4;
            label7.Text = "Số đầu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 100);
            label6.Name = "label6";
            label6.Size = new Size(81, 20);
            label6.TabIndex = 3;
            label6.Text = "Số phần tử";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(298, 49);
            label5.Name = "label5";
            label5.Size = new Size(67, 20);
            label5.TabIndex = 2;
            label5.Text = "Xử lý file";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 49);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 1;
            label4.Text = "Nhập tay";
            // 
            // panel2
            // 
            panel2.Controls.Add(rbNoibot);
            panel2.Controls.Add(rbChen);
            panel2.Controls.Add(rbChon);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(473, 25);
            panel2.Name = "panel2";
            panel2.Size = new Size(239, 269);
            panel2.TabIndex = 2;
            // 
            // rbNoibot
            // 
            rbNoibot.AutoSize = true;
            rbNoibot.Location = new Point(70, 142);
            rbNoibot.Name = "rbNoibot";
            rbNoibot.Size = new Size(81, 24);
            rbNoibot.TabIndex = 3;
            rbNoibot.TabStop = true;
            rbNoibot.Text = "Nổi bọt";
            rbNoibot.UseVisualStyleBackColor = true;
            // 
            // rbChen
            // 
            rbChen.AutoSize = true;
            rbChen.Location = new Point(70, 112);
            rbChen.Name = "rbChen";
            rbChen.Size = new Size(63, 24);
            rbChen.TabIndex = 2;
            rbChen.TabStop = true;
            rbChen.Text = "Chèn";
            rbChen.UseVisualStyleBackColor = true;
            // 
            // rbChon
            // 
            rbChon.AutoSize = true;
            rbChon.Location = new Point(69, 82);
            rbChon.Name = "rbChon";
            rbChon.Size = new Size(64, 24);
            rbChon.TabIndex = 1;
            rbChon.TabStop = true;
            rbChon.Text = "Chọn";
            rbChon.UseVisualStyleBackColor = true;
            //rbChon.CheckedChanged += rbChon_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(75, 14);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 0;
            label2.Text = "Thuật toán";
            // 
            // panel3
            // 
            panel3.Controls.Add(btnXoa);
            panel3.Controls.Add(btnGiam);
            panel3.Controls.Add(btnTang);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(718, 25);
            panel3.Name = "panel3";
            panel3.Size = new Size(291, 269);
            panel3.TabIndex = 3;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(101, 162);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnGiam
            // 
            btnGiam.Location = new Point(101, 127);
            btnGiam.Name = "btnGiam";
            btnGiam.Size = new Size(94, 29);
            btnGiam.TabIndex = 2;
            btnGiam.Text = "Giảm";
            btnGiam.UseVisualStyleBackColor = true;
            // 
            // btnTang
            // 
            btnTang.Location = new Point(101, 91);
            btnTang.Name = "btnTang";
            btnTang.Size = new Size(94, 29);
            btnTang.TabIndex = 1;
            btnTang.Text = "Tăng";
            btnTang.UseVisualStyleBackColor = true;
            btnTang.Click += btnTang_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(111, 10);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 0;
            label3.Text = "Điều khiển";
            // 
            // tbMang
            // 
            tbMang.Location = new Point(174, 405);
            tbMang.Name = "tbMang";
            tbMang.Size = new Size(361, 27);
            tbMang.TabIndex = 4;
            // 
            // tbKetqua
            // 
            tbKetqua.Location = new Point(174, 456);
            tbKetqua.Name = "tbKetqua";
            tbKetqua.Size = new Size(361, 27);
            tbKetqua.TabIndex = 5;
            // 
            // msg
            // 
            msg.Location = new Point(174, 511);
            msg.Name = "msg";
            msg.Size = new Size(227, 27);
            msg.TabIndex = 6;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(29, 408);
            label9.Name = "label9";
            label9.Size = new Size(108, 20);
            label9.TabIndex = 7;
            label9.Text = "Mảng ban đầu:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(29, 463);
            label10.Name = "label10";
            label10.Size = new Size(63, 20);
            label10.TabIndex = 8;
            label10.Text = "Kết quả:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(29, 518);
            label11.Name = "label11";
            label11.Size = new Size(139, 20);
            label11.TabIndex = 9;
            label11.Text = "Thời gian thực hiện:";
            // 
            // TestQueue
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 550);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(msg);
            Controls.Add(tbKetqua);
            Controls.Add(tbMang);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "TestQueue";
            Text = "TestQueue";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Panel panel2;
        private Label label2;
        private Panel panel3;
        private Label label3;
        private TextBox tbMax;
        private TextBox tbMin;
        private TextBox tbSoPT;
        private Button btnNhapMang;
        private Button luuFile;
        private Button docFile;
        private RadioButton rbNoibot;
        private RadioButton rbChen;
        private RadioButton rbChon;
        private Button btnTang;
        private Button btnXoa;
        private Button btnGiam;
        private TextBox tbMang;
        private TextBox tbKetqua;
        private TextBox msg;
        private Label label9;
        private Label label10;
        private Label label11;
    }
}