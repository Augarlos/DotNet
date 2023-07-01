using System.Collections.ObjectModel;

namespace zad4
{
    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableCollection<Subcategory> Subcategories { get; set; }

        public Category()
        {
            Subcategories = new ObservableCollection<Subcategory>();
        }
    }
}
