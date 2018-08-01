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
        public ICommand GoToImageSearchPageCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoToFacePageCommand = new DelegateCommand(GoToFacePage);
            GoToEmotionPageCommand = new DelegateCommand(GoToEmotionPage);
            GoToAzureFAQBotPageCommand = new DelegateCommand(GoToAzureFAQBotPage);
            GoToVisionPageCommand = new DelegateCommand(GoToVisionPage);
            GoToImageSearchPageCommand = new DelegateCommand(GoToImageSearchPage);
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

        async void GoToImageSearchPage()
        {
            await _navigationService.NavigateAsync("ImageSearchPage");
        }
    }
}
