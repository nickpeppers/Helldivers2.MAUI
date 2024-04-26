using Helldivers2.MAUI.ViewModels;

namespace Helldivers2.MAUI.Pages
{
    public class BasePage : ContentPage
    {
        IBaseViewModel? _viewModel;

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                _viewModel = (IBaseViewModel)BindingContext;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                if (_viewModel != null)
                {
                    await _viewModel.Initialize();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("OnAppearing Initialize Exception: " + exc);
            }
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            try
            {
                if (_viewModel != null)
                {
                    await _viewModel.Uninitialize();
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("OnDisappearing Uninitialize Exception: " + exc);
            }
        }
    }
}