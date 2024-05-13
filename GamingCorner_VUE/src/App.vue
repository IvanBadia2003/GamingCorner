<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import HeaderComponent from './components/HeaderComponent.vue';
</script>

<template>
  
    <HeaderComponent />
  

  <main>
    <RouterView />
  </main>
</template>

<style>
body {
  text-align: center;
  padding: 0px;
  margin: 0;
  position: relative;
}


</style>
