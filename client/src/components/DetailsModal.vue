<template>
    <div class="modal fade" id="recipe-modal" tabindex="-1" role="dialog" aria-labelledby="modalTitleId" aria-hidden="true">
        <div class="modal-dialog modal-dialog-scrollable modal-dialog-centered modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalTitleId">Modal title</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body container">
                    {{ recipe.title }}
                    <section class="row">
                        <button @click="favoriteRecipe()" v-if="account.id == recipe.creatorId"
                            class="col btn btn-success">Favorite Recipe</button>
                        <button @click="deleteRecipe()" v-if="account.id == recipe.creatorId"
                            class="col btn btn-danger">Delete Recipe</button>
                    </section>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';


export default {
    props: { id: { type: String, required: true }, showButton: { type: Boolean, default: true } },
    setup() {
        return {
            recipe: computed(() => AppState.activeRecipe),
            account: computed(() => AppState.account),

            async favoriteRecipe() {

            },

            async deleteRecipe() {
                try {

                } catch (error) {
                    Pop.error(error)
                }
            }
        };
    },
};


</script>

<style></style>