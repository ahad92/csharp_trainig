using NUnit.Framework;


namespace WebaddressbookTests
{
    public class LoginTests : TestBase
    {
        [Test]

        public void LoginWithValidCredentails()
        {
            //prepare
            app.Navigator.GoToHomePage();
            app.Auth.Logout();
           
            //action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
          
            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]

        public void LoginWithInvalidCredentails()
        {
            //prepare
            app.Auth.Logout();

            //action
            AccountData account = new AccountData("admin", "12313123");
            app.Auth.Login(account);

            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
