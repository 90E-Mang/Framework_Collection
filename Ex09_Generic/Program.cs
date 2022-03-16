using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex09_Generic
{
    class Person    // DTO, VO, DOMAIN (데이터를 담을 수 있는 클래스)
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Person() { }
        public Person(string name, string phone, string email)
        {
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
        }
        public override string ToString()
        {
            return $"Name : {Name}  Phone : {Phone}  Email : {Email}";
        }
    }

    // MSDN에서 인터페이스를 보고 구현해야되는 것을 찾아서 직접 클래스 만들어서 구현해보기 예제.
    // 난이도 높고 중요한 예제임 !

    // class List<>   <-- 얘도 IEnumerable, IEnumerator 구현한거임.
    class PersonList : IEnumerable, IEnumerator // 옆의 둘을 구현한다는 것은 열거된 자원에 대해서 순차적으로 접근해서 데이터를 read하겠다는 말
    {
        private ArrayList persons = new ArrayList();
        // private List<Person> persons = new List<Person>(); // 사실 이게 더 좋은 방법
        private int pos = -1; // 포인터의 reset 값으로 줄 거임

        public void Add(Person person)
        {
            persons.Add(person);
        }
        public void Add(string name, string phone, string email)
        {
            persons.Add(new Person(name,phone,email));
        }
        // IEnumerator 구현
        public IEnumerator GetEnumerator()
        {
            // IEnumerator를 상속받아서 구현하고 있는 객체의 주소를 리턴해야됨.
            return this;
        }
        public object Current { get { return persons[pos]; } }  // Property 구현 -> get의 로직을 구현 !

        public bool MoveNext()          // bool type가 return 되도록 로직 구현 !
        {
            if (pos + 1 < persons.Count)
            {
                pos++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Reset()         // 실행블럭에 초기화 작업. 보통 배열의 reset은 -1 넣어서 함.
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person(); // <- 데이터 1건 담기

            //List<Person> list = new List<Person>(); // <- 데이터 1건 이상
            PersonList personList = new PersonList();
            for (int i = 0; i < 10; i++)
            {
                personList.Add("Ne"+i, "Ph"+i, "Em"+i); 
            }
            //foreach (Person person in personList)
            //foreach (var person in personList)
            //{
            //    Console.WriteLine(person.ToString());      // Person class에서 tostring 재정의 했음 !
            //}

            IEnumerator ie = personList.GetEnumerator();
            // 위 코드는 ie에 PersonList 객체의 주소값이 전달됨.

            while (ie.MoveNext())
            {
                Console.WriteLine(ie.Current.ToString());
            }
            
            // 앞부분의 Dictionary<int, string>는 var로 써도 됨.
            Dictionary<int, string> dictionary = new Dictionary<int, string>()
            {
                {0,"value_0" },
                {1,"value_1" },
                {2,"value_2" }
            };
            // 초기화 바로 하기

            for (int index = 0; index < dictionary.Count; index++)
            {
                Console.WriteLine($"index : {index}-{dictionary[index]}");
            }

            foreach (var entry in dictionary)   // var를 이용해서 많이 쓰이는 형태
            {
                Console.WriteLine($"key : {entry.Key}, value : {entry.Value}");
            }
        }
    }
}
