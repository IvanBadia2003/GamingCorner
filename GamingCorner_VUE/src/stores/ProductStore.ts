import { defineStore } from 'pinia';
import { computed, reactive, ref } from 'vue';

interface Product {
    productId: number;
    name: string;
    description: string;
    price: number;
    available: boolean;
    imageURL: string;
    pegi: number | null;
    platform: number | null;
    stock: number;
}

interface editedProduct {
    productId: number;
    name: string;
    available: boolean;
    price: number;
}

// Define el tipo de datos para los productos en el carrito
interface CartProduct {
    productId: number;
    name: string;
    price: number;
    imageURL: string;
}

export const useProductStore = defineStore('ProductStore', () => {
    // State
    const products = reactive<Product[]>([]);
    const cart = reactive<CartProduct[]>([]);
    const selectedProductId = ref<number>(-1);
    const product = reactive<Product>({
        productId: 0,
        name: '',
        description: '',
        available: false,
        price: 0,
        imageURL: '',
        pegi: 0,
        platform: 0,
        stock: 0
    });

    // Getter
    const calcularCantidad = computed(() => products.length);
    const selectedGame = computed(() => {
        if (selectedProductId.value !== null) {
            return products.find(func => func.productId === selectedProductId.value);
        }
        return null;
    });

    // Getter para obtener los productos en el carrito
    const cartItems = computed(() => cart);

    // Getter para obtener el total de precios en el carrito
    const totalPrice = computed(() => {
        return cart.reduce((total, item) => total + item.price, 0);
    });

    // Action
    async function fetchProducts() {
        try {
            const response = await fetch('http://gamingcornerapi.retocsv.es/Product');
            console.log("Fetch de grid de productos hecho desde ProductStore.ts");

            const data = await response.json();
            products.splice(0, products.length);
            products.push(...data);
        } catch (error) {
            console.error('Error al obtener los productos:', error);
        }
    }

    function searchProductsPerId(id: number) {
        selectedProductId.value = id;
        return products.find(i => i.productId === id);
    }

    async function fetchProductsById(id: number) {
        try {
            const response = await fetch('http://gamingcornerapi.retocsv.es/Product/' + id);
            console.log("Fetch de un producto hecho desde ProductStore.ts");

            const productData = await response.json();
            Object.assign(product, productData);
        } catch (error) {
            console.error('Error al obtener los detalles del producto:', error);
        }
    }

    async function deleteProduct(id: number, name: string) {
        try {
            const response = await fetch('http://gamingcornerapi.retocsv.es/Product/' + id, {
                method: 'DELETE',
            });
            console.log("Fetch de eliminar producto " + id + " hecho desde ProductStore.ts");
            alert(`Producto: ${name} eliminado con éxito`);
        } catch (error) {
            console.error('Error al eliminar:', error);
        }
    }

    async function purchaseProduct(id: number) {
        // Encuentra el juego en la lista de juegos (puedes ajustar esto según cómo estés manejando los datos)
        const product = products.find(g => g.productId === id);
    
        if (product) {
          // Calcula el nuevo stock y estado de disponibilidad
          const newAvailable = false;
    
          try {
            const response = await fetch('http://gamingcornerapi.retocsv.es/Product/' + id, {
              method: 'PUT',
              headers: {
                'Content-Type': 'application/json',
              },
              body: JSON.stringify({
                available: newAvailable
              }),
            });
    
            if (response.ok) {
                // Actualiza el juego en el store (opcional si ya lo manejas en otro lado)
                product.available = newAvailable;
                console.log('Producto editado exitosamente.');
            } else {
              console.error('Error al editar el juego:', response.statusText);
            }
          } catch (error) {
            console.error('Error al editar el juego:', error);
          }
        } else {
          console.error('Juego no encontrado');
        }
      }

    async function createProduct(product: Product) {
        try {
            const response = await fetch('http://gamingcornerapi.retocsv.es/Product', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(product),
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

    async function editProduct(id: number, product: editedProduct) {
        try {
            const response = await fetch('http://gamingcornerapi.retocsv.es/Product/' + id, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(product),
            });
            if (response.ok) {
                console.log('Producto editado exitosamente.');
            } else {
                console.error('Error al editar el producto:', response.statusText);
            }
        } catch (error) {
            console.error('Error al editar el producto:', error);
        }
    }

    function filterProductsByTitle(title: string) {
        if (title.length < 2) {
            return products;
        } else {
            return products.filter(func => func.name.toLowerCase().includes(title.toLowerCase()));
        }
    }

    // Añadir un producto al carrito
    function addToCart(product: CartProduct) {
        const existingProduct = cart.find(item => item.productId === product.productId);
        if (!existingProduct) {
            cart.push(product);
        }
    }

    // Eliminar un producto del carrito
    function removeFromCart(productId: number) {
        const index = cart.findIndex(item => item.productId === productId);
        if (index !== -1) {
            cart.splice(index, 1);
        }
    }

    // Vaciar el carrito
    function clearCart() {
        cart.splice(0, cart.length);
    }

    return {
        product,
        products,
        cart,
        calcularCantidad,
        fetchProducts,
        searchProductsPerId,
        deleteProduct,
        createProduct,
        editProduct,
        selectedGame,
        filterProductsByTitle,
        fetchProductsById,
        cartItems,
        totalPrice,
        addToCart,
        removeFromCart,
        clearCart,
        purchaseProduct
    };
});
