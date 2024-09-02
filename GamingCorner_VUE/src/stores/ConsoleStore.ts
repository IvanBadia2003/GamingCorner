import { defineStore } from 'pinia';
import type { ListFormat } from 'typescript';
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
}

interface editedConsole {
    consoleId: number;
    name: string;
    stock: number;
    available: boolean;
    price: number;

}

export const useConsoleStore = defineStore('ConsoleStore', () => {
    // State
    const consoles = reactive(new Array<Console>);
    const selectedConsoleId = ref<number>(-1); // Inicializa con un valor que represente que no hay ninguna obra seleccionada
    const Console = reactive<Console>({
        consoleId: 0,
        name: '',
        platformId: 0,
        specifications: '',
        stock: 0,
        available: false,
        price: 0,
        imageURL: '',

      });
    
    // Getter
    // calcula la cantidad de funciones que hay
    const calcularCantidad = computed(() => consoles.length);

    // Getter para obtener la obra seleccionada
    const selectedConsole = computed(() => {
        if (selectedConsoleId.value !== null) {
            return consoles.find(func => func.consoleId === selectedConsoleId.value);
        }
        return null;
    });




    // Action
    // saca de la api todas los juegos que hay
    async function fetchConsoles() {
    
        try {
            const response = await fetch('http://localhost:5000/Console');
            console.log("Fetch de grid de consolas hecho desde ConsoleStore.ts");

            const data = await response.json();
            consoles.splice(0, consoles.length)
            consoles.push(...data);
            // Actualiza la lista de posteos con los datos de la api
        } catch (error) {
            console.error('Error al obtener los posteos:', error);
        }
    }

    // busca en la api la funcion por id
    function searchConsolesPerId(id: number) {
        selectedConsoleId.value = id; // Almacena el ID de la obra buscada
        return consoles.find(i => i.consoleId === id);
    }

    async function fetchConsolesById (id: number) {
        try {
            const response = await fetch('http://localhost:5000/Console/' + id);
            console.log("Fetch de una consola hecho desde ConsoleStore.ts");

            const consoleData = await response.json();

            // Actualiza el estado de la consola
            Object.assign(Console, consoleData);
        } catch (error) {
            console.error('Error al obtener los detalles de la consola:', error);
        }
    };

    

    // eliminar obra
    async function deleteConsole(id: number, name: string) {
        try {
            const response = await fetch('http://localhost:5000/Console/' + id, {
                method: 'DELETE',
            });
            console.log("Fetch de eliminar consolas " + id + " hecho desde ConsolesStore.ts");
            alert(`Consola: ${name} eliminado con éxito`)

        } catch (error) {
            console.error('Error al eliminar:', error);
        }
    }

    // crear obra
    async function createConsole(Console: Console) {
        try {
            const response = await fetch('http://tickettback.retocsv.es:80/Obra', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json', // Indica que estás enviando datos en formato JSON
                },
                body: JSON.stringify(Console), // Convierte el objeto obra a JSON y lo envía en el cuerpo de la solicitud

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

    // editar juego
    async function editConsole(id: number, Console: editedConsole) {
        debugger
        try {
            const response = await fetch('http://localhost:5000/Console/' + id, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json', // Indica que estás enviando datos en formato JSON
                },
                body: JSON.stringify(Console), // Convierte el objeto obra a JSON y lo envía en el cuerpo de la solicitud

            });
            if (response.ok) {
                console.log('Juego editado exitosamente.');
            } else {
                console.error('Error al editar la obra:', response.statusText);
            }
        } catch (error) {
            console.error('Error al editar la obra:', error);
        }
    }

    // Filtrar funciones por título
    function filterConsoleByTitle(title: string) {
        console.log('Busco por titulo en la store');
        if (title.length < 2) {
            return consoles;
        } else {
            const consolesFiltered = consoles.filter(func => func.name.toLowerCase().includes(title.toLowerCase()));
            return consolesFiltered
        }
    }

    /*     function filterGamesByGenre(genres: string[]) {
            console.log('Busco por género en la store');
            console.log(genres);
    
            // Verifica si no se han seleccionado géneros
            if (genres.length < 2) {
                console.log('Ningún género seleccionado');
                // Si no se ha seleccionado ningún género, devuelve todas las funciones sin filtrar
                return games;
    
            } else {
                // Filtra las funciones que coinciden con al menos uno de los géneros seleccionados
                const GamesFiltered = games.filter(func => {
                    // Verifica si la función tiene al menos uno de los géneros seleccionados
                    return func.genero && genres.some(genre => func.genero?.toLowerCase() === genre.toLowerCase());
                });
                return GamesFiltered;
    
            }
        } */


    return { Console, consoles, calcularCantidad, fetchConsoles, searchConsolesPerId, deleteConsole, createConsole, editConsole, selectedConsole, filterConsoleByTitle, fetchConsolesById /* filterGamesByGenre */ };
});