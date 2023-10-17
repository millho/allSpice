using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;
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

        internal Favorite Create(Favorite favoriteData)
        {
            Favorite newFavorite = _repo.Create(favoriteData);
            return newFavorite;
        }

        internal Favorite Get(int favoriteId)
        {
            Favorite favorite = _repo.Get(favoriteId);
            if (favorite == null) throw new Exception($"Favorite not found (id:{favoriteId})");
            return favorite;
        }

        internal List<FavoriteRecipe> GetAccountFavorites(string userId)
        {
            List<FavoriteRecipe> recipes = _repo.GetAccountFavorites(userId);
            return recipes;
        }

        internal string Archive(int favoriteId, string userId)
        {
            Favorite favorite = this.Get(favoriteId);
            if (favorite.AccountId != userId) throw new Exception("Unauthorized");
            _repo.Archive(favoriteId);
            return $"Favorite archived (id:{favoriteId})";
        }
    }
}