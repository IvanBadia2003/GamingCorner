<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { useConsoleStore } from '@/stores/ConsoleStore';
import { useGameStore } from '@/stores/GameStore';
import { useProductStore } from '@/stores/ProductStore';


const props = defineProps<{
  id: number,
  type: string
}>()

const consoleStore = useConsoleStore();
const gameStore = useGameStore();
const productStore = useProductStore();

onMounted(() => {
  if (props.type === 'game') {
    gameStore.fetchGamesById(props.id);
  } else if (props.type === 'console') {
    consoleStore.fetchConsolesById(props.id);
  }else{
    productStore.fetchProductsById(props.id);
  }
});

</script>


<template>
    <article class="card" v-if="type == 'game'">
      <div class="card__img">
        <img :src="gameStore.game.imageURL" alt="">
      </div>
      <div class="card__info">
        <span class="card__title">{{ gameStore.game.name }}</span>
        <span class="card__price">{{ gameStore.game.price }}€</span>
      </div>
    </article>
    <article class="card" v-if="type == 'console'">
      <div class="card__img">
        <img :src="consoleStore.Console.imageURL" alt="">
      </div>
      <div class="card__info">
        <span class="card__title">{{ consoleStore.Console.name }}</span>
        <span class="card__price">{{ consoleStore.Console.price }}€</span>
      </div>
    </article>
    <article class="card" v-if="type == 'product'">
      <div class="card__img">
        <img :src="productStore.product.imageURL" alt="">
      </div>
      <div class="card__info">
        <span class="card__title">{{ productStore.product.name }}</span>
        <span class="card__price">{{ productStore.product.price }}€</span>
      </div>
    </article>

</template>



<style scoped lang="scss">
* {
  text-decoration: none;
}

.card {
  width: auto;
  height: auto;
  position: relative;
  margin-top: 15%;
  display: flex;
  flex-direction: column;
  align-items: center;
  transition: all 0.3s ease;
  border: rgb(46, 46, 46) 5px solid;
  border-radius: 15px;

  @media screen and (min-width: 740px) {
    margin-left: 6%;
    margin-right: 6%;
  }

  &__img {
    width: 100%;
    height: auto;
    position: relative;

    img {
      width: 100%;
      border-radius: 10px 10px 0px 0px;
    }
  }

  &__info {
    width: 100%;
    display: flex;
    justify-content: space-between;
    color: white;
    font-size: clamp(1.2rem, 2vw, 2rem);

    .card__title {
      white-space: nowrap;
      overflow: hidden;
      text-overflow: ellipsis;
      width: 70%;
      text-align: left;
    }

    .card__price {}
  }

}

.card:hover {
  transform: perspective(250px) rotateX(5deg) translateY(-5%) translateZ(0);
}
</style>