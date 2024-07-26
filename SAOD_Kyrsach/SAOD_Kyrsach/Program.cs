using SAOD_Kyrsach;
using System.Text;

class MainClass
{
    static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        List<Book> ListBook = new List<Book>();
        using (FileStream fs = new FileStream(@"./testBase1.dat",
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

                    string authorString =
                        Encoding.Unicode.GetString(Encoding.Convert(Encoding.GetEncoding(866), Encoding.Unicode, author));
                    string titleString =
                        Encoding.Unicode.GetString(Encoding.Convert(Encoding.GetEncoding(866), Encoding.Unicode, title));
                    string publisherString =
                        Encoding.Unicode.GetString(Encoding.Convert(Encoding.GetEncoding(866), Encoding.Unicode, publisher));
                    ListBook.Add(new Book(authorString, titleString, publisherString, yearPublish, countPages));
                }
            }
        }
        ListBook.Sort();
        foreach(Book item in ListBook)
        {
            Console.WriteLine(item);
        }

    }
}