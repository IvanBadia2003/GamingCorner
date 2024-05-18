import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

export const useFilterStore = defineStore('FilterStore', () => {

  // State
  const toggleFilter = ref<boolean>(false);

  // Funciones
/*   const toggleSubMenu = (menuItem: string): void => {
    titleMenuPlatform.value = titleMenuPlatform.value === menuItem ? null : menuItem;
  }; */

  return { /* toggleSubMenu */ toggleFilter }
})
