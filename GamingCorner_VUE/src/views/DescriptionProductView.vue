<script setup lang="ts">
import { onMounted, computed } from 'vue';
import { useRoute } from 'vue-router';
import { useProductStore } from '@/stores/ProductStore';
import { useCartStore } from '@/stores/CartStore';
import BuyComponent from '../components/Description/BuyComponent.vue';
import Multimedia from '../components/Description/Multimedia.vue';
import Description from '../components/Description/Description.vue';


const route = useRoute();
const productStore = useProductStore();
const cartStore = useCartStore();

interface Gender {
    genderId: number,
    videogameId: number
}

interface Product {
    productId: number;
    name: string;
    description: string;
    price: number;
    available: boolean;
    imageURL: string;
}


const ProductId = computed(() => parseInt(route.params.id as string, 10));
onMounted(() => {
    productStore.fetchProductsById(ProductId.value);
});

/* const addToCart = () => {
    const game: Game = gameStore.game; // Asegúrate de que Game esté definido correctamente
    if (game.name) {
        cartStore.addToCart({
            videogameId: game.videogameId,
            name: game.name,
            price: game.price,
            quantity: 1,
            imageURL: game.imageURL
        });
    }
}; */
</script>


<template>
    <div class="container">
        <h2> {{ productStore.product.name }} </h2>

        <section class="section first">
            <BuyComponent :product="productStore.product" :isGame="false" type="product"/>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Especificaciones</h2>
            </div>
            <div class="content">
                <Description :product="productStore.product.description" :isGame="false"/>
            </div>
        </section>


    </div>
</template>

<style scoped lang="scss">
.container {
    margin-top: 100px;
    width: 100%;
    height: auto;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;

    background-color: gray;
    color: white;

    .section {
        width: 90%;
        height: auto;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        background-color: orange;
        border-radius: 15px;
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
        margin: 40px auto;
        padding: 20px;


        .title-container {
            width: 100%;
            display: flex;
            border-bottom: 1px solid orange;
            justify-content: center;
        }

        .content {
            width: 100%;
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-top: 15px;

        }
    }
}

@media screen and (min-width: 767px) {
    .container {

        .first {
            flex-direction: row;
            align-items: normal;
        }
    }
}
</style>
