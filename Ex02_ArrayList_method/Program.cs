using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex02_ArrayList_method
{
    class Program
    {
        public static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.Write("   {0}", obj);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            // Creates and initializes a new ArrayList.
            ArrayList myAL = new ArrayList();
            myAL.Add("The");
            myAL.Add("quick");
            myAL.Add("brown");
            myAL.Add("fox");
            myAL.Add("jumps");

            // Displays the count, capacity and values of the ArrayList.
            Console.WriteLine("Initially,");
            Console.WriteLine("   Count    : {0}", myAL.Count);
            Console.WriteLine("   Capacity : {0}", myAL.Capacity);
            Console.Write("   Values:");
            PrintValues(myAL);

            // Trim the ArrayList.
            myAL.TrimToSize();      // Count의 크기와 수용량을 맞추는 함수.

            // Displays the count, capacity and values of the ArrayList.
            Console.WriteLine("After TrimToSize,");
            Console.WriteLine("   Count    : {0}", myAL.Count);
            Console.WriteLine("   Capacity : {0}", myAL.Capacity);
            Console.Write("   Values:");
            PrintValues(myAL);

            // Clear the ArrayList.
            myAL.Clear();   // 모든 요소를 제거함. (수용량은 그대로 존재)

            // Displays the count, capacity and values of the ArrayList.
            Console.WriteLine("After Clear,");
            Console.WriteLine("   Count    : {0}", myAL.Count);
            Console.WriteLine("   Capacity : {0}", myAL.Capacity);
            Console.Write("   Values:");
            PrintValues(myAL);

            //////////////////////////////////////////////////////////////////////////////
            // 사실 insert는 ArrayList에서 효율이 안좋기 때문에 성능상 안좋음.
            // insert로 기존 자리에 삽입하면 기존자리 부터 뒤에 있는 모든 요소를 뒤로 1칸 밀어냄
            ArrayList myAL2 = new ArrayList();
            myAL2.Insert(0, "The");
            myAL2.Insert(1, "fox");
            myAL2.Insert(2, "jumps");
            myAL2.Insert(3, "over");
            myAL2.Insert(4, "the");
            myAL2.Insert(5, "dog");
            PrintValues(myAL2);

            myAL2.Insert(1, "fox!!!!!!!");
            PrintValues(myAL2);
        }
    }
}
