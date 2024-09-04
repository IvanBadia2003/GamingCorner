import { defineStore } from 'pinia';
import type { ListFormat } from 'typescript';
import { computed, reactive, ref } from 'vue';

interface Product {
    productId: number;
    name: string;
    description: string;
    price: number;
    available: boolean;
    imageURL: string;
}

interface editedProduct {
    productId: number;
    name: string;
    available: boolean;
    price: number;

}

export const useProductStore = defineStore('ProductStore', () => {
    // State
    const products = reactive(new Array<Product>);
    const selectedProductId = ref<number>(-1); // Inicializa con un valor que represente que no hay ninguna obra seleccionada
    const product = reactive<Product>({
        productId: 0,
        name: '',
        description: '',
        available: false,
        price: 0,
        imageURL: '',
    });

    // Getter
    // calcula la cantidad de funciones que hay
    const calcularCantidad = computed(() => products.length);

    // Getter para obtener la obra seleccionada
    const selectedGame = computed(() => {
        if (selectedProductId.value !== null) {
            return products.find(func => func.productId === selectedProductId.value);
        }
        return null;
    });




    // Action
    // saca de la api todas los juegos que hay
    async function fetchProducts() {

        try {
            const response = await fetch('http://localhost:5000/Product');
            console.log("Fetch de grid de juegos hecho desde ProductStore.ts");

            const data = await response.json();
            products.splice(0, products.length)
            products.push(...data);
            // Actualiza la lista de posteos con los datos de la api
        } catch (error) {
            console.error('Error al obtener los posteos:', error);
        }
    }

    // busca en la api la funcion por id
    function searchProductsPerId(id: number) {
        selectedProductId.value = id; // Almacena el ID de la obra buscada
        return products.find(i => i.productId === id);
    }

    async function fetchProductsById(id: number) {
        try {
            const response = await fetch('http://localhost:5000/Product/' + id);
            console.log("Fetch de un juego hecho desde ProductStore.ts");

            const productData = await response.json();

            // Actualiza el estado del juego
            Object.assign(product, productData);
        } catch (error) {
            console.error('Error al obtener los detalles del producto:', error);
        }
    };



    // eliminar obra
    async function deleteProduct(id: number, name: string) {
        try {
            const response = await fetch('http://localhost:5000/Product/' + id, {
                method: 'DELETE',
            });
            console.log("Fetch de eliminar producto " + id + " hecho desde ProductStore.ts");
            alert(`Juego: ${name} eliminado con éxito`)

        } catch (error) {
            console.error('Error al eliminar:', error);
        }
    }

    // crear obra
    async function createProduct(product: Product) {
        try {
            const response = await fetch('http://localhost:5000/Product', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json', // Indica que estás enviando datos en formato JSON
                },
                body: JSON.stringify(product), // Convierte el objeto obra a JSON y lo envía en el cuerpo de la solicitud

            });
            if (response.ok) {
                console.log('Producto creado exitosamente.');
            } else {
                console.error('Error al crear el producto:', response.statusText);
            }
        } catch (error) {
            console.error('Error al crear el producto:', error);
        }
    }

    // editar juego
    async function editProduct(id: number, product: editedProduct) {
        debugger
        try {
            const response = await fetch('http://localhost:5000/Product/' + id, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json', // Indica que estás enviando datos en formato JSON
                },
                body: JSON.stringify(product), // Convierte el objeto obra a JSON y lo envía en el cuerpo de la solicitud

            });
            if (response.ok) {
                console.log('producto editado exitosamente.');
            } else {
                console.error('Error al editar la obra:', response.statusText);
            }
        } catch (error) {
            console.error('Error al editar la obra:', error);
        }
    }

    // Filtrar funciones por título
    function filterProductsByTitle(title: string) {
        console.log('Busco por titulo en la store');
        if (title.length < 2) {
            return products;
        } else {
            const gamesFiltered = products.filter(func => func.name.toLowerCase().includes(title.toLowerCase()));
            return gamesFiltered
        }
    }


    return { product, products, calcularCantidad, fetchProducts, searchProductsPerId, deleteProduct, createProduct, editProduct, selectedGame, filterProductsByTitle, fetchProductsById };
});