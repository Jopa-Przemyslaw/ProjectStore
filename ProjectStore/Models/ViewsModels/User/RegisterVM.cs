using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectStore.Models.ViewsModels.User
{
    public class RegisterVM
    {
        public UserTable userTable { get; set; }
    }
}