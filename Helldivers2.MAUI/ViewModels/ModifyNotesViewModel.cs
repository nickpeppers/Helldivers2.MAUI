using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helldivers2.MAUI.Helpers;
using Helldivers2.MAUI.Models;
using Helldivers2.MAUI.Services;

namespace Helldivers2.MAUI.ViewModels
{
    public partial class ModifyNotesViewModel : BaseViewModel, IQueryAttributable
    {
        static readonly INavigationService _navigationService = ServiceHelper.GetService<INavigationService>();

        [ObservableProperty]
        Note? _note;

        Note? _defaultNote;

        string? _noteType;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Note = query[Constants.Notes] as Note;
            if (Note != null)
            {
                _defaultNote = new Note
                {
                    Id = Note.Id,
                    Title = Note?.Title,
                    Description = Note?.Description
                };
            }

            _noteType = query[Constants.NoteType] as string;
        }

        [RelayCommand]
        private async Task Cancel()
        {
            if (_defaultNote != null)
            {
                await _navigationService.PopAsync(new Dictionary<string, object>
                {
                    { Constants.Notes, _defaultNote },
                    { Constants.NoteType, _noteType == Constants.AddNote ? Constants.RemoveNote : Constants.CancelEdit }
                });
            }
        }

        [RelayCommand]
        private async Task Save()
        {
            if (Note != null)
            {
                await _navigationService.PopAsync(new Dictionary<string, object>
                {
                    { Constants.Notes, Note },
                    { Constants.NoteType, Constants.ModifyNote }
                });
            }
        }
    }
}