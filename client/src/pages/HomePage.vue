<template>
  <section class="row">
    <div class="col-4">
      {{ recipes }}
    </div>
  </section>
</template>

<script>
import Pop from '../utils/Pop';
import { RecipeService } from '../services/RecipeService';
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';

export default {
  setup() {

    onMounted(() => {
      getRecipes();
    })

    async function getRecipes() {
      try {
        await RecipeService.getRecipes()
      } catch (error) {
        Pop.error(error)
      }
    }

    return {
      recipes: computed(() => AppState.recipes)
    }
  }
}
</script>

<style scoped lang="scss"></style>
