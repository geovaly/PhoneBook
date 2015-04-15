using System.Linq;
using InterviewTest.Domain.Model.PhoneBook;
using InterviewTest.Persistance.Serializers;

namespace InterviewTest.Persistance.DataModel.Convertes
{
    public class ContactConverter :
        IDtoConverter<Contact, ContactDto>
    {
        public static readonly ContactConverter Instance = new ContactConverter();

        public Contact ToEntity(ContactDto dto)
        {
            return new Contact(
                new ContactId(dto.ContactId),
                dto.FirstName,
                dto.LastName,
                dto.Address,
                dto.Comments,
                dto.Telephones.Select(ContactTelephoneConverter.Instance.ToEntity));
        }

        public ContactDto ToDto(Contact entity)
        {
            return new ContactDto()
            {
                ContactId = entity.ContactId.Value,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                Comments = entity.Comments,
                Telephones = entity.Telephones
                    .Select(ContactTelephoneConverter.Instance.ToDto)
                    .ToList()
            };
        }
    }
}
