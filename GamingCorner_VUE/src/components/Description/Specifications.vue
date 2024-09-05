<script setup lang="ts">
import { useGameStore } from '@/stores/GameStore';

defineProps<{
    especificacionesArray: string[];
}>()
</script>

<template>
    <div class="requirementsDiv">
        <div class="requirements maximum">
                <table>
                    <tr>
                        <th>CPU:</th>
                        <td>{{ especificacionesArray[0] }}</td>
                    </tr>
                    <tr>
                        <th>GPU:</th>
                        <td>{{ especificacionesArray[1] }}</td>
                    </tr>
                    <tr>
                        <th>Memoria:</th>
                        <td>{{ especificacionesArray[2] }}</td>
                    </tr>
                    <tr>
                        <th>Almacenamiento:</th>
                        <td>{{ especificacionesArray[3] }}</td>
                    </tr>
                    <tr>
                        <th>Peso:</th>
                        <td>{{ especificacionesArray[4] }}</td>
                    </tr>

                </table>
                <table>
                    <tr>
                        <th>Entrada/Salida:</th>
                        <td>{{ especificacionesArray[5] }}</td>
                    </tr>
                    <tr>
                        <th>Red:</th>
                        <td>{{ especificacionesArray[6] }}</td>
                    </tr>
                    <tr>
                        <th>Alimentación:</th>
                        <td>{{ especificacionesArray[7] }}</td>
                    </tr>
                    <tr>
                        <th>Consumo de energía:</th>
                        <td>{{ especificacionesArray[8] }}</td>
                    </tr>
                    <tr>
                        <th>Salida AV:</th>
                        <td>{{ especificacionesArray[9] }}</td>
                    </tr>
                </table>

        </div>
    </div>
</template>

<style scoped lang="scss">
.requirementsDiv {
    width: 100%;
    display: flex;
    flex-direction: column;

    .requirements {
        width: 100%;
        display: flex;
        flex-direction: row;


        .title {
            width: 100%;
            border-bottom: 1px solid black;
            text-align: left;

        }

        table {
            border-collapse: collapse;
            width: 100%;
        }

        th,
        td {
            padding: 10px;
            text-align: left;
        }

    }


    @media screen and (min-width: 767px) {
        flex-direction: row;

    }
}
</style>