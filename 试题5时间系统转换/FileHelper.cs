using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题5时间系统转换
{
    internal static class FileHelper
    {
        static public void OpenFile()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "文本数据|*.txt";
            op.Title = "打开文本数据";
            if(op.ShowDialog() == DialogResult.OK)
            {
                Datacenter.times.Clear();

                StreamReader sr = new StreamReader(op.FileName);

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] parts = line.Split(new char[] {'\t',' '}, StringSplitOptions.RemoveEmptyEntries);

                    int year = int.Parse(parts[0]);
                    int mon = int.Parse(parts[1]);
                    int day = int.Parse(parts[2]);
                    int hour = int.Parse(parts[3]);
                    int min = int.Parse(parts[4]);
                    double sec = double.Parse(parts[5]);

                    Time t = new Time();
                    t.year = year;
                    t.mon = mon;
                    t.day = day;
                    t.hour = hour;
                    t.min = min;
                    t.sec = sec;

                    Datacenter.times.Add(t);
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
            if(sf.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(sf.FileName);
                sr.Write(report);
                sr.Flush();
                sr.Close();
            }
        }
    }
}
