using System;
using System.Collections;
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
            BitArray a = new BitArray(test1);
            //'\u6912'
            // ((char)161).ToString()
            //big5.GetBytes("ABC一二三")

            // 判斷開頭 來驗證 big5 utf8
            //https://eric0806.blogspot.com/2014/07/detect-file-encoding-utf8.html
            // 黑暗大的解法
            //https://blog.darkthread.net/blog/detect-big5-encoding/

            // base64
            // https://blog.hungwin.com.tw/csharp-convert-tobase64string/
            // https://www.monkiapp.co/tw/base64-%E8%A7%A3%E5%AF%86-%E8%A7%A3%E7%A2%BC

            //Code page 編碼代碼
            //https://en.wikipedia.org/wiki/Code_page

            //認識中文字元碼
            //https://idv.sinica.edu.tw/bear/charcodes/Section07.htm
            //https://idv.sinica.edu.tw/bear/charcodes/Section09.htm

            // Unicode Range
            //https://coolong124220.nidbox.com/diary/read/9970811
            //https://blog.miniasp.com/post/2019/01/02/Common-Regex-patterns-for-Unicode-characters

            //BIG-5碼介紹
            //https://heavenchou.buddhason.org/node/23?page=8
            //http://www.cns11643.gov.tw/pageView.jsp?ID=11&SN=&lang=tw

            //編碼介紹
            //https://www.itread01.com/content/1548441494.html
            //https://blog.csdn.net/Wikey_Zhang/article/details/76544172
            //https://blog.csdn.net/qq_41866516/article/details/97836918?spm=1001.2101.3001.6661.1&utm_medium=distribute.pc_relevant_t0.none-task-blog-2~default~BlogCommendFromBaidu~Rate-1.pc_relevant_default&depth_1-utm_source=distribute.pc_relevant_t0.none-task-blog-2~default~BlogCommendFromBaidu~Rate-1.pc_relevant_default&utm_relevant_index=1

            //Unicode To UTF-8 16 32
            //https://www.readfog.com/a/1638084002220969984

            //字節單位
            //http://blog.itpub.net/69955379/viewspace-2676766/

            // C# ASCII Character Code in C#
            //https://stackoverflow.com/questions/3414900/how-to-get-a-char-from-an-ascii-character-code-in-c-sharp

            // 轉換工具
            //https://www.convertworld.com/zh-hant/numerals/hexadecimal.html






        }
    }
}
