using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebaddressbookTests
{
    [Table(Name = "addressbook")]

    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }
        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public ContactData()
        {
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
        public ContactData(string v)
        {
        }

        public ContactData(string firstName, string lastName, string middleName, string nickname, string email)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Nickname = nickname;
            Email = email;
        }


        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Nickname { get; set; }

        public string MiddleName { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string WorkPhone { get; set; }

        public string MobilePhone { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string HomePage { get; set; }

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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email1) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public String GetFullString()
        {
            return  Address + AllPhones + AllEmails;
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
            // return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")+ "\r\n";
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
