using MonkeyFestDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFestDemo.Services
{
    public interface ISeriesService
    {
        Task<IEnumerable<Serie>> GetAllSeriesAsync();
    }
}
