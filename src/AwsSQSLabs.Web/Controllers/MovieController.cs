#region Imports
using AwsSQSLabs.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AwsSQSLabs.Web.Models;
#endregion

namespace AwsSQSLabs.Web.Controllers
{
    public class MovieController : ControllerBase
    {
        #region Members

        private readonly IMovieService _movieService;

        #endregion

        #region Ctor

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ReleaseMovie([FromBody] MovieModel model)
        {
            await _movieService.PublishMovie(model);

            return Ok();
        }

        #endregion
    }
}
