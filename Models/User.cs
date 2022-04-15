using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2.Models
{
    //class user contains field which saves date of birth and methods which count age, chinese and western zodiac signs
    class User
    {
        #region Fields
        private DateTime _dateOfBirth = DateTime.Now;
        #endregion
        #region Properties
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }
        #endregion

        #region Methods
        public int Age()
        {
            int age = -1;
            if (_dateOfBirth <= DateTime.Now)
            {
                age = DateTime.Now.Year - _dateOfBirth.Year;
                if (_dateOfBirth.DayOfYear > DateTime.Now.DayOfYear)
                {
                    age--;
                }
            }
            return age;
        }

        public string ChineseZodiacSign()
        {
            //find out chinese zodiac sign
            string sign = null;
            string[] signs = { "Щур", "Бик", "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Коза", "Мавпа", "Півень", "Собака", "Свиня" };
            return signs[(_dateOfBirth.Year - 4) % 12];
        }

        public string WesternZodiacSign()
        {
            //find out western zodiac sign
            string sign = null;
            switch (_dateOfBirth.Month)
            {
                case 1: sign = (_dateOfBirth.Day <= 20) ? "Козоріг" : "Водолій"; break;
                case 2: sign = (_dateOfBirth.Day <= 19) ? "Водолій" : "Риби"; break;
                case 3: sign = (_dateOfBirth.Day <= 21) ? "Риби" : "Овен"; break;
                case 4: sign = (_dateOfBirth.Day <= 20) ? "Овен" : "Телець"; break;
                case 5: sign = (_dateOfBirth.Day <= 21) ? "Телець" : "Близнюки"; break;
                case 6: sign = (_dateOfBirth.Day <= 22) ? "Близнюки" : "Рак"; break;
                case 7: sign = (_dateOfBirth.Day <= 23) ? "Рак" : "Лев"; break;
                case 8: sign = (_dateOfBirth.Day <= 23) ? "Лев" : "Діва"; break;
                case 9: sign = (_dateOfBirth.Day <= 24) ? "Діва" : "Терези"; break;
                case 10: sign = (_dateOfBirth.Day <= 23) ? "Терези" : "Скорпіон"; break;
                case 11: sign = (_dateOfBirth.Day <= 23) ? "Скорпіон" : "Стрілець"; break;
                case 12: sign = (_dateOfBirth.Day <= 22) ? "Стрілець" : "Козоріг"; break;
            }

            return sign;
        }

        public bool IsValid()
        {
            //check whether person's age is appropriate 
            if (Age() < 0 || Age() > 135) return false;
            return true;
        }

        public bool IsBirthday()
        {
            //check whether today is person's birthday
            if (_dateOfBirth.Month == DateTime.Now.Month && _dateOfBirth.Day == DateTime.Now.Day) return true;
            return false;
        }
        #endregion
    }
}
