using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题18电离层改正
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

                string line1 = sr.ReadLine();
                string[] parts1 = line1.Split('\t',' ');
                Datacenter.hour = int.Parse(parts1[4]);
                Datacenter.min = int.Parse(parts1[5]);
                Datacenter.sec = double.Parse(parts1[6]);

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] parts = line.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string Name = parts[0];
                    double x = double.Parse(parts[1]);
                    double y = double.Parse(parts[2]);
                    double z = double.Parse(parts[3]);

                    Node n = new Node();
                    n.Name = Name;
                    n.xs = x * 1000;
                    n.ys = y * 1000;
                    n.zs = z * 1000;

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
