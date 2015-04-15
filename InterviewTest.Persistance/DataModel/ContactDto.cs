using System.Collections.Generic;
using System.Xml.Serialization;

namespace InterviewTest.Persistance.DataModel
{
  
    public class ContactDto
    {

        [XmlElement("ContactId")]
        public int ContactId { get; set; }

        [XmlElement("Prenume")]
        public string FirstName { get; set; }

        [XmlElement("Nume")]
        public string LastName { get; set; }

        [XmlElement("Adresa")]
        public string Address { get; set; }

        [XmlElement("Mentiuni")]
        public string Comments { get; set; }

        [XmlArray("Telefoane")]
        [XmlArrayItem("ContactTelefon")]
        public List<ContactTelephoneDto> Telephones { get; set; }

    }
}
