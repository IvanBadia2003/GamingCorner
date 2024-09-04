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


export const useCartStore = defineStore('CartStore', () => {
    // Estado para almacenar los juegos en el carrito
    const cart = reactive<Game[]>([]);
  
    // Función para añadir un juego al carrito
    function addGameToCart(game: Game) {
      const existingGame = cart.find(item => item.videogameId === game.videogameId);
      if (!existingGame) {
        cart.push(game);
      }
    }
  
    // Función para eliminar un juego del carrito
    function removeGameFromCart(videogameId: number) {
      const index = cart.findIndex(item => item.videogameId === videogameId);
      if (index !== -1) {
        cart.splice(index, 1);
      }
    }
  
    // Función para obtener el total de juegos en el carrito
    function getCartItems() {
      return cart;
    }
  
    // Función para vaciar el carrito
    function clearCart() {
      cart.splice(0, cart.length);
    }
  
    // Computado para obtener el total de precios
    const totalPrice = computed(() => {
      return cart.reduce((total, game) => total + game.price, 0);
    });
  
    return {
      cart,
      addGameToCart,
      removeGameFromCart,
      getCartItems,
      clearCart,
      totalPrice
    };
  });