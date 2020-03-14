using System;
using System.Collections.Generic;
using System.Text;
using Cw2.TemplatesReviewsForDifferentObjects;
using System.Xml.Linq;
namespace Cw2.DataHandler
{
    public class XMLWriter : IWriter
    {
        private string defaultResultFileName = "result.xml";
        public virtual void WriteDataIntoFile(List<Student> students, Dictionary<string, int> hashCourses, string aimFilePath)
        {
            XElement[] xmlStudents = new XElement[students.Count];
            for (int i = 0; i < students.Count; i++)
            {
                xmlStudents[i] = new XElement("student",
                                              new XAttribute("indexNumber", "s" + students[i].Ska),
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


            }
            XElement[] xmlActiveStudies = new XElement[hashCourses.Count];
            int indexXmlActiveStudies = 0;
            foreach (KeyValuePair<string, int> keyValue in hashCourses)
            {
                
                xmlActiveStudies[indexXmlActiveStudies] = new XElement(
                    "studies",
                    new XAttribute("name", keyValue.Key),
                    new XAttribute("numberOfStudents", keyValue.Value)
                    );
                indexXmlActiveStudies++;
            }


            XDocument document = new XDocument(
                new XElement("uczelnia",
                    new XAttribute("createdAt", DateTime.Now),
                    new XAttribute("author", "Vladyslav Domariev"),
                        new XElement("studenci", xmlStudents),
                    new XElement("activeStudies",
                    xmlActiveStudies
                                 )
                )
            );

            document.Save(aimFilePath);
        }
        public string getDefaultResultFileName()
        {
            return defaultResultFileName;
        }
    }
}
