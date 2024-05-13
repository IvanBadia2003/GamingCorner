<script setup lang="ts">
import ToogleMenuplatform from './ToogleMenuPlatform.vue';
import IconCart from './icons/IconCart.vue';
import IconLogo from './icons/IconLogo.vue';
import IconSearch from './icons/IconSearch.vue';
import IconUser from './icons/IconUser.vue';

import { useHeaderStore } from '@/stores/HeaderStore';

const HeaderStore = useHeaderStore();


</script>

<template>

    <header class="header-container">

        <div class="logo">

            <IconLogo />
        </div>

        <nav class="menu">
            <div class="menu-second">
                <ul>
                    <li>Catálogo</li>
                    <li>Segunda Mano</li>
                    <li>Soporte</li>
                </ul>
            </div>

            <div class="menu-first">
                <div class="search-container">
                    <div class="search">
                        <IconSearch />
                        <input class="search-input" type="search">
                    </div>
                </div>
                <div class="categories">
                    <ul>
                        <li @click="HeaderStore.toggleSubMenu('pc')">PC</li>
                        <li @click="HeaderStore.toggleSubMenu('playstation')">PlayStation</li>
                        <li @click="HeaderStore.toggleSubMenu('xbox')">Xbox</li>
                        <li @click="HeaderStore.toggleSubMenu('nintendo')">Nintendo</li>
                    </ul>

                    <div class="submenu">

                        <div v-if="HeaderStore.titleMenuPlatform === 'pc'">
                            <ToogleMenuplatform title="Juegos" />
                        </div>
                        <div v-if="HeaderStore.titleMenuPlatform === 'playstation'">

                            <ToogleMenuplatform title="Juegos" />
                            <ToogleMenuplatform title="Consolas" />
                        </div>
                        <div v-if="HeaderStore.titleMenuPlatform === 'xbox'">

                            <ToogleMenuplatform title="Juegos" />
                            <ToogleMenuplatform title="Consolas" />
                        </div>
                        <div v-if="HeaderStore.titleMenuPlatform === 'nintendo'">

                            <ToogleMenuplatform title="Juegos" />
                            <ToogleMenuplatform title="Consolas" />
                        </div>

                    </div>
                </div>
                <!-- Submenú -->



            </div>

        </nav>


        <div class="icons-container">
            <div class="icons">

                <IconUser />
                <IconCart />
            </div>
        </div>

    </header>

</template>

<style scoped lang="scss">
@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Bebas+Neue&display=swap');

$primaryFont: 'Bebas Neue';
$secondlyFont: 'Montserrat';

@mixin links {
    list-style: none;
    display: flex;
    flex-direction: row;
    padding: 0;
    color: white;
    font-family: $secondlyFont;

}

.header-container {
    background-color: #4876EB;
    display: flex;
    justify-content: space-between;
    align-items: center;

    width: 100%;
    
    top: 0;
    height: 155px;

    transition: .2s;
    z-index: 2;
    position: fixed;

    animation: scrollHeader both;
    animation-timeline: scroll(root);
    animation-range: 0 200px;

    .logo {
        height: auto;
        width: 15%;
        margin-left: 15px;
        img {
            width: 100%;
        }
    }

    .menu {
        display: flex;
        justify-content: center;
        align-items: center;
        flex-direction: column;
        position: absolute;
        top: 0;
        left: 50%;
        z-index: 11;

        transform: translateX(-50%);

        .menu-first {
            .categories {
                position: absolute;
                left: 50%;
                transform: translateX(-50%);

                ul {
                    @include links();

                    li {
                        padding: {
                            left: 5px;
                            right: 5px;

                        }

                    }
                }

                .submenu {
                    position: relative;
                    left: 50%;
                    transform: translateX(-50%);
                    width: 130%;
                }
            }


            .search-container {
                display: flex;
                justify-content: center;
                align-items: center;

                .search {
                    top: 5%;
                    background-color: white;
                    width: fit-content;
                    height: 41px;
                    /* quitarlo para que se expanda también a lo alto */
                    padding: 4px;
                    display: flex;
                    border-radius: 25px;

                    animation: scrollSearch both;
                    animation-timeline: scroll(root);
                    animation-range: 0 50px;



                    img {
                        background-color: #4876EB;
                        padding: 10px;
                        border-radius: 50px;
                        /* width: 20%; para que se expanda también a lo alto */
                    }

                    &-input {
                        transition: .4s;
                        background-color: transparent;
                        border: 0;
                        outline: none;
                        font-size: 20px;
                        padding: 0;
                        width: 0;
                    }
                }
            }

            .search:hover input {
                width: 150px;
            }
        }

        .menu-second {
            animation: scrollSecondMenu both;
            animation-timeline: scroll(root);
            animation-range: 0 50px;

            ul {
                @include links();
            }
        }
    }

    .icons-container {

        margin-right: 15px;

        .icons {
            display: flex;
            justify-content: space-evenly;
            align-items: center;
            padding: 5px;

            width: auto;

            border: 3px white solid;
            border-radius: 33px;

            background-color: #4876EB;

            /* CONTINUAR CON EL DIV DE LOS ICONOS */
            img {
                width: 30%;
            }
        }


    }
}



@keyframes scrollHeader {
    to {
        background-color: rgba(72, 118, 235, .4);
        backdrop-filter: blur(9px);
        height: 100px;
    }
}

@keyframes scrollSecondMenu {
    to {
        display: none;
    }
}

@keyframes scrollSearch {
    to {
        margin-top: 5%;
    }
}
</style>