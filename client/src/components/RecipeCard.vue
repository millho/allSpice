<template>
    <section class="row text-dark border border-dark rounded elevation-4">
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

export default {
    props: { recipe: { type: Recipe, required: true } },
    setup() {
        return {};
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