using SAOD_Kyrsach.BookRecord;
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
        public BookRecordAdapterGetLastNameByte Value;

        public NodeTree()
        {
            Point = 0;
        }

        public NodeTree(BookRecordAdapterGetLastNameByte val, int point)
        {
            Point = point;
            Value = val;
        }

        public int Compare(NodeTree? x, NodeTree? y)
        {
            if (x.Value.YearPublisher < y.Value.YearPublisher) return -1;
            if (x.Value.YearPublisher > y.Value.YearPublisher) { return 1; }
            return 0;
        }
        public override string ToString()
        {
            if (Value == null) return "null";
            return Value.ToString();
        }
    }
}
