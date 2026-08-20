using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题3线状要素数据
{
    internal static class FileHelper
    {
        static public void OpenFile()
        {
            Datacenter.points.Clear();

            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "文本数据|*.txt";
            op.Title = "打开文本数据";
            if(op.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(op.FileName);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] parts = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    string ID = parts[0];
                    double x = double.Parse(parts[1]);
                    double y = double.Parse(parts[2]);

                    Node p = new Node();
                    p.x = x; 
                    p.y = y;
                    p.ID = ID;

                    Datacenter.points.Add(p);
                }
                sr.Close();
            }
        }

        static public void saveReport(string report)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "文本数据|*.txt";
            sf.Title = "选择文本数据";
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
