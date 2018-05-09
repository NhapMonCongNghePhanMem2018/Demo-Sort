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
        }

        #region Các thuộc tính
        Random rd = new Random();//dùng để tạo giá trị ngẫu nhiên
        int[] M = null; //mảng để lưu các giá trị phần tử
        Button[] Mc = null; //mảng để lưu các button động
        int GAP = 50;//Khoảng cách giữa các button trên giao diện
        int HEIGHT = 100;//chiều cao khi button đổi chỗ cho nhau
        int WIDTH;//Lưu khoảng cách mà 2 button đổi chỗ cho nhau
        int SIZE = 50;//size của 1 button động được tạo ra
        int speed;//Lưu tốc độ thực hiện các thuật toán
        bool Giam = false;//kiểm tra thuật toán đó thực hiện tăng hay giảm
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
            pnButton.Enabled = false;
        }

        #region Xử lí Sự kiện Trên Giao Diện

        private void btnTaoMang_Click(object sender, EventArgs e)
        {
            PlaySound();
            int n = (int)nmSoPhanTu.Value;
            if (n <= 0 || n > 13)
            {
                MessageBox.Show("Số phần tử mảng bạn nhập không hợp lệ!");
                nmSoPhanTu.Focus();
                return;
            }
            int edge = (pnButton.Width - (n * (SIZE + GAP))) / 2;
            M = new int[n];
            Mc = new Button[n];
            pnButton.Controls.Clear();
            for (int i = 0; i < n; i++)
            {
                Button btn = new Button();
                btn.Text = 0 + "";
                btn.Width = btn.Height = SIZE;
                btn.Location = new Point(
                    pnButton.Controls.Count * (btn.Width + GAP) + edge,
                    pnButton.Height / 2 - SIZE / 2);
                btn.Tag = i;
                pnButton.Controls.Add(btn);

                M[i] = 0;
                Mc[i] = btn;
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
            if (M==null)
            {
                MessageBox.Show("Vui lòng tạo mảng trước để thực hiện chức năng này!");
                return;
            }
            for (int i = 0; i < M.Length; i++)
            {
                int value = rd.Next(100);
                M[i] = value;
                Mc[i].Text = value+"";
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
            PlaySound();
            if (backgroundWorker1.CancellationPending)
            {
                StartWorker();
                return;
            }
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

        private void MoveButton(int pos1, int pos2, int v)
        {
            Status st = new Status();
            st.pos1 = pos1;
            st.pos2 = pos2;
            st.Type = MoveType.LINE_TO_TOP_AND_LINE_TO_BOTTOM;
            DebugCode(v);
            for (int x = 0; x < HEIGHT; x++)
            {
                backgroundWorker1.ReportProgress(0, st);
                System.Threading.Thread.Sleep(speed);
            }

            st.Type = MoveType.LEFT_TO_RIGHT_AND_RIGHT_TO_LEFT;
            WIDTH = Math.Abs(pos1 - pos2) * (SIZE + GAP);
            for (int x = 0; x < WIDTH; x++)
            {
                backgroundWorker1.ReportProgress(0, st);
                System.Threading.Thread.Sleep(speed);
            }

            st.Type = MoveType.TOP_TO_LINE_AND_BOTTOM_TO_LINE;
            for (int x = 0; x < HEIGHT; x++)
            {
                backgroundWorker1.ReportProgress(0, st);
                System.Threading.Thread.Sleep(speed);
            }

            st.Type = MoveType.CHANGED;
            backgroundWorker1.ReportProgress(0, st);
        }

        private void DebugCode(int v)
        {
            backgroundWorker1.ReportProgress(0, v);
            System.Threading.Thread.Sleep(speed * 20);
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
                lsbCode.Items.Add("void InterchangeSort(int a[], int N )");
                lsbCode.Items.Add("{");
                lsbCode.Items.Add("\tint i, j;");
                lsbCode.Items.Add("\tfor (i = 0 ; i<N-1 ; i++)");
                lsbCode.Items.Add("\t\tfor (j =i+1; j < N ; j++)");
                if (tangGiam == 1)
                {
                    lsbCode.Items.Add("\t\t\tif(a[j ]> a[i])");
                }
                else
                {
                    lsbCode.Items.Add("\t\t\tif(a[j ]< a[i])");
                }
                lsbCode.Items.Add("\t\t\t\tSwap(a[i], a[j]);");
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
            }
            System.Threading.Thread.Sleep(speed);
            DebugCode(1);
        }


        private void SelectionSort(int[] M, bool giam)
        {
            int temp, i, j;
            for (i = 0; i < M.Length; i++)
            {
                temp = i;
                for (j = i + 1; j < M.Length; j++)
                    if (giam == true)
                    {
                        if (M[j] > M[temp])
                            temp = j;
                    }
                    else
                    {
                        if (M[j] < M[temp])
                            temp = j;
                    }
                if (temp != i)
                {
                    Swap(ref M[temp], ref M[i]);
                    System.Threading.Thread.Sleep(speed);
                    MoveButton(temp, i,6);
                }
            }
        }

        private void BubbleSort(int[] M, bool giam)
        {
            int i, j;
            for (i = 0; i < M.Length - 1; i++)
            {
                
                for (j = M.Length - 1; j > i; j--)
                {
                    if (Giam == true)
                    {
                        if (M[j] > M[j - 1])
                        {
                            Swap(ref M[j], ref M[j - 1]);
                            System.Threading.Thread.Sleep(speed);
                            MoveButton(j, j - 1,5);
                        }
                    }
                    else
                    {
                        if (M[j] < M[j - 1])
                        {
                            Swap(ref M[j], ref M[j - 1]);
                            System.Threading.Thread.Sleep(speed);
                            MoveButton(j, j - 1,5);
                        }
                    }
                }
            }
        }
        #endregion

        #region backgournworker

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((int)radTangGiam.EditValue == 0) Giam = false;
            else if((int)radTangGiam.EditValue == 1) Giam = true;
            if ((int)radThuatToan.EditValue == 0)
                InterchangeSort(M, Giam, e);
            else if ((int)radThuatToan.EditValue == 1)
                SelectionSort(M, Giam);
            else if ((int)radThuatToan.EditValue == 2)
                BubbleSort(M, Giam);
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int i;
            if (int.TryParse(e.UserState.ToString(), out i))
            {
                lsbCode.SelectedIndex = i;
            }
            else
            {
                Status st = e.UserState as Status;
                if (st == null) return;
                if (st.Type == MoveType.CHANGED)
                {
                    Mc[st.pos2].BackColor = Color.White;
                    Mc[st.pos1].BackColor = Color.LightGreen;
                    Button btnTmp = Mc[st.pos2];
                    Mc[st.pos2] = Mc[st.pos1];
                    Mc[st.pos1] = btnTmp;
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
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (Button btn in pnButton.Controls)
            {
                btn.BackColor = Color.Red;
                btn.ForeColor = Color.White;
            }
            btnStart.Enabled = true;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnStart.Focus();
            grpDuLieu.Enabled = true;
            grpThuatToan.Enabled = true;
            grpHuongSapXep.Enabled = true;
        }

        #endregion
    }
}
