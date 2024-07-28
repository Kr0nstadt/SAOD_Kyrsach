using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kyrsach
{
    internal class SortBook 
    {
        private Queue<ByteStruct> books;
        public SortBook(Queue<ByteStruct> list)
        {
            books = list;
        }
        /*private Queue<ByteStruct> DigitalSort(Queue<ByteStruct> list, int nByte)
        {
            Queue<byte[]> queue = new Queue<byte[]>();
            const int nQueues = 256;
            Queue<byte[]>[] tempQueues = new Queue<byte[]>[nQueues];//тут точно 256?
            tempQueues = tempQueues.Select(q => new Queue<byte[]>()).ToArray();
            int maxBytesCount = queue.Max(x => x.Length);
            for (int i = 0; i < maxBytesCount; ++i)
            {
                while (queue.Count > 0)
                {
                    byte[] qItem = queue.Dequeue();
                    tempQueues[qItem[i]].Enqueue(qItem);
                }

                foreach (Queue<byte[]> q in tempQueues)
                {
                    if (q.Count > 0)
                    {
                        while (q.Count > 0)
                        {
                            queue.Enqueue(q.Dequeue());
                        }
                    }
                }
            }

            return queue;
        }*/
    }
}
