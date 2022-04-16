using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2.Models
{
    //class user contains field which saves date of birth and methods which count age, chinese and western zodiac signs
    class Person
    {
        #region Fields

        private string _name;
        private string _surname;
        private DateTime _dateOfBirth = DateTime.Now;
        private string _email;
        #endregion

        #region Constructors

        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;

        }

        public Person(string name, string surname, DateTime dateOfBirth)
        {
            _name = name;
            _surname = surname;
            _dateOfBirth = dateOfBirth;
        }

        public Person(string name, string surname, DateTime dateOfBirth, string email):this(name,surname,dateOfBirth)
        {
            _email = email;
        }

        public Person()
        {

        }


        #endregion
        #region Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public bool IsAdult
        {
            get
            {
                if (Age() < 18) return false;
                return true;
            }
        }

        public string SunSign
        {
            //find out western zodiac sign
            get
            {
                string sign = null;
                switch (_dateOfBirth.Month)
                {
                    case 1:
                        sign = (_dateOfBirth.Day <= 20) ? "Козоріг" : "Водолій";
                        break;
                    case 2:
                        sign = (_dateOfBirth.Day <= 19) ? "Водолій" : "Риби";
                        break;
                    case 3:
                        sign = (_dateOfBirth.Day <= 21) ? "Риби" : "Овен";
                        break;
                    case 4:
                        sign = (_dateOfBirth.Day <= 20) ? "Овен" : "Телець";
                        break;
                    case 5:
                        sign = (_dateOfBirth.Day <= 21) ? "Телець" : "Близнюки";
                        break;
                    case 6:
                        sign = (_dateOfBirth.Day <= 22) ? "Близнюки" : "Рак";
                        break;
                    case 7:
                        sign = (_dateOfBirth.Day <= 23) ? "Рак" : "Лев";
                        break;
                    case 8:
                        sign = (_dateOfBirth.Day <= 23) ? "Лев" : "Діва";
                        break;
                    case 9:
                        sign = (_dateOfBirth.Day <= 24) ? "Діва" : "Терези";
                        break;
                    case 10:
                        sign = (_dateOfBirth.Day <= 23) ? "Терези" : "Скорпіон";
                        break;
                    case 11:
                        sign = (_dateOfBirth.Day <= 23) ? "Скорпіон" : "Стрілець";
                        break;
                    case 12:
                        sign = (_dateOfBirth.Day <= 22) ? "Стрілець" : "Козоріг";
                        break;
                }

                return sign;
            }
        }

        public string ChineseSign
        {
            //find out chinese zodiac sign
            get {
                string sign = null;
                string[] signs =
                {
                    "Щур", "Бик", "Тигр", "Кролик", "Дракон", "Змія", "Кінь", "Коза", "Мавпа", "Півень", "Собака",
                    "Свиня"
                };
                return signs[(_dateOfBirth.Year - 4) % 12];
            }
        }

        public bool IsBirthday
        {
            //check whether today is person's birthday
            get
            {
                if (_dateOfBirth.Month == DateTime.Now.Month && _dateOfBirth.Day == DateTime.Now.Day) return true;
                return false;
            }
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


        public bool IsValid()
        {
            //check whether person's age is appropriate 
            if (Age() < 0 || Age() > 135) return false;
            return true;
        }

        #endregion
    }
}
