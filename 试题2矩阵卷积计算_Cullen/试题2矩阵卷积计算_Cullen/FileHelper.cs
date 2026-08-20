using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace 试题2矩阵卷积计算_Cullen
{
    static class FileHelper
    {
        static public void Openfile()
        {
           
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "文本数据|*.txt";
            op.Title = "打开N矩阵数据";
            if(op.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(op.FileName);
                for(int i = 0; i < 10; i++)
                {
                    string line = sr.ReadLine();
                    string[] parts=line.Split(new char[] {' ','\t',','}, StringSplitOptions.RemoveEmptyEntries);
                    for(int j = 0; j < 10; j++)
                    {
                        Datacenter.N[i, j] = double.Parse(parts[j]);
                    }
                }
                sr.Close();
            }
            op.Title = "打开M矩阵数据";
            if (op.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(op.FileName);
                for (int i = 0; i < 3; i++)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < 3; j++)
                    {
                        Datacenter.M[i, j] = double.Parse(parts[j]);
                    }
                }
                sr.Close();
            }
        }

        static public void saveReport(string report)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "文本数据|*.txt";
            sf.Title = "选择保存路径";
            sf.FileName = "result";
            if(sf.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sf.FileName);
                sw.Write(report);
                sw.Flush();
                sw.Close();
            }
        }


    }

}
