﻿using MonkeyFestDemo.Models;
using MonkeyFestDemo.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MonkeyFestDemo.ViewModels
{
    public class SeriesListPageViewModel : ViewModelBase
    {
        private readonly ISeriesService _seriesService;
        public SeriesListPageViewModel(INavigationService navigationService, ISeriesService seriesService) :
            base(navigationService)
        {
            _seriesService = seriesService;
            Title = "MonkeyFest Series";
            SeriesList = new ObservableCollection<Serie>();
            GetSeriesFromAPI();
        }
        private ObservableCollection<Serie> seriesList;
        public ObservableCollection<Serie> SeriesList
        {
            get { return seriesList; }
            set { SetProperty(ref seriesList, value); }
        }

        private Serie serie;
        public Serie Serie
        {
            get { return serie; }
            set
            {
                SetProperty(ref serie, value);
                //Send single object to details
                if (value != null)
                {
                    ViewDetails.Execute();
                }
            }
        }

        private DelegateCommand viewDetails;
        public DelegateCommand ViewDetails =>
            viewDetails ?? (viewDetails = new DelegateCommand(ExecuteViewDetails));

        void ExecuteViewDetails()
        {
            //Go to the next page...
            var parameters = new NavigationParameters();
            parameters.Add("model", Serie);
            NavigationService.NavigateAsync("SerieDetailsPage", parameters);
        }

        async void GetSeriesFromAPI()
        {
            IsRunning = true;
            var result = await _seriesService.GetAllSeriesAsync();
            IsRunning = false;
            foreach (var item in result)
            {
                SeriesList.Add(item);
            }
            //TODO: Track Event with App Center
        }
    }
}
