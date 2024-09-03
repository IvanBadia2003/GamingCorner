<script setup lang="ts">
import { useGameStore } from '@/stores/GameStore';

defineProps<{
    product: string;
}>()
</script>

<template>
    <div class="requirementsDiv">
         <div class="requirements maximum">
            <table>
                <tr>
                    {{ product }}
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