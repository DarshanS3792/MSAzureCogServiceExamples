using MSAzureCogServiceExamples.Models.BingSearch;
using MSAzureCogServiceExamples.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MSAzureCogServiceExamples.ViewModels
{
    public class ImageSearchPageViewModel : BindableBase
    {
        private string _searchString = "Cute Monkey";
        public string SearchString
        {
            get { return _searchString; }
            set { SetProperty(ref _searchString, value); }
        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private List<ImageResult> _searchResult;
        public List<ImageResult> Images
        {
            get { return _searchResult; }
            set { SetProperty(ref _searchResult, value); }
        }
        public ICommand SearchForImagesCommand { get; set; }

        public ImageSearchPageViewModel()
        {
            SearchForImagesCommand = new DelegateCommand(async () => await SearchForImages());
        }

        public async Task SearchForImages()
        {
            IsBusy = true;
            //Bing Image API
            var url = $"https://api.cognitive.microsoft.com/bing/v7.0/images" +
                      $"search?q={_searchString}" +
                      $"&count=20&offset=0&mkt=en-us&safeSearch=Strict";

            try
            {
                var result = await BingImageSearchService.SearchForImages(url);
                Images = result.Images.Select(i => new ImageResult
                {
                    ContextLink = i.HostPageUrl,
                    FileFormat = i.EncodingFormat,
                    ImageLink = i.ContentUrl,
                    ThumbnailLink = i.ThumbnailUrl,
                    Title = i.Name
                }).ToList();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
