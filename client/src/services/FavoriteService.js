import { AppState } from "../AppState"
import { FavoriteRecipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class favoriteService{
    async favoriteRecipe(favorite){
        const res = await api.post('/api/favorites', favorite)
        logger.log('created favorite ✅', res.data)
        AppState.favoriteRecipes.push(new FavoriteRecipe(res.data))
    }

    async getFavorites(){
        const res = await api.get('/account/favorites')
        logger.log('fetched favorite recipes ✅', res.data)
        AppState.favoriteRecipes = res.data.map(favorite => new FavoriteRecipe(favorite))
    }
}

export const FavoriteService = new favoriteService