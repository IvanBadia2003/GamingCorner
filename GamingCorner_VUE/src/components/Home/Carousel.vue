<script setup>
import { useGameStore } from '@/stores/GameStore';
import Tarjet from '@/components/Tarjet.vue';
import { Swiper, SwiperSlide } from 'swiper/vue';
import 'swiper/swiper-bundle.css';
import { ref } from 'vue';

const GameStore = useGameStore();
GameStore.fetchGames();

const slidesPerView = ref(2);

const breakpoints = {
  750: {
    slidesPerView: 3,
  },
  0: {
    slidesPerView: 2,
  },
  1500: {
    slidesPerView: 4,
  },
};

function onSwiper(swiper) {
  console.log(swiper);
}

function onSlideChange() {
  console.log('slide change');
}

</script>

<template>
    <swiper 
        :slides-per-view="slidesPerView" 
        :space-between="50" 
        @swiper="onSwiper" 
        @slideChange="onSlideChange" 
        :loop="true"
        :breakpoints="breakpoints"
        :navigation="true">
        <swiper-slide v-for="game in GameStore.games" :key="game.videogameId">
            <Tarjet :idGame="game.videogameId" :name="game.name" :price="game.price" :image="game.imageURL"></Tarjet>
        </swiper-slide>
    </swiper>
</template>

<style scoped>
/* Puedes agregar estilos personalizados aquí */
.swiper {
    width: 90%;
    height: 100%;
    /* Center slide text vertically */
    display: flex;
    justify-content: center;
    align-items: center;
}

.swiper-slide {
    text-align: center;
    font-size: 18px;
}
</style>
