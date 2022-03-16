using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex01_ArrayList
{
    
    class Program
    {
        public static void PrintValues(IEnumerable myList)      // 인터페이스 객체참조변수를 parameter를 받는 부분이 keypoint ! (다형성)
        {                                                       // IEumerable을 부모 타입으로 가지는 모든 자식은 parameter로 올 수 있다. 
            IList li = (IList)myList;                           // 그렇다고 해서 자식의 자원에 접근 불가(단, 자식이 구현한 추상메서드는 자식 자원에 접근)
            Console.WriteLine($"count : {li.Count}");
            foreach (Object obj in myList)
                Console.Write("   {0}", obj);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            // Collection을 구현하고 있는 (상속) 대표적인 클래스
            // ArrayList 
            // 동적으로 데이터를 관리 할 수 있는 클래스 !
            // using System.Collections; 아래에 있는 자원

            // ArrayList는 내부적으로 데이터를 Array로 관리한다.
            // 순차적인 데이터에 추가, 삭제 시 성능이 좋음. 
            // 그렇다면 데이터의 추가, 삭제를 데이터의 중간위치에서 할때 좋은 것은 ? -> linkedlist! (노드를 활용)


            ArrayList list = new ArrayList();
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add(10);
            list.Add(20);
            list.Add(30);

            foreach (int temp in list)
            {
                Console.WriteLine($"temp : {temp}");
            }
            Console.WriteLine($"list.count : {list.Count}"); // length는 전체 사이즈, count는 값이 있는 것의 갯수

            
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"list : [{i}]");
            }

            Console.WriteLine("list ArrayList");
            Console.WriteLine($"count : {list.Count}");
            Console.WriteLine($"Capacity : {list.Capacity}"); // Capacity는 수용 가능 용량.

            ////////////////////////////////////////////////////////////////////////////////

            // Creates and initializes a new ArrayList.
            ArrayList myAL = new ArrayList();
            myAL.Add("The");
            myAL.Add("quick");
            myAL.Add("brown");
            myAL.Add("fox");
            myAL.Add("jumps");
            myAL.Add("over");
            myAL.Add("the");
            myAL.Add("lazy");
            myAL.Add("dog");
            
            

            // Displays the ArrayList.
            Console.WriteLine("The ArrayList initially contains the following:");
            PrintValues(myAL);

            // Removes the element containing "lazy".
            myAL.Remove("lazy");

            // Displays the current state of the ArrayList.
            Console.WriteLine("After removing \"lazy\":");
            PrintValues(myAL);

            // Removes the element at index 5.
            myAL.RemoveAt(5);

            // Displays the current state of the ArrayList.
            Console.WriteLine("After removing the element at index 5:");
            PrintValues(myAL);

            // Removes three elements starting at index 4.
            myAL.RemoveRange(4, 3);

            // Displays the current state of the ArrayList.
            Console.WriteLine("After removing three elements starting at index 4:");
            PrintValues(myAL);
        }
    }
}
