using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex02_1_ArrayList_TeamHomework
{
    class Bank
    {
        private List<Account> accounts;
        private int totalAccount;

        public Bank()
        {
            accounts = new List<Account>();
        }      
        public void AddAccount(string accountNO, string name)
        {
            accounts.Add(new Account(accountNO, name));
            totalAccount++;
            Console.WriteLine("계좌번호 등록이 완료되었습니다.");
        }
        public Account GetAccount(string accountNO)
        {
            Account returnAccount = null;
            for (int i = 0; i < accounts.Count; i++)
            {
                if (((Account)accounts[i]).AccountNO == accountNO)
                {
                    Console.WriteLine($"계좌번호 : {((Account)accounts[i]).AccountNO} , 예금주 : {((Account)accounts[i]).Name}");
                    returnAccount = (Account)accounts[i];
                }
                else
                {
                    continue;
                }
            }
            if (returnAccount == null)
            {
                Console.WriteLine("찾는 계좌가 없습니다.");
            }
            return returnAccount;
        }
        public List<Account> FindAccounts(string name)
        {
            List<Account> arr = new List<Account>();
            for (int i = 0; i < accounts.Count; i++)
            {
                if ((accounts[i]).Name == name)
                {
                    Console.WriteLine($"계좌번호 : {accounts[i].AccountNO} , 예금주 : {accounts[i].Name}, 잔고 : {accounts[i].GetBalance()}");
                    arr.Add(accounts[i]);
                }
                else
                {
                    continue;
                }
            }
            if (arr.Count == 0)
            {
                Console.WriteLine("해당 예금주명으로 조회된 계좌가 없습니다.");
            }           
            return arr;
        }
        public List<Account> GetAccounts()
        {
            foreach (Account item in accounts)
            {
                Console.WriteLine($"계좌번호 : {item.AccountNO} , 예금주 : {item.Name}, 잔고 : {item.GetBalance()}");
            }
            return accounts;           
        }
        public int GetTotalAccount()
        {
            return totalAccount;
        }
    }
    
    class Account
    {
        private string accountNO;
        private string name;
        private long balance;
        private List<Transaction> transaction;
        public Account(string accountNO, string name)
        {
            this.accountNO = accountNO;
            this.name = name;
            balance = 0;
            transaction = new List<Transaction>();
        }        
        public string AccountNO
        {
            get { return accountNO; }
        }
        public string Name
        {
            get { return name; }
        }       
        public void Deposit(long amount)
        {
            balance += amount;
            Console.WriteLine($"{amount}원 입금이 완료되었습니다.");
            transaction.Add(new Transaction(DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), "입금", amount, balance));
        }
        public void Withdraw(long amount)
        {
            if (balance < amount)
            {
                Console.WriteLine("잔액이 부족합니다.");
                return;
            }
            balance -= amount;
            Console.WriteLine($"{amount}원 출금이 완료되었습니다.");
            transaction.Add(new Transaction(DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), "출금", amount, balance));
        }
        public long GetBalance()
        {
            return balance;
        }
        public List<Transaction> GetTransactions()
        {
            return transaction;
        }
        public void print(List<Transaction> transaction)
        {
            foreach (Transaction item in transaction)
            {
                item.print();
            }
        }
    }
    class Transaction
    {
        private string transactionDate;
        private string transactionTime;
        private string kind;
        private long amount;
        private long balance;
        public Transaction(string transactionDate, string transactionTime, string kind, long amount, long balance)
        {
            this.transactionDate = transactionDate;
            this.transactionTime = transactionTime;
            this.kind = kind;
            this.amount = amount;
            this.balance = balance;
        }
        public void print()
        {
            Console.WriteLine($"거래일자 : {transactionDate}, 거래시간 : {transactionTime}, 거래구분 : {kind}, 금액 : {amount}, 잔고 : {balance}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            
            bank.AddAccount("123456", "이맹기");
            bank.AddAccount("1112223", "이맹기");
            bank.AddAccount("999888", "안재영");
            bank.AddAccount("777555", "안재영");

            
            bank.GetAccount("123456").Deposit(1000);
            bank.GetAccount("123456").print(bank.GetAccount("123456").GetTransactions());

            bank.GetAccount("123456").Withdraw(300);
            bank.GetAccount("123456").print(bank.GetAccount("123456").GetTransactions());

        }
    }
}
