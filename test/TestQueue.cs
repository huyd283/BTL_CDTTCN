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

namespace Test_Queue
{
    public partial class TestQueue : Form
    {
        private Queue<int> queue;
        public TestQueue()
        {
            InitializeComponent();
            queue = new Queue<int>();
        }
        public static int[] a;
        int min, max, count;
        int n = 0;

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
                    sb.AppendLine(number.ToString() + ",");
                }
                tbMang.Text = sb.ToString();
                MessageBox.Show("Open Success!");

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

        private void InsertionSort(Queue<int> queue)
        {
            int n = queue.Count;
            int[] array = queue.ToArray();
            for (int i = 1; i < n; ++i)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
            queue.Clear();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(array[i]);
            }
        }

        private void SelectionSort(Queue<int> queue)
        {
            //int n = queue.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                Queue<int> tempQueue = new Queue<int>();

                for (int j = 0; j < n - i; j++)
                {
                    int currentElement = queue.Dequeue();
                    tempQueue.Enqueue(currentElement);

                    if (currentElement < queue.Peek())
                    {
                        minIndex = j;
                    }
                }

                int minValue = tempQueue.Peek();
                int count = tempQueue.Count;

                for (int k = 0; k < count; k++)
                {
                    int currentElement = tempQueue.Dequeue();

                    if (k != minIndex)
                    {
                        queue.Enqueue(currentElement);
                    }
                    else
                    {
                        minValue = currentElement;
                    }
                }

                queue.Enqueue(minValue);
            }

        }

        private void BubbleSort(Queue<int> queue)
        {
            int n = queue.Count;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    int x = queue.Dequeue();
                    int y = queue.Peek();

                    if (x > y)
                    {
                        queue.Enqueue(x);
                        queue.Enqueue(y);
                    }
                    else
                    {
                        queue.Enqueue(y);
                        queue.Enqueue(x);
                    }
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
                    msg.Text = " ";
                }
                else
                {
                    msg.Text = "Nhập không thành công!";
                }
            }
            else
            {
                msg.Text = "Nhập không thành công!";
            }
        }

        private void btnTang_Click(object sender, EventArgs e)
        {
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
                        int[] arr = Array.ConvertAll(tbMang.Text.Split(' '), int.Parse);

                        // Sắp xếp mảng tăng dần bằng thuật toán sắp xếp chèn
                        for (int i = 0; i < arr.Length; i++)
                        {
                            int current = arr[i];
                            while (queue.Count > 0 && queue.Peek() > current)
                            {
                                arr[i] = queue.Dequeue();
                                i--;
                            }
                            queue.Enqueue(current);
                        }
                        InsertionSort(queue);
                        // Hiển thị mảng đã sắp xếp trong TextBox
                        tbKetqua.Text = string.Join(", ", queue);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Đầu vào không đúng định dạng. Vui lòng nhập các số nguyên, phân tách bằng dấu phẩy khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (rbChon.Checked)
                {
                    //a = new int[count];
                    //n = a.Length;
                    //char[] c = new char[] { '\r', '\n', ',' };
                    string input = tbMang.Text;
                    //string input2 = input.Replace(c[0], ' ');
                    //string input3 = input2.Replace(c[1], ' ');
                    //string input4 = input3.Trim();
                    if (!string.IsNullOrEmpty(input))
                    {
                        string[] inputArray = input.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);


                        Queue<int> queue1 = new Queue<int>();

                        for (int i = 0; i < inputArray.Length; i++)
                        {
                            int currentElement = int.Parse(inputArray[i]);
                            queue1.Enqueue(currentElement);
                        }

                        SelectionSort(queue);

                        int[] sortedArray = queue.ToArray();
                        Array.Reverse(sortedArray);

                        string result = string.Join(" ", sortedArray);
                        tbKetqua.Text = result;
                    }
                }

                else if (rbNoibot.Checked)
                {

                    string input = tbMang.Text;
                    string[] inputArray = input.Split(' ');
                    if (!string.IsNullOrEmpty(input))
                    {

                        Queue<int> queue = new Queue<int>();

                        for (int i = 0; i < inputArray.Length; i++)
                        {
                            int currentElement = int.Parse(inputArray[i]);
                            queue.Enqueue(currentElement);
                        }

                        BubbleSort(queue);

                        int[] sortedArray = queue.ToArray();
                        Array.Reverse(sortedArray);

                        string result = string.Join(" ", sortedArray);
                        tbKetqua.Text = result;
                    }

                }

            }
        }
    }
}
