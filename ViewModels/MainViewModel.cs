using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Practice_2.Models;
using Practice_2.Tools;

namespace Practice_2.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Person _user=new Person(null, null, DateTime.Now, null);
        private RelayCommand<object> _selectDateCommand;
        private bool _isEnabled=true;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return _user.Name;
            }
            set { _user.Name = value; }
        }

        public string Surname
        {
            get
            { 
                return _user.Surname;
            }
            set
            {
                _user.Surname = value;
            }
        }

        public string Email
        {
            get
            {
                return _user.Email;
            }
            set
            {
                try
                {
                    _user.Email = value;
                    MailAddress ma = new MailAddress(_user.Email);
                }
                catch (FormatException wrongEmailException)
                {
                    MessageBox.Show("Неправильна електронна адреса");
                }
            }
        }

        public DateTime DateOfBirth
        {
            get { return _user.DateOfBirth; }
            set
            {
                try
                {
                    _user.DateOfBirth = value;
                    IsEnabled = false;
                    Task.Run(async () => await renewData());
                    IsEnabled = true;
                }
                catch(DateOfBirthInFutureException dateOfBirthInFutureException)
                {
                    MessageBox.Show(dateOfBirthInFutureException.Message+dateOfBirthInFutureException.DateOfBirth.ToString("d"));
                }
                catch (DateOfBirthInPastException dateOfBirthInPastException)
                {
                    MessageBox.Show(dateOfBirthInPastException.Message + dateOfBirthInPastException.DateOfBirth.ToString("d"));
                }
            }
        }

        public string Age
        {
            get
            {
                return _user.Age().ToString();
            }
            set { _ = _user.Age(); }
        }

        public string IsAdult
        {
            get
            {
                if (_user.IsAdult)
                {
                    return "Так";
                }
                else return "Ні";

            }
            set{}
        }

        public string IsBirthday
        {
            get
            {
                if (_user.IsBirthday)
                {
                    return "Так";
                }
                else return "Ні";


            }
            set{}
        }

        public string WesternZodiacSign
        {
            get
            {
                return _user.SunSign;
            }
            set { _ = _user.SunSign; }
        }
        public string ChineseZodiacSign
        {
            get
            {
                return _user.ChineseSign;
            }
            set { _ = _user.ChineseSign; }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
            }
        }
        public RelayCommand<object> SelectDateCommand
        {
            get
            {
                return _selectDateCommand ??= new RelayCommand<object>(_ => SetData(), CanExecute);
            }
        }
        #endregion
        private void SetData()
        {
            NotifyPropertyChanged("Name");
            NotifyPropertyChanged("Surname");
            NotifyPropertyChanged("Email");
            NotifyPropertyChanged("Age");
            NotifyPropertyChanged("WesternZodiacSign");
            NotifyPropertyChanged("ChineseZodiacSign");
            NotifyPropertyChanged("IsAdult");
            NotifyPropertyChanged("IsBirthday");
            if (_user.IsBirthday) 
            {
                MessageBox.Show("З Днем народження!");
            }
        }

        private async Task renewData()
        {
            await Task.Run(() => Age);
            await Task.Run(() => WesternZodiacSign);
            await Task.Run(() => ChineseZodiacSign);
            await Task.Run(() => IsAdult);
            await Task.Run(() => IsBirthday);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(_user.Name) && !String.IsNullOrWhiteSpace(_user.Surname)&&!String.IsNullOrWhiteSpace(_user.Email);
        }


    }
}
