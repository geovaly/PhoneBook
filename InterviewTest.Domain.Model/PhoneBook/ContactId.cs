using System;

namespace InterviewTest.Domain.Model.PhoneBook
{
    public struct ContactId : IEquatable<ContactId>
    {
        public static readonly ContactId Null = new ContactId(0);

        public readonly int Value;

        public ContactId(int value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ContactId))
                return false;

            return Equals((ContactId)obj);
        }

        public bool Equals(ContactId other)
        {
            return Value == other.Value;
        }

        public static bool operator ==(ContactId id1, ContactId id2)
        {
            return id1.Equals(id2);
        }

        public static bool operator !=(ContactId id1, ContactId id2)
        {
            return !id1.Equals(id2);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Value.GetHashCode();
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }

    }
}
