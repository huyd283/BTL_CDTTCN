using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
            int size = int.Parse(tbSoPT.Text);
            int min = int.Parse(tbSoDau.Text);
            int max = int.Parse(tbSoCuoi.Text);
            randomArray = new List<int>();
            // Tạo mảng ngẫu nhiên
            for (int i = 0; i < size; i++)
            {
                randomArray.Add(random.Next(min, max));
            }
            // Hiển thị mảng ngẫu nhiên
            tbMang.Text = string.Join(" ", randomArray);
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
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Hiển thị OpenFileDialog và kiểm tra kết quả trả về
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Đọc toàn bộ nội dung từ tập tin đã chọn
                string content = System.IO.File.ReadAllText(filePath);

                // Hiển thị nội dung trong TextBox
                tbMang.Text = content;

                MessageBox.Show("File opened successfully!");
            }

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
                    for (int j = i + 1; j < n; j++)
                        if (randomArray[i] < randomArray[j])
                        {
                            tam = randomArray[i];
                            randomArray[i] = randomArray[j];
                            randomArray[j] = tam;
                        }
                // Hiển thị mảng đã sắp xếp
                tbKetQua.Text = string.Join(" ", randomArray);
                stopwatch.Stop();
                msg.Text = "Thời gian thực hiện:  " + stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
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
            if (randomArray == null || randomArray.Count == 0)
            {
                MessageBox.Show("Vui lòng tạo mảng trước khi sắp xếp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int n = randomArray.Count;
            if (rbNoiBot.Checked)
            {
                for (i = 0; i < n - 1; i++)
                    for (int j = i + 1; j < n; j++)
                        //for (int j = 0; j < n - i - 1; j++)
                        if (randomArray[i] > randomArray[j])
                        {
                            tam = randomArray[i];
                            randomArray[i] = randomArray[j];
                            randomArray[j] = tam;
                        }

                // Hiển thị mảng đã sắp xếp
                tbKetQua.Text = string.Join(" ", randomArray);
                stopwatch.Stop();
                msg.Text = "Thời gian thực hiện:  " + stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
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
            }
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