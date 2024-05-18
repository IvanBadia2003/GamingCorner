<script setup lang="ts">

import { ref } from 'vue';
import FilterCategory from './FilterCategory.vue';
import jQuery from 'jquery';

import { useFilterStore } from '@/stores/FilterStore';

const FilterStore = useFilterStore();
</script>

<template>
    <aside class="filter-container" v-show="FilterStore.toggleFilter">
        <FilterCategory title="Género" />
        <FilterCategory title="Plataforma" />
        <FilterCategory title="Sistema" />
        <FilterCategory title="Precio" />
        <FilterCategory title="Mano" />
        <FilterCategory title="Ordenar por" />
    </aside>
</template>

<style scoped lang="scss">
.filter-container {
    transition: 0.2s ease;
    width: 100%;
    height: 70vh;

    position: fixed;
    bottom: 0;
    left: 0;
    z-index: 12;

    background-color: blue;
}
</style>