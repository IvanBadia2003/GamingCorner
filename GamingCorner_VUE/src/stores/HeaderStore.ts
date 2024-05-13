import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

export const useHeaderStore = defineStore('HeaderStore', () => {

  // State
  const titleMenuPlatform = ref<string | null>(null);

  // Funciones
  const toggleSubMenu = (menuItem: string): void => {
    titleMenuPlatform.value = titleMenuPlatform.value === menuItem ? null : menuItem;
  };

  return { toggleSubMenu, titleMenuPlatform }
})
