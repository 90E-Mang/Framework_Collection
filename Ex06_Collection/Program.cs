using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex06_Collection
{
    // 실무 또는 회사코테 문제 등으로 가장 많이 쓰는 것 List<>랑 Dictionary<> !! 이 두개는 무조건 내야됨 !!!!
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            List<string> list2 = new List<string>();

            // stack (LIFO - Last in First Out 후입선출)
            Stack stack = new Stack();
            
            // 데이터 입력 .push
            stack.Push("aaa");
            stack.Push("bbb");

            // 데이터 꺼내보기 .pop

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            // Console.WriteLine(stack.Pop()); --> 업는데 꺼내면 예외떨어짐

            // stack도 Generic 됨 type 강제 가능
            Stack<int> stack2 = new Stack<int>();

            // 그래서 이렇게 넣어야 됨. 중복값 넣어도 문제 없다. 어차피 인덱스로 구분해서 찾기 때문
            stack2.Push(1); //[0]
            stack2.Push(1); //[1]
            stack2.Push(1); //[2]

            // queue (FIFO - First in First Out 선입선출)

            Queue queue = new Queue();

            // queue에 데이터 삽입 .Enqueue
            queue.Enqueue(100);
            queue.Enqueue(200);
            queue.Enqueue(300);

            // 데이터 꺼내기 .Dequeue
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            //Console.WriteLine(queue.Dequeue());    <-- queue도 가진거 보다 많이 꺼내면 예외가 떨어짐

            // 얘도 generic 됨. 문법은 같음
            Queue<string> queue2 = new Queue<string>();

            // Hashtable(java의 hashmap과 같음. key - value로 이루어짐)
            Hashtable ht = new Hashtable();
           
            // 데이터 삽입 .Add(key값, value값)
            ht.Add("A", "사과 개 존맛");
            ht.Add("B", "바나나 개 존맛");
            ht.Add("O", "오랜지 개 존맛");
            //ht.Add("O", "오랜지 개 존맛");   <-- 여기서 이미 있는 O를 key값으로 추가하게 되면 예외가 떨어짐.

            // key 값이 있는지 찾는 함수 .ContainsKey(key값) --> bool 형 반환.
            Console.WriteLine(ht.ContainsKey("O"));

            // key의 집합 뽑기 - return은 Icolloecton 타입
            ICollection ic = ht.Keys;       //  keys의 property(get{})가 내부적으로 list 객체를 생성(new list)하고 주소값을 리턴해서 ic로 줌
                                            //  근데 인터페이스는 미구현 자원들만 있는데 아래 클래스에 구현된놈(재정의된 곳)으로 던져주니까 쓸 수 있음.
            foreach (string key in ic)
            {
                Console.WriteLine(key);
            }

            // key, value를 한번에 보려고 한다면 ? --> DictionaryEntry 로 이게 key와 value를 한번에 준다.
            foreach (DictionaryEntry item in ht)        //Hashtable ht = new Hashtable(); 
            {
                Console.WriteLine($"key : {item.Key}, value : {item.Value}");
            }

            Dictionary<string, string> ht2 = new Dictionary<string, string>();
            ht2.Add("A", "사과 개 존맛");
            ht2.Add("B", "바나나 개 존맛");
            ht2.Add("O", "오랜지 개 존맛");

            //////////////////////////////////////////////////////////////////////////
            // 게시판   댓글 -----> 1 : 다 관계, Dictionary에 List<>를 써서 해결 !
            /*
                1, 홍길동, 방가방가
                2, 김유신, 방가

                댓글
                1, 1, 나도방가
                2, 1, 정말방가

            --> Dictionary<1, List<>> 로 묶기 가능 !! 1대 다 관계에서 활용방안이 무궁무진함
             */
            // 1. List<>
            // 2. Dictionary<,>

            foreach (KeyValuePair<string,string> item in ht2)
            {
                Console.WriteLine($"[{item.Key},{item.Value}]");
            }

            // var 타입으로 하면 이렇게 편하다. 생산성과 효율에선 좋은데 코드의 명확성을 위해서는 위쪽방법도 잘 써야됨.
            foreach (var item in ht2)
            {
                Console.WriteLine($"[{item.Key},{item.Value}]");
            }

            // SortedList -- 얘도 generic이 있음.
            SortedList so = new SortedList();
            SortedList<int, string> so2 = new SortedList<int, string>();

            // SortedList는 이렇게 데이터를 삽입하면 뒤에 삽입되는 애들을 내부적으로 비교해서 정렬해주면서(key의 순서대로) 들어간다.
            so.Add(10,"F");
            so.Add(3, "D");
            so.Add(31, "K");
            so.Add(1, "A");
            Console.WriteLine(so.GetKey(0));
            Console.WriteLine(so.IndexOfValue("D"));
            IList solist = so.GetKeyList();

            foreach (int item in solist)
            {
                Console.WriteLine(item);
            }
            solist = so.GetValueList();
            foreach (string item in solist)
            {
                Console.WriteLine(item);
            }
        }
    }
}
/*
  1. ArrayList  >> List<T>          매우 중요
  2. Stack      >> Stack<T>         기본      --> 무조건 암기 ~!
  3. Queue      >> Queue<T>         기본
  4. HashTable  >> Dictionary<T,V>  매우 중요
  5. SortedList >> SortedList<T,V>
  6. linkedList
  
 */
