using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试题3线状要素数据
{
    internal class Node
    {
        public string ID;
        public double x;
        public double y;

        public bool keep;
    }

    internal static class Datacenter
    {
        static public List<Node> points = new List<Node>();
        static public List<Node> result = new List<Node>();
        
        static public double threshold;
        static public string report = "";
    }
}
