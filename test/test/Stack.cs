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
    public partial class Stack : Form
    {
        private Stack<int> stack;
        Stopwatch stopwatch = new Stopwatch();
        private string filePath;
        public Stack()
        {
            InitializeComponent();
        }
        public static int[] a;
        int min, max, count;
        private void docfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "E:\\";
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.RestoreDirectory = true;
            stack = new Stack<int>();
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
                            stack.Push(number);
                        }
                    }
                }
                StringBuilder sb = new StringBuilder();
                foreach (int number in stack)
                {
                    sb.AppendLine(number.ToString() + " ");
                }
                tbMang.Text = sb.ToString();
                MessageBox.Show("Open Success!");

            }
        }
        private void nhapMang_Click(object sender, EventArgs e)
        {
            tbMang.ResetText();
            stack = new Stack<int>();

            if (int.TryParse(tbMin.Text, out min) && int.TryParse(tbMax.Text, out max) && int.TryParse(tbSoPT.Text, out count))
            {
                if (min <= max && count > 0)
                {

                    Random random = new Random();
                    for (int i = 0; i < count; i++)
                    {
                        int randomNumber = random.Next(min, max + 1);
                        stack.Push(randomNumber);
                    }
                    int[] array = stack.ToArray();
                    Array.Reverse(array);

                    StringBuilder sb = new StringBuilder();
                    foreach (int number in stack)
                    {
                        sb.AppendLine(number.ToString() + " ");
                    }

                    tbMang.Text = sb.ToString();
                    msgE.Text = " ";
                }
                else
                {
                    msgE.Text = "Invalid input!";
                }
            }
            else
            {
                msgE.Text = "Invalid input!";
            }
        }

        private void luuFlie_Click(object sender, EventArgs e)
        {
            string content = tbKetqua.Text;

            // Hiển thị hộp thoại SaveFileDialog để cho phép người dùng chọn vị trí và tên tệp tin để lưu
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn và tên tệp tin
                string filePath = saveFileDialog.FileName; 

                // Sử dụng phương thức WriteAllText trong lớp File để ghi nội dung vào tệp tin
                File.WriteAllText(filePath, content);

                MessageBox.Show("Lưu thành công!");
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            openFileDialog.Title = "Chọn một file để lưu dữ liệu";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                MessageBox.Show("File đã được chọn: " + filePath);
            }
            if (!string.IsNullOrEmpty(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    string data = ("Stack: " + timeload.Text); // Dữ liệu cần lưu
                    writer.WriteLine(data);
                }

                MessageBox.Show("Dữ liệu đã được lưu vào file.");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một file trước khi lưu dữ liệu.");
            }
        }
        private void btnTang_Click(object sender, EventArgs e)
        {
            tbKetqua.Clear();
            stopwatch.Restart();
            stopwatch.Start();
            if (!rbChen.Checked && !rbChon.Checked && !rbNoibot.Checked)
            {
                MessageBox.Show("Mời bạn chọn thuật toán.");
            }
            else
            {
                if (rbChen.Checked)
                {
                    {
                        ////char[] c = new char[] { '\r','\n',',' };
                        //string input = tbMang.Text;
                        ////string input2 = input.Replace(c[0], ' ');
                        ////string input3 = input2.Replace(c[1], ' ');
                        ////string input4 = input3.Trim(' ');
                        string[] inputArray = tbMang.Text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        Stack<int> stack = new Stack<int>();

                        // Chèn các phần tử vào stack theo thứ tự tăng dần
                        foreach (string item in inputArray)
                        {
                            int number = int.Parse(item);
                            if (stack.Count == 0 || number > stack.Peek())
                            {
                                stack.Push(number);
                            }
                            else
                            {
                                Stack<int> tempStack = new Stack<int>();

                                while (stack.Count > 0 && number < stack.Peek())
                                {
                                    tempStack.Push(stack.Pop());
                                }

                                stack.Push(number);

                                while (tempStack.Count > 0)
                                {
                                    stack.Push(tempStack.Pop());
                                }
                            }
                        }

                        // Hiển thị mảng đã sắp xếp
                        tbKetqua.Text = string.Join(" ", stack.Reverse());
                        timeload.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                        MessageBox.Show("Đã sắp xếp xong.");
                    }
                }
                else if (rbChon.Checked)
                {
                    string[] inputArray = tbMang.Text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    Stack<int> stack = new Stack<int>();

                    // Chèn các phần tử vào stack theo thứ tự tăng dần
                    foreach (string item in inputArray)
                    {
                        stack.Push(int.Parse(item));
                    }

                    // Sắp xếp mảng trong stack
                    Stack<int> sortedStack = SelectionSort(stack);

                    // Hiển thị mảng đã sắp xếp
                    tbKetqua.Text = string.Join(" ", sortedStack.Reverse());
                    timeload.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                    MessageBox.Show("Đã sắp xếp xong.");
                }

                else if (rbNoibot.Checked)
                {   string[] inputArray = tbMang.Text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    Stack<int> stack = new Stack<int>();

                    // Chèn các phần tử vào stack theo thứ tự tăng dần
                    foreach (string item in inputArray)
                    {
                        stack.Push(int.Parse(item));
                    }

                    Stack<int> sortedStack = BubbleSort(stack);

                    tbKetqua.Text = string.Join(" ", sortedStack.Reverse());
                    timeload.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                    MessageBox.Show("Đã sắp xếp xong.");
                }
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
                    {
                        ////char[] c = new char[] { '\r','\n',',' };
                        //string input = tbMang.Text;
                        ////string input2 = input.Replace(c[0], ' ');
                        ////string input3 = input2.Replace(c[1], ' ');
                        ////string input4 = input3.Trim(' ');
                        string[] inputArray = tbMang.Text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        Stack<int> stack = new Stack<int>();

                        // Chèn các phần tử vào stack theo thứ tự tăng dần
                        foreach (string item in inputArray)
                        {
                            int number = int.Parse(item);
                            if (stack.Count == 0 || number > stack.Peek())
                            {
                                stack.Push(number);
                            }
                            else
                            {
                                Stack<int> tempStack = new Stack<int>();

                                while (stack.Count > 0 && number < stack.Peek())
                                {
                                    tempStack.Push(stack.Pop());
                                }

                                stack.Push(number);

                                while (tempStack.Count > 0)
                                {
                                    stack.Push(tempStack.Pop());
                                }
                            }
                        }

                        // Hiển thị mảng đã sắp xếp
                        tbKetqua.Text = string.Join(" ", stack);
                        timeload.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                        MessageBox.Show("Đã sắp xếp xong.");
                    }
                }
                else if (rbChon.Checked)
                {
                    string[] inputArray = tbMang.Text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    Stack<int> stack = new Stack<int>();

                    // Chèn các phần tử vào stack theo thứ tự tăng dần
                    foreach (string item in inputArray)
                    {
                        stack.Push(int.Parse(item));
                    }

                    // Sắp xếp mảng trong stack
                    Stack<int> sortedStack = SelectionSort(stack);

                    // Hiển thị mảng đã sắp xếp
                    tbKetqua.Text = string.Join(" ", sortedStack);
                    timeload.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                    MessageBox.Show("Đã sắp xếp xong.");
                }

                else if (rbNoibot.Checked)
                {
                    string[] inputArray = tbMang.Text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    Stack<int> stack = new Stack<int>();

                    // Chèn các phần tử vào stack theo thứ tự tăng dần
                    foreach (string item in inputArray)
                    {
                        stack.Push(int.Parse(item));
                    }

                    Stack<int> sortedStack = BubbleSort(stack);

                    tbKetqua.Text = string.Join(" ", sortedStack);
                    timeload.Text = stopwatch.Elapsed.TotalMilliseconds.ToString("0.######") + " ms";
                    MessageBox.Show("Đã sắp xếp xong.");

                }
            }
        }

        private static Stack<int> SelectionSort(Stack<int> stack)
        {
            //Stack<int> sortedStack = new Stack<int>();

            //while (stack.Count > 0)
            //{
            //    int min = int.MaxValue;

            //    // Tìm phần tử nhỏ nhất trong stack
            //    while (stack.Count > 0)
            //    {
            //        int current = stack.Pop();
            //        if (current < min)
            //        {
            //            min = current;
            //        }
            //        sortedStack.Push(current);
            //    }

            //    // Đẩy các phần tử lớn hơn phần tử nhỏ nhất vào stack
            //    while (sortedStack.Count > 0 && sortedStack.Peek() >= min)
            //    {
            //        int current = sortedStack.Pop();
            //        if (current != min)
            //        {
            //            stack.Push(current);
            //        }
            //    }

            //    // Đẩy phần tử nhỏ nhất vào stack
            //    stack.Push(min);
            //}
            int[] array = stack.ToArray();

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

            stack = new Stack<int>(array);

            return stack;
        }


        private static Stack<int> BubbleSort(Stack<int> stack)
        {
            //int n = stack.Count;

            //for (int i = 0; i < n - 1; i++)
            //{
            //    for (int j = 0; j < n - i - 1; j++)
            //    {
            //        int first = stack.Pop();
            //        int second = stack.Peek();

            //        if (first > second)
            //        {
            //            stack.Pop();
            //            stack.Push(first);
            //            stack.Push(second);
            //        }
            //        else
            //        {
            //            stack.Push(first);
            //        }
            //    }
            //}
            int[] array = stack.ToArray();

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

            stack = new Stack<int>(array);

            return stack;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            tbMang.ResetText();
            tbKetqua.ResetText();
            tbMin.ResetText();
            tbMax.ResetText();
            tbSoPT.ResetText();
            timeload.ResetText();
            rbChen.Checked = false;
            rbChon.Checked = false;
            rbNoibot.Checked = false;
            //tbKetqua.ResetText();
            //tbKetqua.ResetText();
        }
    }
}
