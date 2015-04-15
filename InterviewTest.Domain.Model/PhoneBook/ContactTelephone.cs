using System;

namespace InterviewTest.Domain.Model.PhoneBook
{
    public sealed class ContactTelephone : IEquatable<ContactTelephone>
    {

        public ContactTelephone(string telephoneNumber, string telephoneNumberType)
        {
            TelephoneNumber = telephoneNumber;
            TelephoneNumberType = telephoneNumberType;
        }

        public string TelephoneNumber { get; private set; }

        public string TelephoneNumberType { get; private set; }

        public bool Equals(ContactTelephone other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return string.Equals(TelephoneNumber, other.TelephoneNumber) &&
                   string.Equals(TelephoneNumberType, other.TelephoneNumberType);
        }

        public override bool Equals(object obj)
        {
            return obj is ContactTelephone && Equals((ContactTelephone)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return TelephoneNumber.GetHashCode() * 397 ^ TelephoneNumberType.GetHashCode();
            }
        }

        public override string ToString()
        {
            return TelephoneNumber + " " + TelephoneNumberType;
        }
    }
}
