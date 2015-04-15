using System.Collections.Generic;

namespace InterviewTest.Domain.Model.PhoneBook
{
    public interface IContactRepository
    {
        ContactId GetNextId();

        Contact GetBy(ContactId id);

        List<Contact> ListBy(SearchContactCriteria criteria);

        void Save(Contact contact);

        void SaveAll(IEnumerable<Contact> contacts);

        void Remove(ContactId id);
    }
}