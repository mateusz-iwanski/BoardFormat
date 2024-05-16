using BoardFormat.MVVM.Views;

namespace BoardFormat
{
    public partial class App : Application
    {
        public App()
        {

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NBaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXpfc3RWQ2ZZUUJwXkU=");            


            InitializeComponent();

            //MainPage = new AMain();
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new AppShell();
            //MainPage = new CabinetLibraryView();
        }
    }
}
