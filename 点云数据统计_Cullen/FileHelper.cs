using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace 点云数据统计_Cullen
{
    static class FileHelper
    {
        static public void Openfile()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "文本数据|*.txt";
            op.Title = "打开文本数据";
            if (op.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(op.FileName);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] str = sr.ReadLine().Trim().Split(',');
                    string name = str[0];
                    double x = double.Parse(str[1]);
                    double y = double.Parse(str[2]);//2
                    Point p = new Point(name, x, y);//3
                    Datacenter.points.Add(p);//4
                }

                Datacenter.K80 = Datacenter.points[79];//7
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
            }
        }
    }
}
