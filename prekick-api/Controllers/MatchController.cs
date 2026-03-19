using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace prekick_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        [HttpGet(Name = "GetMatch")]
        public async Task<IEnumerable<Match>> GetMatch()
        {
            var dates = CreateEndAndStartOfWeek();
            string dateFrom = dates.Item1.ToString("yyyy-MM-dd");
            string dateTo = dates.Item2.ToString("yyyy-MM-dd");

            string competitions = "PL,PD,BL1,SA,FL1";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.football-data.org/v4/");
                client.DefaultRequestHeaders.Add("X-Auth-Token", " ");

                string requestUrl = $"matches?dateFrom={dateFrom}&dateTo={dateTo}&competitions={competitions}";

                var response = await client.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }

            Match m1 = new Match();
            List<Match> list = new List<Match>();
            list.Add(m1);
            return list;
        }
        public static (DateTime, DateTime) CreateEndAndStartOfWeek()
        {
            int diff = (7 + (DateTime.Today.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime startOfWeek = DateTime.Today.AddDays(-1 * diff).Date;
            DateTime endOfWeek = startOfWeek.AddDays(6).Date;

            return (startOfWeek, endOfWeek);
        }
    }
}
