<script setup lang="ts">
import { useCartStore } from '@/stores/CartStore';
import { computed } from 'vue';
import Cart from '@/components/Cart/Cart.vue';
import Summary from '@/components/Cart/Summary.vue';

const cartStore = useCartStore();
const cartItems = computed(() => cartStore.cartItems);
/* const totalPrice = computed(() => cartStore.totalPrice);
const totalItems = computed(() => cartStore.totalItems); */



</script>

<template>
    <div class="container">
        <div>
            <Cart/>
        </div>
        <div>
            <Summary/>
        </div>
    </div>
</template>

<style scoped lang="scss">

.container{
    display: flex;
    flex-direction: column;

    color: white;

    div{
        background-color: gray;
        width: 100%;
        height: auto;
    }
}

</style>