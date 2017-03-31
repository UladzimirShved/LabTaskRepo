using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Task2.Utils;

namespace Task2
{
    public class DeserealiseJournals
    {
        //public static T XmlToObject<T>(string file)
        //{          
        //    var xs = new XmlSerializer(typeof(T)); //new XmlSerializer(typeof(T));
        //    //var memoryStream = new MemoryStream();//StringToUtf8ByteArray(xmlString));
        //    using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
        //    {
        //        return (T)xs.Deserialize(fs);//memoryStream);
        //    }
        //}

        private static byte[] StringToUtf8ByteArray(string xmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            var byteArray = encoding.GetBytes(xmlString);
            return byteArray;
        }

        public static List<Journal>/*s*/ DeserealiseXml()
        {
            //var journals = XmlToObject<Journals>("C:\\Users\\Uladzimir_Shved\\FrameWork\\Task2\\Task2\\Data.xml");
            var xs = new XmlSerializer(typeof(List<Journal>), new XmlRootAttribute("Journals"));
            using (var fs = new FileStream("C:\\Users\\Uladzimir_Shved\\FrameWork\\Task2\\Task2\\Data.xml", FileMode.Open, FileAccess.Read))
            {
                var journals = (List<Journal>)xs.Deserialize(fs);
                
                return journals/*.AllJournals*/;
            }                
        }
    }
}
