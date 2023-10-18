<template>
    <section class="row">
        <div class="col-6">{{ ingredient.quantity }}</div>
        <div class="col-6">{{ ingredient.name }}</div>
    </section>
</template>

<script>
import { Ingredient } from '../models/Ingredient';

export default {
    props: { ingredient: { type: Ingredient, required: true } },
    setup() {
        return {};
    },
};
</script>


<style></style>