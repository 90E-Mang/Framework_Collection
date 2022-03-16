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
        private ArrayList accounts;
        private int totalAccount;

        public Bank()
        {
            accounts = new ArrayList();
        }
        public void AddAccount(string accountNO, string name)
        {
            // ?? add(Object parameter) <- ArrayList 의 문제점
            // 1. 쓸데없이 많이 잡아먹는 메모리
            // 2. boxing unboxing 문제 --> (주로 다운) 캐스팅 해야됨.
            accounts.Add(new Account(accountNO,name));
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
                    returnAccount =  (Account)accounts[i];
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
        public Account[] FindAccounts(string name)
        {
            ArrayList arr = new ArrayList();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (((Account)accounts[i]).Name == name)
                {
                    Console.WriteLine($"계좌번호 : {((Account)accounts[i]).AccountNO} , 예금주 : {((Account)accounts[i]).Name}");
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
            Account[] findaccount = new Account[arr.Count];
            for (int i = 0; i < arr.Count; i++)
            {
                findaccount[i] = (Account)arr[i];
            }
            return findaccount;
        }
        public Account[] GetAccounts()
        {
            Account[] getAccounts = new Account[accounts.Count];
            for (int i = 0; i < accounts.Count; i++)
            {
                getAccounts[i] = (Account)accounts[i];
                Console.WriteLine($"계좌번호 : {((Account)accounts[i]).AccountNO} , 예금주 : {((Account)accounts[i]).Name}");
            }
            return getAccounts;
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
        public Account(string accountNO, string name)
        {
            this.accountNO = accountNO;
            this.name = name;
            this.balance = 0;

        }
        public string AccountNO
        {
            get { return accountNO; }
        }
        public string Name
        {
            get { return name; }
        }
        public long Balance
        {
            get { return balance; }
        }
        public void Deposit(long amount)
        {
            balance += amount;
            Console.WriteLine($"{amount}원 입금이 완료되었습니다.");
        }
        public void Withdraw(long amount)
        {
            balance -= amount;
            Console.WriteLine($"{amount}원 출금이 완료되었습니다.");
        }
        public long GetBalance()
        {
            return balance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.AddAccount("123456", "이맹기");
            bank.AddAccount("888999", "이맹기");
            bank.AddAccount("789456", "안재영");
            bank.AddAccount("986532", "김민성");
            bank.AddAccount("875421", "정현정");

            bank.FindAccounts("이맹기");
            Console.WriteLine("-------------------------------------");
            bank.GetAccount("789456");
            Console.WriteLine("-------------------------------------");
            bank.GetAccount("123456");
            Console.WriteLine("-------------------------------------");
            bank.GetAccounts();

            bank.GetAccount("123456").Deposit(1000);
            bank.GetAccount("123456").Withdraw(300);
            long balance = bank.GetAccount("123456").GetBalance();
            

        }
    }
}
