using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helldivers2.MAUI.Helpers;
using Helldivers2.MAUI.Models;
using Helldivers2.MAUI.Pages;
using Helldivers2.MAUI.Services;
using System.Collections.ObjectModel;

namespace Helldivers2.MAUI.ViewModels
{
    public partial class NotesViewModel : BaseViewModel, IQueryAttributable
    {
        static readonly INavigationService _navigationService = ServiceHelper.GetService<INavigationService>();
        static readonly ICacheService _cacheService = ServiceHelper.GetService<ICacheService>();

        [ObservableProperty]
        ObservableCollection<Note>? _notes = new ObservableCollection<Note>();

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var note = query[Constants.Notes] as Note;
            var noteType = query[Constants.NoteType] as string;

            if (note != null)
            {
                switch (noteType)
                {
                    case Constants.RemoveNote:
                        {
                            var deleteNote = Notes?.FirstOrDefault(n => n.Id == note?.Id);
                            if (deleteNote != null)
                            {
                                Notes?.Remove(deleteNote);
                            }
                            break;
                        }
                    case Constants.CancelEdit:
                        {
                            var updatedNote = Notes?.FirstOrDefault(n => n.Id == note?.Id);
                            if (updatedNote != null)
                            {
                                updatedNote.Title = note?.Title;
                                updatedNote.Description = note?.Description;
                            }
                            break;
                        }
                    case Constants.ModifyNote:
                        break;
                }

                await SaveNotesToStorage();
            }
        }

        public override async Task Initialize()
        {
            try
            {
                var notes = await _cacheService.GetNotes();
                if (notes != null && notes.Any())
                {
                    Notes = new ObservableCollection<Note>(notes);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"CacheService.GetNotes() Error: {exc}");
            }
        }

        public override async Task Uninitialize()
        {
            await SaveNotesToStorage();
        }

        /// <summary>
        /// Saves Notes to Akavache Secure Storage
        /// </summary>
        /// <returns></returns>
        async Task SaveNotesToStorage()
        {
            try
            {
                if (Notes != null && Notes.Any())
                {
                    await _cacheService.SaveNotes(Notes.ToList());
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"CacheService.SaveNotes() Error: {exc}");
            }
        }

        [RelayCommand]
        async Task AddNote()
        {
            var newNote = new Note();
            Notes?.Add(newNote);
            await _navigationService.NavigateToAsync(nameof(ModifyNotesPage), new Dictionary<string, object>
            {
                { Constants.Notes, newNote },
                { Constants.NoteType, Constants.AddNote }
            });
        }

        [RelayCommand]
        async Task RemoveNote(Note note)
        {
            Notes?.Remove(note);
            await SaveNotesToStorage();
        }

        [RelayCommand]
        async Task ModifyNote(Note note)
        {
            await _navigationService.NavigateToAsync(nameof(ModifyNotesPage), new Dictionary<string, object>
            {
                { Constants.Notes, note },
                { Constants.NoteType, Constants.ModifyNote },
            });
        }
    }
}