using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_work_26._05._2023
{
    public class Employer
    {
        private DateTime birthDate;
        private string name;
        private string surname;
        private string job_title;

        //public Employer()
        //{
        //    birthDate = new DateTime(2000,12,23);
        //    name = "Петр";
        //    surname = "Корякин";
        //    job_title = "Слесарь";
        //}
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Job_title { get; set; }
        public Employer(/*DateTime _birthDate, string _name, string _surname,string _job_title*/)
        {
               /* BirthDate = new DateTime(2000, 02, 04);
                Name = "неизвестно";
                Surname = "неизвестно";
                Job_title = "неизвестно";*/
            
        }

        

        //public bool SetAge(int _age)
        //{
        //    bool flag = false;
        //    if (_age >= 14 & _age <= 100)
        //    {
        //        age = _age;
        //        flag = true;
        //    }
        //    return flag;
        //}

        //public void SetBirthDate(DateTime _birthDate)
        //{
        //    this.birthDate = _birthDate;
        //}
        //public void SetName(string _name)
        //{
        //    this.name = _name;
        //}
        //public void SetSurname(string _surname)
        //{
        //    this.surname = _surname;
        //}
        //public void SetJob_title(string _job_title)
        //{
        //    this.job_title = _job_title;
        //}

        public virtual void PrintWorkTime()
        {
            Console.WriteLine($"Сотрудник {this.Name} " +
                $" не работает, потому что он экземпляр базового класса");
        }
        public virtual int GetAge(DateTime BirthDate)//метод вычисления сколько лет сотруднику
        {
            DateTime n = DateTime.Now; 
            int age = n.Year - BirthDate.Year;

            if (n.Month < BirthDate.Month || (n.Month == BirthDate.Month && n.Day < BirthDate.Day))
                age--;

            return age;
        }

    }
}
    
    


