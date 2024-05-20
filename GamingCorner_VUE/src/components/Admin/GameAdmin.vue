<script setup lang="ts">
import { useGameStore } from '@/stores/GameStore';
import DeleteGame from './DeleteGame.vue';
import EditGame from './EditGame.vue';
import { ref } from 'vue';

const GameStore = useGameStore();
GameStore.fetchGames();
const editar = ref(false); 
const borrar = ref(false); 

// Función para cambiar el estado de edición
const openEdit = () => {
  editar.value = !editar.value;
}

// Función para cambiar el estado de borrar
const openDelete = () => {
    borrar.value = !borrar.value;
}
</script>

<template>
    <div class="container">
        <button @click="openEdit">{{ editar ? 'Cancelar' : 'Editar' }}</button>
        <button @click="openDelete">{{ borrar ? 'Cancelar' : 'Borrar' }}</button>
        <div v-for="game in GameStore.games" :key="game.videogameId" class="function">
            <div class="info">
                <h3>{{ game.name }}</h3>
            </div>

            <div class="actions" v-if="borrar">
                <DeleteGame :videogame-id="game.videogameId" :name="game.name"/>
            </div>

            <div class="menu" v-if="editar"> 
                <EditGame  :description="game.description"  :price="game.price" :available="game.available" :videogame-id="game.videogameId" :name="game.name"/>
            </div>
        </div>
    </div>
</template>


<style scoped lang="scss">
.container {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;

    button {
        width: 100px;
        height: 50px;
        font-size: 20px;
        margin-top: 20px;
        border-radius: 20px;
    }

    button:last-of-type{
        background-color: red;
        color: white;
        margin-bottom: 30px;
    }

}

.function {
    margin-bottom: 20px;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 8px;
    display: flex;
    justify-content: center;
    align-items: center;
    min-width: 400px;
    max-width: 400px;

    .info {
        flex-grow: 1;
        text-align: left;

        h3 {
            margin-bottom: 10px;
            font-size: 1.5em;
            color: #333;
        }

        p {
            color: #666;
        }
    }

    .actions {
        display: flex;
        align-items: center;

    }
}
</style>