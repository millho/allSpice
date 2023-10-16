<template>
    <section @click="getRecipe()" data-bs-toggle="modal" data-bs-target="#recipe-modal"
        class="row text-dark border border-dark rounded elevation-1">
        <div class="col-12 col-md-6">
            <h5>{{ recipe.title }}</h5>
            <p>{{ recipe.category }}</p>
        </div>
        <div class="col-12 col-md-6">
            <img :src="recipe.img" class="img">
        </div>
    </section>
</template>


<script>
import { Recipe } from '../models/Recipe';
import { RecipeService } from '../services/RecipeService';
import Pop from '../utils/Pop';

export default {
    props: { recipe: { type: Recipe, required: true } },
    setup(props) {
        return {
            async getRecipe() {
                try {
                    const recipeId = props.recipe.id
                    await RecipeService.getRecipe(recipeId)
                } catch (error) {
                    Pop.error(error)
                }
            }
        };
    },
};
</script>


<style lang="scss" scoped>
.img {
    height: 25vh;
    width: 100%;
    object-fit: cover;
    object-position: center;
}
</style>