using System;

namespace WebaddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string nickname;
        private string email;

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return LastName == other.LastName;
        }
        public ContactData(string firstName, string middleName, string lastName, string nickname, string email)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Nickname = nickname;
            Email = email;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Nickname { get; set; }

        public string Id { get; set; }

        public override string ToString()
        {
            return "name = " + FirstName + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, LastName))
            {
                return 1;
            }
            else if (Object.ReferenceEquals(other, FirstName))
             {
                    return 1;
             }

          return (FirstName + LastName).CompareTo(other.FirstName + other.LastName);
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

    }
}
