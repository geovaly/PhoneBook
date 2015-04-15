using InterviewTest.Domain.Model.PhoneBook;
using InterviewTest.Persistance.Serializers;

namespace InterviewTest.Persistance.DataModel.Convertes
{
    public class ContactTelephoneConverter :
        IDtoConverter<ContactTelephone, ContactTelephoneDto>
    {
        public static readonly ContactTelephoneConverter Instance = new ContactTelephoneConverter();

        public ContactTelephone ToEntity(ContactTelephoneDto dto)
        {
            return new ContactTelephone(
               dto.TelephoneNumber, dto.TelephoneNumberType);
        }

        public ContactTelephoneDto ToDto(ContactTelephone entity)
        {
            return new ContactTelephoneDto()
            {
                TelephoneNumber = entity.TelephoneNumber,
                TelephoneNumberType = entity.TelephoneNumberType
            };
        }
    }
}
