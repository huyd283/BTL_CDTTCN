using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                }

                else if (rbNoibot.Checked)
                {   string[] inputArray = tbMang.Text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        Stack<int> stack1 = new Stack<int>();

                        // Chèn các phần tử vào stack theo thứ tự tăng dần
                        foreach (string item in inputArray)
                        {
                            stack1.Push(int.Parse(item));
                        }

                        BubbleSort(stack1);

                        tbKetqua.Text = string.Join(" ", stack.Reverse());
                 }
             }
        }
        private static Stack<int> SelectionSort(Stack<int> stack)
        {
            Stack<int> tempStack = new Stack<int>();

            while (stack.Count > 0)
            {
                int min = stack.Pop();

                while (tempStack.Count > 0 && tempStack.Peek() > min)
                {
                    stack.Push(tempStack.Pop());
                }

                tempStack.Push(min);
            }

            return tempStack;
        }
        static void BubbleSort(Stack<int> stack)
        {
            int n = stack.Count;

            Stack<int> tempStack = new Stack<int>();

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    int curr = stack.Pop();
                    int next = stack.Peek();

                    if (curr > next)
                    {
                        // Swap elements
                        stack.Pop();
                        stack.Push(curr);
                        stack.Push(next);
                    }
                    else
                    {
                        stack.Push(curr);
                    }
                }

                // Di chuyển phần tử nhỏ nhất lên đỉnh stack trung gian
                tempStack.Push(stack.Pop());
            }

            // Đẩy các phần tử từ stack trung gian trở lại stack ban đầu
            while (tempStack.Count > 0)
            {
                stack.Push(tempStack.Pop());
            }
        }
    }

}
