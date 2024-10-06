using SAOD_Kyrsach.BookRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kyrsach.Tree
{
    public class TreeStr
    {
        public NodeTree Root;
        
        private IList<Node> PointCounter(IList<BookRecordAdapterGetLastNameByte> listBook)
        {
            Dictionary<string,int> Name = new Dictionary<string, int>();
            IList<Node> ListBookNode = new List<Node>();
            foreach(BookRecordAdapterGetLastNameByte val in listBook)
            {
                ListBookNode.Add(new Node(val));
            }
            for(int i = 0; i < ListBookNode.Count; i++)
            {
                if (Name.ContainsKey(ListBookNode[i].Name))
                {
                    Name[ListBookNode[i].Name] += 1;
                }
                else
                {
                    Name.Add(ListBookNode[i].Name,1);
                }
            }
            IList<Node> ResList = new List<Node>();
            for(int i = 0; i < ListBookNode.Count; i++)
            {
                if (Name.ContainsKey(ListBookNode[i].Name))
                {
                    ListBookNode[i].Point = Name[ListBookNode[i].Name];
                    ResList.Add(ListBookNode[i]);
                    Name.Remove(ListBookNode[i].Name);
                }
            }
            return ResList;
        }

        public void Add(IList<BookRecordAdapterGetLastNameByte> listBook)
        {
            IList<Node> nodes = PointCounter(listBook);
            for (int i = 0; i < nodes.Count; i++)
            {
                Root = AddToTree(Root, nodes[i]);
            }
        }

        private NodeTree AddToTree(NodeTree node, Node value)
        {
            if (node == null)
                return new NodeTree(value);
            else
            {
                if (value.Point >= node.Point)
                    node.Right = AddToTree(node.Right, value);
                else
                    node.Left = AddToTree(node.Left, value);
            }

            return node;
        }

       

        // Метод для красивого вывода дерева
        public void PrintTree()
        {
            PrintTree(Root, "", true);
        }
        public void InOrderTraversalLeft()
        {
            InOrderTraversalRecursive(Root);
        }

        private void InOrderTraversalRecursive(NodeTree node)
        {
            if (node != null)
            {

                InOrderTraversalRecursive(node.Left);
                Console.WriteLine(node.Value);
                InOrderTraversalRecursive(node.Right);
            }
        }
        public void InOrderTraversalLeftString()
        {
            InOrderTraversalRecursiveString(Root);
        }

        private void InOrderTraversalRecursiveString(NodeTree node)
        {
            if (node != null)
            {

                InOrderTraversalRecursiveString(node.Left);
                _obh += node.Value + "  "+node.Point + "\n";
                InOrderTraversalRecursiveString(node.Right);
            }
        }
        public override string ToString()
        {
            return $"{Root.Value}({Root.Point})";
        }
        private void PrintTree(NodeTree node, string indent, bool last)
        {
            if (node != null)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("R---- ");
                    indent += "   ";
                }
                else
                {
                    Console.Write("L---- ");
                    indent += "|  ";
                }
                Console.WriteLine($"{node.Value}({node.Point})");
                PrintTree(node.Left, indent, false);
                PrintTree(node.Right, indent, true);
            }
        }
        private string _obh = "";
        public string InOrderTraversal => _obh;
    }
}
