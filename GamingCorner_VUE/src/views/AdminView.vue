<script setup lang="ts">
import { ref } from 'vue';
import GameAdmin from '../components/Admin/GameAdmin.vue';
import CreateGame from '../components/Admin/CreateGame.vue';
import CreateConsole from '@/components/Admin/CreateConsole.vue';
/* import Graphics from '../components/Admin/Graphics.vue';
 *//* import { useUserStore } from '@/stores/UserStore';

const loginStore = useUserStore();
 */
const opcionSeleccionada = ref('opcion1'); // Valor por defecto

/* const logout = () => {
    loginStore.logout();
}; */

</script>

<template>
    <div class="admin">
        <div>
            <input type="radio" id="opcion1" name="opciones" value="opcion1" v-model="opcionSeleccionada">
            <label for="opcion1">CREAR</label>
        </div>

        <div>
            <input type="radio" id="opcion2" name="opciones" value="opcion2" v-model="opcionSeleccionada">
            <label for="opcion2">EDITAR / BORRAR</label>
        </div>
        <div>
            <input type="radio" id="opcion3" name="opciones" value="opcion3" v-model="opcionSeleccionada">
            <label for="opcion3">GRÁFICAS</label>
        </div>

        <div id="menuOpcion1" class="menu" v-show="opcionSeleccionada === 'opcion1'">
            <CreateGame />
            <CreateConsole />
        </div>

        <div id="menuOpcion2" class="menu" v-show="opcionSeleccionada === 'opcion2'">
            <GameAdmin />
        </div>

<!--         <div id="menuOpcion3" class="menu" v-show="opcionSeleccionada === 'opcion3'">
            <Graphics />
        </div> -->

    </div>

</template>

<style scoped lang="scss">
.admin {
    margin-top: 100px;
    min-height: 70vh;

    .menu{
        display: flex;
        justify-content: center;
    }
}
</style>