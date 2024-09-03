import { ref, computed, reactive } from 'vue'
import { defineStore } from 'pinia'

interface Gender {
  platformId: number,
  name: string,

}


export const usePlatformStore = defineStore('PlatformStore', () => {

  const paltforms = reactive(new Array<Gender>);
  const selectedPlatformId = ref<number>(-1); // Inicializa con un valor que represente que no hay ningun género seleccionado
  
  // Getter
  // calcula la cantidad de generos que hay
  const calcularCantidad = computed(() => paltforms.length);
  
  // Getter para obtener el género seleccionada
  const selectedPlatform = computed(() => {
      if (selectedPlatformId.value !== null) {
          return paltforms.find(gender => gender.platformId === selectedPlatformId.value);
        }
        return null;
    });
    
    
    
    
    // Action
    // saca de la api todas los juegos que hay
    async function fetchPlatforms() {
        try {
            const response = await fetch('http://localhost:5000/Platform');
            console.log("Fetch de géneros hecho desde Gendertore.ts");
            
            const data = await response.json();
            paltforms.splice(0, paltforms.length)
            paltforms.push(...data);
            // Actualiza la lista de posteos con los datos de la api
        } catch (error) {
            console.error('Error al obtener los posteos:', error);
        }
    }
    fetchPlatforms();

  // busca en la api la funcion por id
  function searchPlatformPerId(id: number) {
    selectedPlatformId.value = id; // Almacena el ID de la obra buscada
      return paltforms.find(i => i.platformId === id);
  }




  return { fetchPlatforms, selectedPlatform, paltforms}
})
