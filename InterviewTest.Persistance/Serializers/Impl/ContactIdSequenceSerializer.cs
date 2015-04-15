using InterviewTest.Persistance.DataModel;
using InterviewTest.Persistance.DataModel.Convertes;
using InterviewTest.Persistance.Sequences;

namespace InterviewTest.Persistance.Serializers.Impl
{
    public class ContactIdSequenceSerializer :
        EntitySerializerUsingXmlSerializer<ContactIdSequence, ContactIdSequenceDto>
    {

        public ContactIdSequenceSerializer(string fileName) :
            base(fileName, ContactIdSequenceConverter.Instance)

        {
        }
    }
}
