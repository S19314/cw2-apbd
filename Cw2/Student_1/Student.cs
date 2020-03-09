using System;
using System.Collections.Generic;
using System.Text;

namespace Cw2.Student_1
{
    public class Student
    {   // prop + tabx2
        // [XmlAttribute ] // atribut fila, a nie objeckta
        public string Email { get; set; }

        public string Imie { get; set; }

        private string _nazwisko;
        public string Nazwisko {
            get { return _nazwisko; }
            set{
                if (value == null) throw new ArgumentException();
                _nazwisko = value;
            }
           
    }

    }
}
