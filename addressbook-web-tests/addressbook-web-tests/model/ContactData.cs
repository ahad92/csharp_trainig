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

        public ContactData(string firstName, string middleName)
        {
            this.firstName = firstName;
            this.middleName = middleName;
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
            return FirstName == other.FirstName;
        }

        public ContactData(string firstName, string middleName,string lastName, string nickname, string email)
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
            get => firstName;

            set => firstName = value;
        }

        public override string ToString()
        {
            return "name = " + FirstName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return (FirstName + LastName).CompareTo(other.FirstName + LastName);
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

    }
}
