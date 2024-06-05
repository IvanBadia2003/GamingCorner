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

    // Computed properties for derived data (optional)
/*     const totalItems = computed(() => cartItems.value.reduce((acc, item) => acc + item.quantity, 0));
   */ const totalPrice = computed(() => {
        return cartItems.value.reduce((total, item) => total + item.price, 0);
    });


    return { cartItems,/*  totalItems, */totalPrice, addToCart, removeFromCart /* clearCart */ };
});
