<script setup lang="ts">

import { useCartStore } from '@/stores/CartStore';

const cartStore = useCartStore();


</script>

<template>
    <div class="summaryContainer">
        <div class="summary">
            <div class="summary__title">
                <h3>Resumen</h3>
            </div>
            <div class="summary__buy">
                <div class="buy__info">
                    <div class="fila">
                        <div class="etiqueta">Precio oficial</div>
                        <div class="valor">149.96€</div>
                    </div>
                    <div class="fila">
                        <div class="etiqueta">Descuento</div>
                        <div class="valor descuento">-82.54€</div>
                    </div>
                    <div class="fila total">
                        <div class="etiqueta">Total</div>
                        <div class="valor">{{ cartStore.totalPrice }}</div>
                    </div>
                </div>
                <router-link :to="'/purchase'" class="buy__button">
                    PROCEDER CON EL PAGO
                </router-link>
            </div>
        </div>
    </div>
</template>

<style scoped lang="scss">
.summaryContainer {
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 20px;
    background-color: #f9f9f9;
}

.summary {
    background-color: #ffffff;
    border-radius: 15px;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
    padding: 20px;
    width: 100%;
    max-width: 400px;
}

.summary__title {
    border-bottom: 1px solid #e0e0e0;
    padding-bottom: 10px;
    margin-bottom: 20px;

    h3 {
        font-size: 24px;
        font-weight: bold;
        color: #333333;
        margin: 0;
    }
}

.summary__buy {
    .buy__info {
        .fila {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 10px 0;
            border-bottom: 1px solid #e0e0e0;

            &:last-child {
                border-bottom: none;
            }

            &.total {
                font-weight: bold;
                font-size: 18px;
            }

            .etiqueta {
                font-size: 16px;
                color: #555555;
            }

            .valor {
                font-size: 16px;
                color: #333333;

                &.descuento {
                    color: #ff4d4d;
                }
            }
        }
    }

    .buy__button {
        display: block;
        text-align: center;
        margin-top: 20px;
        padding: 10px 0;
        background-color: #ff6600;
        color: #ffffff;
        font-size: 16px;
        font-weight: bold;
        border-radius: 10px;
        text-decoration: none;
        transition: background-color 0.3s ease;

        &:hover {
            background-color: #e65c00;
        }
    }
}
</style>
