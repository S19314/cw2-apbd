using System;
using System.Collections;
using System.Text;
using Cw2.TemplatesReviewsForDifferentObjects;
using System.Collections.Generic;
using System.Xml.Linq;
namespace Cw2.DataHandler
{
    public interface IWriter
    {
        public void WriteDataIntoFile(List<Student> students, Dictionary<string, int> hashCourses, string aimFilePath);
        public string getDefaultResultFileName();
    }
}
