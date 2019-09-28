using MonkeyFestDemo.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonkeyFestDemo.ViewModels
{
   public class SerieDetailsPageViewModel : ViewModelBase
    {
        private Serie serie;
        public Serie Serie
        {
            get { return serie; }
            set { SetProperty(ref serie, value); }
        }

        public SerieDetailsPageViewModel(INavigationService navigationService):
            base(navigationService)
        {
            Title = "Details";
        }
        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            Serie = (Serie)parameters["model"];
            
            //TODO: Add Analytics to track event with the Serie's data
            
            //TODO: Add fake crash if the name of the serie contains "Game of"
        }

    }
}
