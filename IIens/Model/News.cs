using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace IIens.Model
{
    class News : INotifyPropertyChanged
    {
        public String Titre { get; set; }

        private String _contenu;
        public String Contenu
        {
            get
            {
                return _contenu;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _contenu = Regex.Replace(value, "(:[a-zA-Z]+:|<br\\s*\\/?>)", "");
            }
        }
        public String Par { get; set; }
        public String Poste { get; set; }

        public String SubTitle
        {
            get
            {
                return "Publié le " + Poste + " par " + Par;
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
