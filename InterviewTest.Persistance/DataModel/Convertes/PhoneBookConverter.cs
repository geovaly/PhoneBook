using System.Linq;
using InterviewTest.Persistance.Serializers;

namespace InterviewTest.Persistance.DataModel.Convertes
{
    public class PhoneBookConverter  :
        IDtoConverter<InMemoryPhoneBook, PhoneBookDto>
    {
        public static readonly PhoneBookConverter Instance = new PhoneBookConverter();

        public InMemoryPhoneBook ToEntity(PhoneBookDto dto)
        {
            return new InMemoryPhoneBook(
                dto.Contacts.Select(ContactConverter.Instance.ToEntity));
        }

        public PhoneBookDto ToDto(InMemoryPhoneBook entity)
        {
            return new PhoneBookDto()
            {
                Contacts = entity.Contacts
                    .Select(ContactConverter.Instance.ToDto)
                    .ToList()
            };
        }
    }
}
