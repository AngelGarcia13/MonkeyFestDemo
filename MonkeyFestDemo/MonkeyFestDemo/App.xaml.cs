using Prism;
using Prism.Ioc;
using MonkeyFestDemo.ViewModels;
using MonkeyFestDemo.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MonkeyFestDemo.Services;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MonkeyFestDemo
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/SeriesListPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ISeriesService, SeriesService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SeriesListPage, SeriesListPageViewModel>();
            containerRegistry.RegisterForNavigation<SerieDetailsPage, SerieDetailsPageViewModel>();
        }
        protected override void OnStart()
        {
            base.OnStart();
            AppCenter.Start("android=26b0e194-5a11-4c87-aa07-eebb79bebed4;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));
        }
    }
}
