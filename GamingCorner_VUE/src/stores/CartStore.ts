// src/stores/cartStore.ts
import { defineStore } from 'pinia';
import { ref, computed, reactive } from 'vue';


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


// Definimos la interfaz del producto en el carrito
interface CartItem {
    game: Game
    quantity: number;
}

export const useCartStore = defineStore('cartStore', () => {
    const cartItems = ref<Game[]>([]); // Reactive array for cart items
    const quantities = ref<{ [key: number]: number }>({}); // Cantidades seleccionadas para cada producto
    const purchaseItems = reactive<CartItem[]>([]); // Productos a comprar



    const addToCart = (item: Game) => {
        const existingItem = cartItems.value.find(cartItem => cartItem.videogameId === item.videogameId);

        if (existingItem) {

            alert('El juego ya está en tu carrito');
        } else {

            cartItems.value.push({ ...item });
        }
    };

    const removeFromCart = (productId: number) => {
        const existingItem = cartItems.value.findIndex(cartItem => cartItem.videogameId === productId);

        if (existingItem != 1) {
            cartItems.value.splice(existingItem, 1)
            alert('El juego ya está borrado de tu carrito');
        } else {

            alert('El juego no está en tu carrito');
        }
    };

    const totalPrice = computed(() => {
        return cartItems.value.reduce((total, item) => {
            const quantity = quantities.value[item.videogameId] || 1; // Obtiene la cantidad o 1 si no está definida
            return total + (item.price * quantity);
        }, 0);
    });

    const addToPurchase = (item: CartItem) => {
        purchaseItems.push({ ...item });

    };

    return { cartItems, totalPrice, addToCart, removeFromCart, quantities, addToPurchase };
});
