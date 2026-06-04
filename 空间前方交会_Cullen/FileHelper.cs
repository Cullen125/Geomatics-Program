using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Web;

namespace 空间前方交会_Cullen
{
    static class FileHelper
    {
        static public void OpenFile()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "文本数据|*.txt";
            op.Title = "打开文本数据";
            if (op.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(op.FileName);

                sr.ReadLine();
                string[] str1 = sr.ReadLine().Trim().Split(',');
                string[] str2 = sr.ReadLine().Trim().Split(',');


                //The 1st point
                Datacenter.name1 = str1[0];
                Datacenter.Xs1 = double.Parse(str1[1]);
                Datacenter.Ys1 = double.Parse(str1[2]);
                Datacenter.Zs1 = double.Parse(str1[3]);
                Datacenter.phi1 = double.Parse(str1[4]);
                Datacenter.omiga1 = double.Parse(str1[5]);
                Datacenter.kapa1 = double.Parse(str1[6]);
                Datacenter.x1 = double.Parse(str1[7]);
                Datacenter.y1 = double.Parse(str1[8]);
                Datacenter.f1 = double.Parse(str1[9]);
                //The 2nd point 
                Datacenter.name2 = str2[0];
                Datacenter.Xs2 = double.Parse(str2[1]);
                Datacenter.Ys2 = double.Parse(str2[2]);
                Datacenter.Zs2 = double.Parse(str2[3]);
                Datacenter.phi2 = double.Parse(str2[4]);
                Datacenter.omiga2 = double.Parse(str2[5]);
                Datacenter.kapa2 = double.Parse(str2[6]);
                Datacenter.x2 = double.Parse(str2[7]);
                Datacenter.y2 = double.Parse(str2[8]);
                Datacenter.f2 = double.Parse(str2[9]);
            }

        }

        static public void saveReport(string report)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "文本数据|*.txt";
            sf.Title = "选择保存路径";
            sf.FileName = "result";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sf.FileName);
                sw.Write(report);
                sw.Flush();
            }
        }
    }
}
