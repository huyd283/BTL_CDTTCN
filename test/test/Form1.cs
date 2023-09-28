using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class btnNhap : Form
    {
        private Random random;
        Stopwatch stopwatch = new Stopwatch();
        public btnNhap()
        {
            InitializeComponent();
            random = new Random();

        }
        int n = 0, i, tam;
        private List<int> randomArray;
        public static int[] a;
        private int kich_Thuoc;
        private int co_Chu;
        private int khoang_Cach;
        private int le_Node;
        private Button[] node1;
        private Label[] chiSo;
        private int size;
        private int min;
        private int max;
        int toc_Do = 4;
        Boolean da_Tao_Mang = false;

        private void btnXoa_Click(object sender, EventArgs e)
        {
            tbSoPT.ResetText();
            tbMang.Clear();
            tbSoCuoi.ResetText();
            tbSoDau.ResetText();
            tbKetQua.ResetText();
            msg.ResetText();
            n = 0;
        }
        private void btnNhapMang_Click(object sender, EventArgs e)
        {
            /*int size = int.Parse(tbSoPT.Text);
            int min = int.Parse(tbSoDau.Text);
            int max = int.Parse(tbSoCuoi.Text);
            randomArray = new List<int>();
            // Tạo mảng ngẫu nhiên
            for (int i = 0; i < size; i++)
            {
                randomArray.Add(random.Next(min, max));
            }
            // Hiển thị mảng ngẫu nhiên
            tbMang.Text = string.Join(" ", randomArray);*/
            if(!string.IsNullOrEmpty(tbSoPT.Text) && !string.IsNullOrEmpty(tbSoDau.Text) && !string.IsNullOrEmpty(tbSoCuoi.Text))
            {
                size = int.Parse(tbSoPT.Text);
                min = int.Parse(tbSoDau.Text);
                max = int.Parse(tbSoCuoi.Text);
                a = new int[size];
                tao_Mang(100, Properties.Resources.img_simple);
                for (int i = 0; i < size; i++)
                {
                    a[i] = random.Next(min,max);
                    node1[i].Text = a[i].ToString();
                }
            }
             else
             if (string.IsNullOrEmpty(tbSoPT.Text))
                 MessageBox.Show("Bạn cần nhập kích thước", "Lỗi", MessageBoxButtons.OK);
             else if (string.IsNullOrEmpty(tbSoDau.Text))
                 MessageBox.Show("Bạn cần nhập số đầu", "Lỗi", MessageBoxButtons.OK);
             else
                 MessageBox.Show("Bạn cần nhập số cuối", "Lỗi", MessageBoxButtons.OK);
        }
        private void tao_Mang(int kc, System.Drawing.Image img_nen)
        {
            kich_Thuoc = 40;
            co_Chu = 10;
            khoang_Cach = 10;
            le_Node = (770 - kich_Thuoc * size - khoang_Cach * (size - 1)) / 2;
            

            // KHởi tạo mảng node
            node1 = new Button[size];
            chiSo = new Label[size];
            lbIndex.Visible = true;
            lbMang.Visible = true;
            for (int i = 0; i < size; i++)
            {
                node1[i] = new Button();
                node1[i].Text = a[i].ToString();
                node1[i].TextAlign = ContentAlignment.MiddleCenter;
                node1[i].Width = kich_Thuoc;
                node1[i].Height = kich_Thuoc;
                node1[i].Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * i, 370);
                node1[i].ForeColor = Color.Black;
                node1[i].Font = new Font(this.Font, FontStyle.Bold);
                node1[i].Font = new System.Drawing.Font("Arial", co_Chu, FontStyle.Bold);
                node1[i].FlatStyle = FlatStyle.Flat;
                node1[i].BackgroundImage = img_nen;
                node1[i].BackgroundImageLayout = ImageLayout.Stretch;
                node1[i].FlatAppearance.BorderSize = 0;
                this.Controls.Add(node1[i]);

                // Tạo nhãn chỉ sổ
                chiSo[i] = new Label();
                chiSo[i].TextAlign = ContentAlignment.MiddleCenter;
                chiSo[i].Text = i.ToString();
                chiSo[i].Width = kich_Thuoc;
                chiSo[i].Height = kich_Thuoc;
                chiSo[i].ForeColor = Color.Black;

                chiSo[i].Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * i, 390 + khoang_Cach * 3);
                chiSo[i].Font = new System.Drawing.Font("Arial", co_Chu - 4, FontStyle.Bold);
                this.Controls.Add(chiSo[i]);
            }
            da_Tao_Mang = true; //Xác nhận đã tạo mảng                                        
            btnNhapMang.Enabled = true;//Cho phép các nút điều khiển có tác dụng khi đã tạo mảng
            docFile.Enabled = true;

            rbChon.Enabled = true;
            rbChen.Enabled = true;
            rbNoiBot.Enabled = true;

            btnTang.Enabled = true;
            btnGiam.Enabled = true;
        }
        private void luuFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Đặt các thuộc tính cho SaveFileDialog
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save a Text File";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Hiển thị SaveFileDialog và kiểm tra kết quả trả về
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                string content = tbKetQua.Text;

                // Lưu nội dung vào tập tin đã chọn
                System.IO.File.WriteAllText(filePath, content);

                MessageBox.Show("Lưu thành công!");
            }
        }

        private void docFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Đặt các thuộc tính cho OpenFileDialog
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Open a Text File";
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Hiển thị OpenFileDialog và kiểm tra kết quả trả về
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Đọc toàn bộ nội dung từ tập tin đã chọn
                string content = System.IO.File.ReadAllText(filePath);
                string input = null;
                a = new int[size];
                tao_Mang(100, Properties.Resources.img_simple);
                while (content != null && i < size)
                {
                    a[i] = Convert.ToInt32(input);
                    node1[i].Text = a[i].ToString();
                    i++;
                }

                // Hiển thị nội dung trong TextBox
                tbMang.Text = content;

                MessageBox.Show("File opened successfully!");
            }
        }

        #region CÁC HÀM DI CHUYỂN
        // Hàm node đi lên
        public void go_up(Control node, int vitri)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                for (int j = 0; j < 100; j++)
                {
                    node.Top -= 1;  // Giảm trục Y của node, làm cho node đi lên trên
                    wait_time(2 * toc_Do);   // Chờ 5 mili giây rồi tiếp tục thực hiện
                }
                node.Refresh();
            });
        }

        // Hàm node đi xuống
        public void go_down(Control node, int vitri)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                //for(int j =0; i<5; )
                //node.Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * vitri, 100);
                for (int j = 0; j < 100; j++)
                {
                    node.Top += 1;  // Giảm trục Y của node, làm cho node đi lên trên
                    wait_time(2 * toc_Do);
                }
                node.Refresh();
            });
        }

        // Hàm node qua trái
        public void to_left(Control node, int vt_cu, int vt_moi) // Tên node, vị trí cũ, vị trí mới
        {
            int s = 2 * (vt_cu - vt_moi) * (kich_Thuoc + khoang_Cach); // độ dài đường đi
            for (int i = 0; i < s; i++)
            {
                node.Left -= 1;
                i++;
                wait_time(toc_Do * (500 / s));
            }
        }

        public void to_right(Control node, int vt_cu, int vt_moi)
        {
            int s = 2 * (vt_moi - vt_cu) * (kich_Thuoc + khoang_Cach); // độ dài đường đi
            for (int i = 0; i < s; i++)
            {
                node.Left += 1;
                i++;
                wait_time(toc_Do * (500 / s));
            }
        }
        #endregion
        // Hàm set màu node
        public void set_node_color(Control t, System.Drawing.Image img_nen)
        {
            t.BackgroundImage = img_nen;
            t.BackgroundImageLayout = ImageLayout.Stretch;
            t.Refresh();
        }

        // Hàm đổi giá trị phần tử mảng
        public void swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        // Hàm trễ một khoảng thời gian mili secondS
        public void wait_time(int milisecond)
        {
            Application.DoEvents();
            Thread.Sleep(milisecond);

        }

        // Hàm đổi giá trị của hai node
        public void swap_button(int t1, int t2)
        {

            Button Temp = node1[t1];
            node1[t1] = node1[t2];
            node1[t2] = Temp;
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {
            stopwatch.Restart();
            stopwatch.Start();
            n = randomArray.Count;
            if (randomArray == null || randomArray.Count == 0)
            {
                MessageBox.Show("Vui lòng tạo mảng trước khi sắp xếp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rbNoiBot.Checked)
            {
                for (i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (randomArray[j] < randomArray[j + 1])
                        {
                            int temp = randomArray[j];
                            randomArray[j] = randomArray[j + 1];
                            randomArray[j + 1] = temp;
                        }
                    }
                    // Hiển thị mảng đã sắp xếp
                    tbKetQua.Text = string.Join(" ", randomArray);
                    stopwatch.Stop();
                    msg.Text = "Thời gian thực hiện:  " + stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                }
            }
            else
            if (rbChon.Checked)
            {
                for (i = 0; i < n - 1; i++)
                {
                    int minIndex = i;
                    // Tìm phần tử nhỏ nhất trong mảng chưa sắp xếp
                    for (int j = i + 1; j < n; j++)
                    {
                        if (randomArray[j] > randomArray[minIndex])
                        {
                            minIndex = j;
                        }
                    }
                    if (i != minIndex)
                    {
                        int temp = randomArray[i];
                        randomArray[i] = randomArray[minIndex];
                        randomArray[minIndex] = temp;
                    }
                    tbKetQua.Text = string.Join(" ", randomArray);
                    stopwatch.Stop();
                    msg.Text = "Thời gian thực hiện:  " + stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                }
            }
            else 
            if (rbChen.Checked)
            {
                for (i = 1; i < n; i++)
                {
                    int key = randomArray[i];
                    int j = i - 1;
                    while (j >= 0 && randomArray[j] < key)
                    {
                        randomArray[j + 1] = randomArray[j];
                        j--;
                    }
                    randomArray[j + 1] = key;
                }
                    tbKetQua.Text = string.Join(" ", randomArray);
                    stopwatch.Stop();
                    msg.Text = "Thời gian thực hiện:  " + stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                }
            }

        private void btnTang_Click(object sender, EventArgs e)
        {
            stopwatch.Restart();
            stopwatch.Start();
            /*if (randomArray == null || randomArray.Count == 0)
            {
                MessageBox.Show("Vui lòng tạo mảng trước khi sắp xếp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            //int n = randomArray.Count;
            if (rbNoiBot.Checked)
            {
                for (i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (randomArray[j] > randomArray[j + 1])
                        {
                            int temp = randomArray[j];
                            randomArray[j] = randomArray[j + 1];
                            randomArray[j + 1] = temp;
                        }
                    }
                    // Hiển thị mảng đã sắp xếp
                    tbKetQua.Text = string.Join(" ", randomArray);
                    stopwatch.Stop();
                    msg.Text = "Thời gian thực hiện:  " + stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                }
            }
            else if (rbChon.Checked)
            {
                tbKetQua.ResetText();
                for (i = 0; i < n - 1; i++)
                {
                    int minIndex = i;
                    // Tìm phần tử nhỏ nhất trong mảng chưa sắp xếp
                    for (int j = i + 1; j < n; j++)
                    {
                        if (randomArray[j] < randomArray[minIndex])
                        {
                            minIndex = j;
                        }
                    }
                    if (i != minIndex)
                    {
                        int temp = randomArray[i];
                        randomArray[i] = randomArray[minIndex];
                        randomArray[minIndex] = temp;
                    }
                    tbKetQua.Text = string.Join(" ", randomArray);
                    stopwatch.Stop();
                    msg.Text = "Thời gian thực hiện:  " + stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                }
            }
            else if (rbChen.Checked)
            {
                int x, j;
                n = int.Parse(tbSoPT.Text);
                set_node_color(node1[0], Properties.Resources.img_done);
                for (int i = 1; i < n; i++)
                {
                    x = a[i];
                    wait_time(100 * toc_Do);

                    Button node_tam = node1[i];
                    set_node_color(node_tam, Properties.Resources.img_pivot);
                    if (x < a[i - 1] && i > 0)
                        go_up(node_tam, i);

                    j = i;
                    wait_time(toc_Do * 100);

                    while (j > 0 && x < a[j - 1])
                    {
                        a[j] = a[j - 1];
                        to_right(node1[j - 1], j - 1, j);
                        swap_button(j - 1, j);
                        wait_time(toc_Do * 100);

                        j--;
                        wait_time(100 * toc_Do);
                    }
                    if (j != i)
                    {
                        a[j] = x;
                        to_left(node_tam, i, j);
                        go_down(node_tam, j);
                        node1[j] = node_tam;
                        wait_time(100 * toc_Do);
                    }
                    else
                        wait_time(100 * toc_Do);
                    set_node_color(node1[j], Properties.Resources.img_done);
                }
                MessageBox.Show("Đã sắp xếp xong.");
                stopwatch.Stop();
                msg.Text = "Thời gian thực hiện:  " + stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
            }
            /*else if (rbChen.Checked)
            {
                for (i = 1; i < n; i++)
                {
                    int key = randomArray[i];
                    int j = i - 1;
                    while (j >= 0 && randomArray[j] > key)
                    {
                        randomArray[j + 1] = randomArray[j];
                        j--;
                    }
                    randomArray[j + 1] = key;
                }
                tbKetQua.Text = string.Join(" ", randomArray);
                stopwatch.Stop();
                msg.Text = "Thời gian thực hiện:  " + stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
            }*/
        }
    }
}






