<script setup lang="ts">
import Carousel from '../components/Home/Carousel.vue';
import Gender from '../components/Home/Gender.vue'; 
import { useGameStore } from '@/stores/GameStore';

const GameStore = useGameStore();
GameStore.fetchGames();
</script>

<template>
  <section class="irregular-div horizon"></section>

  <section class="section">
    <span class="section__title">TOP VENTAS</span>
    <div class="section__content">
      <span>JUEGOS</span>
      <Carousel :isGame="true"/>
    </div>
    <div class="section__content">
      <span>CONSOLAS</span>
      <Carousel :isGame="false"/>
    </div>
  </section>

  <section class="section" style="background-color: orange; padding: 50px 0;">
    <span class="section__title">MEJOR VALORADOS</span>
    <div class="section__content">
      <span>JUEGOS</span>
      <Carousel :isGame="true"/>
    </div>
    <div class="section__content">
      <span>CONSOLAS</span>
      <Carousel :isGame="false"/>
    </div>
  </section>

  <section class="irregular-div gow">
    <div class="info">
      <span class="info__title">God Of War</span>
      <div class="info__price">
        <span class="lastPrice">60€</span>
        <span class="newPrice">30€</span>
      </div>
      <button class="info__btn">COMPRAR</button>
    </div>
  </section>

  <section class="section">
    <span class="section__title">CATEGORÍAS</span>
    <div class="section__grid">
      <Gender />
      <Gender />
      <Gender />
      <Gender />
      <Gender />
      <Gender />
      <Gender />
      <Gender />
      <Gender />
      <Gender />
      <Gender />
      <Gender />
    </div>
  </section>
</template>

<style scoped lang="scss">
.irregular-div {
  width: 100%;
  height: 400px;
  background-size: cover;
  clip-path: polygon(0 0, 100% 0, 100% 100%, 0 90.67%);

  @media (min-width: 764px) {
    clip-path: polygon(0 0, 100% 0, 100% 100%, 0 90.67%);
    height: 650px;
  }

  @media (min-width: 1000px) {
    clip-path: polygon(0 0, 100% 0, 100% 100%, 0 86.67%);
  }
}

.horizon {
  background-image: url('https://cdn2.steamgriddb.com/file/sgdb-cdn/hero/81b69a02d9469be08c2426117991d9f0.png');
  background-position: center;
}

.gow {
  background-image: url('https://assets1.ignimgs.com/2018/04/11/godofwar4-header-1523471294398.jpg');
  background-position: left;
  position: relative;

  .info {
    position: absolute;
    left: 10%;
    top: 20%;
    display: flex;
    flex-direction: column;
    align-items: center;
    color: white;

    @media screen and (min-width: 1400px) {
      left: 70%;
      top: 20%;
    }

    &__title {
      font-size: 2.5rem;
    }

    &__price {
      width: 100%;
      display: flex;
      flex-direction: row;
      justify-content: space-evenly;
      align-items: center;

      .lastPrice {
        font-size: 1.5rem;
        text-decoration: line-through;
      }

      .newPrice {
        font-size: 3rem;
      }
    }

    &__btn {
      width: 70%;
      background-color: orange;
      border: none;
      border-radius: 50px;
      color: white;
      padding: 10px 5px;
      font-size: large;
    }
  }
}

.section {
  margin-top: 70px;
  margin-bottom: 70px;
  display: flex;
  flex-direction: column;
  align-items: center;

  &__title {
    color: white;
    font-size: clamp(2rem, 2.5vw, 2rem);
    margin-bottom: 20px;
  }

  &__content {
    color: white;
    width: 90%;
    text-align: left;
    margin-top: 30px;

    span {
      font-size: clamp(1.5rem, 2.5vw, 2rem);
    }
  }

  &__grid {
    display: grid;
    gap: 20px;
    width: 90%;
    margin-top: 30px;

    @media (min-width: 650px) {
      grid-template-columns: repeat(2, 1fr);
    }

    @media (min-width: 900px) {
      grid-template-columns: repeat(3, 1fr);
    }
    @media (min-width: 1500px) {
      grid-template-columns: repeat(4, 1fr);
    }
  }
}
</style>
