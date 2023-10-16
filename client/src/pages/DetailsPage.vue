<template>
    {{ recipe.title }}
</template>

<script>
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import Pop from '../utils/Pop';
import { RecipeService } from '../services/RecipeService';
import { AppState } from '../AppState';

export default {
    setup() {
        const route = useRoute()

        onMounted(() => {
            getRecipe();
        })

        async function getRecipe() {
            try {
                await RecipeService.getRecipe(route.params.recipeId)
            } catch (error) {
                Pop.error(error)
            }
        }

        return {
            recipe: computed(() => AppState.activeRecipe)
        };
    },
};
</script>


<style></style>