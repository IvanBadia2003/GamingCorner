import { ref, computed } from 'vue';
import { defineStore } from 'pinia';

export const useFilterStore = defineStore('FilterStore', () => {
  // State
  const toggleFilter = ref<boolean>(false);
  const sortOption = ref<string>('');
  const titleMenuFilter = ref<string | null>(null);
  const searchTerm = ref<string>(''); // Estado para el término de búsqueda

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

  return {
    toggleFilter,
    sortOption,
    titleMenuFilter,
    searchTerm,
    setSortOption,
    setSearchTerm,
    filteredItems,
    toggleSubMenu,
  };
});
