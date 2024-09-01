<script setup lang="ts">
import { ref, computed } from 'vue';
import Tarjet from '@/components/Tarjet.vue';
import Modal from '@/components/Modal.vue'; 

import { useGameStore } from '@/stores/GameStore';

const GameStore = useGameStore();
GameStore.fetchGames();

const props = defineProps<{ title: string, isGrid: boolean }>();

const currentPage = ref(1);
const itemsPerPage = ref(6);

const selectedGameId = ref<number | null>(null);  // Estado para el ID del juego seleccionado

const totalPages = computed(() => Math.ceil(GameStore.games.length / itemsPerPage.value));

const paginatedGames = computed(() => {
  const start = (currentPage.value - 1) * itemsPerPage.value;
  const end = start + itemsPerPage.value;
  return GameStore.games.slice(start, end);
});

const nextPage = () => {
  if (currentPage.value < totalPages.value) {
    currentPage.value++;
  }
};

const prevPage = () => {
  if (currentPage.value > 1) {
    currentPage.value--;
  }
};

const handleCardClick = (id: number) => {
  selectedGameId.value = id;  // Actualiza el ID del juego seleccionado
};
</script>


<template>  
  <h2>{{ title }}</h2>
  <div class="product-grid">
    <Tarjet 
      v-for="game in paginatedGames" 
      :key="game.videogameId" 
      :idGame="game.videogameId" 
      :name="game.name"
      :price="game.price" 
      :image="game.imageURL"
      :isGrid="isGrid"
      @click="handleCardClick(game.videogameId)" 
    />
  </div>

  <div class="pagination">
    <button @click="prevPage" :disabled="currentPage === 1"><</button>
    <button @click="nextPage" :disabled="currentPage === totalPages">></button>
  </div>

  <!-- Mostrar el modal solo si selectedGameId no es null -->
  <Modal v-if="selectedGameId" v-model:modelValue="selectedGameId" title="Código del juego">
    <template #default>
      <h3>ID del Juego: {{ selectedGameId }}</h3>
      <!-- Aquí puedes agregar más contenido relacionado con el juego seleccionado -->
    </template>
  </Modal>
</template>




<style scoped lang="scss">
.product-grid {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(150px, 1fr));
    gap: 32px;
    margin: 0 20px;
}

.pagination {
  display: flex;
  justify-content: center;
  margin-top: 1rem;

  button {
    margin: 0 0.5rem;
    padding: 0.5rem 1rem;
    background-color: orange;
    color: white;
    border: 1px solid black;
    border-radius: 5px;
    cursor: pointer;
  }

  button:disabled {
    background-color: #cccccc;
    cursor: not-allowed;
  }
}

@media screen and (min-width: 750px) {
    .product-grid {
        width: 70%;
        grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));

    }
}
</style>