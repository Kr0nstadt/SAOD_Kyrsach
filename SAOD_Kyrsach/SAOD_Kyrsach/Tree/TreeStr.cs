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

        private void BubbleSort(IList<NodeTree> list)
        {
            int n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (list[j].Compare(list[j],list[j + 1]) == -1)
                    {
                        // Меняем местами
                        NodeTree temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }
        private IList<NodeTree> PointCounter(IList<BookRecordAdapterGetLastNameByte> listBook)
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
            IList<NodeTree> List = new List<NodeTree>();
            foreach(var i in ResList)
            {
                List.Add(new NodeTree(i));
            }
            BubbleSort(List);
            return List;
        }

        public void Add(IList<BookRecordAdapterGetLastNameByte> listBook)
        {
            IList<NodeTree> nodes = PointCounter(listBook);
            for (int i = 0; i < nodes.Count; i++)
            {
                Root = AddToTree(Root, nodes[i]);
            }
        }

        private NodeTree AddToTree(NodeTree node, NodeTree value)
        {
            if (node == null)
                return value;
            else
            {
                if (value.Compare(value,node) == 1 || value.Compare(node,value) == 0)
                    node.Right = AddToTree(node.Right, value);
                else
                    node.Left = AddToTree(node.Left, value);
            }

            return node;
        }

       public List<NodeTree> Search( string key)
        {
            ResSearch = "";
            List<NodeTree> ResList = new List<NodeTree>();
            Search(Root,key,ResList);
            return ResList;
        }
        private void Search(NodeTree node, string key, List<NodeTree> list)
        {
            if(node == null) return;
            if (node.Value[0] == key[0]
                && node.Value[1] == key[1]
                && node.Value[2] == key[2])
            {
                list.Add(node);
                ResSearch += node.Value.ToString() + "\n";
            }
            Search(node.Left, key, list);
            Search(node.Right, key, list);
            
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
            return ResSearch;
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
 
        private string ResSearch = "";
        public string InOrderTraversal => _obh;
    }
}
