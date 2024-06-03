<script setup lang="ts">

import { ref } from 'vue';
import FilterCategory from './FilterCategory.vue';
import jQuery from 'jquery';

import { useFilterStore } from '@/stores/FilterStore';

const FilterStore = useFilterStore();
</script>

<template>
    <aside class="filter-container" v-if="FilterStore.toggleFilter">
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
    transition: .2s;
    width: 100%;
    height: auto;


    position: fixed;
    bottom: 0;
    right: 0;
    z-index: 12;

    border-radius: 50px 50px 0 0;
    border: 2px solid orange;
    background-color: #a09c9c;

    @media screen and (min-width: 720px) {
        display: block;
        width: 30%;
        position: relative;
        margin: 9% 0;
        border-radius: 50px ;





    }
}
</style>