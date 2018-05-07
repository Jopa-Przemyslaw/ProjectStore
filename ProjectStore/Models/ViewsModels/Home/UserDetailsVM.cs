using ProjectStore.DAL;

namespace ProjectStore.Models.ViewsModels.Home
{
    public class UserDetailsVM : UserTable
    {
        public UserDetailsVM(UserTable userTable)
        {
            base.UserID = userTable.UserID;
            base.Username = userTable.Username;
            base.Password = userTable.Password;
            base.IsAdmin = userTable.IsAdmin;
            base.Age = userTable.Age;
            base.FirstName = userTable.FirstName;
            base.LastName = userTable.LastName;
        }
    }
}