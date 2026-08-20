using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 卫星轨道预报_Cullen
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
                Datacenter.orbits.Clear();

                StreamReader sr= new StreamReader(op.FileName);
                sr.ReadLine();

                while (! sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    
                    string[] parts = line.Split(new char[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    double t = double.Parse(parts[0]);
                    double x = double.Parse(parts[1]);
                    double y = double.Parse(parts[2]);
                    double z = double.Parse(parts[3]);

                    Orbit o = new Orbit();
                    o.t = t;
                    o.x = x;
                    o.y = y;
                    o.z = z;

                    Datacenter.orbits.Add(o);
                }
                sr.Close();
            }
            
        }

        static public void saveReport(string report)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "文本数据|*";
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
