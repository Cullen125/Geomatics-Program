using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace 试题1出租车轨道数据计算_Cullen
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
                Datacenter.taxis.Clear();//AI加的一条：打开文件前清空旧数据
                StreamReader sr = new StreamReader(op.FileName);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] str = sr.ReadLine().Trim().Split(',');
                    string name = str[0];
                    string status = str[1];
                    string bjtime = str[2];
                    double x = double.Parse(str[3]);
                    double y = double.Parse(str[4]);

                    if(name == "T2")
                    {
                        Taxi t = new Taxi(name, status, bjtime, x, y);
                        Datacenter.taxis.Add(t);
                    }                   
                }
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
