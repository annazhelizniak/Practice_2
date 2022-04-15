using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Practice_2.Models;
using Practice_2.Tools;

namespace Practice_2.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        #region Fields
        private User _user = new User();
        private RelayCommand<object> _selectDateCommand;
        #endregion

        #region Properties
        public DateTime DateOfBirth
        {
            get { return _user.DateOfBirth; }
            set { _user.DateOfBirth = value; }
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

        public string WesternZodiacSign
        {
            get { return _user.WesternZodiacSign(); }
            set { _ = _user.WesternZodiacSign(); }
        }
        public string ChineseZodiacSign
        {
            get
            { return _user.ChineseZodiacSign(); }
            set { _ = _user.ChineseZodiacSign(); }
        }

        public RelayCommand<object> SelectDateCommand
        {
            get
            {
                return _selectDateCommand ??= new RelayCommand<object>(_ => SetData());
            }
        }
        #endregion
        private void SetData()
        {
            NotifyPropertyChanged("Age");
            NotifyPropertyChanged("WesternZodiacSign");
            NotifyPropertyChanged("ChineseZodiacSign");
            if (!_user.IsValid())
            {
                MessageBox.Show("Некоректно обрано дату народження!");
            }
            else
            {
                if (_user.IsBirthday())
                {
                    MessageBox.Show("З Днем народження!");
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }


    }
}
