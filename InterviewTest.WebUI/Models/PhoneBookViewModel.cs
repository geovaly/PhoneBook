using System.Collections.Generic;
using System.Linq;
using InterviewTest.Domain.Model.PhoneBook;

namespace InterviewTest.WebUI.Models
{
    public class PhoneBookViewModel
    {
        public PhoneBookViewModel()
        {
            SearchOrCreateContact = new SearchContactCriteria();
            Contacts = Enumerable.Empty<Contact>();
            SelectContactId = ContactId.Null;
            Telephones = Enumerable.Empty<ContactTelephone>();
        }

        public SearchContactCriteria SearchOrCreateContact { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }

        public ContactId SelectContactId { get; set; }

        public IEnumerable<ContactTelephone> Telephones { get; set; }

        public bool ContactWasNotSelected { get { return SelectContactId == ContactId.Null; } }

    }
}