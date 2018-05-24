using ProjectStore.DAL;
using System.Collections.Generic;

namespace ProjectStore.Models.ViewsModels.Home
{
    /// <summary>
    /// Shopping cart View Model.
    /// </summary>
    public class CartVM
    {
        public List<CollectionTable> collectionList { get; set; }

        public CartVM()
        {
            collectionList = new List<CollectionTable>();
        }

        /// <summary>
        /// Add new item to collection.
        /// </summary>
        /// <param name="collectionTable">New item of type CollectionTable.</param>
        public void Add(CollectionTable collectionTable)
        {
            collectionList.Add(collectionTable);
        }

        /// <summary>
        /// Remove item from collection.
        /// </summary>
        /// <param name="collectionTable">New item of type CollectionTable.</param>
        public void Remove(CollectionTable collectionTable)
        {
            collectionList.Remove(collectionTable);
        }
    }
}