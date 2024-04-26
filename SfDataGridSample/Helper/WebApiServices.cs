using Newtonsoft.Json;
using SfDataGridSample.Model;
using System.Collections.ObjectModel;

namespace SfDataGridSample
{
    internal class WebApiServices
    {
        #region Fields

        public static string webApiUrl = "https://ej2services.syncfusion.com/production/web-services/api/Orders"; // Your Web Api here

        HttpClient client;

        #endregion

        #region Constructor
        public WebApiServices()
        {
            client = new HttpClient();
        }
        #endregion

        #region RefreshDataAsync

        /// <summary>
        /// Retrieves data from the web service.
        /// </summary>
        /// <returns>Returns the ObservableCollection.</returns>
        public async Task<ObservableCollection<OrderInfo>>? ReadDataAsync()
        {
            var uri = new Uri(webApiUrl);
            try
            {
                //Sends request to retrieve data from the web service for the specified Uri
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync(); //Returns the response as JSON string
                    return JsonConvert.DeserializeObject<ObservableCollection<OrderInfo>>(content)!; //Converts JSON string to ObservableCollection
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }
        #endregion
    }
}
