using System;
using System.ComponentModel;

namespace IIens.Model
{
    class News : INotifyPropertyChanged
    {
        public String titre { get; set; }
        public String contenu { get; set; }
        public String par { get; set; }
        public String calDate { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
