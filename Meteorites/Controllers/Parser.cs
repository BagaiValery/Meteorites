using Meteorites.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Meteorites.Controllers
{
    public class Parser
    {
        public async Task<IEnumerable<MeteoriteViewModel>> GetData()
        {
            const string URLJSON = "https://data.nasa.gov/resource/y77d-th95.json";
            using (HttpClient httpClient = new HttpClient())
            {

                try
                {
                    using (var httpResponseMessage = await httpClient.GetAsync(URLJSON))
                    {

                        string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                        var meteorites = JsonConvert.DeserializeObject<IEnumerable<MeteoriteViewModel>>(jsonResponse);
                        return meteorites;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    var meteorites = new List<MeteoriteViewModel>();
                    return meteorites;
                }
            }
        }
    }
}
