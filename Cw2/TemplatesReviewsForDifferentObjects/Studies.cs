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
        public Studies(string name, string mode){
            this.name = name;
            this.mode = mode;
        }

        public void setName(string name) {
            this.name = name; 
        }
        public string getName()
        {
            return name;
        }

        public string getMode()
        {
            return mode;
        }

        public void setMode(string mode)
        {
            this.mode = mode;
        }
    }
}
