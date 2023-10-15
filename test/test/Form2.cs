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
    public partial class Form2 : Form
    {
        private Stack<int> stack;

        public Form2()
        {
            InitializeComponent();
        }
        public static int[] a;
        int min, max, count;
        int n = 0;
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
                    //int[] array = stack.ToArray();
                    //Array.Reverse(array);

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
                string filePath = saveFileDialog.FileName; // Lấy đường dẫn và tên tệp tin

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
                    try
                    {
                        // Lấy mảng từ TextBox và chuyển đổi thành mảng số nguyên
                        int[] arr = Array.ConvertAll(tbMang.Text.Split(' '), int.Parse);

                        // Sắp xếp mảng tăng dần bằng thuật toán sắp xếp chèn
                        for (int i = 0; i < arr.Length; i++)
                        {
                            int current = arr[i];
                            while (stack.Count > 0 && stack.Peek() > current)
                            {
                                arr[i] = stack.Pop();
                                i--;
                            }
                            stack.Push(current);
                        }

                        // Hiển thị mảng đã sắp xếp trong TextBox
                        tbKetqua.Text = string.Join(", ", stack);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Đầu vào không đúng định dạng. Vui lòng nhập các số nguyên, phân tách bằng dấu phẩy hoặc khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (rbChon.Checked)
                {

                    //char[] c = new char[] { '\r','\n',',' };
                    string input = tbMang.Text;
                    //string input2 = input.Replace(c[0], ' ');
                    //string input3 = input2.Replace(c[1], ' ');
                    //string input4 = input3.Trim();
                    if (!string.IsNullOrEmpty(input))
                    {
                        string[] inputArray = input.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);


                        Stack<int> stack1 = new Stack<int>();

                        for (int i = 0; i < inputArray.Length; i++)
                        {
                            int currentElement = int.Parse(inputArray[i]);
                            stack1.Push(currentElement);
                        }

                        SelectionSort(stack);

                        int[] sortedArray = stack.ToArray();
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

                        Stack<int> stack = new Stack<int>();

                        for (int i = 0; i < inputArray.Length; i++)
                        {
                            int currentElement = int.Parse(inputArray[i]);
                            stack.Push(currentElement);
                        }

                        BubbleSort(stack);

                        int[] sortedArray = stack.ToArray();
                        Array.Reverse(sortedArray);

                        string result = string.Join(" ", sortedArray);
                        tbKetqua.Text = result;
                    }

                }

            }
        }
        private void InsertionSort(Stack<int> stack)
        {
            int n = stack.Count;
            int[] array = stack.ToArray();
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
            stack.Clear();
            for (int i = 0; i < n; i++)
            {
                stack.Push(array[i]);
            }
        }
        private void SelectionSort(Stack<int> stackt)
        {
            //int n = stack.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                Stack<int> tempStack = new Stack<int>();

                for (int j = 0; j < n - i; j++)
                {
                    int currentElement = stackt.Pop();
                    tempStack.Push(currentElement);

                    if (currentElement < stackt.Peek())
                    {
                        minIndex = j;
                    }
                }

                int minValue = tempStack.Peek();
                int count = tempStack.Count;

                for (int k = 0; k < count; k++)
                {
                    int currentElement = tempStack.Pop();

                    if (k != minIndex)
                    {
                        stackt.Push(currentElement);
                    }
                    else
                    {
                        minValue = currentElement;
                    }
                }

                stack.Push(minValue);
            }
        }
        private void BubbleSort(Stack<int> stack)
        {
            int n = stack.Count;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    int x = stack.Pop();
                    int y = stack.Peek();

                    if (x > y)
                    {
                        stack.Push(x);
                        stack.Push(y);
                    }
                    else
                    {
                        stack.Push(y);
                        stack.Push(x);
                    }
                }
            }
        }
    }

}
