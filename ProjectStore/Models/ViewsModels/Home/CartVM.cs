using ProjectStore.DAL;
using System.Collections.Generic;

namespace ProjectStore.Models.ViewsModels.Home
{
    public class CartVM
    {
        public List<CollectionTable> collectionList { get; set; }
        public CartVM()
        {
            collectionList = new List<CollectionTable>();
        }
        public void Add(CollectionTable collectionTable)
        {
            collectionList.Add(collectionTable);
        }
        public void Remove(CollectionTable collectionTable)
        {
            collectionList.Remove(collectionTable);
        }
    }
}