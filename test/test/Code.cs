using System;

namespace test
{
    class Code
    {
		public void SXChonTang(System.Windows.Forms.ListBox list_Code)
		{
			list_Code.Items.Add("void SXChonTang(int a[], int n)");
			list_Code.Items.Add("{");
			list_Code.Items.Add("	int minIndex;");
			list_Code.Items.Add("	for (int i = 0; i < n - 1; i++)");
			list_Code.Items.Add("	{");
			list_Code.Items.Add("		minIndex = i;");
			list_Code.Items.Add("		for (int j = i + 1; j < n; j++)");
			list_Code.Items.Add("			if (a[j] < a[minIndex])");
			list_Code.Items.Add("				minIndex = j;");
			list_Code.Items.Add("			int temp = a[i];");
			list_Code.Items.Add("			a[i] = a[maxIndex]");
			list_Code.Items.Add("			a[maxIndex] = temp;");
			list_Code.Items.Add("	}");
			list_Code.Items.Add("}");
		}
		public void SXChonGiam(System.Windows.Forms.ListBox list_Code)
		{
			list_Code.Items.Add("void SXChonGiam(int a[], int n)");
			list_Code.Items.Add("{");
			list_Code.Items.Add("	int maxIndex;");
			list_Code.Items.Add("	for (int i = 0; i < n - 1; i++)");
			list_Code.Items.Add("	{");
			list_Code.Items.Add("		maxIndex = i;");
			list_Code.Items.Add("		for (int j = i + 1; j < n; j++)");
			list_Code.Items.Add("		if (a[j] > a[maxIndex])");
			list_Code.Items.Add("			maxIndex = j;");
			//list_Code.Items.Add("		if (maxIndex != i)");
			list_Code.Items.Add("		int temp = a[i];");
			list_Code.Items.Add("		a[i] = a[maxIndex]");
			list_Code.Items.Add("		a[maxIndex] = temp;");
			list_Code.Items.Add("	}");
			list_Code.Items.Add("}");
		}
		public void SXNoiBotTang(System.Windows.Forms.ListBox list_Code)
		{
			list_Code.Items.Add("void SXNoiBotTang(int a[], int n)");
			list_Code.Items.Add("{");
			list_Code.Items.Add("	int i, j;");
			list_Code.Items.Add("	for (int i = 0; i < n - 1; i++)");
			list_Code.Items.Add("	{");
			list_Code.Items.Add("		for (int j = 0; j < n - i - 1; j++)");
			list_Code.Items.Add("			if (a[j] > a[j + 1])");
			list_Code.Items.Add("			{");
			list_Code.Items.Add("				int temp = a[j];");
			list_Code.Items.Add("				a[j] = a[j + 1];");
			list_Code.Items.Add("				a[j + 1] = temp;");
			list_Code.Items.Add("			}");
			list_Code.Items.Add("	}");
			list_Code.Items.Add("}");
		}
		public void SXNoiBotGiam(System.Windows.Forms.ListBox list_Code)
		{
			list_Code.Items.Add("void SXNoiBotGiam(int a[], int n)");
			list_Code.Items.Add("{");
			list_Code.Items.Add("	int i, j;");
			list_Code.Items.Add("	for (int i = 0; i < n - 1; i++)");
			list_Code.Items.Add("	{");
			list_Code.Items.Add("		for (int j = 0; j < n - i - 1; j++)");
			list_Code.Items.Add("			if (a[j] < a[j + 1])");
			list_Code.Items.Add("			{");
			list_Code.Items.Add("				int temp = a[j];");
			list_Code.Items.Add("				a[j] = a[j + 1];");
			list_Code.Items.Add("				a[j + 1] = temp;");
			list_Code.Items.Add("			}");
			list_Code.Items.Add("	}");
			list_Code.Items.Add("}");
		}
		public void SXChenTang(System.Windows.Forms.ListBox list_Code)
		{
			list_Code.Items.Add("void SXChenTang(int a[], int n)");
			list_Code.Items.Add("{");
			list_Code.Items.Add("	int x,j;");
			list_Code.Items.Add("	for (int i = 1; i < n; i++)");
			list_Code.Items.Add("	{");
			list_Code.Items.Add("		x = a[i];");
			list_Code.Items.Add("		j = i;");
			list_Code.Items.Add("		while (j > 0 && x < a[j - 1])");
			list_Code.Items.Add("		{");
			list_Code.Items.Add("			a[j] = a[j - 1];");
			list_Code.Items.Add("			j--;");
			list_Code.Items.Add("		}");
			list_Code.Items.Add("		a[j] = x;");
			list_Code.Items.Add("	}");
			list_Code.Items.Add("}");
		}
		public void SXChenGiam(System.Windows.Forms.ListBox list_Code)
		{
			list_Code.Items.Add("void SXChenGiam(int a[], int n)");
			list_Code.Items.Add("{");
			list_Code.Items.Add("	int x,j;");
			list_Code.Items.Add("	for (int i = 1; i < n; i++)");
			list_Code.Items.Add("	{");
			list_Code.Items.Add("		x = a[i];");
			list_Code.Items.Add("		j = i;");
			list_Code.Items.Add("		while (j > 0 && x > a[j - 1])");
			list_Code.Items.Add("		{");
			list_Code.Items.Add("			a[j] = a[j - 1];");
			list_Code.Items.Add("			j--;");
			list_Code.Items.Add("		}");
			list_Code.Items.Add("		a[j] = x;");
			list_Code.Items.Add("	}");
			list_Code.Items.Add("}");
		}
	}
}
