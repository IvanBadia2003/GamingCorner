<script setup lang="ts">
import Filter from '@/components/Filter.vue';
import Tarjet from '@/components/Tarjet.vue';

import { useFilterStore } from '@/stores/FilterStore';

const FilterStore = useFilterStore();
</script>

<template>
    <section class="content">
        <button class="filterButton" @click="FilterStore.toggleFilter = !FilterStore.toggleFilter">Filtros</button>
        <div class="grid-container">
            <div class="grid">
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
                <Tarjet></Tarjet>
            </div>
                <Filter/>

        </div>

    </section>
</template>

<style scoped lang="scss">
.content {
    background-color: gray;
    height: auto;

    @media screen and (min-width: 720px) {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
    }

    .filterButton {
        margin-top: 10px;
    
    }

    .grid-container {
        display: flex;
        flex-direction: row;
        align-items: flex-start;
        justify-content: center;
        .grid {
            margin: 9%;
    
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            gap: 32px;
    
            @media screen and (min-width: 720px) {
                grid-template-columns: repeat(3, 1fr);
                /* Máximo 4 columnas */
                gap: 40px;
                row-gap: 80px;
                
            }
    
            @media screen and (min-width: 1250px) {
                grid-template-columns: repeat(4, 1fr);
                /* Máximo 4 columnas */
                gap: 40px;
                row-gap: 80px;
            }
        }

    }
}
</style>
