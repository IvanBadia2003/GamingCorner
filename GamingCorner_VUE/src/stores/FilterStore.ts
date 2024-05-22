import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

export const useFilterStore = defineStore('FilterStore', () => {

  // State
  const toggleFilter = ref<boolean>(false);
  const titleMenuFilter = ref<string | null>(null);

    // Funciones
    const toggleSubMenu = (menuItem: string): void => {
      titleMenuFilter.value = titleMenuFilter.value === menuItem ? null : menuItem;
    };

  // Funciones
/*   const toggleSubMenu = (menuItem: string): void => {
    titleMenuPlatform.value = titleMenuPlatform.value === menuItem ? null : menuItem;
  }; */

  return { toggleFilter, titleMenuFilter, toggleSubMenu }
})
