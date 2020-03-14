using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using Cw2.TemplatesReviewsForDifferentObjects;
namespace Cw2.DataHandler
{
    public class JSONWriter : IWriter
    {
        private string defaultResultFileName = "result.json";
        public virtual void WriteDataIntoFile(List<Student> students, Dictionary<string, int> hashCourses, string aimFilePath) { 
            var jsonString = JsonSerializer.Serialize(students);
            jsonString = jsonString + "\n" + JsonSerializer.Serialize(hashCourses);
            File.WriteAllText(aimFilePath, jsonString);
        }

        public string getDefaultResultFileName() {
            return defaultResultFileName;
        }
    }
}
