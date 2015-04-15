using System.Collections.Generic;
using System.Linq;
using InterviewTest.Domain.Model.PhoneBook;

namespace InterviewTest.Persistance
{
    public class InMemoryPhoneBook
    {
        private readonly Dictionary<ContactId, Contact> _contactsById;

        public InMemoryPhoneBook()
        {
            _contactsById = new Dictionary<ContactId, Contact>();
        }

        public InMemoryPhoneBook(IEnumerable<Contact> contacts)
        {
            _contactsById = contacts.ToDictionary(c => c.ContactId);
        }

        public IEnumerable<Contact> Contacts
        {
            get { return _contactsById.Values; }
        }

        public Contact GetContactBy(ContactId id)
        {
            return _contactsById[id];
        }

        public void SaveContact(Contact contact)
        {
            _contactsById[contact.ContactId] = contact;
        }

        public void RemoveContact(ContactId id)
        {
            _contactsById.Remove(id);
        }
    }
}
