using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题1出租车轨迹计算
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
                Datacenter.taxis.Clear();//清除

                StreamReader sr = new StreamReader(op.FileName);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();//读行

                    string[] parts = line.Split(new char[] { ',','\t' },StringSplitOptions.RemoveEmptyEntries);//分割

                    string Name = parts[0];
                    int Sta = int.Parse(parts[1]);
                    string T = parts[2];
                    double x = double.Parse(parts[3]);
                    double y = double.Parse(parts[4]);//转化

                    // 只保留T2车辆
                    if (Name != "T2")
                    {
                        continue;
                    }

                    Taxi taxi = new Taxi();
                    taxi.Name = Name;
                    taxi.Sta = Sta;
                    taxi.T = T;
                    taxi.x = x;
                    taxi.y = y;//赋值

                    Datacenter.taxis.Add(taxi);//加入列表
                }
                sr.Close();
            }
        }

        static public void saveReport(string report)//这里的string report没记住
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "文本数据|*.txt";
            sf.Title = "输入保存名称";
            sf.FileName = "result";//这一行没记住
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