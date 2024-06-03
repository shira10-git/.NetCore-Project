using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RatingService : IRatingService
    {
        private IRatingRepository ratingRepository;
        public RatingService(IRatingRepository ratingRepository)
        {
            this.ratingRepository = ratingRepository;
        }

        public async Task<Rating> Post(Rating r)
        {
            var rating = await ratingRepository.Post(r);
            return rating;
        }
    }
}
