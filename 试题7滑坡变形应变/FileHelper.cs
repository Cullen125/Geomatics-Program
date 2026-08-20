using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题7滑坡变形应变
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
                // 清除上一次导入的数据
                Datacenter.stats.Clear();

                StreamReader sr = new StreamReader(op.FileName);

                // 读取第一行：监测点总数
                string line = sr.ReadLine();
                int pointCount = int.Parse(line);

                // 外层循环：依次读取每一个监测点
                for (int i = 0; i < pointCount; i++)
                {
                    line = sr.ReadLine();

                    string[] str = line.Split(new char[] { ',' });

                    string name = str[0];
                    int periodCount = int.Parse(str[1]);

                    // 内层循环：读取当前监测点的各期坐标
                    for (int j = 0; j < periodCount; j++)
                    {
                        line = sr.ReadLine();

                        str = line.Split(new char[] { ',' });

                        // 创建一条新的观测记录
                        Stat s = new Stat();
                        s.Name = name;
                        s.Period = int.Parse(str[0]);
                        s.x = double.Parse(str[1]);
                        s.y = double.Parse(str[2]);

                        Datacenter.stats.Add(s);
                    }
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
