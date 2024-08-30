using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_Kyrsach.BookRecord
{
    public class BookRecord
    {
        

        public BookRecord(byte[] author, byte[] title, byte[] publisher, short yearPublishBytes, short countPagesBytes)
        {
            _author = new byte[author.Length];
            Array.Copy(author, _author, _author.Length);

            _title = new byte[title.Length];
            Array.Copy(title, _title, _title.Length);

            _publisher = new byte[publisher.Length];
            Array.Copy(publisher, _publisher, _publisher.Length);

            _yearPublishBytes = yearPublishBytes;
            _countPagesBytes = countPagesBytes;
        }

        public override string ToString()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            string result = string.Format($"{Encoding.Unicode.GetString(Encoding.Convert(Encoding.GetEncoding(866), Encoding.Unicode, _author)), -12} | " +
                                          $"{Encoding.Unicode.GetString(Encoding.Convert(Encoding.GetEncoding(866), Encoding.Unicode, _title)), -32} | " +
                                          $"{Encoding.Unicode.GetString(Encoding.Convert(Encoding.GetEncoding(866), Encoding.Unicode, _publisher)),-16} | " +
                                          $"{_yearPublishBytes,-5} | {_countPagesBytes,-5}");

            /*
            return Encoding.Unicode.GetString(Encoding.Convert(Encoding.GetEncoding(866), Encoding.Unicode, _author)) + "\t" +
            Encoding.Unicode.GetString(Encoding.Convert(Encoding.GetEncoding(866), Encoding.Unicode, _title)) + "\t" +
            Encoding.Unicode.GetString(Encoding.Convert(Encoding.GetEncoding(866), Encoding.Unicode, _publisher)) + "\t" +
            _yearPublishBytes + "\t" + _countPagesBytes;
            */

            return result;
        }

        public byte[] Author => _author;

        public byte[] Title => _title;

        public byte[] Publisher => _publisher;

        public short YearPublishBytes => _yearPublishBytes;

        public short CountPagesBytes => _countPagesBytes;

        private byte[] _author;
        private byte[] _title;
        private byte[] _publisher;
        private short _yearPublishBytes;
        private short _countPagesBytes;
    }
}
