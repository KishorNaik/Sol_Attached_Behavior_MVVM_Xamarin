using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Sol_Demo.Models
{
    public class UserUiModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isAlertBoxDisplay = false;
        public Boolean IsAlertBoxDisplay
        {
            get => _isAlertBoxDisplay;
            set
            {
                _isAlertBoxDisplay = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAlertBoxDisplay)));
            }
        }
    }
}
