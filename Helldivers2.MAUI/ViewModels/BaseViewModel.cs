using CommunityToolkit.Mvvm.ComponentModel;

namespace Helldivers2.MAUI.ViewModels
{
    public abstract class BaseViewModel : ObservableObject, IBaseViewModel
    {
        /// <summary>
        /// Gets called on Page in OnAppearing override in ViewModel to do work
        /// </summary>
        /// <returns></returns>
        public virtual Task Initialize()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Gets called on Page in OnDisappearing override in ViewModel to do work
        /// </summary>
        /// <returns></returns>
        public virtual Task Uninitialize()
        {
            return Task.CompletedTask;
        }
    }

    public interface IBaseViewModel
    {
        Task Initialize();
        Task Uninitialize();
    }
}