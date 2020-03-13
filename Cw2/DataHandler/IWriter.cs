using System;
using System.Collections;
using System.Text;
using Cw2.TemplatesReviewsForDifferentObjects;
namespace Cw2.DataHandler
{
    public interface IWriter
    {
        // Mб нужно изменить на <Student> на <Object>
        void WriteDataIntoFile(IList students);
         //ICollection<Student> students);
         //Student_1[]  )
    }
}
