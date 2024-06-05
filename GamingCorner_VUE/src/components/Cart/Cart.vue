<script setup lang="ts">
import IconSteam from '@/components/icons/platform/IconSteam.vue';
import IconDelete from '@/components/icons/IconDelete.vue';
import { useCartStore } from '@/stores/CartStore';

var quantities: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10] 

const cartStore = useCartStore();

const removeFromCart = (gameId: number) => {
  cartStore.removeFromCart(gameId); // Despachar la acción
};
</script>

<template>
    <div class="cartContainer">
        <div class="cart">
            <div class="cart__title">
                <h3>Carrito</h3>
            </div>
            <div class="cart__product">
                <div v-for="product in cartStore.cartItems" class="product">
                    <div class="product__img">
                        <img :src="product.imageURL" :alt="`${product.name}`">
                    </div>
                    <div class="product__info">
                        <div class="info__up">
                            <div class="platform">
                                <IconSteam />
                            </div>
                            <div class="title">
                                <p>{{product.name}}</p>
                            </div>
                            <div class="delete" @click="removeFromCart(product.videogameId)">
                                <IconDelete />
                            </div>
                        </div>
                        <div class="info__down">
                            <div class="quantity">
                                <select name="quantity" id="quantity">
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                    <option value="4">4</option>
                                    <option value="5">5</option>
                                    <option value="6">6</option>
                                    <option value="7">7</option>
                                    <option value="8">8</option>
                                    <option value="9">9</option>
                                    <option value="10">10</option>
                                </select>
                            </div>
                            <div class="price">
                                <h2>{{product.price}}€</h2>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="separation"></div>


            </div>
        </div>
    </div>
</template>

<style scoped lang="scss">
.cartContainer {
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;

    .cart {
        width: 70%;
        height: auto;
        display: flex;
        flex-direction: column;

        &__title {
            text-align: left;
        }

        &__product {
            border-radius: 5px;
            border: 1px solid orange;
            margin-left: 15px;
            height: auto;
            width: 100%;

            display: flex;
            flex-direction: column;
            align-items: center;

            .product {
                width: 90%;
                height: auto;

                display: flex;
                align-items: center;
                justify-content: space-between;
                margin: 15px 0px;

                &__img {
                    width: 35%;

                    height: auto;

                    img {
                        max-width: 100%;
                    }
                }

                &__info {
                    width: 60%;
                    height: 100%;

                    display: flex;
                    flex-direction: column;


                    .info__up {
                        width: 100%;
                        height: 50%;

                        display: flex;
                        flex-direction: row;
                        justify-content: center;
                        align-items: center;

                        img {
                            max-width: 100%;
                        }

                        .platform {
                            width: 15%;
                            height: 100%;

                            &__icon {
                                width: 100%;
                            }

                        }

                        .title {
                            width: 70%;
                            height: 100%;
                        }

                        .delete {
                            width: 15%;
                            height: 100%;
                        }
                    }

                    .info__down {
                        width: 100%;
                        height: 50%;

                        
                        display: flex;
                        flex-direction: row;
                        justify-content: space-around;
                        align-items: center;

                        .quantity{
                            width: 40%;
                            select{
                                width: 100%;
                            }
                        }

                        .price{
                            width: 30%;
                            select{
                                width: 100%;
                            }
                        }
                    }

                }

            }

            .separation {
                background-color: bisque;
                width: 90%;
                height: 3px;
            }
        }
    }
}
</style>