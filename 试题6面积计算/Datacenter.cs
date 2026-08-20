using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题6面积计算
{
    internal class Points
    {
        public string Name;
        public double x;
        public double y;

    }

    internal class Trig
    {
        public int Id;

        public Points P1;
        public Points P2;
        public Points P3;

        public double L1;
        public double L2;
        public double L3;

        public double S;
        public double A;
    }

    internal static class Datacenter
    {
        static public List<Points> points = new List<Points>();
        static public List<Trig> triangles = new List<Trig>();
        static public double sumA;

        static public string report = "";
    }
}
