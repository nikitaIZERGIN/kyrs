
<table style="width: 100%;">
  <tr>
    <td style="text-align: center; border: none;"> 
        Министерство образования и науки РФ <br/>
        ГБПОУ РМЭ "Йошкар-Олинский Технологический колледж 
    </td>
  </tr>
  <tr>
    <td style="text-align: center; border: none; height: 45em;">
        <h2>
            Курсовой проект <br/>
            "Проектирование и разработка информационных систем" <br/>
            для группы И-31
        <h2>
    </td>
  </tr>
  <tr>
     <td style="text-align: right; border: none; height: 20em;">
        <div style="float: right;" align="left">
            <b>Разработал</b>: <br/>
            Изергин Никита Рудольфович <br/>
            <b>Проверил</b>: <br/>
            Колесников Евгений Иванович
        </div>
    </td>
  </tr>
  <tr>
    <td style="text-align: center; border: none; height: 1em;">
        г.Йошкар-Ола, 2021
    </td>
  </tr>
</table>

<div style="page-break-after: always;"></div>

https://github.com/nikitaIZERGIN/kyrs

# Содержание

* [Теоретическая часть](#Теоретическая-часть)
* [Практическая часть, разработка бд](#Практическая-часть.-Разработка-БД)
* [Практическая часть, разработка кода ИС](#Практическая-часть.-Разработка-кода-ИС)

# Теоретическая-часть
## Диаграммы

### Предметная область  Школа иностранных-языков. Подсистема работы с сотрудниками.


### Диаграмма Use Case:
![ER диаграмма](./img/UseCase.PNG) 

### Диаграмма ER:
![ER диаграмма](./img/ERD.png) 
### Диаграмма Состояний:
![ER диаграмма](./img/Состояний.PNG) 




# Практическая часть
## Программирование С#


### Приложение было разработанно в Visual Studio, пример работы программы:
### Главное окно:
![MainWindow](./img/MainWindow.PNG)
#### Прмер кода разметки страницы:



```xml
<Window x:Class="IzerginKurs.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:IzerginKurs"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Window.Resources>
        <Style TargetType="Button">
            <Setter Property="Background" Value="LightBlue"/>
            <Setter Property="BorderBrush"  Value="DarkGray"/>
            <Setter Property="FontFamily"  Value="Segoe Black"/>
            <Setter Property="Foreground"  Value="Black"/>



        </Style>
    </Window.Resources>
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="150"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <Image 
        Margin="5"
        Source="./img/logo.jpg" 
        VerticalAlignment="Top"/>
        <StackPanel Grid.Column="0"
                    VerticalAlignment="Bottom">
            <Button  x:Name="DeleteButton" Click="DeleteButton_Click"  Content="Удалить" ></Button>
            <Button   Content="Редактировать"  Click="EditButton_Click"  x:Name="EditButton" ></Button>
            <Button Content="Добавить"
                    x:Name="AddService"
                    Click="AddService_Click"
                   
               ></Button>
            <Button Content="Посмотреть услуги"
                    x:Name="ServiceShow"
                    Margin="0 0 0 0"
                    Click="ServiceShow_Click"
                    
                   
                   ></Button>
            <Button Content="Выход"
                    x:Name="ExitButton"
                    Margin="0 0 0 10"
                   ></Button>



        </StackPanel>


        <Grid Grid.Column="1">
            <Grid.RowDefinitions>
                <RowDefinition Height="30"/>
                <RowDefinition Height="1*"/>
                <RowDefinition Height="30"/>
            </Grid.RowDefinitions>
            <StackPanel 
    Orientation="Horizontal" 
    VerticalAlignment="Center"
                Grid.Row="0">
                <Label Content="Цена: "/>
                <RadioButton 
        GroupName="Price"
        Tag="1"
        Content="по возрастанию" 
        IsChecked="True" 
        Checked="RadioButton_Checked"
        VerticalContentAlignment="Center"/>
                <RadioButton 
        GroupName="Price" 
        Tag="2"
        Content="по убыванию" 
        Checked="RadioButton_Checked"
        VerticalContentAlignment="Center"/>
                <Label Content="Фильтр по скидке: "
                     Margin="10,0,0,0"
                        VerticalAlignment="Center"/>
                <ComboBox
                     Name="DiscountFilterComboBox"
                        SelectedIndex="0"
                        SelectionChanged="DiscountFilterComboBox_SelectionChanged"
                         ItemsSource="{Binding FilterByDiscountNamesList}"/>
                <Label Content="Поиск"/>
                <TextBox
                    x:Name="SearchFilterTextBox"
                    Width="250"
                    KeyUp="TextBox_KeyUp"
                    VerticalAlignment="Center"
                    />
            </StackPanel>





            <ListView 
            Grid.Column="1"
            Grid.Row="1"
            ItemsSource="{Binding UserList}"
            x:Name="ProductListView">

                <ListView.ItemTemplate>


                    <DataTemplate>
                        <!-- рисуем вокруг элемента границу с загругленными углами -->
                        <Border 
                BorderThickness="1" 
                BorderBrush="Black" 
                CornerRadius="5">
                            <!-- основная "сетка" из 3-х столбцов: картинка, содержимое, цена -->
                            <Grid 
                    Margin="10" 
                    HorizontalAlignment="Stretch">
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="64"/>
                                    <ColumnDefinition Width="*"/>
                                    <ColumnDefinition Width="100"/>
                                </Grid.ColumnDefinitions>


                                <Image
                        Width="64" 
                        Height="64"
                        Source="{Binding Path=ImagePreview}" />

                               

                                <TextBlock 
                        Text="{Binding Price}" 
                        Grid.Column="2" 
                        HorizontalAlignment="Right" 
                        Margin="10"/>


                                <!-- для содержимого рисуем вложенную сетку -->
                                <Grid Grid.Column="1" Margin="5">
                                    <Grid.RowDefinitions>
                                        <RowDefinition Height="20"/>
                                        <RowDefinition Height="20"/>
                                        <RowDefinition Height="*"/>
                                    </Grid.RowDefinitions>

                                    <StackPanel
                            Orientation="Horizontal">
                                        <TextBlock 
                                Text="{Binding Users }"/>
                                        <TextBlock 
                                Text=" | "/>
                                        <TextBlock 
                                Text="{Binding RoleNikit.Title}"/>
                                    </StackPanel>

                                    <TextBlock 
                            Text="Образование:" 
                            Grid.Row="1"/>
                                    <TextBlock 
                            Text="{Binding Education}" 
                            Grid.Row="2"/>
                                </Grid>

                            </Grid>
                        </Border>
                    </DataTemplate>

                </ListView.ItemTemplate>
                <ListView.ItemContainerStyle>
                    <Style 
            TargetType="ListViewItem">
                        <Style.Triggers>
                            <DataTrigger
                            Binding="{Binding MinSalary}"
                            Value="True">
                                <Setter
                                Property="Background"
                                Value="LightGreen"/>
                            </DataTrigger>
                        </Style.Triggers>
                        <Setter 
                Property="HorizontalContentAlignment"
                Value="Stretch" />
                    </Style>
                </ListView.ItemContainerStyle>
            </ListView>
            <StackPanel Grid.Row="2" Orientation="Horizontal">
                <Label Content="{Binding FilteredServicesCount}"></Label>
                <Label >/</Label>
                <Label Content="{Binding ServicesCount}"/>
            </StackPanel>
        </Grid>

    </Grid>
</Window>

#### Пример Логики главной страницы:

```cs
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
            if (SelectedService == null)
            {
                MessageBox.Show("Не выбран");
                return;
            }

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


```


#### Прмер кода разметки страницы редактирования и добавления услуг:
```xml
     <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="auto"/>
            <ColumnDefinition  Width="*"/>
        </Grid.ColumnDefinitions>

        <Image 
                Grid.Column="0"
            VerticalAlignment="Top"
          MaxWidth="200"
            MaxHeight="200"
           Source="{Binding CurrentUser.ImagePreview}" />

        <StackPanel Grid.Column="1" Orientation="Horizontal" Visibility="{Binding NewProduct}">
            <Label Content="Идентификатор услуги: "/>
            <Label Content="{Binding CurrentUser.id}"/>
        </StackPanel>
        <StackPanel Grid.Column="1" Margin="5 60">
            <Label Content="Имя"/>
            <TextBox Text="{Binding CurrentUser.LastName}"/>
            <Label Content="Фамилия"/>
            <TextBox Text="{Binding CurrentUser.FirstName}"/>
            <Label Content="Отчество"/>
            <TextBox Text="{Binding CurrentUser.MiddleName}"/>
            <Label Content="Зарплата"/>
            <TextBox Text="{Binding CurrentUser.Price}"/>
           
            
            <Label Content="Образование"/>
            <ComboBox
                     Name="DiscountFilterComboBox"
                        SelectedIndex="0"
                       SelectedItem="{Binding CurrentUser.Education}"
                         ItemsSource="{Binding ListEducaitonValue}"/>
            <Label Content="Телефон"/>
            <TextBox Text="{Binding CurrentUser.Phone}"/>
            <Label Content="Email"/>
            <TextBox Text="{Binding CurrentUser.Email}"/>
            <Label Content="Год рождения"/>
            <TextBox Text="{Binding CurrentUser.BirthDate}"/>





            <Button Width="800" Margin="5" HorizontalAlignment="Left" Click="GetImageButton_Click">Выбор картинки</Button>
            <Button Width="800" Margin="5" HorizontalAlignment="Left" Click="SaveButton_Click">Сохранить</Button>
        </StackPanel>
    </Grid>
    ```
#### Пример Логики страницы редактирования заказов:

```cs
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

```
# Тестировние
## Создание библиотеки классов и Юнит тестов
### Библиотека классов
```cs
namespace GalimulinKursTest
{
    public class Class1
    {
        public int DiscountPrice(int price)
        {
            int sum = ((price / 100) * 15) * price;
            return sum;
        }
        public string SalaryNotNull(int salary)
        {
            if (Salary <= 0 || Salary > 100000)
            {
                return "цена не может быть меньше или равана нулю  или больше 100000";
            }
            else
                return "Все правильно";
         }
         
         

    }
}

```
### Юнит тесты (Сделал токлько 2)

```cs
namespace UniTestKurs
{
    [TestClass]
    public class UnitTest1
    {
        static Class1 disk__price;
        [ClassInitialize]
        static public void Init(TestContext tc)
        {
            disk__price = new Class1();
        }
        [TestMethod]
        public void DiscountPrice()
        {
            Assert.AreEqual(disk__price.DiscountPrice(100), 1500);
        }
        [TestMethod]
        public void SummaNotNull()
        {
            Assert.AreEqual(disk__price.SalaryNotNull(-2), "цена не может быть меньше или равана нулю  или больше 100000");
        }
        
       
        
    }
}
