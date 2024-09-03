<script setup lang="ts">
import { ref, computed } from 'vue';
import { useGameStore } from '@/stores/GameStore';
import { useCartStore } from '@/stores/CartStore';
import IconFavorite from '@/components/icons/IconFavorite.vue';
import IconTick from '@/components/icons/IconTick.vue';
import IconCross from '@/components/icons/IconCross.vue';
import IconPegi3 from '@/components/icons/pegi/IconPegi3.vue';
import IconPegi7 from '@/components/icons/pegi/IconPegi7.vue';
import IconPegi12 from '@/components/icons/pegi/IconPegi12.vue';
import IconPegi16 from '@/components/icons/pegi/IconPegi16.vue';
import IconPegi18 from '@/components/icons/pegi/IconPegi18.vue';
import IconSteam from '@/components/icons/platform/IconSteam.vue';
import IconPS from '@/components/icons/platform/IconPS.vue';
import IconXbox from '@/components/icons/platform/IconXbox.vue';
import IconNintendo from '@/components/icons/platform/IconNintendo.vue';

interface Console {
    consoleId: number;
    name: string;
    platformId: number;
    specifications: string;
    stock: number;
    available: boolean;
    price: number;
    imageURL: string;
}

interface Game {
    videogameId: number;
    name: string;
    pegi: number;
    description: string;
    category: string;
    stock: number;
    available: boolean;
    platform: string;
    price: number;
    imageURL: string;
}


defineProps<{
    product: Game | Console;
    isGame: boolean;
}>()

const gameStore = useGameStore();
const cartStore = useCartStore();

const game = computed(() => gameStore.game);

/* const addToCart = () => {
    if (game.value) {
        cartStore.addToCart({
            videogameId: game.value.videogameId,
            name: game.value.name,
            price: game.value.price,
            quantity: 1,
            imageURL: game.value.imageURL
        });
    }
}; */


</script>

<template>
    <div class="principal">
        <div>
            <img :src="product.imageURL" :alt="product.name">
        </div>
    </div>
    <div class="information">
        <div class="terciary">
            <div class="infoIcons">
                <div class="infoIcons__favorite">
                    <IconFavorite class="favorite" />
                </div>
                <div class="infoIcons__pegi" v-if="isGame">
                    <IconPegi3 v-if="product.pegi === 3" />
                    <IconPegi7 v-if="product.pegi === 7" />
                    <IconPegi12 v-if="product.pegi === 12" />
                    <IconPegi16 v-if="product.pegi === 16" />
                    <IconPegi18 v-if="product.pegi === 18" />
                </div>
                <div class="infoIcons__others">
                    <div class="platform" v-if="isGame">
                        <IconSteam v-if="product.platform === 'Steam'" />
                        <IconPS v-if="product.platform === 'PS'" />
                        <IconXbox v-if="product.platform === 'Xbox'" />
                        <IconNintendo v-if="product.platform === 'Nintendo'" />
                    </div>
                    <div class="stock">
                        <IconTick v-if="product.stock > 0" />
                        <IconCross v-else />
                    </div>
                    <div class="valorations">
                        5
                    </div>
                </div>
            </div>
        </div>
        <div class="secundary">
            <div class="price">
                <h2>{{ product.price }}€</h2>
            </div>
            <div class="buttons">
                <button class="button" style="background-color: #ff6600;" @click="addToCart">
                    CARRITO
                </button>
                <router-link :to="{ name: 'cart' }" class="button" style="background-color: orangered;">
                    COMPRAR
                </router-link>
            </div>
        </div>
    </div>
</template>


<style scoped lang="scss">
@mixin content($width, $height) {
    width: $width;
    height: $height;

    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;

    padding: {
        top: 16px;
        bottom: 16px;
    }

}


.principal {
    @include content(100%, auto);

    div {
        display: flex;
        flex-direction: column;
        text-align: center;
        justify-content: center;

        img {
            border-radius: 21px;
        }

        a {
            color: white;
            text-decoration: none;

            margin-top: 15px;

            font: {
                size: 18px;
                weight: bold;
            }

            border-radius: 50px;
            border: 3px solid blue;
            width: 100%;

        }
    }

}

.information {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;


    .secundary {
        display: flex;
        flex-direction: column;
        align-items: center;
        width: 100%;
        justify-content: space-between;

        .price {

            h2 {
                font: {
                    size: 50px;
                }
            }
        }

        .buttons {
            width: 100%;
            display: flex;
            flex-direction: row;
            justify-content: space-between;

            .button {
                width: 45%;
                background-color: gray;
                padding: 10px 10px;
                border-radius: 20px;
                text-decoration: none;
                color: white;

            }
        }
    }

    .terciary {
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: space-between;
        width: 100%;

        img {
            width: 50px;
            height: auto;
            border-radius: 10px;
        }

        .infoIcons {
            display: flex;
            width: 100%;
            justify-content: center;
            gap: 5px;

            &__favorite {
                display: flex;
                align-items: center;
                width: 50px;
                height: 50px;
                border-radius: 10px;

            }

            &__pegi {
                padding: 0px 15px;
                width: 50px;
                height: 50px;
                border-radius: 10px;
            }

            &__others {
                display: flex;
                align-items: center;
                gap: 5px;

                .platform,
                .stock,
                .valorations {
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    width: 50px;
                    height: 50px;
                    border-radius: 10px;
                    box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
                    transition: transform 0.3s ease, box-shadow 0.3s ease;
                }

                .platform:hover,
                .stock:hover,
                .valorations:hover {
                    transform: scale(1.1);
                    box-shadow: 0 4px 12px rgba(0, 0, 0, 0.2);
                }

                .valorations {
                    font-size: 1rem;
                    font-weight: bold;
                    color: #333;
                    color: #fff;
                }


            }
        }
    }
}


@media screen and (min-width: 767px) {
    .principal {
        @include content(30%, 100%);
        align-items: center;

        div {
            height: 100%;
            width: 300px;

            display: flex;
            flex-direction: column;
            text-align: center;
            justify-content: center;

            img {
                border-radius: 21px;
            }

            a {
                color: white;
                text-decoration: none;

                margin-top: 15px;

                font: {
                    size: 18px;
                    weight: bold;
                }

                border-radius: 50px;
                border: 3px solid blue;
                width: 98%;

            }
        }


    }


    .information {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        align-items: center;
        width: 30%;

        .secundary {
            width: 70%;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: space-between;

            .price {

                h2 {
                    font: {
                        size: 50px;
                    }
                }
            }

            .buttons {
                width: 100%;
                display: flex;
                flex-direction: row;
                justify-content: space-between;

                .button {
                    width: 45%;
                    background-color: gray;
                    padding: 10px 10px;
                    border-radius: 20px;
                    text-decoration: none;
                    color: white;

                }
            }
        }


        .terciary {
            @include content(30%, 100%);
            margin-left: 0;
            margin-top: 0;


            .infoIcons {
                @include content(100%, 50%);

                &__others {
                    flex-direction: column
                }
            }

            .infoText {
                @include content(100%, 50%);

            }

        }
    }

}
</style>