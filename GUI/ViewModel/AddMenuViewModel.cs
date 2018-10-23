using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Events;
using GUI.Event;
using BE.Events;
using Prism.Commands;

namespace GUI.ViewModel
{
    public class AddMenuViewModel :  IAddMenuViewModel
    {
        private IEventAggregator _eventAggregator;

        public AddMenuViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            AddFoodCommand = new DelegateCommand<Type>(OnAddFoodOpen, CanAddFoodOpen);
            AddExerciseCommand = new DelegateCommand<Type>(OnAddExercise, CanAddExercise);
            AddBiometrcCommand = new DelegateCommand<Type>(OnAddBiometrc, CanAddBiometrc);
            OpenHomeCommand = new DelegateCommand<Type>(OnOpenHome, CanOpenHome);
        }

        private bool CanOpenHome(Type obj)
        {
            return true;
        }

        private void OnOpenHome(Type obj)
        {
            _eventAggregator.GetEvent<OpenHomeEvent>().Publish();
        }

        public AddMenuViewModel()
        {
        }

        private bool CanAddBiometrc(Type obj)
        {
            return true;
        }

        private void OnAddBiometrc(Type obj)
        {
            _eventAggregator.GetEvent<BE.Events.OpenAddBiometrcEvent>().Publish();
        }

        private bool CanAddExercise(Type obj)
        {
            return true;
        }

        private void OnAddExercise(Type obj)
        {

            _eventAggregator.GetEvent<OpenAddExerciseEvent>().Publish(
                 new OpenAddExerciseEventArg());
        }

        private bool CanAddFoodOpen(object arg)
        {
            return true;
        }


        private void OnAddFoodOpen(Type obj)
        {
            _eventAggregator.GetEvent<OpenAddFoodEvent>().Publish(
                new OpenAddFoodEventArg());
        }

        public Task LoadAsync(int id)
        {
            throw new NotImplementedException();
        }
        
        public ICommand OpenHomeCommand { get; }
        public ICommand AddFoodCommand { get; }
        public ICommand AddExerciseCommand { get; }
        public ICommand AddBiometrcCommand { get; }


    }
}
