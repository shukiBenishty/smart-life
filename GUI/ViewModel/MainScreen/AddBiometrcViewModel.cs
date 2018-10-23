using BE.Models;
using BL;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GUI.ViewModel.MainScreen
{
    public class AddBiometrcViewModel :  ViewModelBase
    {
        private float weight;

        public AddBiometrcViewModel(IBlRouter blRouter, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _blRouter = blRouter;
            AddWeightommand =  new DelegateCommand<Type>(OnAddWeight);
        }

        private async void OnAddWeight(Type obj)
        {

            var bodyDimmenssions = new BodyDimmenssions();
            bodyDimmenssions.DateTime = DateTime.Now;
            bodyDimmenssions.Weight = Weight;
            bodyDimmenssions.Height = Height;
            await _blRouter.AddBodyDimmenssions(bodyDimmenssions);
            _eventAggregator.GetEvent<BE.Events.BodyDimmenssionsUpdateEvent>().Publish();


        }

        private float height;

        public float Height
        {
            get { return height; }
            set { height = value; OnPropertyChanged(); }
        }


        public float Weight
        {
            get { return weight; }
            set { weight = value; OnPropertyChanged(); }
        }

        private IEventAggregator _eventAggregator;
        private IBlRouter _blRouter;

        public ICommand AddWeightommand { get; }
    }
}
