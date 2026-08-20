using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题11对流层改正
{
    internal static class FileHelper
    {
        static public void OpenFile()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "文本数据|*.txt";
            op.Title = "打开文本数据";
            if (op.ShowDialog() == DialogResult.OK)
            {
                Datacenter.nodes.Clear();

                StreamReader sr = new StreamReader(op.FileName);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] parts = line.Split(',');

                    string Name = parts[0];
                    string time = parts[1];
                    int year = int.Parse(parts[1].Substring(0, 4));
                    int mon = int.Parse(parts[1].Substring(4, 2));
                    int day = int.Parse(parts[1].Substring(6, 2));
                    double l = double.Parse(parts[2]); 
                    double b = double.Parse(parts[3]); 
                    double h = double.Parse(parts[4]); 
                    double E = double.Parse(parts[5]);

                    Node n = new Node();
                    n.Name = Name;
                    n.time = time;
                    Datacenter.year = year;
                    Datacenter.mon = mon;
                    Datacenter.day = day;
                    n.l = l;
                    n.b = b;
                    n.h = h;
                    n.E = E;

                    Datacenter.nodes.Add(n);
                }
                sr.Close();
            }
        }

        static public void SaveReport(string report)
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
