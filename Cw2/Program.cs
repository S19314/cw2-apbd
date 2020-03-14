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
        {
            if (args.Length > 3)
            {
                Console.WriteLine("Nie może być więcej niź 3 parametry");
                return;
            }
            string defaultAdresPlikuCSV = "data.csv",
                    defaultAdresDocelowyWyniku = "result.xml",
                    defaultTypDanych = "xml";
            string sourceFilePath,
                    aimFilePath;

            sourceFilePath = ((args[0] == null) || (args[0] == "")) ? defaultAdresPlikuCSV : args[0];
            aimFilePath = ((args[1] == null) || (args[1] == "")) ? defaultAdresDocelowyWyniku : args[1];
            string formatDanych = ((args[2] == null) ||  (args[2] == "")) ? defaultTypDanych : args[2]; 
            
            var students = new List<Student>();
            
            Dictionary<string, int> hashCourses = new Dictionary<string, int>();
            using (StreamWriter logStreamWriter = new StreamWriter("log.txt", false, System.Text.Encoding.Default)) {
                try
                {
                    using (var stream = new StreamReader(new FileInfo(sourceFilePath).OpenRead()))
                    {
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
                            for (int i = 0; i < studentParametrs.Length; i++)
                            {
                                if (studentParametrs[i] == null || studentParametrs[i] == "")
                                {
                                    infoStudent += "; Ma pusty parametry";
                                    isMessageForLog = true;
                                    break;
                                }
                            }
                            var studies = new Studies
                            {
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


                            for (int i = 0; i < students.Count; i++)
                            {
                                if (students[i].Equals(st))
                                {
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
                            string courseName = studentParametrs[2];
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
                catch (FileNotFoundException fnfe)
                {
                    logStreamWriter.WriteLine("Plik " + fnfe.FileName + " nie istnieje");
                    logStreamWriter.Flush();
                }
                catch (DirectoryNotFoundException dnfe) {
                    logStreamWriter.WriteLine("Podana ścieżka jest niepoprawna");
                    logStreamWriter.Flush();
                }
                
            }

            var myWriter = FactoryWriter.createWriter(defaultTypDanych);
            myWriter.WriteDataIntoFile(students, hashCourses, aimFilePath);
            Console.WriteLine("Program finshed!");
        }
    }

}