using System;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Domain.Model.PhoneBook
{
    public class Contact
    {
        private readonly List<ContactTelephone> _telephones;

        public Contact(ContactId contactId)
            : this(
                contactId,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                Enumerable.Empty<ContactTelephone>())
        {
        }

        public Contact(
            ContactId contactId,
            string firstName,
            string lastName,
            string address,
            string comments,
            IEnumerable<ContactTelephone> telephones)
        {
            ContactId = contactId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Comments = comments;
            _telephones = telephones.Distinct().ToList();
        }

        public ContactId ContactId { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Comments { get; set; }

        public IReadOnlyList<ContactTelephone> Telephones
        {
            get { return _telephones; }
        }

        public void Add(ContactTelephone telephone)
        {
            if (_telephones.Contains(telephone))
                return;

            _telephones.Add(telephone);
        }

        public void Remove(ContactTelephone telephone)
        {
            if (!_telephones.Contains(telephone))
                throw new ArgumentException();

            _telephones.Remove(telephone);
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
