using SAOD_Kyrsach.BookRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kyrsach.Tree
{
    public class Node : IComparer<Node>
    {
        public int Point;
        public string Name;
        public string Value;

        public Node(BookRecordAdapterGetLastNameByte BookByte)
        {
            Point = 1;
            Name = GetName(BookByte);
            Value = BookByte.ToString();
        }
        public Node(BookRecordAdapterGetLastNameByte BookByte, int point)
        {
            Point = point;
            Name = GetName(BookByte);
            Value = BookByte.ToString();
        }

        public int Compare(Node? x, Node? y)
        {
            if (x.Value[0] < y.Value[0]) return -1;
            if (x.Value[0] > y.Value[0]) { return 1; }
            return 0;
        }

        private string GetName(BookRecordAdapterGetLastNameByte BookByte)
        {
            string name = "";
            string BookString = BookByte.ToString();
            int i = 0;
            while (true) 
            {
                if (BookString[i] == '|')
                {
                    break;
                }
                name += BookString[i];
                i++;
            }
            return name;
        }
    }
}
