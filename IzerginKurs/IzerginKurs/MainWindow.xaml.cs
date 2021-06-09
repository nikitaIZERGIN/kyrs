using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace IzerginKurs
{
    public partial class ServiceNikita
    {
        public Uri ImagePreviewService
        {
            get
            {
                var imageName = System.IO.Path.Combine(Environment.CurrentDirectory, Photo ?? "");
                return System.IO.File.Exists(imageName) ? new Uri(imageName) : new Uri("pack://application:,,,/img/picture.jpg");
            }
        }
    }
    public partial class UserNikit
    {
        public Boolean MinSalary
        {
            get
            {
                return Price > 30000;
            }
        }
        public string Users
        {
            get
            {
                return FirstName + "" + LastName + "" + MiddleName;
            }
        }
        public double DiscountFloat
        {
            get
            {
                return Convert.ToSingle(Price);
            }
        }
        public Uri ImagePreview
        {
            get
            {
                var imageName = System.IO.Path.Combine(Environment.CurrentDirectory, Photo ?? "");
                return System.IO.File.Exists(imageName) ? new Uri(imageName) : new Uri("pack://application:,,,/img/picture.jpg");
            }
        }
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            UserList = Core.DB.UserNikit.ToList();
        }
        private List<UserNikit> _UserList;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<UserNikit> UserList
        {
            get
            {


                var FilteredServiceList = _UserList.FindAll(item =>
                   item.DiscountFloat >= CurrentDiscountFilter.Item1 &&
                     item.DiscountFloat < CurrentDiscountFilter.Item2
                     
                     );

                if (SearchFilter != "")
                    FilteredServiceList = FilteredServiceList.Where(item =>
                        item.Users.IndexOf(SearchFilter, StringComparison.OrdinalIgnoreCase) != -1).ToList();


                if (SortPriceAscending)
                {

                    return FilteredServiceList.OrderBy(item => (item.Price))
                .ToList();

                }
                else
                {

                    return FilteredServiceList.OrderByDescending(item => (item.Price))
                .ToList();
                }
            }
            set
            {
                _UserList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("UserList"));
                    PropertyChanged(this, new PropertyChangedEventArgs("ServicesCount"));
                    PropertyChanged(this, new PropertyChangedEventArgs("FilteredServicesCount"));
                }
            }
        }
        private Boolean _SortPriceAscending = true;
        public Boolean SortPriceAscending
        {
            get { return _SortPriceAscending; }
            set
            {
                _SortPriceAscending = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("UserList"));
                    PropertyChanged(this, new PropertyChangedEventArgs("ServicesCount"));
                    PropertyChanged(this, new PropertyChangedEventArgs("FilteredServicesCount"));
                }
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            SortPriceAscending = (sender as RadioButton).Tag.ToString() == "1";
        }

       
        public List<string> FilterByDiscountNamesList
        {
            get
            {
                return FilterByDiscountValuesList
                    .Select(item => item.Item1)
                    .ToList();
            }
        }
        private Tuple<double, double> _CurrentDiscountFilter = Tuple.Create(double.MinValue, double.MaxValue);

        public Tuple<double, double> CurrentDiscountFilter
        {
            get
            {
                return _CurrentDiscountFilter;
            }
            set
            {
                _CurrentDiscountFilter = value;
                if (PropertyChanged != null)
                {
                    // при изменении фильтра список перерисовывается
                    PropertyChanged(this, new PropertyChangedEventArgs("UserList"));
                    PropertyChanged(this, new PropertyChangedEventArgs("ServicesCount"));
                    PropertyChanged(this, new PropertyChangedEventArgs("FilteredServicesCount"));
                }
            }
        }

        private void DiscountFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DiscountFilterComboBox.SelectedIndex >= 0)
                CurrentDiscountFilter = Tuple.Create(
                    FilterByDiscountValuesList[DiscountFilterComboBox.SelectedIndex].Item2,
                    FilterByDiscountValuesList[DiscountFilterComboBox.SelectedIndex].Item3

                );
        }

        private List<Tuple<string, double, double>> FilterByDiscountValuesList =
         new List<Tuple<string, double, double>>() {
        Tuple.Create("Все записи", 0d, 1000000d),
        Tuple.Create("от 10000 до 50000", 10000d, 60000d),
        Tuple.Create("от 60000 до 100000", 60000d, 100000d),

    };

        private string _SearchFilter = "";
        public string SearchFilter
        {
            get { return _SearchFilter; }
            set
            {
                _SearchFilter = value;
                if (PropertyChanged != null)
                {
                    // при изменении фильтра список перерисовывается
                    PropertyChanged(this, new PropertyChangedEventArgs("UserList"));
                    PropertyChanged(this, new PropertyChangedEventArgs("ServicesCount"));
                    PropertyChanged(this, new PropertyChangedEventArgs("FilteredServicesCount"));

                }
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            SearchFilter = SearchFilterTextBox.Text;
        }

        public int ServicesCount
        {
            get
            {
                return _UserList.Count;
            }

        }
        public int FilteredServicesCount
        {
            get
            {
                return _UserList.Count;
            }
        }
        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            //  создаем новую услугу
            var NewService = new UserNikit();

            var NewServiceWindow = new windows.UserWindowxaml(NewService);
            if ((bool)NewServiceWindow.ShowDialog())
            {
                //список услуг нужно перечитать с сервера
                UserList = Core.DB.UserNikit.ToList();
                PropertyChanged(this, new PropertyChangedEventArgs("UserList"));
                PropertyChanged(this, new PropertyChangedEventArgs("FilteredProductsCount"));
                PropertyChanged(this, new PropertyChangedEventArgs("ProductsCount"));
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
          
            var item = ProductListView.SelectedItem as UserNikit;
            if (item == null)
            {
                MessageBox.Show("Не выбран клиент");
                return;
            }





            Core.DB.UserNikit.Remove(item);

            // сохраняем изменения
            Core.DB.SaveChanges();

            
            UserList = Core.DB.UserNikit.ToList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var SelectedService = ProductListView.SelectedItem as UserNikit;
            var EditServiceWindow = new windows.UserWindowxaml(SelectedService);
            if ((bool)EditServiceWindow.ShowDialog())
            {
                // при успешном завершении не забываем перерисовать список услуг
                PropertyChanged(this, new PropertyChangedEventArgs("UserList"));
                // и еще счетчики - их добавьте сами
            }
        }

        private void ServiceShow_Click(object sender, RoutedEventArgs e)
        {
            var openServiceNikit = new windows.ServiceWindow();
            openServiceNikit.ShowDialog();
        }
    }
}
