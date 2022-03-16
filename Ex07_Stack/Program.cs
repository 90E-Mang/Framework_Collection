using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex07_Stack
{
    // stack은 어떻게 돌아가는지 무조건 암기 !!!! 기본이다 !!
    // LIFO - Last In First Out   후입선출
    // 내부적으로 array !

    class MyStack       
    {
        object[] items;     // 저장 구조(타입)
        int stackpointer = 0;       // 정적 배열의 위치 정보를 저장
        readonly int s_size;        // 실제 방의 갯수가 몇개인지 비교를 하기 위해 상수값 !
        public MyStack() : this(100)
        {
            
        }
        public MyStack(int size)
        {
            this.s_size = size;
            items = new object[this.s_size];
        }
        public void Push(object item)
        {
            if (stackpointer >= s_size)
            {
                throw new InvalidOperationException("stack full");
            }
            items[stackpointer] = item;
            stackpointer++;         // 포인터를 데이터 넣은 다음 방으로 이동 시킴 !
        }
        public object Pop()
        {
            stackpointer--;
            if (stackpointer >= 0)
            {
                return items[stackpointer];
            }
            else
            {
                stackpointer = 0;  //포인터 초기화
                throw new InvalidOperationException("stack empty");
            }
        }
    }

    // 제너릭 클래스 만들기
    // GStack<string> 으로 적으면 클래스 내의 T가 되있는 곳에 다 string으로 들어감 !
    class GStack<T>
    {
        T[] items;     // 저장 구조(타입)
        int stackpointer = 0;       // 정적 배열의 위치 정보를 저장
        readonly int s_size;        // 실제 방의 갯수가 몇개인지 비교를 하기 위해 상수값 !
        public GStack() : this(100)
        {

        }
        public GStack(int size)
        {
            this.s_size = size;
            items = new T[this.s_size];             // T가 int면 items = new int[this.s_size];
                                                    // T가 string이면 items = new string[this.s_size];   이렇게 알아서 됨.
        }
        public void Push(T item)                    // parameter도 T로 받고
        {
            if (stackpointer >= s_size)
            {
                throw new InvalidOperationException("stack full");
            }
            items[stackpointer] = item;
            stackpointer++;         // 포인터를 데이터 넣은 다음 방으로 이동 시킴 !
        }
        public T Pop()                              // return 값도 T로 !
        {
            stackpointer--;
            if (stackpointer >= 0)
            {
                return items[stackpointer];
            }
            else
            {
                stackpointer = 0;  //포인터 초기화
                throw new InvalidOperationException("stack empty");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // stack 클래스 자체는 C# API에서 제공해주는 자원이다.
            // 그럼에도 불구하고 내부적인 구현방법을 이해해야된다 !!
            Stack stack = new Stack();          // C# API가 제공하는 Stack 알고리즘 !
            MyStack stack2 = new MyStack(3);

            stack2.Push(10);
            stack2.Push(20);
            stack2.Push(30);
            // stack2.Push(40);

            MyStack s = new MyStack(3);
            s.Push(20);
            s.Push(30);
            s.Push(40);
            // s.Push(50);

            int number = (int)s.Pop();  //[object][object][object] 
            Console.WriteLine(number);   //다운 캐스팅 ....
            int number2 = (int)s.Pop();
            Console.WriteLine(number2);
            int number3 = (int)s.Pop();
            Console.WriteLine(number3);

            GStack<int> gStack = new GStack<int>(5);
            gStack.Push(10);
            gStack.Push(20);
            gStack.Push(30);
            gStack.Push(40);

            int data = gStack.Pop();        // casting 문제를 해결 !
            Console.WriteLine($"data : {data}");
        }
    }
}
