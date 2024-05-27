<script setup lang="ts">
defineProps<{
    videogameId: number
    name: string
}>()

import { useGameStore } from '@/stores/GameStore';

const GameStore = useGameStore();

</script>

<template>
    <button @click="GameStore.deleteGame(videogameId, name)">Eliminar</button>
</template>

<style scoped lang="scss">
button {
    padding: 10px 15px;
    background-color: #e74c3c; // Color de fondo
    color: #fff; // Color del texto
    border: none;
    border-radius: 5px;
    cursor: pointer;
    transition: background-color 0.3s ease;

    &:hover {
        background-color: #c0392b; // Cambio de color al pasar el ratón
    }

    &:focus {
        outline: none; // Elimina el contorno al hacer clic
    }

    &:active {
        transform: translateY(2px); // Efecto de clic
    }
}
</style>