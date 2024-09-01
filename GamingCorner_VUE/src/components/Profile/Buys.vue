<script setup lang="ts">
import ProductGrid from '@/components/Grid/ProductGrid.vue';

</script>

<template>
    <div class="container">
        <ProductGrid title="Comprado" :is-grid="false" />
    </div>

</template>

<style scoped lang="scss"> 
.container{
    align-items: center;
    width: 100%;
    display: flex;
    flex-direction: column;
    }
</style>