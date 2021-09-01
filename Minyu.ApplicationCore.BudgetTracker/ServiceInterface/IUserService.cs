using Minyu.ApplicationCore.BudgetTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minyu.ApplicationCore.BudgetTracker.ServiceInterface
{
   public interface IUserService
    {
        //Task<IEnumerable<UserResponseModel>> GetAllUsers();
        Task<UserDetailResponseModel> GetUserDetail(int id);
        Task<List<UserDetailResponseModel>> GetAllUsers();

        //Task<List<MovieCardResponseModel>> GetTopRevenueMovies();
        
        //Task<List<MovieCardResponseModel>> GetTopRatedMovies();
        
        //Task<IEnumerable<MovieReviewResponseModel>> GetMovieReviews(int id);
    }
}
