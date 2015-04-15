using InterviewTest.Domain.Model.PhoneBook;
using InterviewTest.Persistance.Sequences;
using InterviewTest.Persistance.Serializers;

namespace InterviewTest.Persistance.DataModel.Convertes
{
    public class ContactIdSequenceConverter :
        IDtoConverter<ContactIdSequence, ContactIdSequenceDto>
    {
        public static readonly ContactIdSequenceConverter Instance = new ContactIdSequenceConverter();

        public ContactIdSequence ToEntity(ContactIdSequenceDto dto)
        {
            return new ContactIdSequence(new ContactId(dto.CurrentId));
        }

        public ContactIdSequenceDto ToDto(ContactIdSequence entity)
        {
            return new ContactIdSequenceDto()
            {
                CurrentId = entity.CurrentId.Value
            };
        }
    }
}
