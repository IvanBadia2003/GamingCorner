<script setup lang="ts">
import { ref } from 'vue';
import GameAdmin from './../components/Admin/GameAdmin.vue';
import CreateGame from '@/components/Admin/CreateGame.vue';
import { useUserStore } from '@/stores/UserStore';

const loginStore = useUserStore();

const opcionSeleccionada = ref('opcion1'); // Valor por defecto

const logout = () => {
    loginStore.logout();
};

</script>

<template>
    <div class="pago">
        <div>
            <input type="radio" id="opcion1" name="opciones" value="opcion1" v-model="opcionSeleccionada">
            <label for="opcion1">CREAR</label>
        </div>

        <div>
            <input type="radio" id="opcion2" name="opciones" value="opcion2" v-model="opcionSeleccionada">
            <label for="opcion2">EDITAR / BORRAR</label>


        </div>
        <div id="menuOpcion1" class="menu" v-show="opcionSeleccionada === 'opcion1'">
            <CreateGame />


        </div>

        <div id="menuOpcion2" class="menu" v-show="opcionSeleccionada === 'opcion2'">

            <GameAdmin />


        </div>

        <div class="divLogout">
        <RouterLink :to="'/'" @click="logout" class="logout">LOGOUT</RouterLink>
    </div>

    </div>

</template>

<style scoped lang="scss">

.pago {
    .divLogout {
        padding: 20px;
        .logout{
            color: white;
            background-color: red;
            padding: 15px;
            border-radius: 10px;
        }
    }
}
</style>