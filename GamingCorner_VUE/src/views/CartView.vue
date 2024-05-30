<template>
    <div>
        <h2>Carrito de Compras</h2>
        <ul>
            <li v-for="item in cartStore.cartItems" :key="item.videogameId">
                <img :src="item.imageURL" alt="Game Image" width="50" />
                <span>{{ item.name }} - {{ item.quantity }} x {{ item.price }} €</span>
                <button @click="removeFromCart(item.videogameId)">Eliminar</button>
            </li>
        </ul>
        <p><strong>Total:</strong> {{ totalPrice }} €</p>
        <p><strong>Total Artículos:</strong> {{ totalItems }}</p>
        <button @click="clearCart">Vaciar Carrito</button>
    </div>
</template>

<script setup lang="ts">
import { useCartStore } from '@/stores/CartStore';
import { computed } from 'vue';

const cartStore = useCartStore();
const cartItems = computed(() => cartStore.cartItems);
const totalPrice = computed(() => cartStore.totalPrice);
const totalItems = computed(() => cartStore.totalItems);

const removeFromCart = (videogameId: number) => {
    cartStore.removeFromCart(videogameId);
};

const clearCart = () => {
    cartStore.clearCart();
};
</script>

<style scoped>
/* Estilos para el componente */
</style>