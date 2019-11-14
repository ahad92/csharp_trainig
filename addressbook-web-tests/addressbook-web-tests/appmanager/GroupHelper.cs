using System;
using OpenQA.Selenium;


namespace WebaddressbookTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public GroupHelper Remove(int groupNum)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(groupNum);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        internal GroupHelper Modify(int groupNum, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(groupNum);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;

        }

        private GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        private GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            return this;
        }



        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

 
        public GroupHelper SelectGroup(int index)
        {
//            driver.FindElement(By.XPath($"//input[@name='selected[]']['{index}']")).Click();
            driver.FindElement(By.XPath($"//div[@id='content']//span[{index}]//input[@name='selected[]']")).Click();
            return this;
        }


    }
}

