<script setup lang="ts">
import Filter from '@/components/Grid/Filter.vue';
import ProductsGrid from '@/components/Grid/ProductsGrid.vue';

import { useFilterStore } from '@/stores/FilterStore';




const FilterStore = useFilterStore();
</script>

<template>
    <section class="content">
      <button class="filterButton" @click="FilterStore.toggleFilter = !FilterStore.toggleFilter">Filtros</button>
  
      <ProductsGrid title="PRODUCTOS DE SEGUNDA MANO" :is-grid="true" type="product"/>
  
      <Filter />
    </section>
  </template>
  
<style scoped lang="scss">
.content {
    background-color: gray;
    height: auto;
    padding-top: 100px;
    padding-bottom: 100px;

    @media screen and (min-width: 720px) {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
    }

    .filterButton {
        background-color: orange;
        border: none;
        padding: 10px;
        color: #fff;
        border-radius: 5px;

        @media screen and (min-width: 720px) {
            position: fixed;
            margin-top: 190px;
            top: 0;
            left: 5%;
        }

    }
}
</style>
