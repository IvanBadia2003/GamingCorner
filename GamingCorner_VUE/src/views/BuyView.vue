<script setup lang="ts">
import BuyInputs from '@/components/BuyInputs.vue';
import IconPaypal from '@/components/icons/IconPaypal.vue';
import IconVisa from '@/components/icons/IconVisa.vue';
import router from '@/router';
import { ref } from 'vue';
import { useCartStore } from '@/stores/CartStore';
import { useGameStore } from '@/stores/GameStore';
import { useProductStore } from '@/stores/ProductStore';
import { useConsoleStore } from '@/stores/ConsoleStore';
import { useTransactionStore } from '@/stores/TransactionStore';
import { useUserStore } from '@/stores/UserStore';
import { computed } from 'vue';

const userStore = useUserStore();
const cartStore = useCartStore();
const gameStore = useGameStore();
const productStore = useProductStore();
const consoleStore = useConsoleStore();
const transactionStore = useTransactionStore();



const totalPrice = computed(() => {
  const gameTotal = gameStore.cartItems.reduce((sum, item) => sum + item.price, 0);
  const consoleTotal = consoleStore.cartItems.reduce((sum, item) => sum + item.price, 0);
  const productTotal = productStore.cartItems.reduce((sum, item) => sum + item.price, 0);
  return gameTotal + consoleTotal + productTotal;
});
// Función de pago
async function payFunction() {
    const userId = userStore.user.userId;

    try {
        for (const product of gameStore.cartItems) {
            if (product.videogameId) {
                await transactionStore.purchaseGame(product.videogameId, userId);
            }
        }
        for (const product of productStore.cartItems) {
            if (product.productId) {
                await transactionStore.purchaseProduct(product.productId, userId);
            }
        }
        for (const product of consoleStore.cartItems) {
            if (product.consoleId) {
                await transactionStore.purchaseConsole(product.consoleId, userId);
            }
        }
        alert("Pago realizado con éxito");
    } catch (error) {
        console.error("Error al realizar el pago:", error);
        alert("Hubo un problema al procesar tu compra. Por favor, inténtalo de nuevo.");
    }
}

const isValidate = ref<boolean>(false);

const handleValidation = (isValid: boolean) => {
    isValidate.value = isValid;
    console.log('Validación en el padre:', isValid);
};

const opcionSeleccionada = ref('paypal');
</script>

<template>
    <div class="content">
        <div class="info">
            <div>
                <h2>Detalles de la Compra</h2>
            </div>
            <div>
                <h2>Productos Seleccionados</h2>
                <div style="display: flex;justify-content: center;gap: 30px;">
                    <div v-for="product in gameStore.cartItems" :key="product.videogameId" class="product">
                        <img :src="product.imageURL" :alt="product.name">
                    </div>
                    <div v-for="product in productStore.cartItems" :key="product.productId" class="product">
                        <img :src="product.imageURL" :alt="product.name">
                    </div>
                    <div v-for="product in consoleStore.cartItems" :key="product.consoleId" class="product">
                        <img :src="product.imageURL" :alt="product.name">
                    </div>
                </div>
            </div>
            <div>
                <h2>Importe Total</h2>
                <div>
                    <h3>{{ totalPrice }}€</h3>
                </div>
            </div>
        </div>

        <div class="pago">
            <div style="display: flex; align-items: center;">
                <input type="radio" id="paypal" name="opciones" value="paypal" checked v-model="opcionSeleccionada">
                <label for="paypal">
                    <IconPaypal />
                </label>
            </div>
            <div style="display: flex; align-items: center;">
                <input type="radio" id="visa" name="opciones" value="visa" v-model="opcionSeleccionada">
                <label for="visa">
                    <IconVisa />
                </label>
            </div>

            <div id="paypalFields" class="menu" v-if="opcionSeleccionada === 'paypal'">
                <BuyInputs titleInput="Correo Electrónico" classInput="email" typeInput="email"
                    placeholderInput="example@gmail.com" @validate="handleValidation" />
                <BuyInputs titleInput="Contraseña" classInput="password" typeInput="password"
                    placeholderInput="Contraseña123" @validate="handleValidation" />
            </div>

            <div id="visaFields" class="menu" v-else>
                <BuyInputs titleInput="Titular de la Tarjeta" classInput="text" typeInput="text"
                    placeholderInput="Nombre Apellido Apellido" @validate="handleValidation" />
                <BuyInputs titleInput="Número de Tarjeta" classInput="text" typeInput="text"
                    placeholderInput="XXXXXXXXXXXXXXXX" @validate="handleValidation" />
                <BuyInputs titleInput="Fecha de Caducidad" classInput="text" typeInput="text" placeholderInput="MM/AAAA"
                    @validate="handleValidation" />
                <BuyInputs titleInput="CVV" classInput="password" typeInput="password" placeholderInput="123"
                    @validate="handleValidation" />
            </div>
        </div>

        <div class="buttons">
            <RouterLink :to="'/'">CANCELAR</RouterLink>
            <button @click="payFunction" :disabled="!isValidate">PAGAR</button>
        </div>
    </div>
</template>

<style scoped lang="scss">
@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Bebas+Neue&display=swap');
@import url('https://fonts.googleapis.com/css?family=Merryweather');

$primaryColor: #ba1313;
$primaryFont: 'Bebas Neue';
$secondFont: 'Montserrat';
$thirdFont: 'Merryweather';

@mixin h2($fontSize) {
    padding: 0;
    margin-bottom: 0;
    font-family: $primaryFont;
    font-size: $fontSize;
    color: $primaryColor;
}

@mixin h3($fontSize) {
    margin-top: 0;
    margin-bottom: 5%;
    font-family: $secondFont;
    font-size: $fontSize;
}

@mixin button() {
    text-decoration: none;
    font-weight: bold;
    border: 2px solid $primaryColor;
    border-radius: 50px;
    padding: 15px;
    margin: 30px;
    font-family: $secondFont;
    color: $primaryColor;
}

body {
    background-color: white;
    text-align: center;
    padding: 0;
    margin: 0;
}

.content {
    margin-top: 100px;
    width: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.info {
    width: 80%;
    margin: 20px;
    padding: 20px;
    border: 1px solid black;
    border-radius: 8px;
    background-color: #f9f9f9;

    h2 {
        @include h2(30px);
    }

    h3 {
        @include h3(18px);
    }
}

.pago {
    width: 80%;
    margin: 20px;
    padding: 20px;
    border: 1px solid black;
    border-radius: 8px;
    background-color: #f9f9f9;
    text-align: left;

    img{
        max-width: 30%;
    }

    .menu {
        margin-top: 20px;
    }
}

.buttons {
    margin-top: 20px;
    padding-bottom: 50px;

    button, a {
        @include button();
        cursor: pointer;
    }

    button:disabled {
        background-color: grey;
        border-color: grey;
        cursor: not-allowed;
    }
}

@media screen and (min-width: 767px) {
    .info {
        h2 {
            @include h2(36px);
        }

        h3 {
            @include h3(25px);
        }
    }

    .pago label img {
        width: 30%;
    }
}
</style>
