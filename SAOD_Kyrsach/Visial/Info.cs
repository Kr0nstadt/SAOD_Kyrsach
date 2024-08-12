using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using SAOD_Kyrsach;
using SAOD_Kyrsach.BookRecord;
using SAOD_Kyrsach.DigitalSort;
using System.Threading.Tasks;
using Avalonia.Controls;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Visual
{
    internal class Info
    {
        public Info()
        {
            using (FileStream fs = new FileStream(@"C:\Users\karpo\OneDrive\Рабочий стол\SAOD_Kyrsach\SAOD_Kyrsach/testBase1.dat",
                   FileMode.Open))
            {
                byte[] author = new byte[12];
                byte[] title = new byte[32];
                byte[] publisher = new byte[16];
                byte[] yearPublishBytes = new byte[4];
                byte[] countPagesBytes = new byte[4];
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
                        BookRecord bookRecord = new BookRecord(author, title, publisher, yearPublish, countPages);
                        _listBook.Add(new BookRecordAdapterGetLastNameByte(bookRecord));
                    }
                }
            }

            TextInfo textBefSort = new TextInfo(_listBook, _countLine);
            _textBefSort = textBefSort;

            if (_listBook is IList<IByteGetter> listOfBytesGetter)
            {
                DigitalSort.Sort(listOfBytesGetter);
            }

            TextInfo textAftSort = new TextInfo(_listBook, _countLine);
            _textAftSort = textAftSort;

        }
        public string TextBefSort => _textBefSort.ToString();
        public string TextAftSort => _textAftSort.ToString();
        public IList<IByteGetter> ListBef => _listBef;
        public IList<IByteGetter> ListAft => _listAft;
        public int CountLine
        {
            get
            {
                return _countLine;
            }
            set
            {
                _countLine += value;
            }
        }

        private TextInfo _textAftSort;
        private TextInfo _textBefSort;

        private IList<IByteGetter> _listBef;
        private IList<IByteGetter> _listAft;
        private List<IByteGetter> _listBook = new List<IByteGetter>();
        private int _countLine = 20;
    }
}
