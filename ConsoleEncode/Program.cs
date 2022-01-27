using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEncode
{
    class Program
    {
        static void Main(string[] args)
        {
            // ASCII碼表 包含 英文 數字 符號 總共255碼
            // char = unicode 且包含 ASCII
            // Dec 十進位 0~127 標準的 ASCII 編碼, 128~255 擴展的 ASCII 編碼


            // ASCII轉換
            string str = "我是誰";

            byte[] bytes = Encoding.ASCII.GetBytes(str);

            string someString = Encoding.ASCII.GetString(bytes);

            // Unicode 轉換
            int unicode = 65;
            char character = (char)unicode;
            string text = character.ToString();

            string c = Char.ConvertFromUtf32(65);

            string asciichar = (Convert.ToChar(65)).ToString();

            // 如何將文字檔編碼成 ANSI
            System.Text.Encoding.GetEncoding("big5");
            System.Text.Encoding.GetEncoding(950);

            //MEMO
            string[] files = new string[] {
                @"D:\011714\Test\ConsoleTEST\ConsoleTEST\bin\Debug\SUB_FID_01_20210429.TXT",
                @"D:\011714\Test\ConsoleTEST\ConsoleTEST\bin\Debug\SUB_FID_01_20211201.txt"
            };

            string big = string.Empty;

            string utf = string.Empty;
            big = File.ReadAllText(files[0], Encoding.UTF8);
            var bigByte = File.ReadAllBytes(files[0]);

            var loon = Encoding.GetEncoding(950).GetByteCount(big);

            var fileBytes = File.ReadAllBytes(files[1]);
            Encoding big5 = Encoding.GetEncoding(950);

            Encoding encode = (fileBytes.Length == big5.GetByteCount(big5.GetString(fileBytes))) ? Encoding.GetEncoding(950) : Encoding.GetEncoding(65001);

            char ttt = '\u0058';
            var test1 = big5.GetBytes("一");
           

        }
    }
}
