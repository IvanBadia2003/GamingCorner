<script setup lang="ts">
import Tarjet from '@/components/Tarjet.vue';

import { useGameStore } from '@/stores/GameStore';

const GameStore = useGameStore();
GameStore.fetchGames();

</script>

<template>

  <section class="irregular-div">


  </section>

  <section class="content">

  </section>
</template>

<style scoped>
.irregular-div {
  width: 100%;
  height: 450px;
  /* Altura máxima del div */
  background-image: url('https://cdn2.steamgriddb.com/file/sgdb-cdn/hero/81b69a02d9469be08c2426117991d9f0.png');
  background-position: top;
  background-size: cover;
  clip-path: polygon(0 0, 100% 0, 100% 100%, 0 86.67%);
  /* Forma irregular */



}

.content {
  height: 2000px;

}
</style>
