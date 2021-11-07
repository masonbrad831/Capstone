using Capstone.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand CalendarViewCommand { get; set; }
        public RelayCommand TodoViewCommand { get; set; }
        public RelayCommand BrowserCommand { get; set; }



        public HomeViewModel HomeVM { get; set; }
        public BrowserViewModel BrowserVM { get; set; }
        public TodoViewModel TodoVM { get; set; }
        public CalendarViewModel CalendarVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {

            HomeVM = new HomeViewModel();
            CalendarVM = new CalendarViewModel();
            TodoVM = new TodoViewModel();
            BrowserVM = new BrowserViewModel();


            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            CalendarViewCommand = new RelayCommand(o =>
            {
                CurrentView = CalendarVM;
            });

            TodoViewCommand = new RelayCommand(o =>
            {
                CurrentView = TodoVM;
            });

            BrowserCommand = new RelayCommand(o =>
            {
                CurrentView = BrowserVM;
            });
        }
    }
}
