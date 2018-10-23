using BL;
using GUI.Model;
using Prism.Events;
using System;
using System.Collections.Generic;

namespace GUI.ViewModel
{
    public class WeightGraphViewModel : ViewModelBase
    {
      
        private List<BE.Models.BodyDimmenssions> bodyDimmenssionsList;
        private IEventAggregator _eventAggregator;
        private IBlRouter _blRouter;
        private ProfileRespository _profileRespository;

        public WeightGraphViewModel(IEventAggregator eventAggregator, 
            IBlRouter blRouter, GUI.Model.ProfileRespository profileRespository)
        {
            _eventAggregator = eventAggregator;
            _blRouter = blRouter;
            _profileRespository = profileRespository;

            _eventAggregator.GetEvent<BE.Events.BodyDimmenssionsUpdateEvent>()
                .Subscribe(LoadData);
        }

        private async void LoadData()
        {
            BodyDimmenssionsList = await _blRouter.
                  GetBodyDimmenssions();
        }

        public List<BE.Models.BodyDimmenssions> BodyDimmenssionsList
    {
            get { return bodyDimmenssionsList; }
            set { bodyDimmenssionsList = value;
                OnPropertyChanged(); }
        }

    }
}
