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
    public partial class Mang : Form
    {
        private Random random;
        Stopwatch stopwatch = new Stopwatch();
        public Mang()
        {
            InitializeComponent();
            random = new Random();
        }
        int n = 0, i;
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
        Code code_C = new Code();

        private void btnXoa_Click(object sender, EventArgs e)
        {
            tbSoPT.ResetText();
            tbMang.Clear();
            tbSoCuoi.ResetText();
            tbSoDau.ResetText();
            tbKetQua.ResetText();
            msg.ResetText();
            lb_status1.ResetText();
            lb_status2.ResetText();
            lb_status3.ResetText();
            lb_i.ResetText();
            lb_j.ResetText();
            lb_Code.ResetText();
            n = a.Length;
            if (da_Tao_Mang)
            {
                Application.DoEvents();
                this.Invoke((MethodInvoker)delegate
                {
                    for (i = 0; i < n; i++)
                    {
                        this.Controls.Remove(node1[i]);
                        this.Controls.Remove(chiSo[i]);

                    }
                });
            }
            da_Tao_Mang = false;
            btnTang.Enabled = false;
            btnGiam.Enabled = false;
            rbChen.Checked = false;
            rbChon.Checked = false;
            rbNoiBot.Checked = false;
        }

        private void ngănXếpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 nx = new Form2();
            nx.ShowDialog();
        }

        private void btnNhapMang_Click(object sender, EventArgs e)
        {
            tbMang.ResetText();

            if (!string.IsNullOrEmpty(tbSoPT.Text) && !string.IsNullOrEmpty(tbSoDau.Text) && !string.IsNullOrEmpty(tbSoCuoi.Text))
            {
                size = int.Parse(tbSoPT.Text);
                min = int.Parse(tbSoDau.Text);
                max = int.Parse(tbSoCuoi.Text);
                a = new int[size];
                tao_Mang(100, Properties.Resources.img_simple);
                for (int i = 0; i < size; i++)
                {
                    a[i] = random.Next(min, max);
                    node1[i].Text = a[i].ToString();
                }
                foreach (int value in a)
                {
                    tbMang.AppendText(value.ToString() + " ");
                }
                btnTang.Enabled = true;
                btnGiam.Enabled = true;
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
                node1[i].Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * i, 450);
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

                chiSo[i].Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * i, 470 + khoang_Cach * 3);
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
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Lấy nội dung cần ghi từ TextBox hoặc từ dữ liệu khác
                string mang = tbKetQua.Text;
                // Ghi nội dung vào file
                File.WriteAllText(filePath, mang );
                MessageBox.Show("File opened successfully!");
            }
        }

        private void docFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string content = File.ReadAllText(filePath);
                string[] numbersString = content.Split(' ');
                size = numbersString.Length;
                a = new int[size];
                tao_Mang(100, Properties.Resources.img_simple);
                for (int i = 0; i < size; i++)
                {
                    a[i] = int.Parse(numbersString[i].Trim());
                    node1[i].Text = a[i].ToString();
                }
                MessageBox.Show("File opened successfully!");
                tbMang.Text = content;
            }
        }

        #region CÁC HÀM DI CHUYỂN
        // Hàm đổi chỗ hai nod
        public void swap_Node(Control node_a, Control node_b)
        {
            // Thời gian di chuyển tối đa là 1s
            // Nếu 2 node cách nhau >= 4 node thì di chuyển 4 lần 0.25s (lên, sang, sang, xuống)
            // Nếu 2 node cách nhau <=3 node thì chi chuyển 3 lần 0.25s (lên, sang, xuống)
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                Point pa = node_a.Location;  // Lưu vị trí hai node
                Point pb = node_b.Location;
                if (pa != pb)
                {
                    // Node_a lên, node_b xuống 100 đơn vị
                    if (node_a.Location.X < node_b.Location.X)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            node_a.Top -= 1;
                            node_b.Top += 1;
                            wait_time(2 * toc_Do);  // 250 / 100 = 2.5, làm tròn lên 3
                        }
                    }

                    // Node b lên, node a xuống
                    if (node_a.Location.X > node_b.Location.X)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            node_a.Top += 1;
                            node_b.Top -= 1;
                            wait_time(2 * toc_Do);
                        }
                    }

                    // Node a qua phải, node b qua trái
                    if (node_a.Location.X < node_b.Location.X)
                    {
                        int dodai = node_b.Location.X - node_a.Location.X;  // Hai node cách nhau bao nhiêu độ dài
                        int step = dodai / (kich_Thuoc + khoang_Cach);      // Hai node cách nhau bao nhiêu ô
                        int ms = 2;
                        if (step < 4) // Di chuyen 1 lan
                        {
                            ms = (250 / dodai);  // Thời gian wait time
                        }
                        else
                        {
                            ms = 500 / dodai;
                        }

                        for (int j = 0; j < dodai; j++)
                        {
                            node_a.Left += 1;
                            node_b.Left -= 1;
                            wait_time(ms * toc_Do);
                        }
                    }

                    // Node a qua trái, node b qua phải
                    //if (node_a.Location.X > node_b.Location.X)
                    else
                    {
                        int dodai = node_a.Location.X - node_b.Location.X;  // Hai node cách nhau bao nhiêu độ dài
                        int step = dodai / (kich_Thuoc + khoang_Cach);      // Hai node cách nhau bao nhiêu ô
                        int ms = 2;
                        if (step < 3) // Di chuyen 1 lan
                        {
                            ms = (250 / dodai);  // Thời gian wait time
                        }
                        else
                        {
                            ms = 500 / dodai;
                        }

                        for (int j = 0; j < dodai; j++)
                        {
                            node_a.Left -= 1;
                            node_b.Left += 1;
                            wait_time(ms * toc_Do);
                        }
                    }

                    // Khu vực đưa các node về đến đích
                    // a xuống, b lên
                    if (node_b.Location.Y > pa.Y)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            node_a.Top += 1;
                            node_b.Top -= 1;
                            wait_time(2 * toc_Do);
                        }
                    }

                    // a lên, b xuống
                    if (node_b.Location.Y < pa.Y)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            node_a.Top -= 1;
                            node_b.Top += 1;
                            wait_time(3 * toc_Do);
                        }
                    }

                }
                wait_time(250 * toc_Do);
                set_node_color(node_a, Properties.Resources.img_simple);
                set_node_color(node_b, Properties.Resources.img_simple); // Swap xong cho màu về mặc định

            });
        }
        //CÁC HÀM DI CHUYỂN
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
            tbKetQua.Clear();
            msg.Clear();
            n = a.Length;
            for (i = 0; i < n; i++)
            {
                set_node_color(node1[i], Properties.Resources.img_simple);
            }
            wait_time(500);
            if (!rbChen.Checked && !rbChon.Checked && !rbNoiBot.Checked)
            {
                MessageBox.Show("Mời bạn chọn thuật toán.");
            }
            else
            {
                if (cb_Tungbuoc.Checked == true)
                {
                    if (rbChen.Checked)
                    {
                        code_C.SXChenGiam(lb_Code);
                        wait_time(300 * toc_Do);
                        int x, j;
                        set_node_color(node1[0], Properties.Resources.img_done);
                        lb_Code.SelectedIndex = 3;
                        for (int i = 1; i < n; i++)
                        {
                            Refresh();
                            lb_i.Text = "i= " + i;
                            wait_time(500 * toc_Do);
                            lb_Code.SelectedIndex = 5;
                            x = a[i];
                            lb_status1.Text = "x = a[" + i + "] = " + a[i].ToString();
                            wait_time(500 * toc_Do);
                            Button node_tam = node1[i];
                            set_node_color(node_tam, Properties.Resources.img_pivot);
                            if (x > a[i - 1] && i > 0)
                                go_up(node_tam, i);
                            j = i;
                            lb_Code.SelectedIndex = 6;
                            lb_j.Text = "j = " + i;
                            wait_time(150 * toc_Do);
                            lb_status2.Text = "a[j-1] = a["+(j-1)+"] = " + a[j - 1].ToString();
                            wait_time(500 * toc_Do);
                            lb_Code.SelectedIndex = 7;
                            wait_time(500 * toc_Do);
                            while (j > 0 && x > a[j - 1])
                            {
                                lb_Code.SelectedIndex = 9;
                                lb_status3.Text = "a[j]= a[j-1]= a[" + (j - 1) + "] = " + a[j - 1].ToString();
                                wait_time(500 * toc_Do);
                                a[j] = a[j - 1];
                                to_right(node1[j - 1], j - 1, j);
                                swap_button(j - 1, j);
                                wait_time(toc_Do * 150);
                                lb_Code.SelectedIndex = 10;
                                wait_time(500 * toc_Do);
                                j--;
                            }
                            if (j != i)
                            {
                                lb_Code.SelectedIndex = 12;
                                lb_status4.Text = "a[j] = x = " + x;
                                wait_time(500 * toc_Do);
                                a[j] = x;
                                to_left(node_tam, i, j);
                                go_down(node_tam, j);
                                node1[j] = node_tam;
                                wait_time(150 * toc_Do);
                            }
                            else
                                wait_time(300 * toc_Do);
                            set_node_color(node1[j], Properties.Resources.img_done);
                        }
                    }
                    else if (rbNoiBot.Checked)
                    {
                        code_C.SXNoiBotGiam(lb_Code);
                        wait_time(300 * toc_Do);
                        lb_Code.SelectedIndex = 3;
                        for (int i = 0; i < n - 1; i++)
                        {
                            Refresh();
                            lb_i.Text = "i = " + i;
                            wait_time(500 * toc_Do);
                            for (int j = 0; j < n - i - 1; j++)
                            {
                                lb_Code.SelectedIndex = 5;
                                lb_j.Text = "j = " + j;
                                wait_time(500 * toc_Do);
                                lb_status1.Text = "a[j] = a[" + j + "] = " + a[j].ToString();
                                wait_time(toc_Do * 200);
                                lb_status2.Text = "a[j+1] = a[" + (j + 1) + "] = " + a[j + 1].ToString();
                                wait_time(toc_Do * 500);
                                set_node_color(node1[j], Properties.Resources.img_select); // Sét màu cho phần tử j đang xét
                                set_node_color(node1[j + 1], Properties.Resources.img_pivot);
                                wait_time(toc_Do * 150);
                                lb_Code.SelectedIndex = 6;
                                wait_time(500 * toc_Do);
                                if (a[j] < a[j + 1])
                                {
                                    int temp;
                                    temp = a[j];
                                    a[j] = a[j + 1];
                                    a[j + 1] = temp;

                                    lb_Code.SelectedIndex = 8;
                                    lb_status3.Text = "temp = a[j] = a[" + j + "] = " + a[j+1].ToString();
                                    wait_time(500 * toc_Do);
                                    lb_Code.SelectedIndex = 9;
                                    lb_status4.Text = "a[j] = a[j+1] = a[" + (j + 1) + "] = " + a[j].ToString();
                                    wait_time(toc_Do * 500);
                                    lb_Code.SelectedIndex = 10;
                                    lb_Status5.Text = "a[j+1] = temp = " + temp;
                                    wait_time(500 * toc_Do);
                                    swap_Node(node1[j], node1[j + 1]);
                                    swap_button(j, j + 1);
                                    // Sau khi swap button nó tự đổi màu, nên mình phài đặt màu lại
                                    set_node_color(node1[j + 1], Properties.Resources.img_done);
                                    set_node_color(node1[j], Properties.Resources.img_simple);
                                    wait_time(250 * toc_Do);
                                }
                                else  // Nếu không swap thì đổi màu!
                                {
                                    set_node_color(node1[j], Properties.Resources.img_simple);
                                    set_node_color(node1[j + 1], Properties.Resources.img_done);
                                    wait_time(150 * toc_Do);
                                }
                                if (j + 1 == n - i - 1)
                                {
                                    set_node_color(node1[j], Properties.Resources.img_done);
                                    wait_time(150 * toc_Do);
                                }
                            }
                        }
                    }
                    else if (rbChon.Checked)
                    {
                        code_C.SXChonGiam(lb_Code);
                        lb_Code.SelectedIndex = 3;
                        wait_time(300 * toc_Do);
                        for (i = 0; i < n - 1; i++)
                        {
                            Refresh();
                            lb_Code.SelectedIndex = 5;
                            lb_i.Text = "i = " + i;
                            wait_time(toc_Do * 500);
                            int maxIndex = i;
                            set_node_color(node1[i], Properties.Resources.img_pivot);
                            wait_time(toc_Do * 250);
                            lb_status1.Text = "a[maxIndex] = a[i] = a[" + i + "] = " + a[i].ToString();
                            wait_time(toc_Do * 300);
                            // Tìm phần tử lớn nhất trong mảng chưa sắp xếp
                            lb_Code.SelectedIndex = 6;
                            for (int j = i + 1; j < n; j++)
                            {
                                lb_j.Text = "j = " + j;
                                wait_time(toc_Do * 500);
                                set_node_color(node1[j], Properties.Resources.img_select);
                                lb_Code.SelectedIndex = 7;
                                wait_time(toc_Do * 300);
                                //lb_status2.Text = "a[j] = a[" + i + "] = " + a[i].ToString();
                                wait_time(toc_Do * 500);
                                if (a[j] > a[maxIndex])
                                {
                                    lb_Code.SelectedIndex = 8;
                                    wait_time(toc_Do * 500);
                                    maxIndex = j;
                                    lb_status2.Text = "a[maxIndex] = a[" + j.ToString() + "] =" + a[j].ToString();
                                    set_node_color(node1[maxIndex], Properties.Resources.img_simple);
                                    set_node_color(node1[j], Properties.Resources.img_pivot);
                                    wait_time(toc_Do * 250);
                                }
                                else
                                    set_node_color(node1[j], Properties.Resources.img_simple);
                                wait_time(toc_Do * 250);
                            }
                            if (i != maxIndex)
                            {
                                int temp = a[i];
                                a[i] = a[maxIndex];
                                a[maxIndex] = temp;
                                lb_Code.SelectedIndex = 9;
                                lb_status3.Text = "temp = a[" + i + "] = " + a[maxIndex].ToString();
                                wait_time(toc_Do * 500);
                                lb_Code.SelectedIndex = 10;
                                lb_status4.Text = "a[" + i + "] = a[maxIndex] = " + a[i].ToString();
                                wait_time(toc_Do * 500);
                                lb_Code.SelectedIndex = 11;
                                lb_Status5.Text = "a[maxIndex] = temp = a["+maxIndex+"] = " + temp.ToString();
                                wait_time(toc_Do * 500);
                                swap_Node(node1[i], node1[maxIndex]);
                                swap_button(i, maxIndex);
                                set_node_color(node1[i], Properties.Resources.img_done);
                                set_node_color(node1[maxIndex], Properties.Resources.img_simple);
                                wait_time(toc_Do * 250);
                            }
                            set_node_color(node1[i], Properties.Resources.img_done);
                        }
                    }
                    for (int i = 0; i < n; i++)
                        set_node_color(node1[i], Properties.Resources.img_done);
                    foreach (int value in a)
                    {
                        tbKetQua.AppendText(value.ToString() + " ");
                        stopwatch.Stop();
                        msg.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                    }
                    MessageBox.Show("Đã sắp xếp xong.");
                }
                else if (cb_Tungbuoc.Checked == false)
                {
                    if (rbNoiBot.Checked)
                    {
                        for (i = 0; i < n - 1; i++)
                        {
                            for (int j = 0; j < n - i - 1; j++)
                            {
                                if (a[j] < a[j + 1])
                                {
                                    int temp = a[j];
                                    string tam = node1[j].Text;
                                    a[j] = a[j + 1];
                                    node1[j].Text = node1[j + 1].Text;
                                    a[j + 1] = temp;
                                    node1[j + 1].Text = tam;
                                }
                            }
                            set_node_color(node1[i], Properties.Resources.img_done);
                        }
                    }
                    else
                    if (rbChon.Checked)
                    {
                        for (i = 0; i < n - 1; i++)
                        {
                            int maxIndex = i;
                            // Tìm phần tử nhỏ nhất trong mảng chưa sắp xếp
                            for (int j = i + 1; j < n; j++)
                            {
                                if (a[j] > a[maxIndex])
                                {
                                    maxIndex = j;
                                }
                            }
                            if (i != maxIndex)
                            {
                                int temp = a[i];
                                string tam = node1[i].Text;
                                a[i] = a[maxIndex];
                                node1[i].Text = node1[maxIndex].Text;
                                a[maxIndex] = temp;
                                node1[maxIndex].Text = tam;
                            }
                            set_node_color(node1[i], Properties.Resources.img_done);
                        }
                    }
                    else if (rbChen.Checked)
                    {
                        for (i = 1; i < n; i++)
                        {
                            int x, j;
                            //set_node_color(node1[0], Properties.Resources.img_done);
                            for (int i = 1; i < n; i++)
                            {
                                x = a[i];
                                string y = node1[i].Text;
                                //set_node_color(node_tam, Properties.Resources.img_pivot);
                                j = i;

                                while (j > 0 && x > a[j - 1])
                                {
                                    a[j] = a[j - 1];
                                    node1[j].Text = node1[j - 1].Text;
                                    j--;
                                }
                                if (j != i)
                                {
                                    a[j] = x;
                                    node1[j].Text = y;
                                }
                            }
                        }
                    }
                    for (int i = 0; i < n; i++)
                        set_node_color(node1[i], Properties.Resources.img_done);
                    foreach (int value in a)
                    {
                        tbKetQua.AppendText(value.ToString() + " ");
                        stopwatch.Stop();
                        msg.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                    }
                    MessageBox.Show("Đã sắp xếp xong.");
                }
            }
        }
        private void btnTang_Click(object sender, EventArgs e)
        {
            stopwatch.Restart();
            stopwatch.Start();
            tbKetQua.Clear();
            msg.Clear();
            n = a.Length;
            for (i = 0; i < n; i++)
            {
                set_node_color(node1[i], Properties.Resources.img_simple);
            }
            wait_time(500);
            if (!rbChen.Checked && !rbChon.Checked && !rbNoiBot.Checked)
            {
                MessageBox.Show("Mời bạn chọn thuật toán.");
            }
            else if (cb_Tungbuoc.Checked == true)
            {
                if (rbNoiBot.Checked)
                {
                    code_C.SXNoiBotTang(lb_Code);
                    wait_time(300 * toc_Do);
                    lb_Code.SelectedIndex = 3;
                    for (int i = 0; i < n - 1; i++)
                    {
                        Refresh();
                        lb_i.Text = "i = " + i;
                        wait_time(500 * toc_Do);
                        for (int j = 0; j < n - i - 1; j++)
                        {
                            lb_Code.SelectedIndex = 5;
                            lb_j.Text = "j = " + j;
                            wait_time(500 * toc_Do);
                            lb_status1.Text = "a[j] = a[" + j + "] = " + a[j].ToString();
                            wait_time(toc_Do * 200);
                            lb_status2.Text = "a[j+1] = a[" + (j + 1) + "] = " + a[j + 1].ToString();
                            wait_time(toc_Do * 500);
                            set_node_color(node1[j], Properties.Resources.img_select); // Sét màu cho phần tử j đang xét
                            set_node_color(node1[j + 1], Properties.Resources.img_pivot);
                            wait_time(toc_Do * 150);
                            lb_Code.SelectedIndex = 6;
                            wait_time(500 * toc_Do);
                            if (a[j] > a[j + 1])
                            {
                                int temp;
                                temp = a[j];
                                a[j] = a[j + 1];
                                a[j + 1] = temp;

                                lb_Code.SelectedIndex = 8;
                                lb_status3.Text = "temp = a[j] = a[" + j + "] = " + a[j + 1].ToString();
                                wait_time(500 * toc_Do);
                                lb_Code.SelectedIndex = 9;
                                lb_status4.Text = "a[j] = a[j+1] = a[" + (j + 1) + "] = " + a[j].ToString();
                                wait_time(toc_Do * 500);
                                lb_Code.SelectedIndex = 10;
                                lb_Status5.Text = "a[j+1] = temp = " + temp;
                                wait_time(500 * toc_Do);
                                swap_Node(node1[j], node1[j + 1]);
                                swap_button(j, j + 1);
                                // Sau khi swap button nó tự đổi màu, nên mình phài đặt màu lại
                                set_node_color(node1[j + 1], Properties.Resources.img_select);
                                set_node_color(node1[j], Properties.Resources.img_simple);
                                wait_time(250 * toc_Do);
                            }
                            else  // Nếu không swap thì đổi màu!
                            {
                                set_node_color(node1[j], Properties.Resources.img_simple);
                                set_node_color(node1[j + 1], Properties.Resources.img_done);
                                wait_time(150 * toc_Do);
                            }
                            if (j + 1 == n - i - 1)
                            {
                                set_node_color(node1[j + 1], Properties.Resources.img_done);
                                wait_time(150 * toc_Do);
                            }
                        }
                    }
                }
                else if (rbChon.Checked)
                {
                    code_C.SXNoiBotTang(lb_Code);
                    wait_time(300 * toc_Do);
                    lb_Code.SelectedIndex = 3;
                    for (i = 0; i < n - 1; i++)
                    {
                        Refresh();
                        lb_Code.SelectedIndex = 5;
                        lb_i.Text = "i = " + i;
                        wait_time(toc_Do * 500);
                        int minIndex = i;
                        set_node_color(node1[i], Properties.Resources.img_pivot);
                        wait_time(toc_Do * 250);
                        lb_status1.Text = "a[maxIndex] = a[i] = a[" + i + "] = " + a[i].ToString();
                        wait_time(toc_Do * 300);
                        // Tìm phần tử nhỏ nhất trong mảng chưa sắp xếp
                        lb_Code.SelectedIndex = 6;
                        for (int j = i + 1; j < n; j++)
                        {
                            lb_j.Text = "j = " + j;
                            wait_time(toc_Do * 500);
                            set_node_color(node1[j], Properties.Resources.img_select);
                            lb_Code.SelectedIndex = 7;
                            wait_time(toc_Do * 300);
                            if (a[j] < a[minIndex])
                            {
                                lb_Code.SelectedIndex = 8;
                                wait_time(toc_Do * 500);
                                minIndex = j;
                                lb_status2.Text = "a[minIndex] = a[" + j.ToString() + "] =" + a[j].ToString();
                                set_node_color(node1[minIndex], Properties.Resources.img_simple);
                                set_node_color(node1[j], Properties.Resources.img_pivot);
                                wait_time(toc_Do * 250);
                            }
                            else
                                set_node_color(node1[j], Properties.Resources.img_simple);
                            wait_time(toc_Do * 250);
                        }
                        if (i != minIndex)
                        {
                            int temp = a[i];
                            a[i] = a[minIndex];
                            a[minIndex] = temp;
                            lb_Code.SelectedIndex = 9;
                            lb_status3.Text = "temp = a[" + i + "] = " + a[minIndex].ToString();
                            wait_time(toc_Do * 500);
                            lb_Code.SelectedIndex = 10;
                            lb_status4.Text = "a[" + i + "] = a[minIndex] = " + a[i].ToString();
                            wait_time(toc_Do * 500);
                            lb_Code.SelectedIndex = 11;
                            lb_Status5.Text = "a[minIndex] = temp = a[" + minIndex + "] = " + temp.ToString();
                            wait_time(toc_Do * 500);
                            swap_Node(node1[i], node1[minIndex]);
                            swap_button(i, minIndex);
                            set_node_color(node1[i], Properties.Resources.img_done);
                            set_node_color(node1[minIndex], Properties.Resources.img_simple);
                            wait_time(toc_Do * 250);
                        }
                        set_node_color(node1[i], Properties.Resources.img_done);
                    }
                }
                else if (rbChen.Checked)
                {
                    code_C.SXChenTang(lb_Code);
                    wait_time(300 * toc_Do);
                    int x, j;
                    set_node_color(node1[0], Properties.Resources.img_done);
                    lb_Code.SelectedIndex = 3;
                    for (int i = 1; i < n; i++)
                    {
                        Refresh();
                        lb_i.Text = "i= " + i;
                        wait_time(500 * toc_Do);
                        lb_Code.SelectedIndex = 5;
                        x = a[i];
                        lb_status1.Text = "x = a[" + i + "] = " + a[i].ToString();
                        wait_time(500 * toc_Do);
                        Button node_tam = node1[i];
                        set_node_color(node_tam, Properties.Resources.img_pivot);
                        if (x < a[i - 1] && i > 0)
                            go_up(node_tam, i);
                        j = i;
                        lb_Code.SelectedIndex = 6;
                        lb_j.Text = "j = " + i;
                        wait_time(150 * toc_Do);
                        lb_status2.Text = "a[j-1] = a[" + (j - 1) + "] = " + a[j - 1].ToString();
                        wait_time(500 * toc_Do);
                        lb_Code.SelectedIndex = 7;
                        wait_time(toc_Do * 500);

                        while (j > 0 && x < a[j - 1])
                        {
                            lb_Code.SelectedIndex = 9;
                            lb_status3.Text = "a[j]= a[j-1]= a[" + (j - 1) + "] = " + a[j - 1].ToString();
                            wait_time(500 * toc_Do);
                            a[j] = a[j - 1];
                            to_right(node1[j - 1], j - 1, j);
                            swap_button(j - 1, j);
                            wait_time(toc_Do * 100);
                            lb_Code.SelectedIndex = 10;
                            wait_time(500 * toc_Do);
                            j--;                           
                        }
                        if (j != i)
                        {
                            lb_Code.SelectedIndex = 12;
                            lb_status4.Text = "a[j] = x = " + x;
                            wait_time(500 * toc_Do);
                            a[j] = x;
                            to_left(node_tam, i, j);
                            go_down(node_tam, j);
                            node1[j] = node_tam;
                            wait_time(150 * toc_Do);

                        }
                        else
                            wait_time(100 * toc_Do);
                        set_node_color(node1[j], Properties.Resources.img_done);
                        //set_node_color(node1[j + 1], Properties.Resources.img_done);
                    }
                }
                for (int i = 0; i < n; i++)
                    set_node_color(node1[i], Properties.Resources.img_done);
                foreach (int value in a)
                {
                    tbKetQua.AppendText(value.ToString() + " ");
                    stopwatch.Stop();
                    msg.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                }
                MessageBox.Show("Đã sắp xếp xong.");
            }
            else if (cb_Tungbuoc.Checked == false)
            {
                if (rbNoiBot.Checked)
                {
                    for (i = 0; i < n - 1; i++)
                    {
                        for (int j = 0; j < n - i - 1; j++)
                        {
                            if (a[j] > a[j + 1])
                            {
                                int temp = a[j];
                                string tam = node1[j].Text;
                                a[j] = a[j + 1];
                                node1[j].Text = node1[j + 1].Text;
                                a[j + 1] = temp;
                                node1[j + 1].Text = tam;
                            }
                        }
                        set_node_color(node1[i], Properties.Resources.img_done);
                    }
                }
                else if (rbChon.Checked)
                {
                    for (i = 0; i < n - 1; i++)
                    {
                        int minIndex = i;
                        // Tìm phần tử nhỏ nhất trong mảng chưa sắp xếp
                        for (int j = i + 1; j < n; j++)
                        {
                            if (a[j] < a[minIndex])
                            {
                                minIndex = j;
                            }
                        }

                        if (i != minIndex)
                        {
                            int temp = a[i];
                            string tam = node1[i].Text;
                            a[i] = a[minIndex];
                            node1[i].Text = node1[minIndex].Text;
                            a[minIndex] = temp;
                            node1[minIndex].Text = tam;
                        }
                        set_node_color(node1[i], Properties.Resources.img_done);
                    }
                }
                else if (rbChen.Checked)
                {
                    int x, j;
                    //set_node_color(node1[0], Properties.Resources.img_done);
                    for (int i = 1; i < n; i++)
                    {
                        x = a[i];
                        string y = node1[i].Text;
                        j = i;
                        while (j > 0 && x < a[j - 1])
                        {
                            a[j] = a[j - 1];
                            node1[j].Text = node1[j - 1].Text;
                            j--;
                        }
                        if (j != i)
                        {
                            a[j] = x;
                            node1[j].Text = y;
                        }
                    }
                    for (int i = 0; i < n; i++)
                        set_node_color(node1[i], Properties.Resources.img_done);
                }
                for (int i = 0; i < n; i++)
                    set_node_color(node1[i], Properties.Resources.img_done);
                foreach (int value in a)
                {
                    tbKetQua.AppendText(value.ToString() + " ");
                    stopwatch.Stop();
                    msg.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                }
                MessageBox.Show("Đã sắp xếp xong.");
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Thread.Sleep(10000);
        }
        public void Refresh()
        {
            wait_time(300 * toc_Do);
            lb_i.ResetText();
            lb_j.ResetText();
            lb_status1.ResetText();
            lb_status2.ResetText();
            lb_status3.ResetText();
            lb_status4.ResetText();
            lb_Status5.ResetText();
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