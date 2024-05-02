<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
import HeaderComponent from './components/HeaderComponent.vue';
</script>

<template>
  <header>
    <HeaderComponent />
  </header>

  <main>
    <RouterView />
  </main>
</template>

<style>
body {
  background-color: white;
  text-align: center;
  padding: 0px;
  margin: 0px;
}
</style>
