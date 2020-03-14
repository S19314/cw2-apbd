using Cw2.TemplatesReviewsForDifferentObjects;
using Cw2.DataHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.Xml.Linq;

namespace Cw2
{
    class Program
    {
        static void Main(string[] args)
        {//  Вынести запись аж сюда запись ошибок или нет
            ///*
             if(args.Length > 3) {
                Console.WriteLine("Nie może być więcej niź 3 parametry" );
                 return;
             }
            //*/
            string defaultAdresPlikuCSV = "data.csv",
                    defaultAdresDocelowyWyniku = "result.xml",
                    defaultTypDanych = "xml";
            string sourceFilePath,
                    aimFilePath;
            /*_--
            string sourceFilePath = ((args[0] == null) || (args[0] == "")) ? defaultAdresPlikuCSV : args[0],
                aimFilePath = ((args[1] == null) || (args[1] == "")) ? defaultAdresDocelowyWyniku : args[1];
            --_ */
            // formatDanych = ((args[2] == null) ||  (args[2] == "")) ? defaultTypDanych : args[2]; 

            sourceFilePath = @"D:\Projects\C#\APBD\Cwieczenie_2\Cw2\Data\dane.csv";
            

            // formatDanych = (args[2] == "json") ? args[2] :"xml";

            // _--_ var workSheetTemplate = FactoryWriter.createWriter(args[2]);
            
            //            ICollection<Student> 
             var students = new List<Student>();
            //               ICollection 
            //IList students =

            Dictionary<string, int> hashCourses = new Dictionary<string, int>();
            //using (FileStream logFileStream = new FileStream("log.txt", FileMode.Create) ){
            using (StreamWriter logStreamWriter = new StreamWriter("log.txt", false, System.Text.Encoding.Default)) { 
            using (var stream = new StreamReader(new FileInfo(sourceFilePath).OpenRead())) {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] studentParametrs = line.Split(',');

                        bool isMessageForLog = false;
                string infoStudent = "";
                for (int i = 0; i < studentParametrs.Length; i++)
                    infoStudent += " " + studentParametrs[i];

                        
                        if (studentParametrs.Length < 9)
                    {

                        infoStudent = "Student: " + infoStudent + " ma " + studentParametrs.Length + " parametrów, " +
                            "a potrzebno mieć 9";
                            logStreamWriter.Write(infoStudent + "\n");
                            logStreamWriter.Flush();
                            continue;

                    }
                    for(int  i = 0; i < studentParametrs.Length; i++)
                    {
                            if (studentParametrs[i] == null || studentParametrs[i] == "")
                            {
                                infoStudent += "; Ma pusty parametry";
                                isMessageForLog = true;
                                break;
                            }
                    }

                    
                        // Console.WriteLine("ska " + studentParametrs[4] + ", fname " + studentParametrs[0]);
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


                        // ещё проверить на правильность пути


                    for(int i = 0; i < students.Count; i++)
                    {
                            if (students[i].Equals(st)) {
                                infoStudent += " ; Takij student już istnieje w Baze Dannych";
                                isMessageForLog = true; 
                            }
                    }

                    if (isMessageForLog)
                    {
                        logStreamWriter.Write(infoStudent + "\n");
                        logStreamWriter.Flush();
                        continue;
                    }

                    students.Add(st);
                    string courseName = studentParametrs[2];// students[students.Count-1].Studies.Name;
                    if (hashCourses.ContainsKey(courseName))
                    {
                        hashCourses[courseName]++;
                    }
                    else
                    {
                        hashCourses.Add(courseName, 1);
                    }
                }
            }

            }
            aimFilePath = "C:/Users/admin/Desktop/Cw2_CS/result.xml";
            // Закинуть в реализацию интерфейса IWrite


            
            XElement[] xmlStudents = new XElement[students.Count];
            for (int i = 0; i < students.Count; i++) {
                xmlStudents[i] = new XElement("student",
                                              new XAttribute("indexNumber", "s"+students[i].Ska),
                                              new XElement("fname", students[i].Fname),
                                              new XElement("lname", students[i].Lname),
                                              new XElement("birthdate", students[i].Birthdate),
                                              new XElement("email", students[i].Email),
                                              new XElement("mothersName", students[i].MothersName),
                                              new XElement("fathersName", students[i].FathersName),
                                              new XElement("studies",
                                                           new XElement("name", students[i].Studies.Name),
                                                           new XElement("mode", students[i].Studies.Mode)
                                              )
                );

                
                // new XAttribute();
            }
            XElement[] xmlActiveStudies = new XElement[hashCourses.Count];
            int indexXmlActiveStudies = 0;
            foreach (KeyValuePair<string, int> keyValue in hashCourses) {
                Console.WriteLine("Key " + keyValue.Key + ", value " + keyValue.Value);
                xmlActiveStudies[indexXmlActiveStudies] = new XElement(
                    "studies",
                    new XAttribute("name", keyValue.Key),
                    new XAttribute("numberOfStudents", keyValue.Value)
                    );
                indexXmlActiveStudies++;
            }


            // В коммите написать, что пошёл другим путём, так как незватало подсчёта значений
            //  Спросить у преподователя, как лучше делать
            XDocument document = new XDocument( 
                new XElement("uczelnia", 
                    new XAttribute("createdAt", DateTime.Now),
                    new XAttribute("author", "Vladyslav Domariev"),
                        new XElement("studenci", xmlStudents),
                    new XElement("activeStudies",
                    xmlActiveStudies
// Уникальный список с количеством студентов                    // new XElement("studies")
                                 )
                ) // ActiveStudies
            );



            /*
            XElement xmlUczelnia = new XElement("uczelnia");
            document.Add(xmlUczelnia);

            XElement xmlStudent = new XElement("student", new Attribute("indexNumber", "s"+));
            */
            // xmlStudent.ToString()?
            // FileStream fileStream = new FileStream(aimFilePath, FileMode.Create);
            // fileStream.Write(document);
            // C:\Users\admin\Desktop
            // fileStream.Close();
           // using (StreamWriter logStreamWriter = new StreamWriter("log.txt", false, System.Text.Encoding.Default))
            
                document.Save(aimFilePath);
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