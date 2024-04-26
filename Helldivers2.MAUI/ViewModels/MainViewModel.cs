
using Helldivers2.MAUI.Helpers;
using Helldivers2.MAUI.Services;

namespace Helldivers2.MAUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IHelldiversApiService _helldiversApiService = ServiceHelper.GetService<IHelldiversApiService>();

        public override Task Initialize()
        {
            //TODO: Add try catch and cache/load data
            //var campaignInfo = await _helldiversApiService.GetWarCampaign();
            return base.Initialize();
        }
    }
}