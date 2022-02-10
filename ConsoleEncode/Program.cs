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


            #region 如果將中文字轉為ASCII 再轉回字串
            
            string chineseStrToASCII = "我是誰";

            // 得到3個字節 63的bytes 每個字節為 00111111
            // byte 一個字節範圍 0~255 
            byte[] chineseBytes = Encoding.ASCII.GetBytes(chineseStrToASCII);

            // 轉回字串後為 問號
            string chineseBytesToStr = Encoding.ASCII.GetString(chineseBytes);

            #endregion

            #region Unicode 轉換
            int unicodeNum = 65;

            // 轉為Char字符
            char unicodeNumToChar = (char)unicodeNum;
            // 將char 轉為字串
            string charToStr = unicodeNumToChar.ToString();

            // 直接將UTF32 代碼(char 10進位) 轉為字串
            string utf32ToStr = Char.ConvertFromUtf32(65);

            // 將char 轉為字串
            string asciichar = (Convert.ToChar(65)).ToString();
            #endregion

            #region 如何將文字檔編碼成 ANSI
            System.Text.Encoding.GetEncoding("big5");
            System.Text.Encoding.GetEncoding(950);
            #endregion

            # region MEMO
            string[] files = new string[] {
                // big5
                @"D:\011714\Test\ConsoleTEST\ConsoleTEST\bin\Debug\SUB_FID_01_20210429.TXT",
                // utf8
                @"D:\011714\Test\ConsoleTEST\ConsoleTEST\bin\Debug\SUB_FID_01_20211201.txt"
            };

            List<Encoding> encoderList = new List<Encoding>();
            foreach (var item in files)
                encoderList.Add(GetEncoding(File.ReadAllBytes(item)));
 
            Encoding big5 = Encoding.GetEncoding(950);
            Encoding utf8 = Encoding.GetEncoding(65001);
            Encoding unicode = Encoding.Unicode;
          
            //'\u6912'
            // ((char)161).ToString()
            //big5.GetBytes("ABC一二三")
            #endregion

            #region 將unicode 轉換為 UTF8
            // 1個byte(字節) = 8bit(位元)
            // 取得文字"一"的 unicode 編碼的 字節
            // 1個字節=1byte 拆出來後 會發現 "一" 有兩個字節
            // 順序讀取反過來 先讀 [1] 再讀[0]
            // 將兩者數字轉為2進位 拆成兩組字節 
            // 拆成3組 1110xxxx 10xxxxxx 10xxxxxx
            // 轉為10進位
            byte[] unicodeByte = Encoding.Unicode.GetBytes("一");

            string unicodeBit = string.Empty;

            // 10進位轉2進位 因為byte存的都是10進位
            for (int i = unicodeByte.Length - 1; i >= 0; i--)
                unicodeBit += Convert.ToString(unicodeByte[i], 2).PadLeft(8, '0');
            
            // 組合成Utf8格式的 byte[] 轉換後 會變成 三個字節
            string[] utf8BitArr = { $@"1110{unicodeBit.Substring(0, 4)}", $@"10{unicodeBit.Substring(4, 6)}", $@"10{unicodeBit.Substring(10, 6)}" };

            byte[] utf8byteArr = new byte[utf8BitArr.Length];

            for (int i = 0; i < utf8BitArr.Length; i++)
                utf8byteArr[i] = Convert.ToByte(utf8BitArr[i], 2);

            // 將utf8格式的Byte[] 轉成字串
            string convertResult = Encoding.UTF8.GetString(utf8byteArr);

            // 將字串轉為16進位
            string unicodeBase16 = string.Empty;
            for (int i = unicodeByte.Length - 1; i >= 0; i--)
                unicodeBase16 += Convert.ToString(unicodeByte[i], 16).PadLeft(2, '0');

            #endregion

            // 16進位 char
            char base16Char = '\u0058';


            // 取得 "一" 的Big5編碼
            byte[] big5Byte = big5.GetBytes("中");
            byte[] utf8Byte = utf8.GetBytes("測試");
            byte[] unicodeByteR = unicode.GetBytes("測試");
            // 將 Big5 的 byte[] 強制轉成 Unicode 的樣子 => 亂碼
            var big5ToUnicodeFail = Encoding.Unicode.GetString(big5Byte);

            // 將Utf8 的 byte[] 強制轉成 big5 的樣子 => 亂碼
            var utf8ToBig5Fail = big5.GetString(utf8Byte);
            int count = big5.GetByteCount(utf8ToBig5Fail);

            var utf8ToUtf8 = utf8.GetString(utf8Byte);
            int count1 = utf8.GetByteCount(utf8ToUtf8);

            // 測試檢測方法
            var test = GetEncoding(utf8Byte);

            string testStr = "測試Unicode轉UTF8所用的字串";

            string testStrResult = string.Empty;

            foreach (var item in testStr)
            {
                var convResult = UnicodeConvertUtf8(item.ToString());

                testStrResult += utf8.GetString(convResult);
            }
            
            // 黑暗大的解法 bak
            //https://blog.darkthread.net/blog/detect-big5-encoding/

            // base64
            // https://blog.hungwin.com.tw/csharp-convert-tobase64string/
            // https://www.monkiapp.co/tw/base64-%E8%A7%A3%E5%AF%86-%E8%A7%A3%E7%A2%BC

            //Code page 編碼代碼 bak
            //https://en.wikipedia.org/wiki/Code_page

            // Unicode Range bak
            //https://coolong124220.nidbox.com/diary/read/9970811
            //https://blog.miniasp.com/post/2019/01/02/Common-Regex-patterns-for-Unicode-characters

            //BIG-5碼介紹 bak
            //https://heavenchou.buddhason.org/node/23?page=8
            //http://www.cns11643.gov.tw/pageView.jsp?ID=11&SN=&lang=tw

            //編碼介紹 bak
            //https://www.itread01.com/content/1548441494.html
            //https://blog.csdn.net/Wikey_Zhang/article/details/76544172
            //https://blog.csdn.net/qq_41866516/article/details/97836918?spm=1001.2101.3001.6661.1&utm_medium=distribute.pc_relevant_t0.none-task-blog-2~default~BlogCommendFromBaidu~Rate-1.pc_relevant_default&depth_1-utm_source=distribute.pc_relevant_t0.none-task-blog-2~default~BlogCommendFromBaidu~Rate-1.pc_relevant_default&utm_relevant_index=1

            //Unicode To UTF-8 16 32 bak
            //https://www.readfog.com/a/1638084002220969984

            //字節單位 bak
            //http://blog.itpub.net/69955379/viewspace-2676766/

            // C# ASCII Character Code in C# bak
            //https://stackoverflow.com/questions/3414900/how-to-get-a-char-from-an-ascii-character-code-in-c-sharp

            // 轉換工具 bak
            //https://www.convertworld.com/zh-hant/numerals/hexadecimal.html
        }

        public static Encoding GetEncoding(byte[] byteArr)
        {
            Encoding result = Encoding.GetEncoding(950);
            Encoding big5 = Encoding.GetEncoding(950);
            Encoding utf8 = Encoding.GetEncoding(65001);

            // 讀取的檔案byte長度 == 編碼big5 轉byteCount 且 讀取的檔案byte長度 != 編碼 Utf8 轉byteCount 時為Big5
            // 讀取的檔案byte長度 == 編碼big5 轉byteCount 且 讀取的檔案byte長度 == 編碼 Utf8 轉byteCount 時為Utf8
            if (byteArr.Length == big5.GetByteCount(big5.GetString(byteArr)))
                result = (byteArr.Length != utf8.GetByteCount(utf8.GetString(byteArr))) ? Encoding.GetEncoding(950) : Encoding.GetEncoding(65001);
            else
            {
                // 讀取的檔案byte長度 != 編碼big5 轉byteCount 且 讀取的檔案byte長度 == 編碼 Utf8 轉byteCount 時為Utf8
                // 讀取的檔案byte長度 != 編碼big5 轉byteCount 且 讀取的檔案byte長度 != 編碼 Utf8 轉byteCount 時 不明物體
                if (byteArr.Length == utf8.GetByteCount(utf8.GetString(byteArr)))
                    result = Encoding.GetEncoding(65001);
                else
                {
                    // 不明物體
                }
            }

            return result;
        }

        /// <summary>
        /// 一次傳一個字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] UnicodeConvertUtf8(string str)
        {
            byte[] unicodeByte = Encoding.Unicode.GetBytes(str);

            // 對於單字節的符號，字節的第一位設爲 0，後面 7 位爲這個符號的 Unicode 碼。因此對於英語字母，
            // UTF-8 編碼和 ASCII 碼是相同的, 所以 UTF-8 能兼容 ASCII 編碼，這也是互聯網普遍採用 UTF-8 的原因之一
            if (unicodeByte[0] != 0 && unicodeByte[1] == 0)
                return new byte []{ unicodeByte[0] };

            string unicodeBit = string.Empty;

            // 10進位轉2進位 因為byte存的都是10進位
            for (int i = unicodeByte.Length - 1; i >= 0; i--)
                unicodeBit += Convert.ToString(unicodeByte[i], 2).PadLeft(8, '0');

            // 組合成Utf8格式的 byte[] 轉換後 會變成 三個字節
            string[] utf8BitArr = { $@"1110{unicodeBit.Substring(0, 4)}", $@"10{unicodeBit.Substring(4, 6)}", $@"10{unicodeBit.Substring(10, 6)}" };

            byte[] utf8byteArr = new byte[utf8BitArr.Length];

            for (int i = 0; i < utf8BitArr.Length; i++)
                utf8byteArr[i] = Convert.ToByte(utf8BitArr[i], 2);

            // 將utf8格式的Byte[] 轉成字串
            //string convertResult = Encoding.UTF8.GetString(utf8byteArr);

            return utf8byteArr;
        }
    }
}
