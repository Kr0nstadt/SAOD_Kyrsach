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

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
             au = Encoding.Unicode.GetString(Encoding.Convert(Encoding.GetEncoding(866), Encoding.Unicode, _author));
             tit = Encoding.Unicode.GetString(Encoding.Convert(Encoding.GetEncoding(866), Encoding.Unicode, _title));
            pub = Encoding.Unicode.GetString(Encoding.Convert(Encoding.GetEncoding(866), Encoding.Unicode, _publisher));
            yea = _yearPublishBytes.ToString();
             cou = _countPagesBytes.ToString();
        }
        string au;
        string tit;
        string pub;
        string yea;
        string cou;
        public override string ToString()
        {
            string result = au + tit + pub + yea + " "  +cou;            
            return result;
        }
        private string GetName()
        {
            string txt = tit;
            string[] array = txt.Split(' ');
            return array[2];
        }
      
       public string title => GetName();
        public byte[] Author => _author;

        public byte[] Title => _title;

        public byte[] Publisher => _publisher;

        public short yearPublishBytes => _yearPublishBytes;

        public short CountPagesBytes => _countPagesBytes;

        private byte[] _author;
        private byte[] _title;
        private byte[] _publisher;
        private short _yearPublishBytes;
        private short _countPagesBytes;
    }
}
