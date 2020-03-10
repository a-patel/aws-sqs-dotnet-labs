#region Imports
using System.Threading.Tasks;
using AwsSQSLabs.Web.Models;
#endregion

namespace AwsSQSLabs.Web.Services
{
    public interface IMovieService
    {
        Task PublishMovie(MovieModel movieData);
    }
}
