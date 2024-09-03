<script setup lang="ts">
import { ref, computed } from 'vue';
import Tarjet from '@/components/Tarjet.vue';
import Modal from '@/components/Modal.vue'; 

import { useConsoleStore } from '@/stores/ConsoleStore';
import { useGameStore } from '@/stores/GameStore';
import { useFilterStore } from '@/stores/FilterStore';

interface Product {
  price: number;
  name: string;
}

const GameStore = useGameStore();
GameStore.fetchGames();

const ConsoleStore = useConsoleStore();
ConsoleStore.fetchConsoles();

const FilterStore = useFilterStore();

interface Props {
  title: string;
  isGrid: boolean;
  type: string;
}

const props = defineProps<Props>();

const currentPage = ref(1);
const itemsPerPage = ref(6);

const selectedGameId = ref<number | null>(null);

// Lógica para ordenar elementos por precio
const sortItems = (items: Product[]): Product[] => {
  if (FilterStore.sortOption === 'price-asc') {
    return items.sort((a, b) => a.price - b.price);
  } else if (FilterStore.sortOption === 'price-desc') {
    return items.sort((a, b) => b.price - a.price);
  }
  return items;
};

// Lógica para filtrar elementos según el término de búsqueda
const filterItems = (items: Product[]): Product[] => {
  const searchTerm = FilterStore.searchTerm.toLowerCase();
  return items.filter(item => item.name.toLowerCase().includes(searchTerm));
};

const totalPagesGames = computed(() => Math.ceil(GameStore.games.length / itemsPerPage.value));
const totalPagesConsoles = computed(() => Math.ceil(ConsoleStore.consoles.length / itemsPerPage.value));

const paginatedGames = computed(() => {
  const sortedGames = sortItems(filterItems(GameStore.games));
  const start = (currentPage.value - 1) * itemsPerPage.value;
  const end = start + itemsPerPage.value;
  return sortedGames.slice(start, end);
});

const paginatedConsoles = computed(() => {
  const sortedConsoles = sortItems(filterItems(ConsoleStore.consoles));
  const start = (currentPage.value - 1) * itemsPerPage.value;
  const end = start + itemsPerPage.value;
  return sortedConsoles.slice(start, end);
});

const nextPage = () => {
  if (props.type === 'game' && currentPage.value < totalPagesGames.value) {
    currentPage.value++;
  } else if (props.type === 'console' && currentPage.value < totalPagesConsoles.value) {
    currentPage.value++;
  }
};

const prevPage = () => {
  if (currentPage.value > 1) {
    currentPage.value--;
  }
};

const handleCardClick = (id: number) => {
  selectedGameId.value = id;
};
</script>

<template>
  <h2>{{ props.title }}</h2>
  <div class="product-grid">
    <Tarjet v-if="props.type === 'game'"
      v-for="game in paginatedGames" 
      :key="game.videogameId" 
      :idGame="game.videogameId" 
      :name="game.name"
      :price="game.price" 
      :image="game.imageURL"
      :isGrid="isGrid"
      :isGame="true"
      @click="handleCardClick(game.videogameId)" 
    />
    <Tarjet v-if="props.type === 'console'"
      v-for="console in paginatedConsoles" 
      :key="console.consoleId" 
      :idGame="console.consoleId" 
      :name="console.name"
      :price="console.price" 
      :image="console.imageURL"
      :isGrid="isGrid"
      :isGame="false"
      @click="handleCardClick(console.consoleId)" 
    />
  </div>

  <div class="pagination">
    <button @click="prevPage" :disabled="currentPage === 1"><</button>
    <button @click="nextPage" :disabled="props.type === 'game' ? currentPage === totalPagesGames : currentPage === totalPagesConsoles">></button>
  </div>

  <Modal v-if="selectedGameId" v-model:modelValue="selectedGameId" title="Código del juego">
    <template #default>
      <h3>ID del Juego: {{ selectedGameId }}</h3>
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