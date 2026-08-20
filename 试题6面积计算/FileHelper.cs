using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题6面积计算
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
                Datacenter.points.Clear();

                StreamReader sr = new StreamReader(op.FileName);
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] parts = line.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);

                    string Name = parts[0];
                    double x = double.Parse(parts[1]);
                    double y = double.Parse(parts[2]);

                    Points p = new Points();
                    p.Name = Name;
                    p.x = x;
                    p.y = y;

                    Datacenter.points.Add(p);
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
