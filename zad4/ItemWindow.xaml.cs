using System.Windows;

namespace zad4
{
    public partial class ItemWindow : Window
    {
        public ItemWindow(Subcategory selectedSubcategory)
        {
            InitializeComponent();
            itemDataGrid.ItemsSource = selectedSubcategory.Items;
        }
    }
}
