using System.IO;
using System.Text;
using static System.Console;
using System;

namespace SystemFile
{
    static class Program
    {
        
        static void Main()
        {
           using (Stream stream = new FileStream("./tets.txt", FileMode.Truncate ))
            {
                string Test = "апролдавпро";  //windows-1251
                //utf-8
                byte[] Bytes = Encoding.Unicode.GetBytes(Test);
                //byte[] BadBytes = { 250 };
                //stream.Write(BadBytes, 0, 1);
                stream.Write(Bytes, 0, Bytes.Length);
            }
            using (Stream stream = new FileStream("./tets.txt", FileMode.Open))
            {
                long len = stream.Length;
                byte[] Bytes = new byte[len];
                int readed = stream.Read(Bytes, 0, Bytes.Length-1);
                
               // WriteLine(Encoding.Unicode.GetString(Bytes));
                Encoding.Unicode.GetString(Bytes, 0, readed);
            }
              ReadKey();
        }
    }
}
