using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using InterviewTest.Domain.Model.PhoneBook;
using InterviewTest.WebUI.Common;
using InterviewTest.WebUI.Models;

namespace InterviewTest.WebUI.Controllers
{
    public class PhoneBookController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public PhoneBookController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public ViewResult Index(SearchContactCriteria criteria, ContactId selectId)
        {
            var contacts = _contactRepository.ListBy(criteria);
            Contact selectContact = SelectedContact(selectId, contacts);

            return View("Index",
                new PhoneBookViewModel()
                {
                    Contacts = contacts,
                    SearchOrCreateContact = criteria,
                    SelectContactId = selectId,
                    Telephones = selectContact.Telephones
                });
        }

        [HttpPost]
        [MultipleButton(Name = "Index", Argument = "ListContacts")]
        public RedirectToRouteResult ListContacts(SearchContactCriteria criteria)
        {
            return RedirectToIndexAction(criteria);
        }

        [HttpPost]
        [MultipleButton(Name = "Index", Argument = "CreateContact")]
        public RedirectToRouteResult CreateContact(SearchContactCriteria criteria)
        {
            ContactId nextId = _contactRepository.GetNextId();
            _contactRepository.Save(new Contact(nextId)
            {
                FirstName = criteria.FirstName,
                LastName = criteria.LastName,
                Address = criteria.Address,
                Comments = criteria.Comments
            });

            return RedirectToIndexAction(nextId);
        }

        [HttpPost]
        public RedirectToRouteResult RemoveContact(SearchContactCriteria criteria, ContactId contactId)
        {
            _contactRepository.Remove(contactId);
            return RedirectToIndexAction(criteria);
        }

        [HttpPost]
        public RedirectToRouteResult AddTelephone(SearchContactCriteria criteria, ContactId selectId, ContactTelephone telephone)
        {
            var contact = _contactRepository.GetBy(selectId);
            contact.Add(telephone);
            _contactRepository.Save(contact);
            return RedirectToIndexAction(criteria, selectId);
        }

        [HttpPost]
        public RedirectToRouteResult RemoveTelephone(SearchContactCriteria criteria, ContactId selectId, ContactTelephone telephone)
        {
            var contact = _contactRepository.GetBy(selectId);
            contact.Remove(telephone);
            _contactRepository.Save(contact);
            return RedirectToIndexAction(criteria, selectId);
        }

        private static Contact SelectedContact(ContactId id, List<Contact> contacts)
        {
            return contacts.FirstOrDefault(x => x.ContactId == id)
                ?? new Contact(ContactId.Null);
        }

        private RedirectToRouteResult RedirectToIndexAction(ContactId selectId)
        {
            return RedirectToAction("Index", new { SelectId = selectId });
        }

        private RedirectToRouteResult RedirectToIndexAction(SearchContactCriteria criteria)
        {
            return RedirectToAction("Index", criteria);
        }

        private RedirectToRouteResult RedirectToIndexAction(SearchContactCriteria criteria, ContactId selectId)
        {
            return RedirectToAction("Index", new { SelectId = selectId }.ToRoutes(criteria));
        }

    }
}