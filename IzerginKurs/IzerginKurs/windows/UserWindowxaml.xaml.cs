using Microsoft.Win32;
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
    /// Логика взаимодействия для UserWindowxaml.xaml
    /// </summary>
    public partial class UserWindowxaml : Window, INotifyPropertyChanged
    {

        public List<string> ListEducaitonValue
        {
            get
            {
                return ListEducation
                    .Select(item => item.Item1)
                    .ToList();
            }
        }

        private List<Tuple<string, string>> ListEducation =
            new List<Tuple<string, string>>()
            {
                Tuple.Create("Среднее","Среднее"),
         Tuple.Create("Высшее","Высшее"),
         Tuple.Create("Среднее Специальное","Среднее Специальное"),

            };
        public UserWindowxaml(UserNikit user)
        {
            InitializeComponent();
            this.DataContext = this;
            CurrentUser = user;
        }
        public UserNikit CurrentUser { get; set; }
        public string WindowName
        {
            get
            {
                return CurrentUser.Id == 0 ? "Новая услуга" : "Редоктирование улсгуи";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void GetImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog GetImageDialog = new OpenFileDialog();
            // задаем фильтр для выбираемых файлов
            // до символа "|" идет произвольный текст, а после него шаблоны файлов раздеренные точкой с запятой
            GetImageDialog.Filter = "Файлы изображений: (*.png, *.jpg)|*.png;*.jpg";
            // чтобы не искать по всему диску задаем начальный каталог
            GetImageDialog.InitialDirectory = Environment.CurrentDirectory;
            if (GetImageDialog.ShowDialog() == true)
            {
                // перед присвоением пути к картинке обрезаем начало строки, т.к. диалог возвращает полный путь
                // (тут конечно еще надо проверить есть ли в начале Environment.CurrentDirectory)
                CurrentUser.Photo = GetImageDialog.FileName.Substring(Environment.CurrentDirectory.Length + 1);
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("CurrentUser"));
                }
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.Price <= 0 || CurrentUser.Price > 1000000)
            {
                MessageBox.Show("Зарплата не может быть меньше или равно нулю или больше 1000000");
                return;
            }

           



           
            // если запись новая, то добавляем ее в список
            if (CurrentUser.Id == 0)
                Core.DB.UserNikit.Add(CurrentUser);

            // сохранение в БД
            try
            {
                Core.DB.SaveChanges();
            }
            catch
            {
            }
            DialogResult = true;
        }
        public string NewProduct
        {
            get
            {
                if (CurrentUser.Id == 0) return "collapsed";
                return "visible";



            }
        }
    }
}
