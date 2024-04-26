
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helldivers2.MAUI.Helpers;
using Helldivers2.MAUI.Models;
using Helldivers2.MAUI.Services;
using System.Collections.ObjectModel;

namespace Helldivers2.MAUI.ViewModels
{
    public partial class CampaignViewModel : BaseViewModel
    {
        static readonly IHelldiversApiService _helldiversApiService = ServiceHelper.GetService<IHelldiversApiService>();
        static readonly ICacheService _cacheService = ServiceHelper.GetService<ICacheService>();

        [ObservableProperty]
        ObservableCollection<Campaign>? _campaigns;

        [ObservableProperty]
        bool _loading = false;

        [ObservableProperty]
        bool _refreshing = false;

        public override async Task Initialize()
        {
            try
            {
                if (Loading)
                    return;

                Loading = true;
                await LoadCampaignData();
            }
            catch (Exception exc)
            {
                Console.WriteLine($"helldiversApiService.GetWarCampaign() Error: {exc}");
                await LoadCachedWarCampaign();
            }
            finally
            {
                Loading = false;
            }
        }

        async Task LoadCampaignData()
        {
            var campaignInfo = await _helldiversApiService.GetWarCampaign();
            Campaigns = new ObservableCollection<Campaign>(campaignInfo);
            await _cacheService.SaveCampaigns(campaignInfo);
        }

        async Task LoadCachedWarCampaign()
        {
            try
            {
                var campaignInfo = await _cacheService.GetCampaigns();
                Campaigns = new ObservableCollection<Campaign>(campaignInfo);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"CacheService.GetCampaigns() Error: {exc}");
            }
        }

        [RelayCommand]
        async Task Refresh()
        {
            try
            {
                await LoadCampaignData();
            }
            catch (Exception exc)
            {
                Console.WriteLine($"helldiversApiService.GetWarCampaign() Error: {exc}");
                await LoadCachedWarCampaign();
            }
            finally
            {
                Refreshing = false;
            }
        }
    }
}