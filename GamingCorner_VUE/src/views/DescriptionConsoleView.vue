<script setup lang="ts">
import { onMounted, computed } from 'vue';
import { useRoute } from 'vue-router';
import { useGameStore } from '@/stores/GameStore';
import { useConsoleStore } from '@/stores/ConsoleStore';
import { useCartStore } from '@/stores/CartStore';
import BuyComponent from '../components/Description/BuyComponent.vue';
import Requirements from '../components/Description/Requirements.vue';
import Multimedia from '../components/Description/Multimedia.vue';
import Description from '../components/Description/Description.vue';
import Specifications from '@/components/Description/Specifications.vue';


const route = useRoute();
const consoleStore = useConsoleStore();
const cartStore = useCartStore();

interface Gender {
    genderId: number,
    videogameId: number
}

interface Console {
    consoleId: number;
    name: string;
    platformId: number;
    specifications: string;
    stock: number;
    available: boolean;
    price: number;
    imageURL: string;
}


const ConsoleId = computed(() => parseInt(route.params.id as string, 10));
onMounted(() => {
    consoleStore.fetchConsolesById(ConsoleId.value);
});

/* const addToCart = () => {
    const game: Game = gameStore.game; // Asegúrate de que Game esté definido correctamente
    if (game.name) {
        cartStore.addToCart({
            videogameId: game.videogameId,
            name: game.name,
            price: game.price,
            quantity: 1,
            imageURL: game.imageURL
        });
    }
}; */
</script>


<template>
    <div class="container">
        <h2> {{ consoleStore.Console.name }} </h2>

        <section class="section first">
            <BuyComponent :product="consoleStore.Console" :isGame="false"/>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Especificaciones</h2>
            </div>
            <div class="content">
                <Specifications :product="consoleStore.Console.specifications"/>
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
                <h2>Productos similares</h2>
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
