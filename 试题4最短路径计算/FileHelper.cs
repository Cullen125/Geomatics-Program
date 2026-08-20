using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题4最短路径计算
{
    internal static class FileHelper
    {
        static public void OpenFile()
        {

            Datacenter.edges.Clear();
            Datacenter.vertices.Clear();

            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "文本数据|*.txt";
            op.Title = "打开文本数据";
            if(op.ShowDialog()== DialogResult.OK)
            {
                StreamReader sr = new StreamReader(op.FileName);

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] parts = line.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);

                    string begin = parts[0];
                    string end = parts[1];
                    double wei = double.Parse(parts[2]);

                    E e = new E(begin,end,wei);
                    Datacenter.edges.Add(e);

                    if (!Datacenter.vertices.Any(v => v.name == begin))
                    {
                        Datacenter.vertices.Add(new V(begin));
                    }

                    if (!Datacenter.vertices.Any(v => v.name == end))
                    {
                        Datacenter.vertices.Add(new V(end));
                    }//??? I Don't Understand...
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
                StreamWriter sr = new StreamWriter(sf.FileName);
                sr.Write(report);
                sr.Flush();
                sr.Close();
            }

        }
    }
}
