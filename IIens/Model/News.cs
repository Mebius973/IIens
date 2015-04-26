using System;
using System.ComponentModel;

namespace IIens.Model
{
    class News : INotifyPropertyChanged
    {
        public String Titre { get; set; }
        public String Contenu { get; set; }
        public String Par { get; set; }
        public String CalDate { get; set; }

        public String SubTitle
        {
            get
            {
                return "Publié le " + CalDate + " par " + Par;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
