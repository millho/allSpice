<template>
  <section class="row">
    <button class="btn btn-primary col m-2" @click="filter = ''">All</button>
    <button class="btn btn-primary col m-2" @click="filter = 'favorites'">Favorites</button>
    <button class="btn btn-primary col m-2" @click="filter = 'created'">My Recipes</button>
  </section>
  <section class="row">
    <div class="col-12 col-md-4 px-md-4 g-3" v-for="recipe in recipes" :key="recipe.id">
      <RecipeCard :recipe="recipe" />
    </div>
  </section>
</template>

<script>
import Pop from '../utils/Pop';
import { RecipeService } from '../services/RecipeService';
import { computed, watchEffect, ref } from 'vue';
import { AppState } from '../AppState';

export default {
  setup() {
    const filter = ref('')

    watchEffect(() => {
      getRecipes();
      // getFavorites();
      getCreated();
    })

    async function getRecipes() {
      try {
        await RecipeService.getRecipes()
      } catch (error) {
        Pop.error(error)
      }
    }

    // async function getFavorites() {
    //   try {
    //     await FavoriteService.getFavorites()
    //   } catch (error) {
    //     Pop.error(error)
    //   }
    // }

    async function getCreated() {
      try {
        // await RecipeService.getRecipes()
      } catch (error) {
        Pop.error(error)
      }
    }

    return {
      recipes: computed(() => {
        if (filter.value == 'favorites') { return AppState.favoriteRecipes }
        if (filter.value == 'created') { return AppState.createdRecipes }
        else { return AppState.recipes }
      })
    }
  }
}
</script>

<style scoped lang="scss"></style>
