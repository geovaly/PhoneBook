using System.Collections.Generic;
using System.Xml.Serialization;

namespace InterviewTest.Persistance.DataModel
{
    [XmlRoot("AgendaTelefonica")]
    public class PhoneBookDto
    {
        [XmlArray("Contacte")]
        [XmlArrayItem("Contact")]
        public List<ContactDto> Contacts { get; set; }
    }
}
