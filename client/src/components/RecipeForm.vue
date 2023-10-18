<template>
    <form @submit="createRecipe()">
        <input v-model="recipeData.title" type="text" placeholder="Title">
        <input v-model="recipeData.instructions" type="text" placeholder="Recipe Instructions">
        <input v-model="recipeData.img" type="text" placeholder="Recipe Image URL">
        <input v-model="recipeData.category" type="text">
    </form>
</template>

<script>
import { ref } from 'vue';

export default {
    setup() {
        const recipeData = ref({});

        return {
            recipeData,
        };
    },
};
</script>


<style></style>