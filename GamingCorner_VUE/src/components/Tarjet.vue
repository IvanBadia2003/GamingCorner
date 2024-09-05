<script setup lang="ts">
import { ref, onMounted } from 'vue';

const props = defineProps<{
  idGame: number,
  name: string,
  price: number,
  image: string,
  isGrid: boolean
  isGame?: boolean  
}>()


const isSelected = ref(false)


</script>


<template>
  <router-link v-if="props.isGrid && props.isGame == true" :to="{
    name: 'description-game',
    params: {
      id: props.idGame
    }
  }">
    <article class="card">
      <div class="card__img">
        <img :src="props.image" alt="">
      </div>
      <div class="card__info">
        <span class="card__title">{{ props.name }}</span>
        <span class="card__price">{{ props.price }}€</span>
      </div>
    </article>
  </router-link>

  <router-link v-if="props.isGrid && props.isGame == false" :to="{
    name: 'description-console',
    params: {
      id: props.idGame
    }
  }">
    <article class="card">
      <div class="card__img">
        <img :src="props.image" alt="">
      </div>
      <div class="card__info">
        <span class="card__title">{{ props.name }}</span>
        <span class="card__price">{{ props.price }}€</span>
      </div>
    </article>
  </router-link>
  <div v-if="props.isGame == undefined">
    <article class="card">
      <div class="card__img">
        <img :src="props.image" alt="">

      </div>
      <div class="card__info">
        <span class="card__title">{{ props.name }}</span>
        <span class="card__price">{{ props.price }}€</span>
      </div>
    </article>
  </div>
</template>



<style scoped lang="scss">
* {
  text-decoration: none;
}
a{
    font-family: 'Montserrat';
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