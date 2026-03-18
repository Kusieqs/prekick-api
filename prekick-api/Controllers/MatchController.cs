using Microsoft.AspNetCore.Mvc;

namespace prekick_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        [HttpGet(Name = "GetMatch")]
        public IEnumerable<Match> GetMatch()
        {
            Match m1 = new Match();
            List<Match> list = new List<Match>();
            list.Add(m1);
            return list;
        }
    }
}
