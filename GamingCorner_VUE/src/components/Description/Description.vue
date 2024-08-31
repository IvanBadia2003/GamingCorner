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
</script>

<template>
    <div class="description-container">
        <p :class="{ 'show-more': showFullText }" ref="description">
            The Legend of Zelda: Breath of the Wild para Nintendo Switch es un juego de acción y aventuras de Nintendo,
            la última entrega de la larga serie de The Legend of Zelda. El juego ofrece un formato de mundo abierto, con
            amplia libertad y pocas instrucciones para los jugadores. La jugabilidad consiste en recolectar utensilios y
            materiales, completar misiones secundarias y resolver ingeniosos puzles y mazmorras.
            Gran parte del encanto de este juego reside en el hecho de que premia la experimentación, por lo que te
            anima a que te salgas del guion y explores el inmenso mundo que ofrece a tu propio ritmo.
            The Legend of Zelda: Breath of the Wild para Nintendo Switch es un juego de acción y aventuras de Nintendo,
            la última entrega de la larga seriteriales, completar misiones secundarias y resolver ingeniosos puzles y mazmorras.
            Gran parte del encanto de este juego reside en el hecho de que premia la experimentación, por lo que te
            anima a que te salgas del guion y explores el inmenso mundo que ofrece a tu propio ritmo.
            The Legend of Zelda: Breath of the Wild para Nintendo Switch es un juego de acción y aventuras de Nintendo,
            la última entrega de la larga serie de The Legend of Zelda. El juego ofrece un formato de mundo abierto, con
            amplia libertad y pocas instrucciones para los jugadores. La jugabilidad consiste en recolectar utensilios y
            materiales, completar misiones secundarias y resolver ingeniosos puzles y mazmorras.
            Gran parte del encanto de este juego reside en el hecho de que premia la experimentación, por lo que te
            anima a que te salgas del guion y explores el inmenso mundo que ofrece a tu propio ritmo.e de The Legend of Zelda. El juego ofrece un formato de mundo abierto, con
            amplia libertad y pocas instrucciones para los jugadores. La jugabilidad consiste en recolectar utensilios y
            materiales, completar misiones secundarias y resolver ingeniosos puzles y mazmorras.
            Gran parte del encanto de este juego reside en el hecho de que premia la experimentación, por lo que te
            anima a que te salgas del guion y explores el inmenso mundo que ofrece a tu propio ritmo.
            ma
            amplia libertad y pocas instrucciones para los jugadores. La jugabilidad consiste en recolectar utensilios y
            materiales, completar misiones secundarias y resolver ingeniosos puzles y mazmorras.
            Gran parte del encanto de este juego reside en el hecho de que premia la experimentación, por lo que te
            anima a que te salgas del guion y explores el inmenso mundo que ofrece a tu propio ritmo.
            The Legend of Zelda: Breath of the Wild para Nintendo Switch es un juego de acción y aventuras de Nintendo,
            la última entrega de la larga seriteriales, completar misiones secundarias y resolver ingeniosos puzles y mazmorras.
            Gran parte del encanto de este juego reside en el hecho de que premia la experimentación, por lo que te
            anima a que te salgas del guion y explores el inmenso mundo que ofrece a tu propio ritmo.
            The Legend of Zelda: Breath of the Wild para Nintendo Switch es un juego de acción y aventuras de Nintendo,
            la última entrega de la larga serie de The Legend of Zelda. El juego ofrece un formato de mundo abierto, con
            amplia libertad y pocas instrucciones para los jugadores. La jugabilidad consiste en recolectar utensilios y
            materiales, completar misiones secundarias y resolver ingeniosos puzles y mazmorras.
            Gran parte del encanto de este juego reside en el hecho de que premia la experimentación, por lo que te
            anima a que te salgas del guion y explores el inmenso mundo que ofrece a tu propio ritmo.e de The Legend of Zelda. El juego ofrece un formato de mundo abierto, con
            amplia libertad y pocas instrucciones para los jugadores. La jugabilidad consiste en recolectar utensilios y
            materiales, completar misiones secundarias y resolver ingeniosos puzles y mazmorras.
            Gran parte del encanto de este juego reside en el hecho de que premia la experimentación, por lo que te
            anima a que te salgas del guion y explores el inmenso mundo que ofrece a tu propio ritmo.
            ma
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
    max-width: 90%;
    margin: 20px auto;
    padding: 20px;
    background-color: #f7f7f7;
    border-radius: 15px;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
    overflow: hidden;

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
