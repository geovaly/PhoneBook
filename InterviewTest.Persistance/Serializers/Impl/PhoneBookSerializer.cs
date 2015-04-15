using InterviewTest.Persistance.DataModel;
using InterviewTest.Persistance.DataModel.Convertes;

namespace InterviewTest.Persistance.Serializers.Impl
{
    public class PhoneBookSerializer :
        EntitySerializerUsingXmlSerializer<InMemoryPhoneBook, PhoneBookDto>
    {
        public PhoneBookSerializer(string fileName) :
            base(fileName, PhoneBookConverter.Instance)
        {
        }
    }
}
