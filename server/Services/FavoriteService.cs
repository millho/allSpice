using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Repositories;

namespace server.Services
{
    public class FavoriteService
    {
        private readonly FavoriteRepository _repo;
        public FavoriteService(FavoriteRepository repo)
        {
            _repo = repo;
        }
    }
}