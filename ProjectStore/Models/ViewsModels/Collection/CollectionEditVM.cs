using ProjectStore.DAL;

namespace ProjectStore.Models.ViewsModels.Collection
{
    /// <summary>
    /// CollectionEdit View Model.
    /// </summary>
    public class CollectionEditVM : CollectionTable
    {
        public CollectionEditVM() : base() { }
        public CollectionEditVM(CollectionTable collectionTable)
        {
            base.Title = collectionTable.Title;
            base.Author = collectionTable.Author;
            base.Director = collectionTable.Director;
            base.DateReleased = collectionTable.DateReleased;
            base.Price = collectionTable.Price;
            base.Type = collectionTable.Type;
        }
    }
}