using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;

namespace MSAzureCogServiceExamples.ViewModels
{
    public class HomePageViewModel
    {
        INavigationService _navigationService;

        public ICommand GoToFacePageCommand { get; set; }
        public ICommand GoToEmotionPageCommand { get; set; }
        public ICommand GoToAzureFAQBotPageCommand { get; set; }
        public ICommand GoToVisionPageCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoToFacePageCommand = new DelegateCommand(GoToFacePage);
            GoToEmotionPageCommand = new DelegateCommand(GoToEmotionPage);
            GoToAzureFAQBotPageCommand = new DelegateCommand(GoToAzureFAQBotPage);
            GoToVisionPageCommand = new DelegateCommand(GoToVisionPage);
        }

        async void GoToFacePage()
        {
            await _navigationService.NavigateAsync("FacePage");
        }

        async void GoToEmotionPage()
        {
            await _navigationService.NavigateAsync("EmotionPage");
        }

        async void GoToAzureFAQBotPage()
        {
            await _navigationService.NavigateAsync("AzureFAQBotPage");
        }

        async void GoToVisionPage()
        {
            await _navigationService.NavigateAsync("VisionPage");
        }
    }
}
