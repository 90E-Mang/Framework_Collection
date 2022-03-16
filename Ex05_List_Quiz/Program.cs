using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Ex05_List_Quiz
{
    /*
    Emp 클래스 생성
    사번 (empno)  정수
    이름 (ename)  문자열
    직종 (job)      문자열
    급여 (sal)       정수
    생성자를 통해서 member field 초기화
    -------------------------------------------
    List<T> 사용하여 사원 3명을 만드세요
    
    사원의 정보를 (사원 , 이름 , 직종 , 급여)  출력하세요
    일반  for  과 foreach
     */
    class Emp
    {
        int empno;
        string ename;
        string job;
        int sal;

        public Emp(int empno, string ename, string job, int sal)
        {
            this.empno = empno;
            this.ename = ename;
            this.job = job;
            this.sal = sal;
        }
        public override string ToString()
        {
            return ($"{empno},{ename},{job},{sal}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Emp> employee = new List<Emp>();
            employee.Add(new Emp(17931119, "이맹기", "곧 개발자", 4700));
            employee.Add(new Emp(17931108, "박혜리", "돔황챠", 4700));
            employee.Add(new Emp(17931090, "김혜원", "시집갔음", 4700));

            for (int i = 0; i < employee.Count; i++)
            {
                Console.WriteLine(employee[i].ToString());
            }
        }
    }
}
