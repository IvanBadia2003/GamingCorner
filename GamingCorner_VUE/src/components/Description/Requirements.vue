<script setup lang="ts">
import { useGameStore } from '@/stores/GameStore';

defineProps<{
    productMin: string[];
    productMax: string[];
}>()
</script>

<template>
    <div class="requirementsDiv">
        <div class="requirements minimum">
            <div class="title">
                <h2>Mínimos</h2>
            </div>
            <table>
                <tr>
                    <th>OS:</th>
                    <td>{{ productMin[0] }}</td>
                </tr>
                <tr>
                    <th>Procesador:</th>
                    <td>{{ productMin[1] }}</td>
                </tr>
                <tr>
                    <th>Memoria:</th>
                    <td>{{ productMin[2] }}</td>
                </tr>
                <tr>
                    <th>Gráfica:</th>
                    <td>{{ productMin[3] }}</td>
                </tr>
                <tr>
                    <th>Almacenamiento:</th>
                    <td>{{ productMin[4] }}</td>
                </tr>
                <tr>
                    <th>DirectX:</th>
                    <td>{{ productMin[5] }}</td>
                </tr>
            </table>
        </div>

        <div class="requirements maximum">
            <div class="title">
                <h2>Máximos</h2>
            </div>
            <table>
                <tr>
                    <th>OS:</th>
                    <td>{{ productMax[0] }}</td>
                </tr>
                <tr>
                    <th>Procesador:</th>
                    <td>{{ productMax[1] }}</td>
                </tr>
                <tr>
                    <th>Memoria:</th>
                    <td>{{ productMax[2] }}</td>
                </tr>
                <tr>
                    <th>Gráfica:</th>
                    <td>{{ productMax[3] }}</td>
                </tr>
                <tr>
                    <th>Almacenamiento:</th>
                    <td>{{ productMax[4] }}</td>
                </tr>
                <tr>
                    <th>DirectX:</th>
                    <td>{{ productMax[5] }}</td>
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
        flex-direction: column;


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