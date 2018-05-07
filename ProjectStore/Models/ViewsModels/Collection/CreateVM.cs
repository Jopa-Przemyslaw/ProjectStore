using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectStore.Models.ViewsModels.Collection
{
    public class CreateVM
    {
        public CollectionTable collectionTable { get; set; }
    }
}