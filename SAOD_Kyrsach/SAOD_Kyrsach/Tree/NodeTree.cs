using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kyrsach.Tree
{
    public class NodeTree : IComparer<NodeTree>
    {
        public NodeTree Left = null;
        public NodeTree Right = null;
        public int Point;
        public string Value;

        public NodeTree(Node node)
        {
            Point = node.Point;
            Value = node.Value;
        }

        public int Compare(NodeTree? x, NodeTree? y)
        {
            if (x.Value[0] < y.Value[0]) return -1;
            if (x.Value[0] > y.Value[0]) { return 1; }
            return 0;
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
