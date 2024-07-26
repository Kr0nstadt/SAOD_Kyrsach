using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kyrsach
{
    internal class ByteStruct
    {
        private byte[] author;
        private byte[] title;
        private byte[] publisher;
        private short yearPublishBytes;
        private short countPagesBytes;

        public Queue<ByteStruct> bytes;

        public ByteStruct()
        {
            MakeQueue();
        }
        public ByteStruct(byte[] author, byte[] title, byte[] publisher, short yearPublishBytes, short countPagesBytes)
        {
            this.author = author;
            this.title = title;
            this.publisher = publisher;
            this.yearPublishBytes = yearPublishBytes;
            this.countPagesBytes = countPagesBytes;
        }

        private void MakeQueue()
        {
            bytes = new Queue<ByteStruct>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (FileStream fs = new FileStream(@"testBase1.dat",
                       FileMode.Open))
            {
                byte[] author = new byte[12];
                byte[] title = new byte[32];
                byte[] publisher = new byte[16];
                short yearPublish = 0;
                short countPages = 0;



                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (fs.Read(author) != 0)
                    {
                        int count = fs.Read(title);
                        count = fs.Read(publisher);
                        yearPublish = br.ReadInt16();
                        countPages = br.ReadInt16();
                        bytes.Enqueue(new ByteStruct(author,title,publisher,yearPublish,countPages));   
                    }
                }
            }

        }
    }
}
