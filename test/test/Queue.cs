using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using test;

namespace test
{
    public partial class Queue : Form
    {
        Stopwatch stopwatch = new Stopwatch();

        private Queue<int> queue;
        public Queue()
        {
            InitializeComponent();
            queue = new Queue<int>();
        }
        public static int[] a;
        int min, max, count;
        int n = 0;

        private static Queue<int> SelectionSort(Queue<int> queue)
        {
            int[] array = queue.ToArray();

            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }

            queue = new Queue<int>(array);

            return queue;
        }
        private static Queue<int> BubbleSort(Queue<int> queue)
        {
            int[] array = queue.ToArray();

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            queue = new Queue<int>(array);

            return queue;
        }

        private void btnTang_Click(object sender, EventArgs e)
        {
            stopwatch.Restart();
            stopwatch.Start();
            tbKetqua.Clear();
            if (!rbChen.Checked && !rbChon.Checked && !rbNoibot.Checked)
            {
                MessageBox.Show("Mời bạn chọn thuật toán.");
            }
            else
            {
                if (rbChen.Checked)
                {
                    {
                        string[] inputArray = tbMang.Text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        Queue<int> queue = new Queue<int>();

                        // Chèn các phần tử vào queue theo thứ tự tăng dần
                        foreach (string item in inputArray)
                        {
                            int number = int.Parse(item);
                            if (queue.Count == 0 || number > queue.Peek())
                            {
                                queue.Enqueue(number);
                            }
                            else
                            {
                                Queue<int> tempQueue = new Queue<int>();

                                while (queue.Count > 0 && number < queue.Peek())
                                {
                                    tempQueue.Enqueue(queue.Dequeue());
                                }

                                queue.Enqueue(number);

                                while (tempQueue.Count > 0)
                                {
                                    queue.Enqueue(tempQueue.Dequeue());
                                }
                            }
                        }
                        //InsertionSort(queue);
                        // Hiển thị mảng đã sắp xếp
                        timeload.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";

                        tbKetqua.Text = string.Join(" ", queue);
                        MessageBox.Show("Đã sắp xếp xong.");
                    }
                }
                else if (rbChon.Checked)
                {
                    string[] inputArray = tbMang.Text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    Queue<int> queue = new Queue<int>();

                    // Chèn các phần tử vào queue theo thứ tự tăng dần
                    foreach (string item in inputArray)
                    {
                        queue.Enqueue(int.Parse(item));
                    }

                    // Sắp xếp mảng trong queue
                    Queue<int> sortedQueue = SelectionSort(queue);
                    SelectionSort(queue);
                    // Hiển thị mảng đã sắp xếp
                    tbKetqua.Text = string.Join(" ", sortedQueue);
                    MessageBox.Show("Đã sắp xếp xong.");
                    timeload.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";

                }

                else if (rbNoibot.Checked)
                {
                    string[] inputArray = tbMang.Text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    Queue<int> queue = new Queue<int>();

                    // Chèn các phần tử vào queue theo thứ tự tăng dần
                    foreach (string item in inputArray)
                    {
                        queue.Enqueue(int.Parse(item));
                    }

                    Queue<int> sortedQueue = BubbleSort(queue);

                    tbKetqua.Text = string.Join(" ", sortedQueue);
                    timeload.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";

                    MessageBox.Show("Đã sắp xếp xong.");

                }
            }
        }

