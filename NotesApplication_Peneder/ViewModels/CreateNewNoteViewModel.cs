using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using NotesExercise03_Peneder.Services;

namespace NotesExercise03_Peneder.ViewModels
{
    public class CreateNewNoteViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private readonly IDataService _dataService;

        private readonly IDialogService _dialogService;


        public CreateNewNoteViewModel(INavigationService navigationService,
                                      IDataService dataService,
                                      IDialogService dialogService)
        {
            this._navigationService = navigationService;
            this._dataService = dataService;
            this._dialogService = dialogService;

            Text = "";

            Time = DateTime.Now;
            DispatcherTimer time = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            time.Tick += new EventHandler<object>(time_tick);
            time.Start();
        }

        public DateTime Time { get; set; }


        public void AddNote()
        {
            _dataService.SaveNote(new Note(Text, DateTime.Now));
            Text = string.Empty;
        }

        private void time_tick(object sender, object e)
        {
            Time = DateTime.Now;
        }

        public bool CanAddNote => !string.IsNullOrEmpty(Text);
        public string Text { get; set; }

        public void NavigateBack()
        {
            _navigationService.GoBack();
        }
    }
}
