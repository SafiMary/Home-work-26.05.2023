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

    
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Job_title { get; set; }
        public Employer()
        {
           
            
        }

        

     
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
    
    


