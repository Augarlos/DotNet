using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Linq;

namespace zad4
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Category> categories;

        public MainWindow()
        {
            InitializeComponent();
            LoadCategoriesFromXml();
            categoryListBox.ItemsSource = categories;
        }

        private void LoadCategoriesFromXml()
        {
            categories = new ObservableCollection<Category>();
            XDocument xmlDoc = XDocument.Load("data.xml");

            foreach (XElement categoryElement in xmlDoc.Descendants("Category"))
            {
                Category category = new Category()
                {
                    Name = categoryElement.Element("Name").Value,
                    Description = categoryElement.Element("Description").Value
                };

                foreach (XElement subcategoryElement in categoryElement.Descendants("Subcategory"))
                {
                    Subcategory subcategory = new Subcategory()
                    {
                        Name = subcategoryElement.Element("Name").Value,
                        Description = subcategoryElement.Element("Description").Value
                    };

                    foreach (XElement itemElement in subcategoryElement.Descendants("Item"))
                    {
                        Item item = new Item()
                        {
                            Name = itemElement.Element("Name").Value,
                            Year = 0,
                            EngineCapacity = 0.0,
                            DriveType = itemElement.Element("DriveType").Value
                        };

                        if (int.TryParse(itemElement.Element("Year").Value, out int year))
                        {
                            item.Year = year;
                        }

                        if (double.TryParse(itemElement.Element("EngineCapacity").Value, out double engineCapacity))
                        {
                            item.EngineCapacity = engineCapacity;
                        }

                        subcategory.Items.Add(item);
                    }

                    category.Subcategories.Add(subcategory);
                }

                categories.Add(category);
            }
        }

        private void CategoryListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Category selectedCategory = categoryListBox.SelectedItem as Category;

            if (selectedCategory != null)
            {
                CategoryWindow categoryWindow = new CategoryWindow(selectedCategory);
                categoryWindow.ShowDialog();
            }
        }
    }
}
