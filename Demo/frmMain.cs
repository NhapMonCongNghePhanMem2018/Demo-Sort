using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Demo
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        System.Media.SoundPlayer SoundPlayer = new System.Media.SoundPlayer(Demo.Properties.Resources.Mouse_click_sound_effect);
        public frmMain()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SoundPlayer.Load();

            lblIndexI.AutoSize = true;
            lblIndexJ.AutoSize = true;
            lblTemp.AutoSize = true;

            lblIndexI.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            lblIndexJ.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
            lblTemp.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
        }

        Label lblIndexI = new Label();
        Label lblIndexJ = new Label();
        Label lblTemp = new Label();
        string lblTemp_Text;
        string lblIndexI_Text;
        string lblIndexJ_Text;



        #region Các thuộc tính
        Random rd = new Random();//dùng để tạo giá trị ngẫu nhiên
        int[] M = null; //mảng để lưu các giá trị phần tử
        Button[] Mc = null; //mảng để lưu các button động
        int GAP = 50;//Khoảng cách giữa các button trên giao diện
        int HEIGHT = 100;//chiều cao khi button đổi chỗ cho nhau
        int WIDTH;//Lưu khoảng cách mà 2 button đổi chỗ cho nhau
        int SIZE = 50;//size của 1 button động được tạo ra
        int speed;//Lưu tốc độ thực hiện các thuật toán
        
        #endregion

        readonly ManualResetEvent busy = new ManualResetEvent(false);

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            nmSoPhanTu.Focus();
            lblSpeed.Text = trackbarSpeed.Value + "";
            speed = 11 - trackbarSpeed.Value;
            //grpCode.Enabled = false;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
        }

        #region Xử lí Sự kiện Trên Giao Diện

        private void btnTaoMang_Click(object sender, EventArgs e)
        {
            PlaySound();
            btnXoaMang.PerformClick();
            int n = (int)nmSoPhanTu.Value;
            if (n <= 0 || n > 13)
            {
                MessageBox.Show("Số phần tử mảng bạn nhập không hợp lệ!");
                nmSoPhanTu.Focus();
                return;
            }
            int Edge = (pnButton.Width - (n * (SIZE + GAP))) / 2;
            M = new int[n];
            Mc = new Button[n];
            pnButton.Controls.Clear();
            for (int i = 0; i < n; i++)
            {
                Button btn = new Button();
                btn.Enabled = false;
                btn.Text = 0 + "";
                btn.Width = btn.Height = SIZE;
                btn.Location = new Point(
                    i * (btn.Width + GAP) + Edge,
                    pnButton.Height / 2 - SIZE / 2);
                btn.Tag = i;
                pnButton.Controls.Add(btn);

                M[i] = 0;
                Mc[i] = btn;


                Label lbl = new Label();
                lbl.Enabled = false;
                lbl.BackColor = pnButton.BackColor;
                lbl.AutoSize = true;
                lbl.Text = i + "";
                lbl.Location = new Point(btn.Location.X + SIZE / 2 - 10,
                    pnButton.Height - SIZE / 2);
                lbl.Font = new Font("Tahoma", 13.8F, FontStyle.Bold);
                pnButton.Controls.Add(lbl);
            }
            nmIndex.Maximum = n - 1;
        }

        private void btnXoaMang_Click(object sender, EventArgs e)
        {
            PlaySound();
            pnButton.Controls.Clear();
            nmSoPhanTu.Focus();
            M = null;
            Mc = null;
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            PlaySound();
            if (M == null)
            {
                MessageBox.Show("Vui lòng tạo mảng trước để thực hiện chức năng này!");
                return;
            }
            for (int i = 0; i < M.Length; i++)
            {
                Mc[i].BackColor = Color.White;
                int value = rd.Next(100);
                M[i] = value;
                Mc[i].Text = value + "";
            }
        }

        private void btnNhapTay_Click(object sender, EventArgs e)
        {
            PlaySound();
            if (M == null)
            {
                MessageBox.Show("Vui lòng tạo mảng trước để thực hiện chức năng này!");
                return;
            }
            if (txtGiaTri.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá trị :3");
                return;
            }
            M[(int)nmIndex.Value] = int.Parse(txtGiaTri.Text);
            Mc[(int)nmIndex.Value].Text = txtGiaTri.Text;
        }

        private void radThuatToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlaySound();
            if (radTangGiam.EditValue == null)
                return;
            int thuatToan = radThuatToan.SelectedIndex;
            int tangGiam = radTangGiam.SelectedIndex;
            NapCodeLenListBox(thuatToan, tangGiam);
            lsbCode.SelectedIndex = 1;
        }

        private void radTangGiam_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlaySound();
            if (radThuatToan.EditValue == null)
                return;
            int thuatToan = radThuatToan.SelectedIndex;
            int tangGiam = radTangGiam.SelectedIndex;
            NapCodeLenListBox(thuatToan, tangGiam);
            lsbCode.SelectedIndex = 1;
        }

        private void trackbarSpeed_EditValueChanged(object sender, EventArgs e)
        {
            PlaySound();
            lblSpeed.Text = trackbarSpeed.Value + "";
            speed = 11 - trackbarSpeed.Value;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (M == null)
            {
                MessageBox.Show("Bạn chưa tạo mảng");
                return;
            }
            if (radThuatToan.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn thuật toán!");
                return;
            }
            if (radTangGiam.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn hướng xắp xếp!");
                return;
            }

            if (radThuatToan.SelectedIndex == 0)
            {
                pnButton.Controls.Add(lblIndexI);
                pnButton.Controls.Add(lblIndexJ);
                lblIndexI_Text = "i=";
                lblIndexJ_Text = "j=";
            }
            else if (radThuatToan.SelectedIndex == 1)
            {
                pnButton.Controls.Add(lblIndexI);
                pnButton.Controls.Add(lblIndexJ);
                pnButton.Controls.Add(lblTemp);
                lblIndexI_Text = "i=";
                lblIndexJ_Text = "j=";
                if (radTangGiam.SelectedIndex == 0)
                    lblTemp_Text = "Max=";
                else
                    lblTemp_Text = "Min=";
            }
            else if (radThuatToan.SelectedIndex == 2)
            {
                pnButton.Controls.Add(lblIndexI);
                pnButton.Controls.Add(lblIndexJ);
                pnButton.Controls.Add(lblTemp);
                lblIndexI_Text = "i=";
                lblIndexJ_Text = "j=";
                lblTemp_Text = "j-1=";
            }
            else if (radThuatToan.SelectedIndex == 3)
            {
                pnButton.Controls.Add(lblIndexJ);
                pnButton.Controls.Add(lblTemp);
                lblIndexJ_Text = "pos=";
                lblTemp_Text = "Key";
            }
            else if (radThuatToan.SelectedIndex == 4)
            {
                pnButton.Controls.Add(lblIndexI);
                pnButton.Controls.Add(lblIndexJ);
                pnButton.Controls.Add(lblTemp);
                lblIndexI_Text = "i=";
                lblIndexJ_Text = "j=";
                lblTemp_Text = "x=";
            }
            else if (radThuatToan.SelectedIndex == 5)
            {
                pnButton.Controls.Add(lblIndexI);
                pnButton.Controls.Add(lblTemp);
                lblIndexI_Text = "i=";
                lblIndexJ_Text = "j=";
                lblTemp_Text = "";
            }
            PlaySound();
            if (backgroundWorker1.CancellationPending)
            {
                StartWorker();
                return;
            }

            btnStart.Enabled = false;
            btnPause.Enabled = true;
            btnStop.Enabled = true;
            btnPause.Focus();
            grpDuLieu.Enabled = false;
            grpThuatToan.Enabled = false;
            grpHuongSapXep.Enabled = false;

            StartWorker();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            PlaySound();
            PauseWorker();
            btnPause.Enabled = false;
            btnStart.Enabled = true;
            btnStart.Focus();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            PlaySound();
            CancelWorker();
        }

        #endregion

        #region Hàm Xử Lí

        void PlaySound()
        {
            //SoundPlayer.Play();
        }

        void StartWorker()
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            // Unblock the worker 
            busy.Set();
        }

        void CancelWorker()
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();

                // Unblock worker so it can see that
                busy.Set();
                pnButton.Controls.Clear();
            }
        }

        void PauseWorker()
        {
            // Block the worker
            busy.Reset();
        }

        private void MoveButton(int pos1, int pos2, int index)
        {
            Status st = new Status();
            st.pos1 = pos1;
            st.pos2 = pos2;
            st.Type = MoveType.LINE_TO_TOP_AND_LINE_TO_BOTTOM;
            DebugCode(index);
            for (int x = 0; x < HEIGHT; x++)
            {
                backgroundWorker1.ReportProgress(3, st);
                System.Threading.Thread.Sleep(speed);
            }

            st.Type = MoveType.LEFT_TO_RIGHT_AND_RIGHT_TO_LEFT;
            WIDTH = Math.Abs(pos1 - pos2) * (SIZE + GAP);
            for (int x = 0; x < WIDTH; x++)
            {
                backgroundWorker1.ReportProgress(3, st);
                System.Threading.Thread.Sleep(speed);
            }

            st.Type = MoveType.TOP_TO_LINE_AND_BOTTOM_TO_LINE;
            for (int x = 0; x < HEIGHT; x++)
            {
                backgroundWorker1.ReportProgress(3, st);
                System.Threading.Thread.Sleep(speed);
            }

            st.Type = MoveType.CHANGED;
            backgroundWorker1.ReportProgress(3, st);
        }

        private void MoveButton_2(int pos1, int pos2, int type,int index)
        {
            Status st = new Status();
            st.pos1 = pos1;
            st.pos2 = pos2;
            DebugCode(index);
            if (type == 0)
            {
                st.Type = MoveType.LINE_TO_TOP;
                for (int x = 0; x < HEIGHT; x++)
                {
                    backgroundWorker1.ReportProgress(0, st);
                    System.Threading.Thread.Sleep(speed);
                }
                st.Type = MoveType.EXCHANGED;
                backgroundWorker1.ReportProgress(3, st);
            }
            else if (type == 1)
            {
                st.Type = MoveType.LEFT_TO_RIGHT;
                WIDTH = Math.Abs(pos1 - pos2) * (SIZE + GAP);
                for (int x = 0; x < WIDTH; x++)
                {
                    backgroundWorker1.ReportProgress(3, st);
                    System.Threading.Thread.Sleep(speed);
                }
                st.Type = MoveType.EXCHANGED;
                backgroundWorker1.ReportProgress(3, st);
            }
            else if (type == 2)
            {
                st.Type = MoveType.RIGHT_TO_LEFT;
                WIDTH = Math.Abs(pos1 - pos2) * (SIZE + GAP);
                for (int x = 0; x < WIDTH; x++)
                {
                    backgroundWorker1.ReportProgress(3, st);
                    System.Threading.Thread.Sleep(speed);
                }

                st.Type = MoveType.TOP_TO_LINE;
                for (int x = 0; x < HEIGHT; x++)
                {
                    backgroundWorker1.ReportProgress(3, st);
                    System.Threading.Thread.Sleep(speed);
                }

                st.Type = MoveType.DONE;
                backgroundWorker1.ReportProgress(3, st);
            }
        }

        private void DebugCode(int v)
        {
            backgroundWorker1.ReportProgress(1, v);
            System.Threading.Thread.Sleep(speed * 20);
        }

        private void MoveIndex(Label lblIndex, int x, Point location, int type)
        {
            MoveIndex index = new MoveIndex(lblIndex, x, location, type);
            backgroundWorker1.ReportProgress(2, index);
            System.Threading.Thread.Sleep(speed * 30);
        }

        private void NapCodeLenListBox(int thuatToan, int tangGiam)
        {
            lsbCode.Items.Clear();
            if (tangGiam == 0)
                lsbCode.Items.Add("Sắp Tăng");
            else
                lsbCode.Items.Add("Sắp Giảm");
            if (thuatToan == 0)
            {
                lsbCode.Items.Add("void InterchangeSort(int M[], int N )");
                lsbCode.Items.Add("{");
                lsbCode.Items.Add("\tint i, j;");
                lsbCode.Items.Add("\tfor (i = 0 ; i<N-1 ; i++)");
                lsbCode.Items.Add("\t\tfor (j =i+1; j < N ; j++)");
                if (tangGiam == 1)
                {
                    lsbCode.Items.Add("\t\t\tif(M[j] > M[i])");
                }
                else
                {
                    lsbCode.Items.Add("\t\t\tif(M[j] < M[i])");
                }
                lsbCode.Items.Add("\t\t\t\tSwap(M[i], M[j]);");
                lsbCode.Items.Add("}");
            }
            else if (thuatToan == 1)
            {
                lsbCode.Items.Add("void SelectionSort(int M[], int N)");
                if (tangGiam == 0)
                {
                    lsbCode.Items.Add("{");
                    lsbCode.Items.Add("\tint min, i, j;");
                    lsbCode.Items.Add("\tfor(i = 0; i < N - 1; i++)");
                    lsbCode.Items.Add("\t{");
                    lsbCode.Items.Add("\t\tmin = i;");
                    lsbCode.Items.Add("\t\tfor(j = i + 1; j < N; j++)");
                    lsbCode.Items.Add("\t\t\tif(M[j] > M[min])");
                    lsbCode.Items.Add("\t\t\t\tmin = j;");
                    lsbCode.Items.Add("\t\tSwap(M[min], M[i]);");
                    lsbCode.Items.Add("\t}");
                    lsbCode.Items.Add("}");
                }
                else
                {
                    lsbCode.Items.Add("{");
                    lsbCode.Items.Add("\tint max, i, j;");
                    lsbCode.Items.Add("\tfor(i = 0; i < N - 1; i++)");
                    lsbCode.Items.Add("\t{");
                    lsbCode.Items.Add("\t\tmax = i;");
                    lsbCode.Items.Add("\t\tfor(j = i + 1; j < N; j++)");
                    lsbCode.Items.Add("\t\t\tif(M[j] < M[max])");
                    lsbCode.Items.Add("\t\t\t\tmax = j;");
                    lsbCode.Items.Add("\t\tSwap(M[max], M[i]);");
                    lsbCode.Items.Add("\t}");
                    lsbCode.Items.Add("}");
                }

            }
            else if (thuatToan == 2)
            {
                lsbCode.Items.Add("void BubbleSort(int M[],int n) ");
                lsbCode.Items.Add("{");
                lsbCode.Items.Add("\tint i, j;");
                lsbCode.Items.Add("\tfor (i = 0 ; i<n-1 ; i++)");
                lsbCode.Items.Add("\t\tfor (j =n-1; j >i ; j --) ");
                if (tangGiam == 1)
                {
                    lsbCode.Items.Add("\t\t\tif(M[j] > M[j-1])");
                }
                else
                {
                    lsbCode.Items.Add("\t\t\tif(M[j] < M[i-1])");
                }
                lsbCode.Items.Add("\t\t\t\tSwap(M[j], M[j-1]); ");
                lsbCode.Items.Add("}");
            }
            else if (thuatToan == 3)
            {
                lsbCode.Items.Add("void InsertionSort(int M[],int n)");
                lsbCode.Items.Add("{");
                lsbCode.Items.Add("\tint pos,key;");
                lsbCode.Items.Add("\tfor(int i=1;i<n;i++)");
                lsbCode.Items.Add("\t{");
                lsbCode.Items.Add("\t\tkey = M[i];");
                lsbCode.Items.Add("\t\tpos = i - 1;");
                if (tangGiam == 0)
                    lsbCode.Items.Add("\t\twhile((pos >= 0) && (M[pos] > key))");
                else
                    lsbCode.Items.Add("\t\twhile((pos >= 0) && (M[pos] < key))");
                lsbCode.Items.Add("\t\t{");
                lsbCode.Items.Add("\t\t\tM[pos + 1] = M[pos];");
                lsbCode.Items.Add("\t\t\tpos--; ");
                lsbCode.Items.Add("\t\t}");
                lsbCode.Items.Add("\t\tM[pos+1] = key; ");
                lsbCode.Items.Add("\t}");
                lsbCode.Items.Add("}");
            }
            else if (thuatToan == 4)
            {
                lsbCode.Items.Add("void QuickSort(int M[], int left, int right)");
                lsbCode.Items.Add("{");
                lsbCode.Items.Add("\tint i, j, x;");
                lsbCode.Items.Add("\tx = M[(left + right) / 2];");
                lsbCode.Items.Add("\ti = left, j = right;");
                if (tangGiam == 0)
                {
                    lsbCode.Items.Add("\twhile(i < j)");
                    lsbCode.Items.Add("\t{");
                    lsbCode.Items.Add("\t\twhile(M[i] < x) i++;");
                    lsbCode.Items.Add("\t\twhile(M[j] > x) j--;");
                    lsbCode.Items.Add("\t\tif(i <= j)");
                    lsbCode.Items.Add("\t\t{");
                    lsbCode.Items.Add("\t\t\tSwap(M[i], M[j]);");
                    lsbCode.Items.Add("\t\t\ti++; j--;");
                    lsbCode.Items.Add("\t\t}");
                    lsbCode.Items.Add("\t}");
                    lsbCode.Items.Add("\tif(left < j)");
                    lsbCode.Items.Add("\t\t QuickShort(a, left, j);");
                    lsbCode.Items.Add("\tif(i < right");
                    lsbCode.Items.Add("\t\tQuickSort(a, i, right);");
                    lsbCode.Items.Add("}");
                }
                else
                {
                    lsbCode.Items.Add("\twhile(i < j)");
                    lsbCode.Items.Add("\t{");
                    lsbCode.Items.Add("\t\twhile(M[i] > x) i++;");
                    lsbCode.Items.Add("\t\twhile(M[j] < x) j--;");
                    lsbCode.Items.Add("\t\tif(i <= j)");
                    lsbCode.Items.Add("\t\t{");
                    lsbCode.Items.Add("\t\t\tSwap(M[i], M[j]);");
                    lsbCode.Items.Add("\t\t\ti++; j--;");
                    lsbCode.Items.Add("\t\t}");
                    lsbCode.Items.Add("\t}");
                    lsbCode.Items.Add("\tif(left > j)");
                    lsbCode.Items.Add("\t\t QuickShort(a, left, j);");
                    lsbCode.Items.Add("\tif(i > right");
                    lsbCode.Items.Add("\t\tQuickSort(a, i, right);");
                    lsbCode.Items.Add("}");
                }
            }
            else if (thuatToan == 5)
            {
                lsbCode.Items.Add("void ShakerSort(int M[], int n)");
                lsbCode.Items.Add("{");
                lsbCode.Items.Add("\tint Left = 0, Right = n - 1, k = 0;");
                lsbCode.Items.Add("\twhile(Left < Right)");
                lsbCode.Items.Add("\t{");
                lsbCode.Items.Add("\t\tfor(int i = Left; i < Right; i++)");
                lsbCode.Items.Add("\t\t{");
                if (tangGiam == 1)
                {
                    lsbCode.Items.Add("\t\t\tif(M[i] < M[i+1])");
                }
                else
                {
                    lsbCode.Items.Add("\t\t\tif(M[i] > M[i+1])");
                }
                lsbCode.Items.Add("\t\t\t{");
                lsbCode.Items.Add("\t\t\t\tswap(M[i], M[i+1]);");
                lsbCode.Items.Add("\t\t\t\tk = i;");
                lsbCode.Items.Add("\t\t\t}");
                lsbCode.Items.Add("\t\t}");
                lsbCode.Items.Add("\t\tRight = k;");
                lsbCode.Items.Add("\t\tfor(int i = Right; i > Left; i--)");
                lsbCode.Items.Add("\t\t{");
                if (tangGiam == 1)
                {
                    lsbCode.Items.Add("\t\t\tif(M[i] > M[i-1])");
                }
                else
                {
                    lsbCode.Items.Add("\t\t\tif(M[i] < M[i-1])");
                }
                
                lsbCode.Items.Add("\t\t\t{");
                lsbCode.Items.Add("\t\t\t\tswap(M[i], M[i-1]);");
                lsbCode.Items.Add("\t\t\t\tk = i;");
                lsbCode.Items.Add("\t\t\t}");
                lsbCode.Items.Add("\t\t}");
                lsbCode.Items.Add("\t\tLeft = k;");
                lsbCode.Items.Add("\t}");
                lsbCode.Items.Add("}");
            }
        }

        #endregion

        #region Thuật Toán

        private void Swap(ref int a, ref int b) { int temp = a; a = b; b = temp; }

        void InterchangeSort(int[] M, bool giam, DoWorkEventArgs e)
        {
            int i, j;
            System.Threading.Thread.Sleep(speed);
            DebugCode(3);
            for (i = 0; i < M.Length - 1; i++)
            {
                Mc[i].BackColor = Color.LightGreen;
                System.Threading.Thread.Sleep(speed);
                DebugCode(4);
                MoveIndex(lblIndexI, i, Mc[i].Location, 1);
                for (j = i + 1; j < M.Length; j++)
                {
                    Mc[j].BackColor = Color.Yellow;
                    busy.WaitOne();
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    System.Threading.Thread.Sleep(speed);
                    DebugCode(5);
                    MoveIndex(lblIndexJ, j, Mc[j].Location, 2);
                    if (giam == true)
                    {
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(6);
                        if (M[j] > M[i])
                        {
                            Swap(ref M[i], ref M[j]);
                            System.Threading.Thread.Sleep(speed);
                            MoveButton(j, i, 7);
                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(6);
                        if (M[j] < M[i])
                        {
                            Swap(ref M[i], ref M[j]);
                            System.Threading.Thread.Sleep(speed);
                            MoveButton(j, i, 7);
                        }
                    }
                    Mc[j].BackColor = Color.White;
                }
                Mc[i].BackColor = Color.Red;
            }
            System.Threading.Thread.Sleep(speed);
            DebugCode(1);
        }

        private void SelectionSort(int[] M, bool giam, DoWorkEventArgs e)
        {
            int temp, i, j;
            System.Threading.Thread.Sleep(speed);
            DebugCode(3);
            for (i = 0; i < M.Length - 1; i++)
            {
                Mc[i].BackColor = Color.LightGreen;
                System.Threading.Thread.Sleep(speed);
                DebugCode(4);
                MoveIndex(lblIndexI, i, Mc[i].Location, 1);

                temp = i;
                System.Threading.Thread.Sleep(speed);
                DebugCode(6);
                MoveIndex(lblTemp, temp, Mc[temp].Location, 3);

                for (j = i + 1; j < M.Length; j++)
                {
                    Mc[j].BackColor = Color.Yellow;
                    busy.WaitOne();
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                    System.Threading.Thread.Sleep(speed);
                    DebugCode(7);
                    MoveIndex(lblIndexJ, j, Mc[j].Location, 2);

                    if (giam == true)
                    {
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(8);
                        if (M[j] > M[temp])
                        {
                            temp = j;
                            System.Threading.Thread.Sleep(speed);
                            DebugCode(9);
                            MoveIndex(lblTemp, temp, Mc[temp].Location, 3);
                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(8);
                        if (M[j] < M[temp])
                        {
                            temp = j;
                            System.Threading.Thread.Sleep(speed);
                            DebugCode(9);
                            MoveIndex(lblTemp, temp, Mc[temp].Location, 3);
                        }
                    }
                    Mc[j].BackColor = Color.White;
                }
                System.Threading.Thread.Sleep(speed);
                DebugCode(10);
                Mc[temp].BackColor = Color.Pink;
                if (temp != i)
                {
                    Swap(ref M[temp], ref M[i]);
                    System.Threading.Thread.Sleep(speed);
                    MoveButton(temp, i, 10);
                }
                Mc[temp].BackColor = Color.White;
                Mc[i].BackColor = Color.Red;
            }
            System.Threading.Thread.Sleep(speed);
            DebugCode(1);
        }

        private void BubbleSort(int[] M, bool giam, DoWorkEventArgs e)
        {
            int i, j;
            System.Threading.Thread.Sleep(speed);
            DebugCode(3);
            for (i = 0; i < M.Length - 1; i++)
            {
                System.Threading.Thread.Sleep(speed);
                DebugCode(4);
                MoveIndex(lblIndexI, i, Mc[i].Location, 1);
                for (j = M.Length - 1; j > i; j--)
                {
                    busy.WaitOne();
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    System.Threading.Thread.Sleep(speed);
                    DebugCode(5);
                    MoveIndex(lblIndexJ, j, Mc[j].Location, 2);
                    Mc[j].BackColor = Color.Yellow;
                    Mc[j - 1].BackColor = Color.Yellow;
                   
                    if (giam)
                    {
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(6);
                        MoveIndex(lblTemp, j - 1, Mc[j - 1].Location, 3);
                        if (M[j] > M[j - 1])
                        {
                            Swap(ref M[j], ref M[j - 1]);
                            System.Threading.Thread.Sleep(speed);
                            MoveButton(j, j - 1, 7);
                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(6);
                        MoveIndex(lblTemp, j - 1, Mc[j - 1].Location, 3);
                        if (M[j] < M[j - 1])
                        {
                            Swap(ref M[j], ref M[j - 1]);
                            System.Threading.Thread.Sleep(speed);
                            MoveButton(j, j - 1, 7);
                        }
                    }
                    Mc[j].BackColor = Color.White;
                    Mc[j - 1].BackColor = Color.White;
                }
                Mc[i].BackColor = Color.Red;
            }
            System.Threading.Thread.Sleep(speed);
            DebugCode(1);
        }

        private void InsertionSort(int[] M, bool giam, DoWorkEventArgs e)
        {
            int pos, key;
            System.Threading.Thread.Sleep(speed);
            DebugCode(3);
            for (int i = 1; i < M.Length; i++)
            {
                busy.WaitOne();
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                System.Threading.Thread.Sleep(speed);
                DebugCode(4);
                MoveIndex(lblTemp, i, Mc[i].Location, 4);

                key = M[i];
                System.Threading.Thread.Sleep(speed);
                DebugCode(6);
                MoveButton_2(i, 0, 0, 6);
                

                pos = i - 1;
                System.Threading.Thread.Sleep(speed);
                DebugCode(7);
                MoveIndex(lblIndexJ, pos, Mc[pos].Location, 2);

                if (giam)
                {
                    while ((pos >= 0) && (M[pos] < key))
                    {
                        busy.WaitOne();
                        if (backgroundWorker1.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        System.Threading.Thread.Sleep(speed);
                        DebugCode(8);
                        MoveIndex(lblIndexJ, pos, Mc[pos].Location, 2);

                        M[pos + 1] = M[pos];
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(10);
                        MoveButton_2(pos, pos + 1, 1, 10);

                        pos--;
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(11);
                    }
                }
                else
                {
                    while ((pos >= 0) && (M[pos] > key))
                    {
                        busy.WaitOne();
                        if (backgroundWorker1.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        System.Threading.Thread.Sleep(speed);
                        DebugCode(8);
                        MoveIndex(lblIndexJ, pos, Mc[pos].Location, 2);

                        M[pos + 1] = M[pos];
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(10);
                        MoveButton_2(pos, pos + 1, 1, 10);

                        pos--;
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(11);
                    }
                }

                M[pos + 1] = key;
                System.Threading.Thread.Sleep(speed);
                DebugCode(13);
                MoveButton_2(i, pos + 1, 2, 13);
            }
        }

        private void QuickSort(int[] M, int left, int right, bool giam, DoWorkEventArgs e)
        {
            int i, j, x;
            System.Threading.Thread.Sleep(speed);
            DebugCode(3);
            x = M[(left + right) / 2];
            Mc[(left + right) / 2].BackColor = Color.Red;
            System.Threading.Thread.Sleep(speed);
            DebugCode(4);
            MoveIndex(lblTemp, (left + right) / 2, Mc[(left + right) / 2].Location, 3);
            i = left; j = right;
            System.Threading.Thread.Sleep(speed);
            DebugCode(5);
            MoveIndex(lblIndexI, i, Mc[i].Location, 1);
            MoveIndex(lblIndexJ, j, Mc[j].Location, 2);
            Mc[i].BackColor = Color.Yellow;
            Mc[j].BackColor = Color.Yellow;
            if (giam)
            {
                while (i < j)
                {
                    System.Threading.Thread.Sleep(speed);
                    DebugCode(6);
                    while (M[i] > x)
                    {
                        System.Threading.Thread.Sleep(speed * 20);
                        Mc[i].BackColor = Color.White;
                        i++;
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(8);
                        MoveIndex(lblIndexI, i, Mc[i].Location, 1);
                        Mc[i].BackColor = Color.Yellow;
                    }
                    while (M[j] < x)
                    {
                        System.Threading.Thread.Sleep(speed * 20);
                        Mc[j].BackColor = Color.White;
                        j--;
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(9);
                        MoveIndex(lblIndexJ, j, Mc[j].Location, 2);
                        Mc[j].BackColor = Color.Yellow;
                    }
                    if (i <= j)
                    {
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(10);
                        Swap(ref M[i], ref M[j]);
                        System.Threading.Thread.Sleep(speed);
                        MoveButton(j, i, 12);
                        Mc[i].BackColor = Color.White;
                        Mc[j].BackColor = Color.White;
                        i++; j--;
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(13);
                        if (j >= 0)
                        {
                            MoveIndex(lblIndexJ, j, Mc[j].Location, 2);
                        }
                        if (i < M.Length)
                        {
                            MoveIndex(lblIndexI, i, Mc[i].Location, 1);
                        }
                    }
                }
            }
            else
            {
                while (i < j)
                {
                    System.Threading.Thread.Sleep(speed);
                    DebugCode(6);
                    while (M[i] < x)
                    {
                        System.Threading.Thread.Sleep(speed * 20);
                        Mc[i].BackColor = Color.White;
                        i++;
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(8);
                        MoveIndex(lblIndexI, i, Mc[i].Location, 1);
                        Mc[i].BackColor = Color.Yellow;
                    }
                    while (M[j] > x)
                    {
                        System.Threading.Thread.Sleep(speed * 20);
                        Mc[j].BackColor = Color.White;
                        j--;
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(9);
                        MoveIndex(lblIndexJ, j, Mc[j].Location, 2);
                        Mc[j].BackColor = Color.Yellow;
                    }
                    if (i <= j)
                    {
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(10);
                        Swap(ref M[i], ref M[j]);
                        System.Threading.Thread.Sleep(speed);
                        MoveButton(j, i, 12);
                        Mc[i].BackColor = Color.White;
                        Mc[j].BackColor = Color.White;
                        i++; j--;
                        System.Threading.Thread.Sleep(speed);
                        DebugCode(13);
                        if (j >= 0)
                        {
                            MoveIndex(lblIndexJ, j, Mc[j].Location, 2);
                        }
                        if (i < M.Length)
                        {
                            MoveIndex(lblIndexI, i, Mc[i].Location, 1);
                        }
                    }
                }
            }
            if (left < j)
            {
                System.Threading.Thread.Sleep(speed);
                DebugCode(16);
                QuickSort(M, left, j, giam, e);
            }
            if (i < right)
            {
                System.Threading.Thread.Sleep(speed);
                DebugCode(18);
                QuickSort(M, i, right, giam, e);
            }
        }

        private void ShakerSort(int[] M, bool giam, DoWorkEventArgs e)
        {
            int Left = 0, Right = M.Length - 1, k = 0;
            System.Threading.Thread.Sleep(speed);
            DebugCode(3);
            while (Left < Right)
            {
                System.Threading.Thread.Sleep(speed);
                DebugCode(4);
                for (int i = Right; i > Left; i--)
                {
                    lblTemp_Text = "i-1=";
                    busy.WaitOne();
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    System.Threading.Thread.Sleep(speed);
                    DebugCode(6);
                    
                    Mc[i].BackColor = Color.Yellow;
                    Mc[i - 1].BackColor = Color.Yellow;

                    MoveIndex(lblIndexI, i, Mc[i].Location, 1);
                    MoveIndex(lblTemp, i - 1, Mc[i - 1].Location, 3);

                    if (giam)
                    {
                        if (M[i] > M[i - 1])
                        {
                            System.Threading.Thread.Sleep(speed);
                            DebugCode(8);

                            Swap(ref M[i], ref M[i - 1]);
                            MoveButton(i, i - 1, 10);

                            k = i;
                            System.Threading.Thread.Sleep(speed);
                            DebugCode(11);
                        }
                    }
                    else
                    {
                        if (M[i] < M[i - 1])
                        {
                            System.Threading.Thread.Sleep(speed);
                            DebugCode(8);

                            Swap(ref M[i], ref M[i - 1]);
                            MoveButton(i, i - 1, 10);

                            k = i;
                            System.Threading.Thread.Sleep(speed);
                            DebugCode(11);
                        }
                    }
                    Mc[i].BackColor = Color.White;
                    Mc[i - 1].BackColor = Color.White;
                }

                Mc[k - 1].BackColor = Color.Red;

                Left = k;
                System.Threading.Thread.Sleep(speed);
                DebugCode(14);

                for (int i = Left; i < Right; i++)
                {
                    lblTemp_Text = "i+1=";
                    busy.WaitOne();
                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    System.Threading.Thread.Sleep(speed);
                    DebugCode(15);

                    Mc[i].BackColor = Color.Pink;
                    Mc[i + 1].BackColor = Color.Pink;

                    MoveIndex(lblIndexI, i, Mc[i].Location, 1);
                    MoveIndex(lblTemp, i + 1, Mc[i + 1].Location, 3);

                    if (giam)
                    {
                        if (M[i] < M[i + 1])
                        {
                            System.Threading.Thread.Sleep(speed);
                            DebugCode(17);

                            Swap(ref M[i], ref M[i + 1]);
                            MoveButton(i + 1, i, 19);

                            k = i;
                            System.Threading.Thread.Sleep(speed);
                            DebugCode(20);
                        }
                    }
                    else
                    {
                        if (M[i] > M[i + 1])
                        {
                            System.Threading.Thread.Sleep(speed);
                            DebugCode(17);

                            Swap(ref M[i], ref M[i + 1]);
                            MoveButton(i + 1, i, 19);

                            k = i;
                            System.Threading.Thread.Sleep(speed);
                            DebugCode(20);
                        }
                    }
                    Mc[i].BackColor = Color.White;
                    Mc[i + 1].BackColor = Color.White;
                }

                Mc[k + 1].BackColor = Color.Red;

                Right = k;
                System.Threading.Thread.Sleep(speed);
                DebugCode(23);
            }
            System.Threading.Thread.Sleep(speed);
            DebugCode(1);
        }
        #endregion

        #region backgournworker

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool Giam = false;//kiểm tra thuật toán đó thực hiện tăng hay giảm

            if ((int)radTangGiam.EditValue == 0) Giam = false;
            else if((int)radTangGiam.EditValue == 1) Giam = true;

            if ((int)radThuatToan.EditValue == 0)
                InterchangeSort(M, Giam, e);
            else if ((int)radThuatToan.EditValue == 1)
                SelectionSort(M, Giam, e);
            else if ((int)radThuatToan.EditValue == 2)
                BubbleSort(M, Giam, e);
            else if ((int)radThuatToan.EditValue == 3)
                InsertionSort(M, Giam, e);
            else if ((int)radThuatToan.EditValue == 4)
                QuickSort(M, 0, M.Length - 1, Giam, e);
            else if ((int)radThuatToan.EditValue == 5)
                ShakerSort(M, Giam, e);
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
            {
                int i = int.Parse(e.UserState.ToString());
                lsbCode.SelectedIndex = i;
            }
            else if(e.ProgressPercentage == 2)
            {
                MoveIndex moveIndex = e.UserState as MoveIndex;

                if (moveIndex.Type == 1)
                {
                    moveIndex.lbl.Text = lblIndexI_Text + moveIndex.Index;
                    moveIndex.lbl.Location = new Point(moveIndex.Location.X + SIZE / 2 - 10, moveIndex.Location.Y + HEIGHT + (int)(SIZE * 1.5));
                }
                else if(moveIndex.Type == 2)
                {
                    moveIndex.lbl.Text = lblIndexJ_Text + moveIndex.Index;
                    moveIndex.lbl.Location = new Point(moveIndex.Location.X + SIZE / 2 - 10, moveIndex.Location.Y - HEIGHT - SIZE);
                }
                else if(moveIndex.Type == 3)
                {
                    moveIndex.lbl.Text = lblTemp_Text + moveIndex.Index;
                    moveIndex.lbl.Location = new Point(moveIndex.Location.X + 10, moveIndex.Location.Y + HEIGHT + SIZE);
                }
                else if(moveIndex.Type==4)
                {
                    moveIndex.lbl.Text = lblTemp_Text;
                    moveIndex.lbl.Location = new Point(moveIndex.Location.X + 10, moveIndex.Location.Y + HEIGHT + (int)(SIZE * 1.5));
                }
            }
            else
            {
                Status st = e.UserState as Status;
                if (st == null) return;
                if (st.Type == MoveType.CHANGED)
                {
                    Color colortmp = Mc[st.pos1].BackColor;
                    Button btnTmp = Mc[st.pos2];
                    Mc[st.pos2] = Mc[st.pos1];
                    Mc[st.pos2].BackColor = btnTmp.BackColor;
                    Mc[st.pos1] = btnTmp;
                    Mc[st.pos1].BackColor = colortmp;
                    return;
                }
                else if (st.Type == MoveType.DONE)
                {
                    for(int i =0;i<Mc.Length;i++)
                    {
                        pnButton.Controls.Remove(Mc[i]);
                    }

                    int n = (int)nmSoPhanTu.Value;
                    int Edge = (pnButton.Width - (n * (SIZE + GAP))) / 2;

                    for (int i = 0; i < M.Length; i++)
                    {
                        Button btn = new Button();
                        int value = rd.Next(100);
                        btn.Enabled = false;
                        btn.Text = M[i] + "";
                        btn.BackColor = Color.White;
                        btn.Width = btn.Height = SIZE;
                        btn.Location = new Point(i * (btn.Width + GAP) + Edge,
                                                 pnButton.Height / 2 - SIZE / 2);
                        btn.Tag = i;
                        pnButton.Controls.Add(btn);

                        Mc[i] = btn;
                        btn.Tag = M[i];
                    }

                    return;
                }
                else if (st.Type == MoveType.EXCHANGED)
                {
                    return;
                }
                Button btn1 = Mc[st.pos1];
                Button btn2 = Mc[st.pos2];
                if (st.Type == MoveType.LINE_TO_TOP_AND_LINE_TO_BOTTOM)
                {
                    btn1.Top = btn1.Top + 1;
                    btn2.Top = btn2.Top - 1;
                }
                else if (st.Type == MoveType.LEFT_TO_RIGHT_AND_RIGHT_TO_LEFT)
                {
                    btn1.Left = btn1.Left - 1;
                    btn2.Left = btn2.Left + 1;
                }
                else if (st.Type == MoveType.TOP_TO_LINE_AND_BOTTOM_TO_LINE)
                {
                    btn1.Top = btn1.Top - 1;
                    btn2.Top = btn2.Top + 1;
                }
                else if (st.Type == MoveType.LINE_TO_TOP)
                {
                    btn1.Top = btn1.Top + 1;
                }

                else if (st.Type == MoveType.LEFT_TO_RIGHT)
                {
                    btn1.Left = btn1.Left + 1;
                }
                else if (st.Type == MoveType.RIGHT_TO_LEFT)
                {
                    btn1.Left = btn1.Left - 1;
                }
                else if (st.Type == MoveType.TOP_TO_LINE)
                {
                    btn1.Top = btn1.Top - 1;
                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (Button btn in Mc)
            {
                btn.BackColor = Color.Red;
                btn.ForeColor = Color.White;
            }

            pnButton.Controls.Remove(lblIndexI);
            pnButton.Controls.Remove(lblIndexJ);
            
            //if(radThuatToan.SelectedIndex == 1 || radThuatToan.SelectedIndex == 2)
                pnButton.Controls.Remove(lblTemp);

            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnStart.Focus();
            grpDuLieu.Enabled = true;
            grpThuatToan.Enabled = true;
            grpHuongSapXep.Enabled = true;
            if (e.Cancelled == true) return;
            MessageBox.Show("Đã sắp xếp xong mảng!");
        }

        #endregion
    }
}
