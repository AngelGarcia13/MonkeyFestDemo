using MonkeyFestDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MonkeyFestDemo.Services
{
    public class SeriesService : ISeriesService
    {
        public async System.Threading.Tasks.Task<IEnumerable<Serie>> GetAllSeriesAsync()
        {
            var result = new List<Serie>();
            try
            {
                using (var client = new HttpClient())
                {
                    var stringResponse = await client.GetStringAsync("https://api.trackseries.tv/v1/Stats/TopSeries/");
                    result = JsonConvert.DeserializeObject<List<Serie>>(stringResponse);
                }
            }
            catch (Exception ex)
            {
                //TODO: App Crash Track with App Center: Crashes.TrackError(ex);
            }

            return result;
        }
    }

}
