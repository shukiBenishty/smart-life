using BE.Events;
using BL;
using GUI.Event;
using GUI.View;
using GUI.View.Services;
using GUI.ViewModel.google;
using GUI.ViewModel.MainScreen;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GUI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IHomeViewModel _homeViewModel;
        private bool getIsLogOn;
        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;
        private IBlRouter _blRouter;
        private object selectedView;
        private DateTime getDateTime;

        private async void initAsyc()
        {
            GetIsLogOn = await _blRouter.GetislogOn();
        }

        private void OpenProfile(UserLogInSeccEventArg obj)
        {
            GetIsLogOn = true;
        }

        private void OpenAddExercise(OpenAddExerciseEventArg obj)
        {
            var view = new GUI.View.MainScreen.AddExerciseView();
            view.DataContext = new GUI.ViewModel.MainScreen.AddExerciseViewModel();
            SelectedView = view;
        }

        private void OpenAddFood(OpenAddFoodEventArg obj)
        {
            SelectedView = new SearchFoodView(
                new SearchViewModel(_eventAggregator, _messageDialogService, getDateTime, _blRouter));
        }
        
        private void Subscribe()
        {
            _eventAggregator.GetEvent<OpenAddFoodEvent>()
                 .Subscribe(OpenAddFood);
            _eventAggregator.GetEvent<OpenAddExerciseEvent>()
                .Subscribe(OpenAddExercise);
            _eventAggregator.GetEvent<UserLogInSeccEvent>()
               .Subscribe(OpenProfile);
            _eventAggregator.GetEvent<BE.Events.OpenHomeEvent>()
                .Subscribe(OpenHome);
            _eventAggregator.GetEvent<OpenAddBiometrcEvent>()
                .Subscribe(OpenAddBiometrc);
            _eventAggregator.GetEvent<BE.Events.SelectedDateChangedEvent>()
                .Subscribe(OnSelectedDateChanged);
            _eventAggregator.GetEvent<BE.Events.BodyDimmenssionsUpdateEvent>()
                .Subscribe(OnBodyDimmenssionsUpdate);
        }

        private void OnBodyDimmenssionsUpdate()
        {
            throw new NotImplementedException();
        }

        private void OnSelectedDateChanged(SelectedDateChangedEventArg obj)
        {
            getDateTime = obj.SelectedDate;
        }

        private void OpenAddBiometrc()
        {
            var view = new GUI.View.MainScreen.AddBiometrcView();
            view.DataContext = new AddBiometrcViewModel(_blRouter, _eventAggregator);
            SelectedView = view;
        }

        private void OpenHome()
        {
            SelectedView = HomeView;
        }

        public MainViewModel(IEventAggregator eventAggregator,
          IMessageDialogService messageDialogService,
            IAddMenuViewModel addMenuViewModel,
            IGoogleLoginViewModel googleLoginViewModel,
            IHomeViewModel homeViewModel,
            TopMainWindowViewModel topMainWindowViewModel,
            RegisterViewModel registerViewModel,
            IBlRouter blRouter )
        {
            RegisterViewModel = registerViewModel;
            _homeViewModel = homeViewModel;
            AddMenuViewModel = addMenuViewModel;
            GoogleLoginViewModel = googleLoginViewModel;
            TopMainWindowViewModel = topMainWindowViewModel;
            _eventAggregator = eventAggregator;
            _messageDialogService = messageDialogService;
            _blRouter = blRouter;

            Subscribe();

            getDateTime = DateTime.Now;
            GetIsLogOn = false;
            RegisterMode = false;
            initAsyc();

            HomeView = new HomeView();
            HomeView.DataContext = _homeViewModel;
            SelectedView = HomeView;




        }

        public object SelectedView
        {
            get { return selectedView; }
            set { selectedView = value; OnPropertyChanged(); }
        }

        public GUI.View.HomeView HomeView { get;  }
        public IAddMenuViewModel AddMenuViewModel { get; }
        public IGoogleLoginViewModel GoogleLoginViewModel { get;  }
        public TopMainWindowViewModel TopMainWindowViewModel { get; }
        public RegisterViewModel RegisterViewModel { get; }

        public Boolean GetIsLogOn
        {
            get { return getIsLogOn; }
            set {
                getIsLogOn = value;
                OnPropertyChanged();
            }
        }
        private Boolean registerMode;

        public Boolean RegisterMode
        {
            get { return registerMode; }
            set { registerMode = value; OnPropertyChanged(); }
        }

       


    }
}

