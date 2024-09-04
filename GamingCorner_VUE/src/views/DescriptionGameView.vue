<script setup lang="ts">
import { onMounted, computed } from 'vue';
import { useRoute } from 'vue-router';
import { useGameStore } from '@/stores/GameStore';
import { useCartStore } from '@/stores/CartStore';
import BuyComponent from '../components/Description/BuyComponent.vue';
import Requirements from '../components/Description/Requirements.vue';
import Multimedia from '../components/Description/Multimedia.vue';
import Description from '../components/Description/Description.vue';
import Carousel from '@/components/Home/Carousel.vue';

const route = useRoute();
const gameStore = useGameStore();
const cartStore = useCartStore();

const gameId = computed(() => parseInt(route.params.id as string, 10));
onMounted(() => {
    gameStore.fetchGamesById(gameId.value);
});
</script>

<template>
    <div class="container">
        <h2>{{ gameStore.game.name }}</h2>

        <section class="section first">
            <BuyComponent :product="gameStore.game" :isGame="true"/>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Requisitos</h2>
            </div>
            <div class="content">
                <Requirements :productMin="gameStore.requisitos1Array" :productMax="gameStore.requisitos2Array"/>
            </div>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Multimedia</h2>
            </div>
            <div class="content">
                <Multimedia />
            </div>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Descripción</h2>
            </div>
            <div class="content">
                <Description :product="gameStore.game.description" :isGame="true"/>
            </div>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Productos similares</h2>
            </div>
            <div class="content">
                <Carousel :isGame="true" />
            </div>
        </section>
    </div>
</template>

<style scoped lang="scss">
.container {
    margin-top: 100px;
    width: 100%;
    height: auto;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;

    background-color: gray;
    color: white;

    .section {
        width: 90%;
        height: auto;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        background-color: orange;
        border-radius: 15px;
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        margin: 40px auto;
        padding: 20px;


        .title-container {
            width: 100%;
            display: flex;
            border-bottom: 1px solid orange;
            justify-content: center;
        }

        .content {
            width: 100%;
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-top: 15px;

        }
    }
}

@media screen and (min-width: 767px) {
    .container {

        .first {
            flex-direction: row;
            align-items: normal;
        }
    }
}
</style>
