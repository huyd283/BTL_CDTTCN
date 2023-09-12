using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
        public partial class btnNhap : Form
    {
        private Random random;
        private List<int> randomArray;
        public btnNhap()
        {
            InitializeComponent();
            random = new Random();

        }
        int n = 0, i,tam;
        int[] a = new int[100];
        string s,s1;

        private void btnXoa_Click(object sender, EventArgs e)
        {
            KhungNhap.ResetText();
            KhungXuat.Clear();
            KhungXuat.ResetText();
            n = 0;
            s = " ";
        }

        private void btnNhapMang_Click(object sender, EventArgs e)
        {
            int size = int.Parse(KhungNhap.Text);
            int min = int.Parse(tbSoDau.Text);
            int max = int.Parse(tbSoCuoi.Text);
            randomArray = new List<int>();
            // Tạo mảng ngẫu nhiên
            for (int i = 0; i < size; i++)
            {
                randomArray.Add(random.Next(min,max));
            }
            // Hiển thị mảng ngẫu nhiên
            KhungXuat.Text = string.Join(" ", randomArray);
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {
            if (randomArray == null || randomArray.Count == 0)
            {
                MessageBox.Show("Vui lòng tạo mảng trước khi sắp xếp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int n = randomArray.Count;
            for (i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (randomArray[j] < randomArray[j + 1])
                    {
                        tam = randomArray[i];
                        randomArray[i] = randomArray[j + 1];
                        randomArray[j + 1] = tam;
                    }

            // Hiển thị mảng đã sắp xếp
            tbKetQua.Text = string.Join(" ", randomArray);
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
            
                string arrayText = string.Join(" ", randomArray);
            KhungXuat.Text = arrayText;

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