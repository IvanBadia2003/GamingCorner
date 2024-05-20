<script setup lang="ts">
import Filter from '@/components/Filter.vue';
import Tarjet from '@/components/Tarjet.vue';

import { useFilterStore } from '@/stores/FilterStore';
import { useGameStore } from '@/stores/GameStore';
import { onMounted } from 'vue';

const FilterStore = useFilterStore();
const GameStore = useGameStore();
 
GameStore.fetchGames();



</script>

<template>
    <section class="content">
        <Filter />
        <button class="filterButton" @click="FilterStore.toggleFilter = !FilterStore.toggleFilter">Filtros</button>
        <div class="grid-container">
            <Tarjet v-for="game in GameStore.games" 
            :key="game.videogameId" 
            :idGame="game.videogameId" 
            :name="game.name" 
            :pegi="game.pegi" 
            :description="game.description" 
            :category="game.category"
            :stock="game.stock"
            :available="game.available"
            :platform="game.platform"
            :price="game.price"
            :image="game.imageURL"></Tarjet>

        </div>
    </section>

</template>

<style scoped lang="scss">
.content {
    background-color: beige;
    height: auto;

    .filterButton {
        margin-top: 10px;
    }

    .grid-container {
        margin: 15px;
        background-color: #fff;

        display: grid;
        grid-template-columns:
            repeat(auto-fit,
                minmax(150px, 1fr));

        gap: 32px;
    }
}
</style>