<script setup lang="ts">
import { onMounted, computed } from 'vue';
import { useRoute } from 'vue-router';
import { useGameStore } from '@/stores/GameStore';
import { useCartStore } from '@/stores/CartStore';
import BuyComponent from '../components/Description/BuyComponent.vue';
import Requirements from '../components/Description/Requirements.vue';
import Multimedia from '../components/Description/Multimedia.vue';
import Description from '../components/Description/Description.vue';



const route = useRoute();
const gameStore = useGameStore();
const cartStore = useCartStore();

interface Gender {
    genderId: number,
    videogameId: number
}

interface Game {
    videogameId: number;
    name: string;
    pegi: number;
    description: string;
    category: string;
    stock: number;
    available: boolean;
    platform: string;
    price: number;
    imageURL: string;
    listVideogameGender: Gender
}


const gameId = computed(() => parseInt(route.params.id as string, 10));
onMounted(() => {
    gameStore.fetchGamesById(gameId.value);
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
        <h2> {{ gameStore.game.name }} </h2>

        <section class="section first">
            <BuyComponent/>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Requisitos</h2>
            </div>
            <div class="content">
                <Requirements/>
            </div>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Multimedia</h2>
            </div>
            <div class="content">
                <Multimedia/>
            </div>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Descripción</h2>
            </div>
            <div class="content">
                <Description/>
            </div>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Opiniones</h2>
            </div>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Productos similares</h2>
            </div>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Consolas con las que puedes jugar</h2>
            </div>
        </section>

        <!--         <button @click="addToCart">Añadir al Carrito</button>
 -->
    </div>
</template>

<style scoped lang="scss">
.container {
    width: 100%;
    height: auto;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;

    .section {
        width: 90%;
        height: auto;
        margin: 20px;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;

        .title-container {
            width: 100%;
            display: flex;
            border-bottom: 1px solid blue;
        }

        .content{
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
