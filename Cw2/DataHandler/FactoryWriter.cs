using System;
using System.Collections.Generic;
using System.Text;

namespace Cw2.DataHandler
{
    public class FactoryWriter
    {
        public static IWriter createWriter(string typeWriter) {
            return null; //--
            /* --
            switch (typeWriter) {
                case "json":
                    return new JSONWriter();
                default:
                    return new XMLWriter();
            }
            -- */
        }
    }
}
