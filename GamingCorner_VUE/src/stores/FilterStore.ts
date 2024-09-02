import { ref } from 'vue';
import { defineStore } from 'pinia';

export const useFilterStore = defineStore('FilterStore', () => {
  // State
  const toggleFilter = ref<boolean>(false);
  const sortOption = ref<string>(''); // Ahora con acceso directo
  const titleMenuFilter = ref<string | null>(null);

  // Funciones
  const toggleSubMenu = (menuItem: string): void => {
    titleMenuFilter.value = titleMenuFilter.value === menuItem ? null : menuItem;
  };

  const setSortOption = (option: string): void => {
    sortOption.value = option; // Accede directamente a sortOption
  };

  return {
    toggleFilter,
    sortOption, // Asegúrate de devolver sortOption
    titleMenuFilter,
    toggleSubMenu,
    setSortOption
  };
});
