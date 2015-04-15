using System.Xml.Serialization;

namespace InterviewTest.Persistance.DataModel
{
    public class ContactTelephoneDto
    {
        [XmlElement("NumarTelefon")]
        public string TelephoneNumber { get; set; }

        [XmlElement("TipNumarTelefon")]
        public string TelephoneNumberType { get; set; }
    }
}
