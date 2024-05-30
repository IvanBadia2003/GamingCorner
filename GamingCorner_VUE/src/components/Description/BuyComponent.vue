<script setup lang="ts">
import { useGameStore } from '@/stores/GameStore';
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

const gameStore = useGameStore();

</script>

<template>
    <div class="principal">
        <div>
            <img :src="gameStore.game.imageURL" :alt="`${gameStore.game.name}`">
        </div>

    </div>
    <div class="information">
        <div class="terciary">
            <div class="infoIcons">
                <div class="infoIcons__favorite">
                    <IconFavorite class="favorite" />
                </div>
                <div class="infoIcons__pegi">
                    <IconPegi3 v-if="gameStore.game.pegi == 3" />
                    <IconPegi7 v-if="gameStore.game.pegi == 7" />
                    <IconPegi12 v-if="gameStore.game.pegi == 12" />
                    <IconPegi16 v-if="gameStore.game.pegi == 16" />
                    <IconPegi18 v-if="gameStore.game.pegi == 18" />
                </div>
                <div class="infoIcons__others">
                    <div class="infoIcons__others__platform">
                        <IconSteam />
                    </div>
                    <div class="infoIcons__others__stock">
                        <IconTick IconCross v-if="gameStore.game.stock > 0" />
                        <IconCross v-else />
                    </div>
                    <div class="infoIcons__others__valorations">
                        5
                    </div>
                </div>
            </div>
        </div>
        <div class="secundary">
            <h2>{{ gameStore.game.price }}€</h2>
            <router-link :to="'/cart'" class="button">
                COMPRAR
            </router-link>
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
        flex-direction: row;
        align-items: center;
        width: 100%;
        justify-content: space-between;

        h2 {
            font: {
                size: 50px;
            }
        }

        .button {
            background-color: gray;
            padding: 20px;
            border-radius: 20px;
            text-decoration: none;
            color: white;


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

            &__favorite {
                display: flex;
                align-items: center;
                padding: 0px 15px;


            }

            &__pegi {
                padding: 0px 15px;

            }

            &__others {
                display: flex;

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
        width: 20%;

        .secundary {
            display: flex;
            flex-direction: column;
            align-items: center;
            width: auto;
            justify-content: space-between;

            h2 {
                font: {
                    size: 50px;
                }
            }

            .button {
                background-color: gray;
                padding: 30px 70px;
                border-radius: 20px;
                text-decoration: none;
                color: white;


            }
        }


        .terciary {
            @include content(30%, 100%);
            margin-left: 0;
            margin-top: 0;


            .infoIcons {
                @include content(100%, 50%);

                &__favorite {
                    display: flex;
                    align-items: center;
                    padding: 0px 15px;


                }

                &__pegi {
                    padding: 0px 15px;

                }

                &__others {
                    display: flex;
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