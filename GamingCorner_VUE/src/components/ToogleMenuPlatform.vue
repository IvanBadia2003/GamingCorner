<script setup lang="ts">

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
      <li>steam</li>
      <li>ubisoft</li>
      <li>Epic games</li>
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
  background-color: #fff;
  display: flex;


  ul {
    width: 100%;
    display: flex;
    justify-content: space-around;
    align-items: center;
  }
}
</style>