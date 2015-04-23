using System;
using System.ComponentModel;

namespace IIens.Model
{
    class News : INotifyPropertyChanged
    {
        public String title { get; set; }
        public String description { get; set; }
        public String author { get; set; }
        public String publicationDate { get; set; }
    }
}
