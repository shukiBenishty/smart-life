using Autofac;
using BL;
using GUI.View;
using GUI.View.Services;
using GUI.ViewModel;
using GUI.ViewModel.google;
using Prism.Events;

namespace GUI.Startup
{
    public class Bootstrapper
    {

        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();

            builder.RegisterType<MainWindow>().AsSelf();

            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<RegisterViewModel>().AsSelf();
            builder.RegisterType<AddMenuViewModel>().AsSelf();
            builder.RegisterType<ActivityViewModel>().As<IActivityViewModel>();
            builder.RegisterType<AddMenuViewModel>().As<IAddMenuViewModel>();
            builder.RegisterType<GoogleLoginViewModel>().As<IGoogleLoginViewModel>();
            builder.RegisterType<HomeViewModel>().As<IHomeViewModel>();
            builder.RegisterType<TopMainWindowViewModel>().AsSelf();
            

            builder.RegisterType<BlRouter>().As<IBlRouter>();
            builder.RegisterType<SearchFoodView>().AsSelf();
            
            builder.RegisterType<SearchViewModel>().
                As<ISearchViewModel>();


            return builder.Build();
        }
    }
}
