using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kyrsach.Tree
{
    public class NodeTree
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
    }
}
