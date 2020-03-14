using Cw2.TemplatesReviewsForDifferentObjects;
using Cw2.DataHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Collections;


namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {//  Вынести запись аж сюда запись ошибок или нет
            /*
             if(args.lenght > 3) {
                 Write.console("Nie może być więcej niź 3 parametry" );
                 return;
             }
            */

            string sourceFilePath,
                    aimFilePath;
            /*_--
            string sourceFilePath = ((args[0] == null) || (args[0] == "")) ? "data.csv" : args[0],
                aimFilePath = ((args[1] == null) || (args[1] == "")) ? "result.xml" : args[1];
            --_ */
            // formatDanych = ((args[2] == null) ||  (args[2] == "")) ? "xml" : args[2]; 

            sourceFilePath = "D:/Uniwesity/4_semestr/APBD/pgago_FTP/Zajęcia 2/cwiczenia_notatki/Cw2/Cw2/Data/dane.csv";
            

            // formatDanych = (args[2] == "json") ? args[2] :"xml";

            // _--_ var workSheetTemplate = FactoryWriter.createWriter(args[2]);
            
            //            ICollection<Student> 
             var students = new List<Student>();
            //               ICollection 
            //IList students = 


            using (var stream = new StreamReader(new FileInfo(sourceFilePath).OpenRead())) {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] studentParametrs = line.Split(',');
                    // Piotr Gago
                    // Najlepej zrobić jako parametr jeden objekt Studies?
                    // albo dwa parametry typu string?
                    // Albo nie ma różnicy w tym wypadku? 
                    Console.WriteLine("ska " + studentParametrs[4] + ", fname " + studentParametrs[0]);
                    var studies = new Studies { 
                        Name = studentParametrs[2],
                        Mode = studentParametrs[3]
                    };
                   
                    var st = new Student
                    {
                        Ska = studentParametrs[4],
                        Fname = studentParametrs[0],
                        Lname = studentParametrs[1],
                        Birthdate = studentParametrs[5],
                        Email = studentParametrs[6],
                        MothersName = studentParametrs[7],
                        FathersName = studentParametrs[8],
                        Studies = studies
                    };
                    
                    /*
                    st.Ska(studentParametrs[4]);
                    st.setFname(studentParametrs[0]);
                    st.setLname(studentParametrs[1]);
                    st.setBirthdate(studentParametrs[5]);
                    st.setEmail(studentParametrs[6]);
                    st.setMothersName(studentParametrs[7]);
                    st.setFathersName(studentParametrs[8]);
                    st.SetStudies( new Studies(
                                               studentParametrs[2], 
                                               studentParametrs[3]
                                               )
                    );
                    */
                    //,
                    //                        studentParametrs[7],
                    //                        studentParametrs[8]


                    students.Add(st);        
                }
            }


            aimFilePath = "C:/Users/admin/Desktop/Cw2_CS/result.xml";
            // Закинуть в реализацию интерфейса IWrite



            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                                      new XmlRootAttribute("uczelnia"));

            Stream fileStream = new FileStream(aimFilePath, FileMode.Create);
            serializer.Serialize(fileStream, students);
            // C:\Users\admin\Desktop
            fileStream.Close();
            
        }
    }

}




/*
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
        

     */