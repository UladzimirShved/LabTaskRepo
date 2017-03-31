using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Task2.Utils
{

    public class Journals
    {
        [XmlElement("Journal")]
        public List<Journal> AllJournals { get; set; }
    }
    public class Journal
    {
        [XmlAttribute("journame")]
        public string JournName { get; set; }
        [XmlElement("Navigation")]
        public List<Navigations> Journs { get; set; }
    }
    
    public class Navigations
    {
        [XmlElement("BigItem")]
        public List<BigItem> BigItems { get; set; }
    }

    public class BigItem
    {
        [XmlAttribute("name")]
        public string BigItemName { get; set; }
        [XmlElement("Item")]
        public List<SmallItem> SmallItems { get; set; }
    }

    public class SmallItem
    {
        [XmlAttribute("smallName")]
        public string Item { get; set; }
    }


}
