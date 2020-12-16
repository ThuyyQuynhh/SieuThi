namespace QuanAo
{
    partial class ThongkeDoanhthu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.raBtn = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.dtgvDoanhthu = new System.Windows.Forms.DataGridView();
            this.Trigia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpChonngay = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbChonthang = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbChonnam = new System.Windows.Forms.ComboBox();
            this.txbDoanhthu = new System.Windows.Forms.RichTextBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDoanhthu)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("96336166-9707-4d8c-8ec9-b748b3543d77");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(356, 200);
            this.dockPanel1.Size = new System.Drawing.Size(356, 598);
            this.dockPanel1.Text = "Doanh thu";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.btnThongKe);
            this.dockPanel1_Container.Controls.Add(this.raBtn);
            this.dockPanel1_Container.Controls.Add(this.label1);
            this.dockPanel1_Container.Controls.Add(this.panel3);
            this.dockPanel1_Container.Controls.Add(this.radioButton2);
            this.dockPanel1_Container.Controls.Add(this.radioButton3);
            this.dockPanel1_Container.Controls.Add(this.panel2);
            this.dockPanel1_Container.Controls.Add(this.panel1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(5, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(344, 568);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "THỐNG KÊ THEO:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(21, 107);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(234, 23);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "THỐNG KÊ THEO THÁNG";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // raBtn
            // 
            this.raBtn.AutoSize = true;
            this.raBtn.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raBtn.Location = new System.Drawing.Point(21, 65);
            this.raBtn.Name = "raBtn";
            this.raBtn.Size = new System.Drawing.Size(222, 23);
            this.raBtn.TabIndex = 2;
            this.raBtn.TabStop = true;
            this.raBtn.Text = "THỐNG KÊ THEO NGÀY";
            this.raBtn.UseVisualStyleBackColor = true;
            this.raBtn.CheckedChanged += new System.EventHandler(this.raBtn_CheckedChanged);
            this.raBtn.Click += new System.EventHandler(this.raBtn_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(21, 153);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(213, 23);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "THỐNG KÊ THEO NĂM";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.radioButton3_Click);
            // 
            // dtgvDoanhthu
            // 
            this.dtgvDoanhthu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvDoanhthu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDoanhthu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.MaCT,
            this.MaSP,
            this.TenSP,
            this.SLBan,
            this.Gia,
            this.Trigia});
            this.dtgvDoanhthu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvDoanhthu.Location = new System.Drawing.Point(2, 25);
            this.dtgvDoanhthu.Name = "dtgvDoanhthu";
            this.dtgvDoanhthu.RowHeadersWidth = 51;
            this.dtgvDoanhthu.RowTemplate.Height = 24;
            this.dtgvDoanhthu.Size = new System.Drawing.Size(964, 571);
            this.dtgvDoanhthu.TabIndex = 0;
            // 
            // Trigia
            // 
            this.Trigia.DataPropertyName = "Trigia";
            this.Trigia.HeaderText = "Trị giá";
            this.Trigia.MinimumWidth = 6;
            this.Trigia.Name = "Trigia";
            // 
            // Gia
            // 
            this.Gia.DataPropertyName = "Gia";
            this.Gia.HeaderText = "Đơn giá";
            this.Gia.MinimumWidth = 6;
            this.Gia.Name = "Gia";
            // 
            // SLBan
            // 
            this.SLBan.DataPropertyName = "SLBan";
            this.SLBan.HeaderText = "Số lượng";
            this.SLBan.MinimumWidth = 6;
            this.SLBan.Name = "SLBan";
            // 
            // TenSP
            // 
            this.TenSP.DataPropertyName = "TenSP";
            this.TenSP.HeaderText = "Tên sản phẩm";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            // 
            // MaSP
            // 
            this.MaSP.DataPropertyName = "MaSP";
            this.MaSP.HeaderText = "Mã sản phẩm";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            // 
            // MaCT
            // 
            this.MaCT.DataPropertyName = "MaCT";
            this.MaCT.HeaderText = "Mã chi tiết";
            this.MaCT.MinimumWidth = 6;
            this.MaCT.Name = "MaCT";
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "Mã hoá đơn";
            this.MaHD.MinimumWidth = 6;
            this.MaHD.Name = "MaHD";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpChonngay);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-1, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 48);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Chọn ngày:";
            // 
            // dtpChonngay
            // 
            this.dtpChonngay.Enabled = false;
            this.dtpChonngay.Location = new System.Drawing.Point(105, 10);
            this.dtpChonngay.Name = "dtpChonngay";
            this.dtpChonngay.Size = new System.Drawing.Size(200, 23);
            this.dtpChonngay.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Doanh Thu";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbChonthang);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(-1, 292);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 48);
            this.panel2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chọn tháng:";
            // 
            // cmbChonthang
            // 
            this.cmbChonthang.Enabled = false;
            this.cmbChonthang.FormattingEnabled = true;
            this.cmbChonthang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbChonthang.Location = new System.Drawing.Point(108, 10);
            this.cmbChonthang.Name = "cmbChonthang";
            this.cmbChonthang.Size = new System.Drawing.Size(197, 24);
            this.cmbChonthang.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(271, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 19);
            this.label6.TabIndex = 3;
            this.label6.Text = "(VND)";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbChonnam);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(-1, 372);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(324, 48);
            this.panel3.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Chọn năm:";
            // 
            // cmbChonnam
            // 
            this.cmbChonnam.Enabled = false;
            this.cmbChonnam.FormattingEnabled = true;
            this.cmbChonnam.Items.AddRange(new object[] {
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cmbChonnam.Location = new System.Drawing.Point(105, 10);
            this.cmbChonnam.Name = "cmbChonnam";
            this.cmbChonnam.Size = new System.Drawing.Size(197, 24);
            this.cmbChonnam.TabIndex = 9;
            // 
            // txbDoanhthu
            // 
            this.txbDoanhthu.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDoanhthu.Location = new System.Drawing.Point(126, 15);
            this.txbDoanhthu.Name = "txbDoanhthu";
            this.txbDoanhthu.Size = new System.Drawing.Size(139, 54);
            this.txbDoanhthu.TabIndex = 4;
            this.txbDoanhthu.Text = "";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(96, 449);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(114, 63);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.panel4);
            this.groupControl1.Controls.Add(this.dtgvDoanhthu);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(356, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(968, 598);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Thống kê";
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txbDoanhthu);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(2, 502);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(964, 94);
            this.panel4.TabIndex = 5;
            // 
            // ThongkeDoanhthu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.dockPanel1);
            this.Name = "ThongkeDoanhthu";
            this.Size = new System.Drawing.Size(1324, 598);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDoanhthu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RichTextBox txbDoanhthu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dtgvDoanhthu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trigia;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.RadioButton raBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbChonnam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbChonthang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpChonngay;
        private System.Windows.Forms.Label label2;
    }
}
