using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题2反距离加权
{
    internal static class FileHelper
    {
        static public void OpenFile()
        {           
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "文本数据|*.txt";
            op.Title = "打开文本数据";
            if(op.ShowDialog()== DialogResult.OK)
            {
                Datacenter.Kpoints.Clear();

                StreamReader sr = new StreamReader(op.FileName);
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    string Name = parts[0];
                    double x = double.Parse(parts[1]);
                    double y = double.Parse(parts[2]);
                    double H = double.Parse(parts[3]);

                    KPoint k = new KPoint();
                    k.Name = Name;
                    k.x = x;
                    k.y = y;
                    k.H = H;

                    Datacenter.Kpoints.Add(k);
                }
                sr.Close();//这个总是会忘记，还是放在大框架中写比较稳妥
            }
        }

        static public void saveReport(string report)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "文本数据|*.txt";
            sf.Title = "选择文本数据";
            sf.FileName = "result";
            if(sf.ShowDialog()== DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sf.FileName);
                sw.Write(report);
                sw.Flush();
                sw.Close();
            }

        }

    }
}
