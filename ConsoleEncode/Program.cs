using System;
using System.Collections.Generic;
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


            string str = "我是誰";

            byte[] bytes = Encoding.ASCII.GetBytes(str);

            string someString = Encoding.ASCII.GetString(bytes);
        }
    }
}
