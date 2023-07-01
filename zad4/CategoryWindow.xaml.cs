using System.Windows;
using System.Windows.Controls;

namespace zad4
{
    public partial class CategoryWindow : Window
    {
        private Category category;

        public CategoryWindow(Category selectedCategory)
        {
            InitializeComponent();
            category = selectedCategory;
            subcategoryListBox.ItemsSource = category.Subcategories;
        }

        private void SubcategoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Subcategory selectedSubcategory = subcategoryListBox.SelectedItem as Subcategory;

            if (selectedSubcategory != null)
            {
                ItemWindow itemWindow = new ItemWindow(selectedSubcategory);
                itemWindow.ShowDialog();
            }
        }
    }
}
