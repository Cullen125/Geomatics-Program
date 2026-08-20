using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题9坐标系转换
{
    internal static class FileHelper
    {
        static public void OpenFile()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "数据文件|*.dat";
            op.Title = "打开数据文件";
            if (op.ShowDialog() == DialogResult.OK)
            {
                Datacenter.nodes.Clear();

                StreamReader sr = new StreamReader(op.FileName);
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    string Name = parts[0];
                    double x = double.Parse(parts[1]);
                    double y = double.Parse(parts[2]);
                    double z = double.Parse(parts[3]);

                    Node n = new Node();
                    n.Name = Name;
                    n.x = x;
                    n.y = y;
                    n.z = z;

                    Datacenter.nodes.Add(n);
                }
                sr.Close();
            }
        }

        static public void saveReport(string report)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "数据文件|*.dat";
            sf.Title = "选择保存路径";
            sf.FileName = "NEU.dat";
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
