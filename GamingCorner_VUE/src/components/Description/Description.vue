<template>
    <p :class="{ 'show-more': showFullText }" ref="description">
        The Legend of Zelda: Breath of the Wild para Nintendo Switch es un juego de acción y aventuras de Nintendo,
        la última entrega de la larga serie de The Legend of Zelda. El juego ofrece un formato de mundo abierto, con
        amplia libertad y pocas instrucciones para los jugadores. La jugabilidad consiste en recolectar utensilios y
        materiales, completar misiones secundarias y resolver ingeniosos puzles y mazmorras.
        Gran parte del encanto de este juego reside en el hecho de que premia la experimentación, por lo que te
        anima a que te salgas del guion y explores el inmenso mundo que ofrece a tu propio ritmo.
        The Legend of Zelda: Breath of the Wild para Nintendo Switch es un juego de acción y aventuras de Nintendo,
        la última entrega de la larga serie de The Legend of Zelda. El juego ofrece un formato de mundo abierto, con
        amplia libertad y pocas instrucciones para los jugadores. La jugabilidad consiste en recolectar utensilios y
        materiales, completar misiones secundarias y resolver ingeniosos puzles y mazmorras.
        Gran parte del encanto de este juego reside en el hecho de que premia la experimentación, por lo que te
        anima a que te salgas del guion y explores el inmenso mundo que ofrece a tu propio ritmo.
        <div class="fade" v-if="!showFullText"></div>
    </p>
    <button @click="toggleText">
        MÁS
    </button>
</template>

<script setup lang="ts">
import { ref, nextTick } from 'vue';

const showFullText = ref<boolean>(false);
const description = ref<HTMLElement | null>(null);

const toggleText = async () => {
    showFullText.value = !showFullText.value;
    await nextTick();
    if (description.value) {
        const fullHeight = description.value.scrollHeight + 'px';
        if (showFullText.value) {
            description.value.style.maxHeight = fullHeight;
        } else {
            description.value.style.maxHeight = '100px';
        }
    }
};
</script>

<style lang="scss">

h2 {
    font-size: 1.5em;
    margin-bottom: 10px;
}

p {
    max-height: 100px;
    overflow: hidden;
    position: relative;
    margin-bottom: 20px;
    transition: max-height 0.5s ease;

    &.show-more {
        max-height: none; /* Este valor será sobrescrito por JavaScript */
    }
}

.fade {
    content: "";
    position: absolute;
    bottom: -15px;
    left: 0;
    width: 100%;
    height: 60px;
    background: linear-gradient(to bottom, rgba(45, 62, 139, 0) 0%, rgba(45, 62, 139, 1) 100%);
    pointer-events: none;
}

button {
    background-color: #3498db;
    color: white;
    border: none;
    padding: 10px 20px;
    cursor: pointer;
    font-size: 1em;
    border-radius: 5px;

    &:hover {
        background-color: #2980b9;
    }
}

</style>
