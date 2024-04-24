
using Helldivers2.MAUI.Helpers;
using Helldivers2.MAUI.Services;

namespace Helldivers2.MAUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IHelldiversApiService _helldiversApiService = ServiceHelper.GetService<IHelldiversApiService>();

        public override async Task Initialize()
        {
            var campaignInfo = await _helldiversApiService.GetWarCampaign();
        }
    }
}