        private void docFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\";
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;
            queue = new Queue<int>();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        int number;
                        if (int.TryParse(line, out number))
                        {
                            queue.Enqueue(number);
                        }
                    }
                }
                StringBuilder sb = new StringBuilder();
                foreach (int number in queue)
                {
                    sb.AppendLine(number.ToString() + " ");
                }
                tbMang.Text = sb.ToString();
                MessageBox.Show("Mở file thành công!");
                btnTang.Enabled = true;
                btnGiam.Enabled = true;
            }
        }

        private void luuFile_Click(object sender, EventArgs e)
        {
            string content = tbKetqua.Text;

            // Hiển thị hộp thoại SaveFileDialog để cho phép người dùng chọn vị trí và tên tệp tin để lưu
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName; // Lấy đường dẫn và tên tệp tin

                // Sử dụng phương thức WriteAllText trong lớp File để ghi nội dung vào tệp tin
                File.WriteAllText(filePath, content);

                MessageBox.Show("Lưu thành công!");
            }
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {
            stopwatch.Restart();
            stopwatch.Start();
            tbKetqua.Clear();
            if (!rbChen.Checked && !rbChon.Checked && !rbNoibot.Checked)
            {
                MessageBox.Show("Mời bạn chọn thuật toán.");
            }
            else
            {
                if (rbChen.Checked)
                {
                    try
                    {
                        // Lấy mảng từ TextBox và chuyển đổi thành mảng số nguyên
                        string[] inputArray = tbMang.Text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        Queue<int> queue = new Queue<int>();

                        // Chèn các phần tử vào stack theo thứ tự tăng dần
                        foreach (string item in inputArray)
                        {
                            int number = int.Parse(item);
                            if (queue.Count == 0 || number > queue.Peek())
                            {
                                queue.Enqueue(number);
                            }
                            else
                            {
                                Queue<int> tempQueue = new Queue<int>();

                                while (queue.Count > 0 && number < queue.Peek())
                                {
                                    tempQueue.Enqueue(queue.Dequeue());
                                }

                                queue.Enqueue(number);

                                while (tempQueue.Count > 0)
                                {
                                    queue.Enqueue(tempQueue.Dequeue());
                                }
                            }
                        }

                        // Hiển thị mảng đã sắp xếp
                        tbKetqua.Text = string.Join(" ", queue.Reverse());
                        timeload.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                        MessageBox.Show("Đã sắp xếp xong.");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Đầu vào không đúng định dạng. Vui lòng nhập các số nguyên, phân tách bằng dấu phẩy khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (rbChon.Checked)
                {
                    string[] inputArray = tbMang.Text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    Queue<int> queue = new Queue<int>();

                    // Chèn các phần tử vào stack theo thứ tự tăng dần
                    foreach (string item in inputArray)
                    {
                        queue.Enqueue(int.Parse(item));
                    }

                    // Sắp xếp mảng trong stack
                    Queue<int> sortedQueue = SelectionSort(queue);

                    // Hiển thị mảng đã sắp xếp
                    tbKetqua.Text = string.Join(" ", sortedQueue.Reverse());
                    timeload.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                    MessageBox.Show("Đã sắp xếp xong.");
                }

                else if (rbNoibot.Checked)
                {

                    string[] inputArray = tbMang.Text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    Queue<int> queue = new Queue<int>();

                    // Chèn các phần tử vào stack theo thứ tự tăng dần
                    foreach (string item in inputArray)
                    {
                        queue.Enqueue(int.Parse(item));
                    }

                    Queue<int> sortedQueue = BubbleSort(queue);

                    tbKetqua.Text = string.Join(" ", sortedQueue.Reverse());
                    timeload.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                    MessageBox.Show("Đã sắp xếp xong.");

                }

            }
        }



        private void btnNhapMang_Click(object sender, EventArgs e)
        {
            tbMang.ResetText();
            queue = new Queue<int>();

            if (int.TryParse(tbMin.Text, out min) && int.TryParse(tbMax.Text, out max) && int.TryParse(tbSoPT.Text, out count))
            {
                if (min <= max && count > 0)
                {

                    Random random = new Random();
                    for (int i = 0; i < count; i++)
                    {
                        int randomNumber = random.Next(min, max + 1);
                        queue.Enqueue(randomNumber);
                    }

                    StringBuilder sb = new StringBuilder();
                    foreach (int number in queue)
                    {
                        sb.AppendLine(number.ToString() + " ");
                    }

                    tbMang.Text = sb.ToString();
                    timeload.Text = " ";
                }
                else
                {
                    timeload.Text = "Nhập không thành công!";
                }
            }
            else
            {
                timeload.Text = "Nhập không thành công!";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            tbSoPT.ResetText();
            tbMin.ResetText();
            tbMax.ResetText();
            tbMang.Clear();
            tbKetqua.Clear();

            btnTang.Enabled = false;
            btnGiam.Enabled = false;
            rbChen.Checked = false;
            rbChon.Checked = false;
            rbNoibot.Checked = false;
        }



    }
}
