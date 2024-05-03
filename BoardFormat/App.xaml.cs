using BoardFormat.MVVM.Views;

namespace BoardFormat
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AMain();
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new AppShell();
            //MainPage = new CabinetLibraryView();
        }
    }
}
