import { defineStore } from 'pinia';
import { computed, reactive, ref } from 'vue';

interface Console {
    consoleId: number;
    name: string;
    platformId: number;
    specifications: string;
    stock: number;
    available: boolean;
    price: number;
    imageURL: string;
    videogameId: number | null;
    pegi: number | null;
    platform: number | null;
}

interface editedConsole {
    consoleId: number;
    name: string;
    stock: number;
    available: boolean;
    price: number;
}

interface CartConsole {
    consoleId: number;
    name: string;
    price: number;
    imageURL: string;
}

export const useConsoleStore = defineStore('ConsoleStore', () => {
    // State
    const consoles = reactive<Console[]>([]);
    const cart = reactive<CartConsole[]>([]);
    const selectedConsoleId = ref<number>(-1);
    const Console = reactive<Console>({
        consoleId: 0,
        name: '',
        platformId: 0,
        specifications: '',
        stock: 0,
        available: false,
        price: 0,
        imageURL: '',
        videogameId: 0,
        pegi: 0,
        platform: 0
    });

    // Getter
    const calcularCantidad = computed(() => consoles.length);
    const selectedConsole = computed(() => {
        if (selectedConsoleId.value !== null) {
            return consoles.find(func => func.consoleId === selectedConsoleId.value);
        }
        return null;
    });

    // Getter para obtener los consolas en el carrito
    const cartItems = computed(() => cart);

    // Getter para obtener el total de precios en el carrito
    const totalPrice = computed(() => {
        return cart.reduce((total, item) => total + item.price, 0);
    });

    // Action
    async function fetchConsoles() {
        try {
            const response = await fetch('http://localhost:5000/Console');
            console.log("Fetch de grid de consolas hecho desde ConsoleStore.ts");
            const data = await response.json();
            consoles.splice(0, consoles.length);
            consoles.push(...data);
        } catch (error) {
            console.error('Error al obtener las consolas:', error);
        }
    }

    function searchConsolesPerId(id: number) {
        selectedConsoleId.value = id;
        return consoles.find(i => i.consoleId === id);
    }

    async function purchaseConsole(id: number) {
        // Encuentra el juego en la lista de juegos (puedes ajustar esto según cómo estés manejando los datos)
        const Console = consoles.find(g => g.consoleId === id);
    
        if (Console) {
          // Calcula el nuevo stock y estado de disponibilidad
          const newStock = Console.stock - 1;
          const newAvailable = newStock > 0;
    
          try {
            const response = await fetch('http://localhost:5000/Console/' + id, {
              method: 'PUT',
              headers: {
                'Content-Type': 'application/json',
              },
              body: JSON.stringify({
                price: Console.price,
                stock: newStock,
                available: newAvailable
              }),
            });
    
            if (response.ok) {
              console.log('Console editado exitosamente.');
              // Actualiza el juego en el store (opcional si ya lo manejas en otro lado)
              Console.stock = newStock;
              Console.available = newAvailable;
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

    async function fetchConsolesById(id: number) {
        try {
            const response = await fetch('http://localhost:5000/Console/' + id);
            console.log("Fetch de una consola hecho desde ConsoleStore.ts");
            const consoleData = await response.json();
            Object.assign(Console, consoleData);
        } catch (error) {
            console.error('Error al obtener los detalles de la consola:', error);
        }
    }

    async function deleteConsole(id: number, name: string) {
        try {
            const response = await fetch('http://localhost:5000/Console/' + id, {
                method: 'DELETE',
            });
            console.log("Fetch de eliminar consolas " + id + " hecho desde ConsoleStore.ts");
            alert(`Consola: ${name} eliminada con éxito`);
        } catch (error) {
            console.error('Error al eliminar:', error);
        }
    }

    async function createConsole(Console: Console) {
        try {
            const response = await fetch('http://localhost:5000/Console', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(Console),
            });
            if (response.ok) {
                console.log('Consola creada exitosamente.');
            } else {
                console.error('Error al crear la consola:', response.statusText);
            }
        } catch (error) {
            console.error('Error al crear la consola:', error);
        }
    }

    async function editConsole(id: number, Console: editedConsole) {
        try {
            const response = await fetch('http://localhost:5000/Console/' + id, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(Console),
            });
            if (response.ok) {
                console.log('Consola editada exitosamente.');
            } else {
                console.error('Error al editar la consola:', response.statusText);
            }
        } catch (error) {
            console.error('Error al editar la consola:', error);
        }
    }

    function filterConsoleByTitle(title: string) {
        console.log('Busco por título en la store');
        if (title.length < 2) {
            return consoles;
        } else {
            return consoles.filter(func => func.name.toLowerCase().includes(title.toLowerCase()));
        }
    }

    // Añadir una consola al carrito
    function addToCart(console: CartConsole) {
        const existingConsole = cart.find(item => item.consoleId === console.consoleId);
        if (!existingConsole) {
            cart.push(console);
        }
    }

    // Eliminar una consola del carrito
    function removeFromCart(consoleId: number) {
        const index = cart.findIndex(item => item.consoleId === consoleId);
        if (index !== -1) {
            cart.splice(index, 1);
        }
    }

    // Vaciar el carrito
    function clearCart() {
        cart.splice(0, cart.length);
    }

    return {
        Console,
        consoles,
        calcularCantidad,
        fetchConsoles,
        searchConsolesPerId,
        deleteConsole,
        createConsole,
        editConsole,
        selectedConsole,
        filterConsoleByTitle,
        fetchConsolesById,
        cartItems,
        totalPrice,
        addToCart,
        removeFromCart,
        clearCart,
        purchaseConsole
    };
});
