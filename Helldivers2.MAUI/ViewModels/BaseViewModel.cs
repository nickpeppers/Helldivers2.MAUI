using CommunityToolkit.Mvvm.ComponentModel;

namespace Helldivers2.MAUI.ViewModels
{
    public abstract class BaseViewModel : ObservableObject, IBaseViewModel
    {
        public virtual Task Initialize()
        {
            return Task.CompletedTask;
        }

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