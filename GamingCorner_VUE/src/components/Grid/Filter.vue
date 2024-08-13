<script setup lang="ts">

import { ref } from 'vue';
import FilterCategory from '.././FilterCategory.vue';
import jQuery from 'jquery';

import { useFilterStore } from '@/stores/FilterStore';

const FilterStore = useFilterStore();
</script>

<template>
    <aside class="filter-container" v-if="FilterStore.toggleFilter">
        <FilterCategory title="Género" />
        <FilterCategory title="Sistema" />
        <FilterCategory title="Precio" />
        <FilterCategory title="Producto" />
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

    border-radius: 20px 20px 0 0;
    background-color: orange;

    @media screen and (min-width: 900px) {
        display: block;
        width: 30%;
        margin: 9% 0;
        border-radius: 0 20px 20px 0 ;
        left: 0;
    }
}
</style>