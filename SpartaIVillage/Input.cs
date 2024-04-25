using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaIVillage
{
    internal class Input
    {
        //초기 잘못입력 시 
        public static void InputError()
        {
            Console.WriteLine(" --- 잘못된 입력입니다. --- ");
            Thread.Sleep(1000);
        }
    }
}
