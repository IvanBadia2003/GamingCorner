<script setup lang="ts">
import { computed } from 'vue';
import TarjetProfile from '../TarjetProfile.vue';
import { useUserStore } from '@/stores/UserStore';

// Obtén la tienda del usuario
const UserStore = useUserStore();

// Asegúrate de que UserStore.buys esté bien inicializado
console.log(UserStore.transactions);
console.log(UserStore.buys);

// Filtra juegos y consolas
const games = computed(() => 
  UserStore.buys.filter(transaction => transaction.videogameId !== null)
);

const consoles = computed(() => 
  UserStore.buys.filter(transaction => transaction.consoleId !== null)
);

const products = computed(() => 
  UserStore.buys.filter(transaction => transaction.productId !== null)
);
</script>

<template>
    <div class="container">
        <h2>COMPRAS</h2>
        <div class="product-grid" v-if="UserStore.buys.length > 0">
            <!-- Mostrar juegos -->
            <TarjetProfile v-for="(game, index) in games" :key="index"
                :id="(game.videogameId as number)" type="game"/> 

            <!-- Mostrar consolas -->
            <TarjetProfile v-for="console in consoles" :key="(console.consoleId as number)"
                :id="(console.consoleId as number)" type="console"/> 

            <TarjetProfile v-for="product in products" :key="(product.productId as number)"
                :id="(product.productId as number)" type="product"/> 
        </div>
        <p v-else>No has comprado nada</p>
    </div>
</template>


<style scoped lang="scss">
.container {
    align-items: center;
    width: 100%;
    display: flex;
    flex-direction: column;
    .product-grid{
        display: flex;
        width: 20%;

    }
    a{
    font-family: 'Montserrat';
  }
}
</style>