using SAOD_Kyrsach.BookRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kyrsach.DigitalSort
{
    public static class DigitalSort
    {
        public static void Sort(IList<BookRecordAdapterGetLastNameByte> list)
        {
            Queue<BookRecordAdapterGetLastNameByte> queue = new Queue<BookRecordAdapterGetLastNameByte>(list);
            const int nQueues = 256;
            Queue<BookRecordAdapterGetLastNameByte>[] tempQueues = new Queue<BookRecordAdapterGetLastNameByte>[nQueues];
            tempQueues = tempQueues.Select(q => new Queue<BookRecordAdapterGetLastNameByte>()).ToArray();
            int maxBytesCount = queue.Max(x => x.CountByte);
            for (int i = 0; i < maxBytesCount; ++i)
            {
                while (queue.Count > 0)
                {
                    BookRecordAdapterGetLastNameByte qItem = queue.Dequeue();
                    tempQueues[qItem.GetByte(maxBytesCount - i - 1)].Enqueue(qItem); 
                }

                foreach (Queue<BookRecordAdapterGetLastNameByte> q in tempQueues)
                {
                    while (q.Count > 0)
                    {
                        queue.Enqueue(q.Dequeue());
                    }
                }
            }

            list.Clear();
            
            foreach(BookRecordAdapterGetLastNameByte byteGetter in queue)
            {
                list.Add(byteGetter);
            }
        }
    }
}
