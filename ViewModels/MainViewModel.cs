﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
                if (_user.IsValid())
                {
                    return _user.Name;
                }

                return "---";
            }
            set { _user.Name = value; }
        }

        public string Surname
        {
            get
            {
                if (_user.IsValid())
                {
                    return _user.Surname;
                }

                return "---";
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
                if (_user.IsValid())
                {
                    return _user.Email;
                }

                return "---";
            }
            set
            {
                try
                {
                    _user.Email = value;
                }
                catch (WrongEmailException wrongEmailException)
                {
                    MessageBox.Show(wrongEmailException.Message + wrongEmailException.Email);
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
                if (_user.IsValid())
                {
                    return _user.Age().ToString();
                }

                return "---";
            }
            set { _ = _user.Age(); }
        }

        public string IsAdult
        {
            get
            {
                if(_user.IsValid())
                    if (_user.IsAdult)
                    {
                        return "Так";
                    }
                    else return "Ні";

                return "---";
            }
            set{}
        }

        public string IsBirthday
        {
            get
            {
                if (_user.IsValid())
                    if (_user.IsBirthday)
                    {
                        return "Так";
                    }
                    else return "Ні";

                return "---";
            }
            set{}
        }

        public string WesternZodiacSign
        {
            get
            {
                if (_user.IsValid())
                {
                    return _user.SunSign;
                }

                return "---";
            }
            set { _ = _user.SunSign; }
        }
        public string ChineseZodiacSign
        {
            get
            {
                if (_user.IsValid())
                {
                    return _user.ChineseSign;
                }

                return "---";
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
