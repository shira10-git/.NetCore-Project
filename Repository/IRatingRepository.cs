using Entities;

namespace Repositories
{
    public interface IRatingRepository
    {
        Task<Rating> Post(Rating r);
    }
}