using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题1出租车轨迹计算
{
    internal class Taxi//保存文件里每一行原始数据。
    {
        public string Name;
        public int Sta;
        public string T;
        public double MJD;
        public double x;
        public double y;
    } 

    internal class Result//保存相邻两个轨迹点形成的一段结果。
    {
        public int Id;
        public double BMJD;
        public double EMJD;
        public double v;
        public double a;
        public double s;
    }

    internal static class Datacenter
    {
        static public List<Taxi> taxis = new List<Taxi>();
        static public List<Result> results = new List<Result>();

        static public double sumS;
        static public double sumL;

        static public string report = "";
    }
}
