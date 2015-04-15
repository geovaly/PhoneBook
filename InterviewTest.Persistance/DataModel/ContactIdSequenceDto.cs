using System.Xml.Serialization;

namespace InterviewTest.Persistance.DataModel
{
    [XmlRoot("ContactIdSequence")]
    public class ContactIdSequenceDto
    {
        [XmlElement("CurrentId")]
        public int CurrentId { get; set; }
    }
}
