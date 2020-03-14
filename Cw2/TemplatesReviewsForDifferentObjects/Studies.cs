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
        public Studies() {}

        public string Name {
            set {
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
                mode = value;
            }
            get
            {
                return mode;
            }
        }

    }
}
