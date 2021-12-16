using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookStoreContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new BookStoreContext();
            Load();
        }
        private void Load()
        {
            BooksGrid.ItemsSource = _context.Books.ToList();
        }
        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(TbPrice.Text, out decimal price))
            {
                return;
            }
            Book book = new()
            {
                Name = TbName.Text,
                Price = price,
                Author = TbAuthor.Text,
                Category = TbCategory.Text,

            };
            _context.Books.Add(book);
            _context.SaveChanges();
            Load();
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (BooksGrid.SelectedItem is Book selectedBook)
            {
                if (!decimal.TryParse(TbPrice.Text, out decimal price))
                {
                    return;
                }
                selectedBook.Name = TbName.Text;
                selectedBook.Price = price;
                selectedBook.Author = TbAuthor.Text;
                selectedBook.Category = TbCategory.Text;
                _context.SaveChanges();
                Load();
            }
           
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (BooksGrid.SelectedItem is Book selectedBook)
            {
                _context.Books.Remove(selectedBook);
                _context.SaveChanges();
                Load();
            }

        }
        private void BooksGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BooksGrid.SelectedItem is Book selectedBook)
            {
                TbName.Text = selectedBook.Name;
                TbPrice.Text = selectedBook.Price.ToString();
                TbAuthor.Text = selectedBook.Author;
                TbCategory.Text = selectedBook.Category;
            }
            
        }

    }
}
