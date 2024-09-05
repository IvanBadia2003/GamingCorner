import { defineStore } from 'pinia';
import { computed, reactive, ref } from 'vue';

interface Game {
    videogameId: number;
    name: string;
    pegi: number;
    description: string;
    category: string;
    stock: number;
    available: boolean;
    requisitos1: string;
    requisitos2: string;
    platform: string;
    price: number;
    imageURL: string;
    code: string | null;
    consoleId: number | null
}

interface createGame {
    name: string,
    pegi: number,
    code: string,
    description: string,
    requisitos1: string,
    requisitos2: string,
    stock: number,
    available: boolean,
    price: number,
    platformId: number,
    genderId: number,
    imageURL: string
}

interface editedGame {
    videogameId: number;
    stock: number;
    available: boolean;
    price: number;
}

// Define el tipo de datos para los juegos en el carrito
interface CartGame {
    videogameId: number;
    name: string;
    price: number;
    imageURL: string;
}

export const useGameStore = defineStore('GameStore', () => {
    // State
    const games = reactive<Game[]>([]);
    const cart = reactive<CartGame[]>([]);
    const selectedGameId = ref<number>(-1);
    const game = reactive<Game>({
        videogameId: 0,
        name: '',
        pegi: 0,
        description: '',
        category: '',
        stock: 0,
        available: false,
        requisitos1: '',
        requisitos2: '',
        platform: '',
        price: 0,
        imageURL: '',
        code: '',
        consoleId: 0
    });

    // Getter
    const calcularCantidad = computed(() => games.length);
    const requisitos1Array = computed(() => game.requisitos1.split(';'));
    const requisitos2Array = computed(() => game.requisitos2.split(';'));
    const selectedGame = computed(() => {
        if (selectedGameId.value !== null) {
            return games.find(func => func.videogameId === selectedGameId.value);
        }
        return null;
    });

    // Getter para obtener los juegos en el carrito
    const cartItems = computed(() => cart);

    // Getter para obtener el total de precios en el carrito
    const totalPrice = computed(() => {
        return cart.reduce((total, item) => total + item.price, 0);
    });

    // Action
    async function fetchGames() {
        try {
            const response = await fetch('http://gamingcornerapi.retocsv.es/Videogame');
            console.log("Fetch de grid de juegos hecho desde GameStore.ts");
            const data = await response.json();
            games.splice(0, games.length);
            games.push(...data);
        } catch (error) {
            console.error('Error al obtener los juegos:', error);
        }
    }

    function searchGamesPerId(id: number) {
        selectedGameId.value = id;
        return games.find(i => i.videogameId === id);
    }

    async function fetchGamesById(id: number) {
        try {
            const response = await fetch('http://gamingcornerapi.retocsv.es/Videogame/' + id);
            console.log("Fetch de un juego hecho desde GameStore.ts");
            const gameData = await response.json();
            Object.assign(game, gameData);
        } catch (error) {
            console.error('Error al obtener los detalles del juego:', error);
        }
    }

    async function deleteGame(id: number, name: string) {
        try {
            const response = await fetch('http://gamingcornerapi.retocsv.es/Videogame/' + id, {
                method: 'DELETE',
            });
            console.log("Fetch de eliminar juegos " + id + " hecho desde GameStore.ts");
            alert(`Juego: ${name} eliminado con éxito`);
        } catch (error) {
            console.error('Error al eliminar:', error);
        }
    }

    async function createGame(game: createGame) {
        try {
            const response = await fetch('http://gamingcornerapi.retocsv.es/Videogame', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(game),
            });
            if (response.ok) {
                console.log('Juego creado exitosamente.');
            } else {
                console.error('Error al crear el juego:', response.statusText);
            }
        } catch (error) {
            console.error('Error al crear el juego:', error);
        }
    }

    async function editGame(id: number, juego: editedGame) {
        try {
            const response = await fetch('http://gamingcornerapi.retocsv.es/Videogame/' + id, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(juego),
            });
            if (response.ok) {
                console.log('Juego editado exitosamente.');
            } else {
                console.error('Error al editar el juego:', response.statusText);
            }
        } catch (error) {
            console.error('Error al editar el juego:', error);
        }
    }

    async function purchaseGame(id: number) {
        // Encuentra el juego en la lista de juegos (puedes ajustar esto según cómo estés manejando los datos)
        const game = games.find(g => g.videogameId === id);

        if (game) {
            // Calcula el nuevo stock y estado de disponibilidad
            const newStock = game.stock - 1;
            const newAvailable = newStock > 0;

            try {
                const response = await fetch('http://gamingcornerapi.retocsv.es/Videogame/' + id, {
                    method: 'PUT',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({
                        price: game.price,
                        stock: newStock,
                        available: newAvailable
                    }),
                });

                if (response.ok) {
                    console.log('Juego editado exitosamente.');
                    // Actualiza el juego en el store (opcional si ya lo manejas en otro lado)
                    game.stock = newStock;
                    game.available = newAvailable;
                } else {
                    console.error('Error al editar el juego:', response.statusText);
                }
            } catch (error) {
                console.error('Error al editar el juego:', error);
            }
        } else {
            console.error('Juego no encontrado');
        }
    }


    function filterGamesByTitle(title: string) {
        if (title.length < 2) {
            return games;
        } else {
            return games.filter(func => func.name.toLowerCase().includes(title.toLowerCase()));
        }
    }



    async function filterGamesByGenre(id: number) {
        try {
            if (id === 0) {
                fetchGames();
            } else {
                const response = await fetch(`http://gamingcornerapi.retocsv.es/Gender/${id}/videogames`);
                console.log("Fetch de grid de juegos por género hecho desde GameStore.ts");
                const data = await response.json();
                if (Array.isArray(data)) {
                    games.splice(0, games.length);
                    games.push(...data);
                } else {
                    console.error('La respuesta del servidor no es un array:', data);
                }
            }
        } catch (error) {
            console.error('Error al obtener los videojuegos:', error);
        }
    }

    async function filterGamesByPlatform(id: number) {
        try {
            if (id === 0) {
                fetchGames();
            } else {
                const response = await fetch(`http://gamingcornerapi.retocsv.es/Platform/${id}/videogames`);
                console.log("Fetch de grid de juegos por plataforma hecho desde GameStore.ts");
                const data = await response.json();
                if (Array.isArray(data)) {
                    games.splice(0, games.length);
                    games.push(...data);
                } else {
                    console.error('La respuesta del servidor no es un array:', data);
                }
            }
        } catch (error) {
            console.error('Error al obtener los videojuegos:', error);
        }
    }

    // Añadir un juego al carrito
    function addToCart(game: CartGame) {
        const existingGame = cart.find(item => item.videogameId === game.videogameId);
        if (!existingGame) {
            cart.push(game);
        }
    }

    // Eliminar un juego del carrito
    function removeFromCart(videogameId: number) {
        const index = cart.findIndex(item => item.videogameId === videogameId);
        if (index !== -1) {
            cart.splice(index, 1);
        }
    }

    // Vaciar el carrito
    function clearCart() {
        cart.splice(0, cart.length);
    }

    return {
        game,
        games,
        cart,
        calcularCantidad,
        fetchGames,
        searchGamesPerId,
        deleteGame,
        createGame,
        editGame,
        selectedGame,
        filterGamesByTitle,
        fetchGamesById,
        filterGamesByGenre,
        filterGamesByPlatform,
        requisitos1Array,
        requisitos2Array,
        cartItems,
        totalPrice,
        addToCart,
        removeFromCart,
        clearCart,
        purchaseGame
    };
});
