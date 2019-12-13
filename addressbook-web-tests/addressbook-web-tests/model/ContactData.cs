using System;

namespace WebaddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public ContactData(string firstName, string lastName, string middleName, string nickname, string email)
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

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string WorkPhone { get; set; }

        public string MobilePhone { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(MobilePhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
           return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")+ "\r\n";
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
            return FirstName == other.FirstName && LastName == other.LastName;
            //            return LastName == other.FirstName && LastName == other.FirstName;
            //            return LastName == other.LastName;
        }

        public override string ToString()
        {
            return "name = "  + LastName + " " + FirstName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int compare = LastName.CompareTo(other.LastName);
            if (compare == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            return compare;
        }

        public override int GetHashCode()
        {
            return (FirstName + LastName).GetHashCode();
        }

    }
}
