import { ref, computed } from 'vue';
import { defineStore } from 'pinia';

export const useFilterStore = defineStore('FilterStore', () => {
  // State
  const toggleFilter = ref<boolean>(false);
  const sortOption = ref<string>('');
  const titleMenuFilter = ref<string | null>(null);
  const searchTerm = ref<string>(''); // Estado para el término de búsqueda
  const priceRange = ref<number>(0); // Estado para el rango de precios seleccionado


  // Funciones
  const toggleSubMenu = (menuItem: string): void => {
    titleMenuFilter.value = titleMenuFilter.value === menuItem ? null : menuItem;
  };

  const setSortOption = (option: string): void => {
    sortOption.value = option;
  };

  const setSearchTerm = (term: string): void => {
    searchTerm.value = term;
  };

  // Computed para el término de búsqueda
  const filteredItems = computed(() => {
    // Aquí podrías agregar la lógica para filtrar productos o elementos con el término de búsqueda
    return searchTerm.value.toLowerCase();
  });

    // Función para actualizar el rango de precios
    const setPriceRange = (range: number): void => {
      priceRange.value = range;
    };

  return {
    toggleFilter,
    sortOption,
    titleMenuFilter,
    searchTerm,
    setSortOption,
    setSearchTerm,
    filteredItems,
    toggleSubMenu,
    priceRange,
    setPriceRange
  };
});
