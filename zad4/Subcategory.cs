using System.Collections.ObjectModel;

namespace zad4
{
    public class Subcategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableCollection<Item> Items { get; set; }

        public Subcategory()
        {
            Items = new ObservableCollection<Item>();
        }
    }
}
