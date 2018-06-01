namespace Demo
{
    partial class frmMain
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
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpCode = new DevExpress.XtraEditors.GroupControl();
            this.lsbCode = new DevExpress.XtraEditors.ListBoxControl();
            this.grpThuatToan = new DevExpress.XtraEditors.GroupControl();
            this.radThuatToan = new DevExpress.XtraEditors.RadioGroup();
            this.grpDuLieu = new DevExpress.XtraEditors.GroupControl();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.nmIndex = new System.Windows.Forms.NumericUpDown();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnNhapTay = new DevExpress.XtraEditors.SimpleButton();
            this.btnRandom = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.nmSoPhanTu = new System.Windows.Forms.NumericUpDown();
            this.btnTaoMang = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoaMang = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.btnStop = new DevExpress.XtraEditors.SimpleButton();
            this.btnPause = new DevExpress.XtraEditors.SimpleButton();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.sidePanel1 = new DevExpress.XtraEditors.SidePanel();
            this.grpTocDo = new DevExpress.XtraEditors.GroupControl();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.trackbarSpeed = new DevExpress.XtraEditors.TrackBarControl();
            this.grpHuongSapXep = new DevExpress.XtraEditors.GroupControl();
            this.radTangGiam = new DevExpress.XtraEditors.RadioGroup();
            this.groupControl8 = new DevExpress.XtraEditors.GroupControl();
            this.pnButton = new DevExpress.Utils.FlyoutPanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpCode)).BeginInit();
            this.grpCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lsbCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpThuatToan)).BeginInit();
            this.grpThuatToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radThuatToan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDuLieu)).BeginInit();
            this.grpDuLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoPhanTu)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            this.sidePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTocDo)).BeginInit();
            this.grpTocDo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarSpeed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHuongSapXep)).BeginInit();
            this.grpHuongSapXep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTangGiam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).BeginInit();
            this.groupControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnButton)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Glass Oceans";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.panel2);
            this.panelControl2.Controls.Add(this.grpDuLieu);
            this.panelControl2.Controls.Add(this.panel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 466);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1350, 318);
            this.panelControl2.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grpCode);
            this.panel2.Controls.Add(this.grpThuatToan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(318, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(748, 314);
            this.panel2.TabIndex = 4;
            // 
            // grpCode
            // 
            this.grpCode.Controls.Add(this.lsbCode);
            this.grpCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCode.Location = new System.Drawing.Point(0, 0);
            this.grpCode.Name = "grpCode";
            this.grpCode.Size = new System.Drawing.Size(450, 314);
            this.grpCode.TabIndex = 1;
            this.grpCode.Text = "Code C/C++";
            // 
            // lsbCode
            // 
            this.lsbCode.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbCode.Appearance.Options.UseFont = true;
            this.lsbCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbCode.Location = new System.Drawing.Point(2, 27);
            this.lsbCode.Name = "lsbCode";
            this.lsbCode.Size = new System.Drawing.Size(446, 285);
            this.lsbCode.TabIndex = 0;
            // 
            // grpThuatToan
            // 
            this.grpThuatToan.Controls.Add(this.radThuatToan);
            this.grpThuatToan.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpThuatToan.Location = new System.Drawing.Point(450, 0);
            this.grpThuatToan.Margin = new System.Windows.Forms.Padding(4);
            this.grpThuatToan.Name = "grpThuatToan";
            this.grpThuatToan.Size = new System.Drawing.Size(298, 314);
            this.grpThuatToan.TabIndex = 2;
            this.grpThuatToan.Text = "Thuật Toán";
            // 
            // radThuatToan
            // 
            this.radThuatToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radThuatToan.Location = new System.Drawing.Point(2, 27);
            this.radThuatToan.Name = "radThuatToan";
            this.radThuatToan.Properties.Columns = 2;
            this.radThuatToan.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Interchange Sort"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Selection Sort"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Bubble Sort"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Insertion Sort"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "Quick Sort"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(5, "Shaker Sort")});
            this.radThuatToan.Size = new System.Drawing.Size(294, 285);
            this.radThuatToan.TabIndex = 0;
            this.radThuatToan.SelectedIndexChanged += new System.EventHandler(this.radThuatToan_SelectedIndexChanged);
            // 
            // grpDuLieu
            // 
            this.grpDuLieu.Controls.Add(this.groupControl6);
            this.grpDuLieu.Controls.Add(this.groupControl5);
            this.grpDuLieu.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpDuLieu.Location = new System.Drawing.Point(2, 2);
            this.grpDuLieu.Name = "grpDuLieu";
            this.grpDuLieu.Size = new System.Drawing.Size(316, 314);
            this.grpDuLieu.TabIndex = 0;
            this.grpDuLieu.Text = "Dữ Liệu";
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.txtGiaTri);
            this.groupControl6.Controls.Add(this.nmIndex);
            this.groupControl6.Controls.Add(this.labelControl3);
            this.groupControl6.Controls.Add(this.labelControl2);
            this.groupControl6.Controls.Add(this.btnNhapTay);
            this.groupControl6.Controls.Add(this.btnRandom);
            this.groupControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl6.Location = new System.Drawing.Point(2, 179);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(312, 133);
            this.groupControl6.TabIndex = 1;
            this.groupControl6.Text = "Dữ Liệu Mảng";
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaTri.Location = new System.Drawing.Point(237, 97);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(50, 28);
            this.txtGiaTri.TabIndex = 7;
            // 
            // nmIndex
            // 
            this.nmIndex.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmIndex.Location = new System.Drawing.Point(146, 97);
            this.nmIndex.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nmIndex.Name = "nmIndex";
            this.nmIndex.Size = new System.Drawing.Size(47, 28);
            this.nmIndex.TabIndex = 6;
            this.nmIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(208, 103);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(23, 21);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Là:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(6, 103);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(143, 21);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Giá trị phần tử thứ:";
            // 
            // btnNhapTay
            // 
            this.btnNhapTay.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhapTay.Appearance.Options.UseFont = true;
            this.btnNhapTay.Location = new System.Drawing.Point(189, 46);
            this.btnNhapTay.Name = "btnNhapTay";
            this.btnNhapTay.Size = new System.Drawing.Size(98, 38);
            this.btnNhapTay.TabIndex = 1;
            this.btnNhapTay.Text = "Nhập Tay";
            this.btnNhapTay.Click += new System.EventHandler(this.btnNhapTay_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandom.Appearance.Options.UseFont = true;
            this.btnRandom.Location = new System.Drawing.Point(50, 46);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(98, 38);
            this.btnRandom.TabIndex = 0;
            this.btnRandom.Text = "Ngẫu Nhiên";
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.nmSoPhanTu);
            this.groupControl5.Controls.Add(this.btnTaoMang);
            this.groupControl5.Controls.Add(this.btnXoaMang);
            this.groupControl5.Controls.Add(this.labelControl1);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl5.Location = new System.Drawing.Point(2, 27);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(312, 152);
            this.groupControl5.TabIndex = 0;
            this.groupControl5.Text = "Tạo Mảng";
            // 
            // nmSoPhanTu
            // 
            this.nmSoPhanTu.Cursor = System.Windows.Forms.Cursors.Default;
            this.nmSoPhanTu.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmSoPhanTu.Location = new System.Drawing.Point(82, 104);
            this.nmSoPhanTu.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.nmSoPhanTu.Name = "nmSoPhanTu";
            this.nmSoPhanTu.Size = new System.Drawing.Size(81, 28);
            this.nmSoPhanTu.TabIndex = 5;
            this.nmSoPhanTu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTaoMang
            // 
            this.btnTaoMang.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnTaoMang.Appearance.Options.UseFont = true;
            this.btnTaoMang.Location = new System.Drawing.Point(188, 51);
            this.btnTaoMang.Name = "btnTaoMang";
            this.btnTaoMang.Size = new System.Drawing.Size(98, 38);
            this.btnTaoMang.TabIndex = 4;
            this.btnTaoMang.Text = "Tạo Mảng";
            this.btnTaoMang.Click += new System.EventHandler(this.btnTaoMang_Click);
            // 
            // btnXoaMang
            // 
            this.btnXoaMang.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaMang.Appearance.Options.UseFont = true;
            this.btnXoaMang.Location = new System.Drawing.Point(188, 96);
            this.btnXoaMang.Name = "btnXoaMang";
            this.btnXoaMang.Size = new System.Drawing.Size(98, 38);
            this.btnXoaMang.TabIndex = 3;
            this.btnXoaMang.Text = "Xóa Mảng";
            this.btnXoaMang.Click += new System.EventHandler(this.btnXoaMang_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(6, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(157, 42);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Số phần tử của mảng\r\n(Tối đa 13 phần tử)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelControl4);
            this.panel1.Controls.Add(this.sidePanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1066, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 314);
            this.panel1.TabIndex = 3;
            // 
            // panelControl4
            // 
            this.panelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.panelControl4.Controls.Add(this.btnStop);
            this.panelControl4.Controls.Add(this.btnPause);
            this.panelControl4.Controls.Add(this.btnStart);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(0, 209);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(282, 105);
            this.panelControl4.TabIndex = 2;
            // 
            // btnStop
            // 
            this.btnStop.ImageOptions.Image = global::Demo.Properties.Resources.Stop_icon;
            this.btnStop.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnStop.Location = new System.Drawing.Point(199, 27);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(73, 46);
            this.btnStop.TabIndex = 3;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.ImageOptions.Image = global::Demo.Properties.Resources.Media_Controls_Pause_icon;
            this.btnPause.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnPause.Location = new System.Drawing.Point(104, 27);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(73, 46);
            this.btnPause.TabIndex = 2;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStart
            // 
            this.btnStart.ImageOptions.Image = global::Demo.Properties.Resources.Start_icon;
            this.btnStart.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnStart.Location = new System.Drawing.Point(7, 27);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(73, 46);
            this.btnStart.TabIndex = 1;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // sidePanel1
            // 
            this.sidePanel1.Controls.Add(this.grpTocDo);
            this.sidePanel1.Controls.Add(this.grpHuongSapXep);
            this.sidePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.sidePanel1.Location = new System.Drawing.Point(0, 0);
            this.sidePanel1.Name = "sidePanel1";
            this.sidePanel1.Size = new System.Drawing.Size(282, 209);
            this.sidePanel1.TabIndex = 0;
            this.sidePanel1.Text = "sidePanel1";
            // 
            // grpTocDo
            // 
            this.grpTocDo.Controls.Add(this.lblSpeed);
            this.grpTocDo.Controls.Add(this.trackbarSpeed);
            this.grpTocDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTocDo.Location = new System.Drawing.Point(0, 104);
            this.grpTocDo.Name = "grpTocDo";
            this.grpTocDo.Size = new System.Drawing.Size(282, 104);
            this.grpTocDo.TabIndex = 1;
            this.grpTocDo.Text = "Tốc Độ";
            // 
            // lblSpeed
            // 
            this.lblSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSpeed.Location = new System.Drawing.Point(123, 63);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(42, 33);
            this.lblSpeed.TabIndex = 2;
            this.lblSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackbarSpeed
            // 
            this.trackbarSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackbarSpeed.EditValue = 5;
            this.trackbarSpeed.Location = new System.Drawing.Point(2, 27);
            this.trackbarSpeed.Name = "trackbarSpeed";
            this.trackbarSpeed.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.trackbarSpeed.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.trackbarSpeed.Size = new System.Drawing.Size(278, 75);
            this.trackbarSpeed.TabIndex = 1;
            this.trackbarSpeed.Value = 5;
            this.trackbarSpeed.EditValueChanged += new System.EventHandler(this.trackbarSpeed_EditValueChanged);
            // 
            // grpHuongSapXep
            // 
            this.grpHuongSapXep.Controls.Add(this.radTangGiam);
            this.grpHuongSapXep.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpHuongSapXep.Location = new System.Drawing.Point(0, 0);
            this.grpHuongSapXep.Name = "grpHuongSapXep";
            this.grpHuongSapXep.Size = new System.Drawing.Size(282, 104);
            this.grpHuongSapXep.TabIndex = 0;
            this.grpHuongSapXep.Text = "Hướng Sắp Xếp";
            // 
            // radTangGiam
            // 
            this.radTangGiam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radTangGiam.Location = new System.Drawing.Point(2, 27);
            this.radTangGiam.Name = "radTangGiam";
            this.radTangGiam.Properties.Columns = 2;
            this.radTangGiam.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Tăng"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Giảm")});
            this.radTangGiam.Size = new System.Drawing.Size(278, 75);
            this.radTangGiam.TabIndex = 0;
            this.radTangGiam.SelectedIndexChanged += new System.EventHandler(this.radTangGiam_SelectedIndexChanged);
            // 
            // groupControl8
            // 
            this.groupControl8.Controls.Add(this.pnButton);
            this.groupControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl8.Location = new System.Drawing.Point(0, 0);
            this.groupControl8.Name = "groupControl8";
            this.groupControl8.Size = new System.Drawing.Size(1350, 466);
            this.groupControl8.TabIndex = 3;
            this.groupControl8.Text = "Khung Mô Phỏng";
            // 
            // pnButton
            // 
            this.pnButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnButton.FlyoutPanel = null;
            this.pnButton.Location = new System.Drawing.Point(2, 27);
            this.pnButton.Name = "pnButton";
            this.pnButton.Size = new System.Drawing.Size(1346, 437);
            this.pnButton.TabIndex = 0;
            // 
            // frmMain
            // 
            this.Appearance.BackColor = System.Drawing.Color.Gold;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 784);
            this.Controls.Add(this.groupControl8);
            this.Controls.Add(this.panelControl2);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần Mềm Mô Phỏng Các Thuật Tóa Sắp Xếp";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpCode)).EndInit();
            this.grpCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lsbCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpThuatToan)).EndInit();
            this.grpThuatToan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radThuatToan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDuLieu)).EndInit();
            this.grpDuLieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            this.groupControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoPhanTu)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.sidePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpTocDo)).EndInit();
            this.grpTocDo.ResumeLayout(false);
            this.grpTocDo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarSpeed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpHuongSapXep)).EndInit();
            this.grpHuongSapXep.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radTangGiam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).EndInit();
            this.groupControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.GroupControl grpCode;
        private DevExpress.XtraEditors.ListBoxControl lsbCode;
        private DevExpress.XtraEditors.GroupControl grpThuatToan;
        private DevExpress.XtraEditors.RadioGroup radThuatToan;
        private DevExpress.XtraEditors.GroupControl grpDuLieu;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.NumericUpDown nmIndex;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnNhapTay;
        private DevExpress.XtraEditors.SimpleButton btnRandom;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private System.Windows.Forms.NumericUpDown nmSoPhanTu;
        private DevExpress.XtraEditors.SimpleButton btnTaoMang;
        private DevExpress.XtraEditors.SimpleButton btnXoaMang;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.SimpleButton btnStop;
        private DevExpress.XtraEditors.SimpleButton btnPause;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.SidePanel sidePanel1;
        private DevExpress.XtraEditors.GroupControl grpTocDo;
        private System.Windows.Forms.Label lblSpeed;
        private DevExpress.XtraEditors.TrackBarControl trackbarSpeed;
        private DevExpress.XtraEditors.GroupControl grpHuongSapXep;
        private DevExpress.XtraEditors.RadioGroup radTangGiam;
        private DevExpress.XtraEditors.GroupControl groupControl8;
        private DevExpress.Utils.FlyoutPanelControl pnButton;
    }
}

