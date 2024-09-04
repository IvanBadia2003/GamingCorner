<script setup lang="ts">
import { ref, onMounted, computed } from 'vue';
import Tarjet from '@/components/Tarjet.vue'; 
import Modal from '@/components/Modal.vue'; 
import { useUserStore } from '@/stores/UserStore';
import { useRoute } from 'vue-router';

// Obtén la tienda del usuario
const UserStore = useUserStore();

// Obtenemos el ID del usuario de la ruta o de la tienda
const route = useRoute();
const userId = route.params.userId || UserStore.user.userId;

// Define el estado para las transacciones
/* const transactions = computed(() => UserStore.user.transactions);
 */
/* // Define el estado para los detalles de los productos
const products = computed(() => UserStore.user.itemDetails.products);
const videogames = computed(() => UserStore.user.itemDetails.videogames);
const consoles = computed(() => UserStore.user.itemDetails.consoles); */

// Define el estado para el juego seleccionado para el modal
const selectedGameId = ref<number | null>(null);

// Llama a fetchUserTransactions cuando el componente se monta
/* onMounted(() => {
    UserStore.fetchUserTransactions(Number(userId));
});
 */
// Maneja el clic en la tarjeta para mostrar el modal
function handleCardClick(id: number) {
    selectedGameId.value = id;
}

</script>

<template>
    <div class="container">
        <h2>COMPRAS</h2>
        <div class="product-grid">
            <!-- Mostrar juegos -->
<!--             <Tarjet v-if="videogames" v-for="(game, id) in videogames" :key="id"
                :idGame="id" :name="game.name" :price="game.price" :image="game.imageURL" :isGrid="false"
                :isGame="true" @click="handleCardClick(id)" /> -->
            <!-- Mostrar consolas -->
<!--             <Tarjet v-if="consoles" v-for="(console, id) in consoles" :key="id"
                :idConsole="id" :name="console.name" :price="console.price" :image="console.imageURL" :isGrid="false"
                :isGame="false" @click="handleCardClick(id)" /> -->
        </div>
<!--         <Modal v-if="selectedGameId" v-model:modelValue="selectedGameId" title="Código del juego">
            <template #default>
                <h3>ID del Juego: {{ selectedGameId }}</h3>
            </template>
        </Modal> -->
    </div>
</template>

<style scoped>
/* Añadir estilo para el contenedor y las tarjetas aquí */
</style>


<style scoped lang="scss">
.container {
    align-items: center;
    width: 100%;
    display: flex;
    flex-direction: column;
}
</style>