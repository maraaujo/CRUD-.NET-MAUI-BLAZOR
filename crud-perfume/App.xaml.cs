using crud_perfume.Database;

namespace crud_perfume
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Database = new DbContext();
            MainPage = new MainPage();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "crud-perfume" };
        }
        public static DbContext Database { get; private set; }
    }
}
