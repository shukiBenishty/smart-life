using BE.Models;
using BL;
using Prism.Commands;
using System;
using System.Windows.Input;

namespace GUI.ViewModel
{
    public  class RegisterViewModel :ViewModelBase
    {

        private IBlRouter _blRouter;
        private Profile profile;

        public RegisterViewModel(BL.IBlRouter blRouter)
        {
            _blRouter = blRouter;
            profile = new Profile();
            bodyDimmenssions = new BodyDimmenssions();
            SaveCommand = new  DelegateCommand<Type>(OnSave, CanSave);
        }

        private bool CanSave(Type arg)
        {
            return true;
        }

        private async void OnSave(Type obj)
        {
           await   _blRouter.RegisterDataSave(BodyDimmenssions, Profile);
        }

        public Profile Profile
        {
            get { return profile; }
            set { profile = value; }
        }

        private BodyDimmenssions bodyDimmenssions;

        public BodyDimmenssions BodyDimmenssions
        {
            get { return bodyDimmenssions; }
            set { bodyDimmenssions = value; }
        }

        public ICommand SaveCommand { get; }


    }
}
