using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex08_01_LibraryManagement
{
    class Library
    {
        List<Book> books;
        int SEQ;            // 책 고유번호 생성용
        public Library()
        {
            books = new List<Book>();
        }

        public void addBook(string select)
        {
                
            string isbn = $"{DateTime.Now.ToString("yyMMdd")}{0000 + SEQ}";
            Console.Write("책 제목을 입력해주세요.");
            string title = Console.ReadLine();
            Console.Write("저자를 입력해주세요.");
            string author = Console.ReadLine();
            Console.Write("출판사를 입력해주세요.");
            string publisher = Console.ReadLine();
            Console.Write("가격을 입력해주세요.");
            int price = Convert.ToInt32(Console.ReadLine());
            if (select == "1")
            {
                books.Add(new Book(isbn, title, author, publisher, price));
            }
            else if (select == "2")
            {
                Console.Write("언어를 입력해주세요 : ");
                string language = Console.ReadLine();
                books.Add(new Book(isbn, title, author, publisher, price, language));
            }
            SEQ++;
            Console.WriteLine("도서 추가를 완료했습니다.");
        }
        public void deleteBook(string isbn)
        {
            foreach (Book temp in books)
            {
                if (isbn == temp.ISBN)
                {
                    books.Remove(temp);
                    Console.WriteLine("해당 도서 삭제를 완료했습니다.");
                    return;
                }
            }
        }
        public void search(string isbn)
        {
            foreach (Book temp in books)
            {
                if (books.Count == 0)
                {
                    Console.WriteLine("저장된 도서목록이 없습니다.");
                    return;
                }
                else if(isbn == temp.ISBN)
                {
                    if (temp.Language.Length != 0)
                    {
                        Console.WriteLine($"ISBN : {temp.ISBN}, 책 제목 : {temp.Title}, 저자 : {temp.Author}, 출판사 : {temp.Publisher}, 가격 : {temp.Price}, 언어 : {temp.Language}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"ISBN : {temp.ISBN}, 책 제목 : {temp.Title}, 저자 : {temp.Author}, 출판사 : {temp.Publisher}, 가격 : {temp.Price}");
                        return;
                    }
                }               
            }
            Console.WriteLine("찾는 도서가 없습니다.");
        }
        public void inquire()
        {
            foreach (Book temp in books)
            {
                if (temp.Language.Length != 0)
                {
                    Console.WriteLine($"ISBN : {temp.ISBN}, 책 제목 : {temp.Title}, 저자 : {temp.Author}, 출판사 : {temp.Publisher}, 가격 : {temp.Price}, 언어 : {temp.Language}");
                }
                else
                {
                    Console.WriteLine($"ISBN : {temp.ISBN}, 책 제목 : {temp.Title}, 저자 : {temp.Author}, 출판사 : {temp.Publisher}, 가격 : {temp.Price}");
                }
            }
        }        
        public void menu()
        {
            
            bool endprogram = true;
            while (endprogram)
            {
                Console.WriteLine("*******************************************************************");
                Console.WriteLine("*메뉴를 선택해주세요                                                  *");
                Console.WriteLine("*1. 도서추가  2. 도서삭제  3. 도서검색  4. 전체 도서 조회  5. 프로그램 종료*");
                Console.WriteLine("*******************************************************************");

                string select = Console.ReadLine();

                switch (select)
                {
                    case "1":
                        Console.WriteLine("입력할 도서 유형을 선택해주세요. 1. 일반서적  2. 프로그래밍 서적");
                        Console.Write("입력값 : ");
                        string input = Console.ReadLine();
                        addBook(input);
                        break;
                    case "2":
                        Console.WriteLine("삭제하고자 하는 ISBN을 입력해주세요.");
                        string isbn = Console.ReadLine();
                        deleteBook(isbn);
                        break;
                    case "3":
                        Console.WriteLine("찾으시는 도서의 ISBN을 입력해주세요.");
                        isbn = Console.ReadLine();
                        search(isbn);
                        break;
                    case "4":
                        inquire();
                        break;
                    case "5":
                        endprogram = false;
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
}
