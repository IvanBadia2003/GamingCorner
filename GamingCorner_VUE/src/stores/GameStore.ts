import { defineStore } from 'pinia';
import type { ListFormat } from 'typescript';
import { computed, reactive, ref } from 'vue';

interface Gender    {
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

interface editedGame {
    videogameId: number;
    description: string;
    available: boolean;
    price: number;

}

export const useGameStore = defineStore('GameStore', () => {
    // State
    const games = reactive(new Array<Game>);
    const selectedGameId = ref<number>(-1); // Inicializa con un valor que represente que no hay ninguna obra seleccionada

    // Getter
    // calcula la cantidad de funciones que hay
    const calcularCantidad = computed(() => games.length);

    // Getter para obtener la obra seleccionada
    const selectedGame = computed(() => {
        if (selectedGameId.value !== null) {
            return games.find(func => func.videogameId === selectedGameId.value);
        }
        return null;
    });




    // Action
    // saca de la api todas los juegos que hay
    async function fetchGames() {
        debugger
        try {
            const response = await fetch('http://localhost:5000/Videogame');
            console.log("Fetch de grid de juegos hecho desde GameStore.ts");

            const data = await response.json();
            games.splice(0, games.length)
            games.push(...data);
            // Actualiza la lista de posteos con los datos de la api
        } catch (error) {
            console.error('Error al obtener los posteos:', error);
        }
    }

    // busca en la api la funcion por id
    function searchGamesPerId(id: number) {
        selectedGameId.value = id; // Almacena el ID de la obra buscada
        return games.find(i => i.videogameId === id);
    }

    // eliminar obra
    async function deleteGame(id: number, name: string) {
        try {
            const response = await fetch('http://localhost:5000/Videogame/' + id, {
                method: 'DELETE',
            });
            console.log("Fetch de eliminar juegos " + id + " hecho desde GameStore.ts");
            alert(`Juego: ${name} eliminado con éxito`)

        } catch (error) {
            console.error('Error al eliminar:', error);
        }
    }

    // crear obra
    async function createGame(game: Game) {
        try {
            const response = await fetch('http://tickettback.retocsv.es:80/Obra', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json', // Indica que estás enviando datos en formato JSON
                },
                body: JSON.stringify(game), // Convierte el objeto obra a JSON y lo envía en el cuerpo de la solicitud

            });
            if (response.ok) {
                console.log('Juego creada exitosamente.');
            } else {
                console.error('Error al crear el juego:', response.statusText);
            }
        } catch (error) {
            console.error('Error al crear el juego:', error);
        }
    }

    // editar obra
    async function editGame(id: number, juego: editedGame) {
        try {
            const response = await fetch('http://tickettback.retocsv.es:80/Obra/' + id, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json', // Indica que estás enviando datos en formato JSON
                },
                body: JSON.stringify(juego), // Convierte el objeto obra a JSON y lo envía en el cuerpo de la solicitud

            });
            if (response.ok) {
                console.log('Juego editada exitosamente.');
            } else {
                console.error('Error al editar la obra:', response.statusText);
            }
        } catch (error) {
            console.error('Error al editar la obra:', error);
        }
    }


    // funcion para sacar el dia de la obra
    const formatoFecha = (fechaHora: string) => {
        const fecha = new Date(fechaHora)
        const options: Intl.DateTimeFormatOptions = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' };
        return fecha.toLocaleDateString('es-ES', options);
    };

    // Filtrar funciones por título
    function filterGamesByTitle(title: string) {
        console.log('Busco por titulo en la store');
        if (title.length < 2) {
            return games;
        } else {
            const gamesFiltered = games.filter(func => func.name.toLowerCase().includes(title.toLowerCase()));
            return gamesFiltered
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


    return { games, calcularCantidad, fetchGames, searchGamesPerId, deleteGame, createGame, editGame, selectedGame, formatoFecha, filterGamesByTitle /* filterGamesByGenre */ };
});