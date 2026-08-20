using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题11对流层改正
{
    internal class Node
    {
        //原始文件信息
        public string Name = "";
        public string time = "";
        public double l;//经度
        public double b;//纬度
        public double h;
        public double E;

        //湿分量系数
        public double mw;

        public double aw;
        public double bw;
        public double cw;

        //干分量系数
        public double md;

        public double ad;
        public double bd;
        public double cd;

        //延迟改正
        public double ZHD;
        public double ZWD;
        public double dS;

    }

    internal static class Datacenter
    {
        static public List<Node> nodes = new List<Node>();

        static public int year;
        static public int mon;
        static public int day;

        static public string report = "";
    }
}
