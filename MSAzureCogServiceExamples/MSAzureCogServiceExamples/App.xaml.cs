using MSAzureCogServiceExamples.ViewModels;
using MSAzureCogServiceExamples.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MSAzureCogServiceExamples
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<FacePage, FacePageViewModel>();
            containerRegistry.RegisterForNavigation<EmotionPage, EmotionPageViewModel>();
            containerRegistry.RegisterForNavigation<AzureFAQBotPage>();
            containerRegistry.RegisterForNavigation<VisionPage, VisionPageViewModel>();
        }
    }
}
