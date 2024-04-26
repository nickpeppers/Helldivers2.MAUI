using CommunityToolkit.Mvvm.ComponentModel;

namespace Helldivers2.MAUI.Models
{
    public partial class Note : ObservableObject
    {
        public string Id = Guid.NewGuid().ToString();

        [ObservableProperty]
        string? _title;

        [ObservableProperty]
        string? _description;
    }
}