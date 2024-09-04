<script setup lang="ts">
import { ref, onMounted } from 'vue';

const props = defineProps<{
  idProduct: number,
  name: string,
  price: number,
  image: string,
  isGrid: boolean
  isProduct?: boolean  
}>()


const isSelected = ref(false)


</script>


<template>
  <router-link v-if="props.isGrid && props.isProduct == true" :to="{
    name: 'description-product',
    params: {
      id: props.idProduct
    }
  }">
    <article class="card">
      <div class="card__img">
        <img :src="props.image" alt="">
        <div class="discount">
          <span>-50%</span>
        </div>
      </div>
      <div class="card__info">
        <span class="card__title">{{ props.name }}</span>
        <span class="card__price">{{ props.price }}€</span>
      </div>
    </article>
  </router-link>
  <div v-if="props.isProduct == undefined">
    <article class="card">
      <div class="card__img">
        <img :src="props.image" alt="">
        <div class="discount">
          <span>-50%</span>
        </div>
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


    .discount {
      position: absolute;
      height: 40px;
      width: 30px;
      background-color: orange;
      right: 15px;
      top: -10px;
      border-top-right-radius: 5px;
      border-bottom-right-radius: 10px;
      border-bottom-left-radius: 10px;
      border: rgb(46, 46, 46) 2px solid;

      display: flex;
      align-items: center;
      justify-content: center;

      span {
        transform: rotate(270deg);
        color: white;
      }

    }

    .discount::after {
      position: absolute;
      content: "";
      background-color: orangered;
      height: 10px;
      width: 10px;
      top: 0;
      right: 30px;
      clip-path: polygon(100% 100%, 0 100%, 100% 0, 100% 0);
      border: rgb(46, 46, 46) 2px solid;

    }

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