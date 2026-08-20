using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题2反距离加权
{
    internal class KPoint
    {
        public string Name;
        public double x;
        public double y;
        public double H;
    }

    internal class TPoint
    {
        public string Name;
        public double x;
        public double y;
        public double H;

        public string Used;
    }

    internal class Near
    {
        public KPoint point;
        public double dist;
    }

    internal static class Datacenter
    {
        static public List<KPoint> Kpoints = new List<KPoint>();
        static public List<TPoint> Tpoints = new List<TPoint>();

        static public string report = "";
    }
}
