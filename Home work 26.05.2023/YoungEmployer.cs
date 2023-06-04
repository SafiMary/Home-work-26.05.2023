using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_work_26._05._2023
{
    public class YoungEmployer : Employer
    {
        public YoungEmployer()
            : base() { }

        public override void PrintWorkTime()//метод определения рабочего времени
        {
            if (GetAge(this.BirthDate) >= 14 && GetAge(this.BirthDate) <= 17)
            {
                Console.WriteLine($"Сотрудник {this.Name} " +
                $"работает 5/2 4 часа в день");
            }
            if (GetAge(this.BirthDate) >= 18 && GetAge(this.BirthDate) <= 55)
            {
                Console.WriteLine($"Сотрудник {this.Name} " +
                $"работает 5/2 8 часов в день или 12-тичасовые смены 2/2");
            }
            else
            {
                Console.WriteLine($"Сотрудник {this.Name} пенсионер " +
                $"работает 8 часов в день, не более 4 дней в неделю ");
            }
        }
        public override int GetAge(DateTime BirthDate)//метод вычисления сколько лет сотруднику
        {
            DateTime n = DateTime.Now;
            int age = n.Year - BirthDate.Year;

            if (n.Month < BirthDate.Month || (n.Month == BirthDate.Month && n.Day < BirthDate.Day))
                age--;

            return age;
        }
    }
}
    

