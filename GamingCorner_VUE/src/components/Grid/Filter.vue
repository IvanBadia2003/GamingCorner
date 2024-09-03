<script setup lang="ts">
import { ref } from 'vue';
import FilterCategory from '../FilterCategory.vue';
import { useFilterStore } from '@/stores/FilterStore';

const FilterStore = useFilterStore();


</script>

<template>
  <aside class="filter-container" v-if="FilterStore.toggleFilter">
    <!-- Categorías de Filtros -->
    <FilterCategory title="Buscar" />
    <FilterCategory title="Género" />
    <FilterCategory title="Plataforma" />
    <FilterCategory title="Precio" />
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
        width: 20%;
        margin: 9% 5%;
        border-radius: 20px;
        left: 0;

    }
    
}
</style>