# MonkeyFestDemo
App Center Workshop


1. Clone the repo's master branch.
2. Create an App Center Project and connect the Build source to the Github project
3. Add App Center SDK (see overview Xamarin.Forms Tab)
4. Search for the TrackEvent TODO's
  
//When app fetchs data
  Analytics.TrackEvent("List of series fetched from internet");
 
//When click on a detail 
  var analyticsData = new Dictionary<string, string>
            {
                { "Name", Serie.Name }
            };
  Analytics.TrackEvent("Serie clicked", analyticsData);


5. Search for the Crash TODO's:
//When click on a detail 
 if (Serie.Name.Contains("Game of"))
            {
                Crashes.TrackError(new Exception("The winter is here!"));
            }


