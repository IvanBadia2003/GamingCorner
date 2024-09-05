<script setup lang="ts">
import { ref, computed } from 'vue';

import { useProductStore } from '@/stores/ProductStore';
import { useFilterStore } from '@/stores/FilterStore';
import TarjetProduct from '../TarjetProduct.vue';

interface Product {
    productId: number;
    name: string;
    description: string;
    price: number;
    available: boolean;
    imageURL: string;
}

const ProductStore = useProductStore();
ProductStore.fetchProducts();

const FilterStore = useFilterStore();

const props = defineProps<{ title: string; }>();

const currentPage = ref(1);
const itemsPerPage = ref(6);

const selectedProductId = ref<number | null>(null);

// Función para ordenar productos por precio
const sortItems = (items: Product[]): Product[] => {
  if (FilterStore.sortOption === 'price-asc') {
    return items.sort((a, b) => a.price - b.price);
  } else if (FilterStore.sortOption === 'price-desc') {
    return items.sort((a, b) => b.price - a.price);
  }
  return items;
};

// Función para filtrar productos por nombre
const filterItems = (items: Product[]): Product[] => {
  const searchTerm = FilterStore.searchTerm.toLowerCase();
  return items.filter(item => item.name.toLowerCase().includes(searchTerm));
};

// Número total de páginas basado en productos filtrados y ordenados
const totalPagesProducts = computed(() => Math.ceil(filteredAndSortedItems.value.length / itemsPerPage.value));

// Productos filtrados y ordenados según los criterios
const filteredAndSortedItems = computed(() => {
  const filteredItems = filterItems(ProductStore.products);
  return sortItems(filteredItems);
});

// Productos a mostrar en la página actual
const paginatedProducts = computed(() => {
  const start = (currentPage.value - 1) * itemsPerPage.value;
  const end = start + itemsPerPage.value;
  return filteredAndSortedItems.value.slice(start, end);
});

// Ir a la siguiente página
const nextPage = () => {
  if (currentPage.value < totalPagesProducts.value) {
    currentPage.value++;
  }
};

// Volver a la página anterior
const prevPage = () => {
  if (currentPage.value > 1) {
    currentPage.value--;
  }
};

// Manejar clic en la tarjeta para mostrar el modal
const handleCardClick = (id: number) => {
  selectedProductId.value = id;
};
</script>

<template>
  <h2>{{ props.title }}</h2>
  <div class="product-grid" v-if="paginatedProducts.length > 0">
    <TarjetProduct 
      v-for="product in paginatedProducts" 
      :key="product.productId" 
      :idProduct="product.productId" 
      :name="product.name"
      :price="product.price" 
      :image="product.imageURL"
      :isProduct="true"
      :isGrid="true"
      @click="handleCardClick(product.productId)" 
    />
  </div>
  <p v-else>No hay productos de segunda mano para comprar</p>

  <div class="pagination" v-if="paginatedProducts.length > 0">
    <button @click="prevPage" :disabled="currentPage === 1"><</button>
    <button @click="nextPage" :disabled="currentPage === totalPagesProducts">></button>
  </div>

</template>
<style scoped lang="scss">
.product-grid {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(150px, 1fr));
    gap: 32px;
    margin: 0 20px;
}
a{
    font-family: 'Montserrat';
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