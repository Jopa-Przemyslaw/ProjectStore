using ProjectStore.DAL;

namespace ProjectStore.Models.ViewsModels.User
{
    /// <summary>
    /// Register View Model.
    /// </summary>
    public class RegisterVM
    {
        /// <summary>
        /// User template.
        /// </summary>
        public UserTable userTable { get; set; }
    }
}