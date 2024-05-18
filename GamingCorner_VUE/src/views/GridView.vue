<script setup lang="ts">
import Filter from '@/components/Filter.vue';
import Tarjet from '@/components/Tarjet.vue';

import { useFilterStore } from '@/stores/FilterStore';

const FilterStore = useFilterStore();
</script>

<template>
    <section class="content">
        <Filter/>
        <button class="filterButton" @click="FilterStore.toggleFilter = !FilterStore.toggleFilter">Filtros</button>
        <div class="grid-container">
            <Tarjet></Tarjet>
            <Tarjet></Tarjet>
            <Tarjet></Tarjet>
            <Tarjet></Tarjet>
            <Tarjet></Tarjet>
            <Tarjet></Tarjet>
            <Tarjet></Tarjet>
            <Tarjet></Tarjet>
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
        repeat(
            auto-fit,
            minmax(150px, 1fr)
        );

        gap: 32px;
    }
}
</style>