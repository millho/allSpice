import { AppState } from "../AppState"
import { Ingredient } from "../models/Ingredient"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class ingredientService{
    async getIngredients(recipeId){
        const res = await api.get(`/api/recipes/${recipeId}/ingredients`)
        logger.log('fetched ingredients ✅', res.data)
        AppState.ingredients = res.data.map(ing => new Ingredient(ing))
    }
}

export const IngredientService = new ingredientService