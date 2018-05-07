using ProjectStore.DAL;

namespace ProjectStore.Models.ViewsModels.Collection
{
    public class CollectionDetailsVM : CollectionTable
    {
        public CollectionDetailsVM(CollectionTable collectionTable)
        {
            base.Id = collectionTable.Id;
            base.Title = collectionTable.Title;
            base.Author = collectionTable.Author;
            base.Director = collectionTable.Director;
            base.DateReleased = collectionTable.DateReleased;
            base.Price = collectionTable.Price;
            base.Type = collectionTable.Type;
        }
    }
}