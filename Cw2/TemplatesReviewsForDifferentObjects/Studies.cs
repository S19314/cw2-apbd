using System;
using System.Collections.Generic;
using System.Text;

namespace Cw2.TemplatesReviewsForDifferentObjects
{
    [Serializable]
    public class Studies
    {
        private string name,
                       mode;
        public Studies() { //_ string name, string mode){
            //_ this.name = name;
            //_ this.mode = mode;
        }

        public string Name {
            set {
                if (value == null || value == "")
                    Console.WriteLine("Excp");
                name = value;
            }

             get
            {
                return name;
            }
        }
        public string Mode
        {

            set
            {
                if (value == null || value == "")
                    Console.WriteLine("Excp");
                mode = value;
            }
            get
            {
                return mode;
            }
        }

    }
}
