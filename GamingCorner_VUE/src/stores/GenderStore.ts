import { ref, computed, reactive } from 'vue'
import { defineStore } from 'pinia'

interface Gender {
  genderId: number,
  backgroundImg: string,
  name: string,
  characterImg: string
}


export const useGenderStore = defineStore('GenderStore', () => {

  const genders = reactive(new Array<Gender>);
  const selectedGenderId = ref<number>(-1); // Inicializa con un valor que represente que no hay ningun género seleccionado
  
  // Getter
  // calcula la cantidad de generos que hay
  const calcularCantidad = computed(() => genders.length);
  
  // Getter para obtener el género seleccionada
  const selectedGender = computed(() => {
      if (selectedGenderId.value !== null) {
          return genders.find(gender => gender.genderId === selectedGenderId.value);
        }
        return null;
    });
    
    
    
    
    // Action
    // saca de la api todas los juegos que hay
    async function fetchGenders() {
        debugger
        try {
            const response = await fetch('http://localhost:5000/Gender');
            console.log("Fetch de géneros hecho desde Gendertore.ts");
            
            const data = await response.json();
            genders.splice(0, genders.length)
            genders.push(...data);
            // Actualiza la lista de posteos con los datos de la api
        } catch (error) {
            console.error('Error al obtener los posteos:', error);
        }
    }
    fetchGenders();

  // busca en la api la funcion por id
  function searchGenderPerId(id: number) {
      selectedGenderId.value = id; // Almacena el ID de la obra buscada
      return genders.find(i => i.genderId === id);
  }




  return { fetchGenders, selectedGender, genders}
})
