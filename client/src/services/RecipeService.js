import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class recipeService{
    async getRecipes(){
        const res = await api.get('/api/recipes')
        logger.log('fetched recipes ✅', await res.data)
        AppState.recipes = res.data.map(recipe => new Recipe(recipe))
    }

    async getRecipe(recipeId){
        const res = await api.get(`/api/recipes/${recipeId}`)
        logger.log('fetched recipe ✅', res.data)
        AppState.activeRecipe = new Recipe(res.data)
    }
}

export const RecipeService = new recipeService