using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题8矩阵卷积计算
{
    internal static class FileHelper
    {
        static public void OpenFile()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "文本数据|*.txt";
            op.Title = "打开N矩阵文本数据";
            if (op.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(op.FileName);

                
                 for(int I = 0; I < 10; I++)
                 {
                    string line = sr.ReadLine();
                    
                    string[] parts = line.Split(new char[] { '\t',' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int J = 0; J < 10; J++)
                     {
                         Datacenter.N[I,J] = double .Parse(parts[J]);
                     }
                 }               
                sr.Close();
            }

            OpenFileDialog oq = new OpenFileDialog();
            oq.Filter = "文本数据|*.txt";
            oq.Title = "打开M矩阵文本数据";
            if (oq.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(oq.FileName);


                for (int I = 0; I < 3; I++)
                {
                    string line = sr.ReadLine();

                    string[] parts = line.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int J = 0; J < 3; J++)
                    {
                        Datacenter.M[I, J] = double.Parse(parts[J]);
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
            if (sf.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sf.FileName);
                sw.Write(report);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