/*private void btnXoa_Click(object sender, EventArgs e)
        {
            KhungNhap.ResetText();
            KhungXuat.Clear();
            KhungXuat.ResetText();
            n = 0;
            s = " ";
        }

        private void btnNhapMang_Click(object sender, EventArgs e)
        {
            s = KhungNhap.Text;
            i = s.LastIndexOf(" ");
            while (i != -1)
            {
                s1 = s.Substring(i);
                s = s.Substring(0, i);
                a[n] = Convert.ToInt32(s1);
                n++;
                i = s.LastIndexOf(" ");
            }
            a[n] = Convert.ToInt32(s);
            s = " ";
            for (i = n; i >= 0; i--)
                s = s + " " + a[i].ToString();
            KhungXuat.Text = s.Trim();
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {
            for (i = 0; i < n; i++)
                for (int j = i + 1; j <= n; j++)
                    if (a[i] < a[j])
                    {
                        tam = a[i];
                        a[i] = a[j];
                        a[j] = tam;
                    }
            s = " ";
            for (i = 0; i <= n; i++)
                s = s + " " + a[i].ToString();
            KhungXuat.Text = s.Trim();
        }


        private void btnTang_Click(object sender, EventArgs e)
        {
            for (i = 0; i < n; i++)
                for (int j = i + 1; j <= n; j++)
                    if (a[i] > a[j])
                    {
                        tam = a[i];
                        a[i] = a[j];
                        a[j] = tam;
                    }
            s = " ";
            for (i = 0; i <= n; i++)
                s = s + " " + a[i].ToString();
            KhungXuat.Text = s.Trim();

        }
    }*/