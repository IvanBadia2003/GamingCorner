// src/stores/cartStore.ts
import { defineStore } from 'pinia';
import { ref, computed } from 'vue';

// Definimos la interfaz del producto en el carrito
interface CartItem {
    videogameId: number;
    name: string;
    price: number;
    quantity: number;
    imageURL: string;
}

export const useCartStore = defineStore('cart', () => {
    // Estado del carrito
    const cartItems = ref<CartItem[]>([]);

    // Computed para el total de artículos en el carrito
    const totalItems = computed(() => cartItems.value.reduce((sum, item) => sum + item.quantity, 0));

    // Computed para el total del precio en el carrito
    const totalPrice = computed(() => cartItems.value.reduce((sum, item) => sum + item.price * item.quantity, 0));

    // Acción para agregar un producto al carrito
    function addToCart(item: CartItem) {
        const existingItem = cartItems.value.find(cartItem => cartItem.videogameId === item.videogameId);
        if (existingItem) {
            existingItem.quantity += item.quantity;
        } else {
            cartItems.value.push(item);
        }
    }

    // Acción para eliminar un producto del carrito
    function removeFromCart(videogameId: number) {
        cartItems.value = cartItems.value.filter(item => item.videogameId !== videogameId);
    }

    // Acción para vaciar el carrito
    function clearCart() {
        cartItems.value = [];
    }

    return { cartItems, totalItems, totalPrice, addToCart, removeFromCart, clearCart };
});
