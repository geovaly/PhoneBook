namespace InterviewTest.Domain.Model.PhoneBook
{
    public class SearchContactCriteria
    {
        public SearchContactCriteria()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Address = string.Empty;
            Comments = string.Empty;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Comments { get; set; }
    }
}