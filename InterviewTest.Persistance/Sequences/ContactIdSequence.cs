using InterviewTest.Domain.Model.PhoneBook;

namespace InterviewTest.Persistance.Sequences
{
    public class ContactIdSequence
    {
        public ContactId CurrentId { get; set; }

        public ContactIdSequence()
            : this(new ContactId(0))
        {
        }

        public ContactIdSequence(ContactId contactId)
        {
            CurrentId = contactId;
        }

    }
}
