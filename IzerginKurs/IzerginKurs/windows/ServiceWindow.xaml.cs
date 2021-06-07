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
using System.Windows.Shapes;

namespace IzerginKurs.windows
{
    /// <summary>
    /// Логика взаимодействия для ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window, INotifyPropertyChanged
    {
        public ServiceWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ServiceList = Core.DB.ServiceNikita.ToList();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private List<ServiceNikita> _ServiceList;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<ServiceNikita> ServiceList
        {
            get
            {

                return _ServiceList;


            }
            set
            {
                _ServiceList = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ServiceList"));
                }
                {

                }

            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var SelectedService = ProductListView.SelectedItem as ServiceNikita;
            var EditServiceWindow = new windows.ServiceNikit(SelectedService);
            if ((bool)EditServiceWindow.ShowDialog())
            {
                // при успешном завершении не забываем перерисовать список услуг
                PropertyChanged(this, new PropertyChangedEventArgs("ServiceList"));
                // и еще счетчики - их добавьте сами
            }
        }
    }
}
