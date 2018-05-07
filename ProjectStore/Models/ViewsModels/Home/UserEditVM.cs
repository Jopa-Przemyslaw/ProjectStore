using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectStore.Models.ViewsModels.Home
{
    public class UserEditVM : UserTable
    {
        public UserEditVM() : base() { }
        public UserEditVM(UserTable userTable)
        {
            base.Username = userTable.Username;
            base.Password = userTable.Password;
            base.IsAdmin = userTable.IsAdmin;
            base.Age = userTable.Age;
            base.FirstName = userTable.FirstName;
            base.LastName = userTable.LastName;
        }
    }
}