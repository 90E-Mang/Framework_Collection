using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex08_01_LibraryManagement
{
    class Book
    {
        string isbn;
        string title;
        string author;
        string publisher;
        int price;
        string language;

        public Book(string isbn, string title, string author, string publisher, int price) : this(isbn, title, author, publisher, price, "")
        {     
            
        }
        public Book(string isbn, string title, string author, string publisher, int price, string language) 
        {
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.price = price;
            this.language = language;
        }
        #region<property>
        public string ISBN
        {
            get { return isbn; }
        }
        public string Title
        {
            get { return title; }
        }
        public string Publisher
        {
            get { return publisher; }
        }
        public string Author
        {
            get { return author; }
        }
        public int Price
        {
            get { return price; }
        }
        public string Language
        {
            get { return language; }
        }
        #endregion
    }

}
