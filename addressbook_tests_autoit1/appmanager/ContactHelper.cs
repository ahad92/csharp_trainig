using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class ContactHelper : HelperBase
    {
        public static string CONTACTWINTITLE = "Contact Editor";
        public static string QUESTIONWINTITLE = "Question";

        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();

            string count = aux.ControlListView(
                WINTITLE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                "GetItemCount", "", ""
                );
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlListView(
                    WINTITLE, "", "WindowsForms10.Window.8.app.0.2c908d510",
                "GetText", "#0|#" + i, "");

                list.Add(new ContactData()
                {
                    FirstName = item
                });
            }
            return list;
        }

        public void Delete(int groupNumber)
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d59");
            aux.WinWait(QUESTIONWINTITLE);
            aux.ControlClick(QUESTIONWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d52");
        }

        public void Add(ContactData newContact)
        {
            OpenContactsDialogue();
            aux.ControlClick(CONTACTWINTITLE, "", "WindowsForms10.EDIT.app.0.2c908d516");
            aux.Send(newContact.FirstName);
            CloseContactsDialogue();
        }

        private void CloseContactsDialogue()
        {
            aux.ControlClick(CONTACTWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d58");
        }

        private void OpenContactsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d58");
            aux.WinWait(CONTACTWINTITLE);
        }
    }
}