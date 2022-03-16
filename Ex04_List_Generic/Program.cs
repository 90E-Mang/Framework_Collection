using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04_List_Generic
{
    // ArrayList가 Object 타입을 가지고 노는 것에 대한 반기 >> 반환시 복잡한 casting 문제가 생김
    // TIP) JAVA : AraayList<int> list = new ArrayList<int>();
    // ㄴ> JAVA : interface     List<int> list = new ArrayList<int>();   다형성

    // C# : Arraylist list = new ArrayList();       list.add(Object);
    // C# : List<int> list = new List<int>;         list.add(int);

    class Account
    {
        public string num;
        public string name;

        public Account(string num, string name)
        {
            this.num = num;
            this.name = name;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(); // 타입강제
            // list.Add("가나다"); <- 타입이 위에서 int로 강제되었기 때문에 넣을 수 없다.
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            foreach(int item in list)
            {
                Console.WriteLine($"item : {item}");
            }
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"item : {list[i]}");
            }

            List<bool> list2 = new List<bool>();
            list2.Add(true);
            list2.Add(false);
            Console.WriteLine(list2.Count);
            list2.Clear();
            Console.WriteLine($"Clear : {list2.Count}");


            // Practice
            int[] array = { 10,20,30};

            List<int> list3 = new List<int>(array); // 생성자의 parameter로 배열을 받을 수 있다 -- > IEnumerable을 구현하고 하위자원을 올 수 있다.(다형성)
            Console.WriteLine(list3.Count);

            // 사용 (객체타입의 List !! 매우 중요하다 개발할때 밥먹듯이 쓴다 !! 무조건 중요 !)
            List<Account> list4 = new List<Account>();
            list4.Add(new Account("111", "이맹기"));
            list4.Add(new Account("111", "개김치"));
            list4.Add(new Account("111", "동차르"));
            list4.Add(new Account("111", "개욱타"));

            //foreach (Account account in list4)
            //{
            //    Console.WriteLine($"번호 : {(Account)account.num}, 이름 : {(Account)account.name}");
            //}
            foreach (Account account in list4)
            {
                Console.WriteLine($"번호 : {account.num}, 이름 : {account.name}");
            }
        }
    }
}
