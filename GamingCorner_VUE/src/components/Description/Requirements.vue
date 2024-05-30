<script setup lang="ts">
import { useGameStore } from '@/stores/GameStore';

const gameStore = useGameStore();

</script>

<template>
<div class="requirements minimum">
    <div class="title">
        <h2>Mínimos</h2>
    </div>
    <table>
        <tr>
            <th>OS:</th>
            <td>Windows 10 (64-bit)</td>
        </tr>
        <tr>
            <th>Procesador:</th>
            <td>Intel Core i5-4670 (quad-core) / AMD FX-Series FX-4350 (quad-core)</td>
        </tr>
        <tr>
            <th>Memoria:</th>
            <td>8 GB RAM</td>
        </tr>
        <tr>
            <th>Gráfica:</th>
            <td>NVIDIA GeForce GTX 1050 (2 GB) / AMD Radeon RX-460 (4 GB)</td>
        </tr>
        <tr>
            <th>Almacenamiento:</th>
            <td>15GB</td>
        </tr>
        <tr>
            <th>DirectX:</th>
            <td>Version 12</td>
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
            <td>Windows 10 (64-bit)</td>
        </tr>
        <tr>
            <th>Procesador:</th>
            <td>Intel Core i5-4670 (quad-core) / AMD FX-Series FX-4350 (quad-core)</td>
        </tr>
        <tr>
            <th>Memoria:</th>
            <td>8 GB RAM</td>
        </tr>
        <tr>
            <th>Gráfica:</th>
            <td>NVIDIA GeForce GTX 1050 (2 GB) / AMD Radeon RX-460 (4 GB)</td>
        </tr>
        <tr>
            <th>Almacenamiento:</th>
            <td>15GB</td>
        </tr>
        <tr>
            <th>DirectX:</th>
            <td>Version 12</td>
        </tr>
    </table>
</div>
</template>

<style scoped lang="scss">

.requirements {
    width: 100%;
    display: flex;
    flex-direction: column;


    .title{
        width: 100%;
        border-bottom: 1px solid black;
        text-align: left;

    }
    table {
            border-collapse: collapse;
            width: 100%;
        }
        th, td {
            padding: 10px;
            text-align: left;
        }

}


@media screen and (min-width: 767px) {
    
}
</style>