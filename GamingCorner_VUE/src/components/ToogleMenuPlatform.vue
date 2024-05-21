<script setup lang="ts">
import IconEpicGames from './icons/IconEpicGames.vue';
import IconSteam from './icons/IconSteam.vue';
import IconUbisoft from './icons/IconUbisoft.vue';


defineProps<{
  title: string

}>()

</script>

<template>
  <div class="title">
    <h1>{{ title }}</h1>
  </div>
  <div class="icons">
    <ul>
      <li><IconSteam class="icon"/></li>
      <li><IconUbisoft class="icon"/></li>
      <li><IconEpicGames class="icon"/></li>
    </ul>
  </div>

</template>

<style scoped lang="scss">
.title {
  width: 100%;
  border: 1px solid black;
  border-radius: 50px;
  margin-bottom: 10px;

  h1 {
    text-align: left;
    margin: 5px 10px;

  }
}

.icons {
  width: 100%;
  height: auto;
  display: flex;


  ul {
    width: 100%;
    display: flex;
    justify-content: space-between;
    align-items: center;
    list-style: none;
    padding: 0;
    li {
      .icon {
        max-width: 90px;
        height: auto;
      }
    }
  }
}

</style>