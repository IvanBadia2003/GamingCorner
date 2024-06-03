<script setup lang="ts">
// No se requiere ningún script específico para esta funcionalidad
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
                        <div class="valor">67.96€</div>
                    </div>
                </div>
                <router-link :to="'/'" class="buy__button">
                    PROCEDER CON EL PAGO
                </router-link>

            </div>
        </div>
    </div>
</template>

<style scoped lang="scss">
.summaryContainer {
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;

    .summary {
        width: 70%;
        height: auto;
        display: flex;
        flex-direction: column;

        &__title {
            text-align: left;
        }

        &__buy {
            margin-left: 15px;
            height: auto;
            width: 100%;
            display: flex;
            flex-direction: column;
            align-items: center;

            .buy__info {
                background-color: #3a7dd1;
                color: white;
                padding: 5px;
                border-radius: 10px;
                text-align: right;
                width: 100%;

                .fila {
                    display: flex;
                    justify-content: space-between;
                    margin-bottom: 10px;

                    .etiqueta {
                        font-weight: bold;
                    }

                    .valor {
                        text-align: right;
                    }

                    .descuento {
                        color: #ff7272;
                    }
                }

                .total {
                    font-size: 1.4em;
                    border-top: 1px solid white;
                    padding-top: 10px;
                }

            }

            .buy__button {
                margin-top: 15px;
                width: 100%;
                background-color: #3a7dd1;
                color: white;
                padding: 15px 0;
                border-radius: 10px;
                text-decoration: none;
            }
        }
    }
}
</style>
