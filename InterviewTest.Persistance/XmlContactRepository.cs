using System;
using System.Collections.Generic;
using System.Linq;
using InterviewTest.Persistance.Common;
using InterviewTest.Domain.Model.PhoneBook;

namespace InterviewTest.Persistance
{
    public class XmlContactRepository : IContactRepository
    {
        private readonly Lazy<InMemoryPhoneBook> _lazyPhoneBook;
        private readonly IEntitySerializer<InMemoryPhoneBook> _phoneBookSerializer;
        private readonly IGenerateSequenceId<ContactId> _idSequence;

        public XmlContactRepository(
            IEntitySerializer<InMemoryPhoneBook> phoneBookSerializer,
            IGenerateSequenceId<ContactId> idSequence)
        {
            _phoneBookSerializer = phoneBookSerializer;
            _idSequence = idSequence;
            _lazyPhoneBook = new Lazy<InMemoryPhoneBook>(DeserializePhoneBook);
        }

        public ContactId GetNextId()
        {
            return _idSequence.GenerateNextId();
        }

        public Contact GetBy(ContactId id)
        {
            return PhoneBook.GetContactBy(id);
        }

        public List<Contact> ListBy(SearchContactCriteria criteria)
        {
            return PhoneBook.Contacts
                .Like(c => c.FirstName, criteria.FirstName)
                .Like(c => c.LastName, criteria.LastName)
                .Like(c => c.Address, criteria.Address)
                .Like(c => c.Comments, criteria.Comments)
                .ToList();
        }

        public void Save(Contact contact)
        {
            PhoneBook.SaveContact(contact);
            _phoneBookSerializer.Serialize(PhoneBook);
        }

        public void SaveAll(IEnumerable<Contact> contacts)
        {
            foreach (var c in contacts)
                PhoneBook.SaveContact(c);

            _phoneBookSerializer.Serialize(PhoneBook);
        }

        public void Remove(ContactId id)
        {
            PhoneBook.RemoveContact(id);
            _phoneBookSerializer.Serialize(PhoneBook);
        }

        private InMemoryPhoneBook PhoneBook
        {
            get { return _lazyPhoneBook.Value; }
        }

        private InMemoryPhoneBook DeserializePhoneBook()
        {
            return _phoneBookSerializer.WasSerialized
                ? _phoneBookSerializer.Deserialize()
                : new InMemoryPhoneBook();
        }

    }
}
