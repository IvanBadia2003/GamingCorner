<script setup lang="ts">
import { ref, nextTick } from 'vue';

const showFullText = ref<boolean>(false);
const description = ref<HTMLElement | null>(null);

const textButton = ref("MAS");
const toggleText = async () => {
    showFullText.value = !showFullText.value;
    await nextTick();
    if (description.value) {
        const fullHeight = description.value.scrollHeight + 'px';
        if (showFullText.value) {
            description.value.style.maxHeight = fullHeight;
            textButton.value = "MENOS"
        } else {
            description.value.style.maxHeight = '100px';
            textButton.value = "MAS"
        }
    }
};

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
    product: string ;
    isGame: boolean;
}>()
</script>

<template>
    <div class="description-container">
        <p :class="{ 'show-more': showFullText }" ref="description">
            {{ product }}
            <div class="fade" v-if="!showFullText"></div>
        </p>
        <button @click="toggleText">
            {{textButton}}
        </button>
    </div>
</template>

<style scoped lang="scss">
.description-container {
    position: relative;
    max-width: 70%;
    margin: 20px auto;
    padding: 20px;
    background-color: #f7f7f7;
    border-radius: 15px;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
    overflow: hidden;
    font-family: 'Montserrat';
  
    p {
        margin: 0;
        font-size: calc(0.5em + 1.5vw) ;
        line-height: 1.6;
        color: #333;
        text-align: justify;
        max-height: 150px; // Limitar la altura máxima cuando el texto está contraído
        overflow: hidden;
        transition: max-height 0.3s ease, opacity 0.3s ease;

        &.show-more {
            max-height: 100%; // Expandir el texto al 100% de su altura
        }
    }

    .fade {
        position: absolute;
        bottom: 0;
        left: 0;
        width: 100%;
        height: 50px;
        background: linear-gradient(to bottom, rgba(247, 247, 247, 0), #f7f7f7);
    }

    button {
        display: block;
        margin: 20px auto 0 auto;
        padding: 10px 20px;
        background-color: #ff6600;
        color: white;
        font-size: 1rem;
        font-weight: bold;
        border: none;
        border-radius: 25px;
        cursor: pointer;
        transition: background-color 0.3s ease, transform 0.3s ease;

        &:hover {
            background-color: #e65c00;
            transform: scale(1.05);
        }

        &:focus {
            outline: none;
        }
    }
}

@media screen and (min-width: 767px) {
    .description-container {
        p {
            font-size: calc(1em + 0.2vw) ;

        }

    }

}
</style>
