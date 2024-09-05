<script setup lang="ts">
import { useGameStore } from '@/stores/GameStore';
import { useConsoleStore } from '@/stores/ConsoleStore';
import Tarjet from '@/components/Tarjet.vue';
import { Swiper, SwiperSlide } from 'swiper/vue';
import 'swiper/swiper-bundle.css';
import { ref } from 'vue';

const GameStore = useGameStore();
GameStore.fetchGames();

const ConsoleStore = useConsoleStore();
ConsoleStore.fetchConsoles();

const props = defineProps({
    isGame: {
        type: Boolean
    }

});
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

function onSwiper(swiper: any) {
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
        <swiper-slide v-if="isGame" v-for="game in GameStore.games" :key="game.videogameId">
            <Tarjet :idGame="game.videogameId" :name="game.name" :price="game.price" :image="game.imageURL" :is-grid="true" :isGame="props.isGame"></Tarjet>
        </swiper-slide>
        <swiper-slide v-else v-for="console in ConsoleStore.consoles" :key="console.consoleId">
            <Tarjet :idGame="console.consoleId" :name="console.name" :price="console.price" :image="console.imageURL" :is-grid="true" :isGame="props.isGame"></Tarjet>
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
