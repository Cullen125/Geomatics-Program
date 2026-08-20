using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace 试题9坐标系转换
{
    internal class Node
    {
        public string Name;

        public double x;
        public double y;
        public double z;

        public double b;
        public double l;
        public double h;

        public double n;
        public double e;
        public double u;
    }

    internal static class Datacenter
    {
        static public List<Node> nodes = new List<Node>();
        static public double[,] T = new double[3, 3];
        static public string report = "";
    }
}
