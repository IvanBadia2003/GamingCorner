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

// Definimos la interfaz del producto en el carrito
interface CartItem {
    product: Game | Console;
    quantity: number;
}


export const useCartStore = defineStore('cartStore', () => {
    const cartItems = ref<CartItem[]>([]); // Reactive array for cart items
    const quantities = ref<{ [key: number]: number }>({}); // Cantidades seleccionadas para cada producto
    const purchaseItems = reactive<CartItem[]>([]); // Productos a comprar

    const addToCart = (item: Game | Console, isGame: boolean) => {
        const productId = isGame ? (item as Game).videogameId : (item as Console).consoleId;
        const existingItem = cartItems.value.find(cartItem => {
            const cartProductId = isGame ? (cartItem.product as Game).videogameId : (cartItem.product as Console).consoleId;
            return cartProductId === productId;
        });

        if (existingItem) {
            alert('El producto ya está en tu carrito');
        } else {
            cartItems.value.push({ product: item, quantity: 1 });
        }
    };

    const removeFromCart = (productId: number, isGame: boolean) => {
        const index = cartItems.value.findIndex(cartItem => {
            const cartProductId = isGame ? (cartItem.product as Game).videogameId : (cartItem.product as Console).consoleId;
            return cartProductId === productId;
        });

        if (index !== -1) {
            cartItems.value.splice(index, 1);
            alert('El producto ha sido eliminado de tu carrito');
        } else {
            alert('El producto no está en tu carrito');
        }
    };

    const totalPrice = computed(() => {
        return cartItems.value.reduce((total, item) => {
            const productPrice = item.product.price;
            const quantity = item.quantity || 1;
            return total + (productPrice * quantity);
        }, 0);
    });

    const addToPurchase = (item: CartItem) => {
        purchaseItems.push({ ...item });
    };

    return { cartItems, totalPrice, addToCart, removeFromCart, quantities, addToPurchase };
});