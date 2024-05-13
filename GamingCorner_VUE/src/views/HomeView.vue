<script setup lang="ts">
import Tarjet from '@/components/Tarjet.vue';

</script>

<template>

  <section class="banner">

  </section>

  <section class="content">
    <Tarjet></Tarjet>
    <Tarjet></Tarjet>
    <Tarjet></Tarjet>
    <Tarjet></Tarjet>
    <Tarjet></Tarjet>
    <Tarjet></Tarjet>
    <Tarjet></Tarjet>
    <Tarjet></Tarjet>
  </section>
</template>

<style scoped>


  .content {
    height: 2000px;
    background-color: beige;

    display: grid;
    grid-template-columns: 
      repeat(
        auto-fit,
        minmax(400px, 1fr)
      );
    gap: 35px;
  }
</style>

