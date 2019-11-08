namespace WebaddressbookTests
{
    public class ContactData
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
    }
}
