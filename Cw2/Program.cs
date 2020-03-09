using Cw2.Student_1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = //"Z:\\APBD\\GITHUB\\cw1-apbd3\\Cw2\\Cw2\\Data\\dane.csv";//
            @"Data\dane.csv";

            var fi = new FileInfo(path);
            Console.WriteLine("SSSS " + fi.Directory);
            //using ( 
            var stream = new StreamReader(fi.OpenRead()); //))
            { // using lubaja klasa, kotoraja imeet Dispose
                // Dispose czasie wsego u waznych klas
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
             stream.Dispose();

            // XML  
            //var list = new List<Student_1.Student>();
            var list = new List<Student>();

            var st = new Student
            {
                Imie = "Jan",
                Nazwisko = "Kowalski",
                Email =  "kowalksi@wp.pl"
            };
            list.Add(st);

            st.Email = "aa";
            // typeof - poluczenia tipa, bez sozdania objekta

            // pgago\studenci -> sxxxx/
            FileStream writer = new FileStream(@"data.xml", FileMode.Create)
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>),
                                                            new XmlRootAttribute("uczenlnia"));
            xmlSerializer.Serialize(writer, list);
        }
    }
}
