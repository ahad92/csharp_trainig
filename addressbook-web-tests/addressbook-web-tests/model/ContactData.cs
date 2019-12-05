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
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.nickname = nickname;
            this.email = email;
        }

        public string FirstName
        {
            get => firstName;

            set => firstName = value;
        }

        public string MiddleName
        {
            get => middleName;

            set => middleName = value;
        }

        public string LastName
        {
            get => lastName;

            set => lastName = value;
        }

        public string Email
        {
            get => email;

            set => email = value;
        }

        public string Nickname
        {
            get => nickname;

            set => nickname = value;
        }

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
