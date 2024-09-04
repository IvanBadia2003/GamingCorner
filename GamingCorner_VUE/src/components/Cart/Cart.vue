<script setup lang="ts">
import IconSteam from '@/components/icons/platform/IconSteam.vue';
import IconDelete from '@/components/icons/IconDelete.vue';
import { useGameStore } from '@/stores/GameStore';
import { useConsoleStore } from '@/stores/ConsoleStore';
import { useProductStore } from '@/stores/ProductStore';
import { computed } from 'vue';

const gameStore = useGameStore();
const consoleStore = useConsoleStore();
const productStore = useProductStore();

const removeFromCart = (id: number, type: string) => {
  if (type === 'game') {
    gameStore.removeFromCart(id);
  } else if (type === 'console') {
    consoleStore.removeFromCart(id);
  } else if (type === 'product') {
    productStore.removeFromCart(id);
  }
};

const totalPrice = computed(() => {
  const gameTotal = gameStore.cartItems.reduce((sum, item) => sum + item.price, 0);
  const consoleTotal = consoleStore.cartItems.reduce((sum, item) => sum + item.price, 0);
  const productTotal = productStore.cartItems.reduce((sum, item) => sum + item.price, 0);
  return gameTotal + consoleTotal + productTotal;
});
</script>


<template>
  <div class="cartContainer">
    <div class="cart">
      <div class="cart__title">
        <h3>Carrito</h3>
      </div>
      <div class="cart__product">
        <div v-if="gameStore.cartItems.length > 0">
          <div v-for="product in gameStore.cartItems" :key="product.videogameId" class="product">
            <div class="product__img">
              <img :src="product.imageURL" :alt="product.name">
            </div>
            <div class="product__info">
              <div class="info__up">
                <div class="platform">
                  <IconSteam />
                </div>
                <div class="title">
                  <p>{{ product.name }}</p>
                </div>
                <div class="delete" @click="removeFromCart(product.videogameId, 'game')">
                  <IconDelete />
                </div>
              </div>
              <div class="info__down">
                <div class="price">
                  <h2>{{ product.price }}€</h2>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div v-if="consoleStore.cartItems.length > 0">
          <div v-for="product in consoleStore.cartItems" :key="product.consoleId" class="product">
            <div class="product__img">
              <img :src="product.imageURL" :alt="product.name">
            </div>
            <div class="product__info">
              <div class="info__up">
                <div class="platform">
                  <IconSteam />
                </div>
                <div class="title">
                  <p>{{ product.name }}</p>
                </div>
                <div class="delete" @click="removeFromCart(product.consoleId, 'console')">
                  <IconDelete />
                </div>
              </div>
              <div class="info__down">
                <div class="price">
                  <h2>{{ product.price }}€</h2>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div v-if="productStore.cartItems.length > 0">
          <div v-for="product in productStore.cartItems" :key="product.productId" class="product">
            <div class="product__img">
              <img :src="product.imageURL" :alt="product.name">
            </div>
            <div class="product__info">
              <div class="info__up">
                <div class="platform">
                  <IconSteam />
                </div>
                <div class="title">
                  <p>{{ product.name }}</p>
                </div>
                <div class="delete" @click="removeFromCart(product.productId, 'product')">
                  <IconDelete />
                </div>
              </div>
              <div class="info__down">
                <div class="price">
                  <h2>{{ product.price }}€</h2>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div v-else>
          <div class="empty-cart">
            No hay productos en el carrito
          </div>
        </div>
      </div>

      <div class="totalPrice">
        <h2>Total: {{ totalPrice }}€</h2>
      </div>
    </div>
  </div>
</template>





<style scoped lang="scss">
.cartContainer {
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 20px;
  background-color: #f5f5f5;
}

.cart {
  background-color: #ffffff;
  border-radius: 15px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  padding: 20px;
  width: 100%;
  max-width: 800px;
}

.cart__title {
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

.cart__product {
  .product {
    display: flex;
    align-items: center;
    padding: 15px 0;
    border-bottom: 1px solid #e0e0e0;

    &:last-child {
      border-bottom: none;
    }

    &__img {
      flex: 0 0 80px;

      img {
        width: 100%;
        border-radius: 10px;
        box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
      }
    }

    &__info {
      flex: 1;
      margin-left: 20px;
      display: flex;
      flex-direction: column;
      justify-content: space-between;

      .info__up {
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-bottom: 10px;

        img {
          max-width: 100%;
        }

        .platform {

          width: 30px;
          height: 30px;
          fill: #333333;

        }

        .title {
          flex: 1;
          margin-left: 15px;

          p {
            font-size: 18px;
            color: #555555;
            margin: 0;
            font-weight: 500;
          }
        }

        .delete {
          cursor: pointer;
          transition: transform 0.2s ease;
          width: 24px;
          height: 24px;
          fill: #ff4d4d;

          &:hover {
            transform: scale(1.1);
          }
        }
      }

      .info__down {
        display: flex;
        justify-content: space-between;
        align-items: center;

        .quantity {
          select {
            padding: 5px;
            border-radius: 5px;
            border: 1px solid #ccc;
            background-color: #fff;
            color: #333;
            font-size: 16px;

            &:focus {
              border-color: #888;
              outline: none;
            }
          }
        }

        .price {
          h2 {
            font-size: 20px;
            font-weight: bold;
            color: #333333;
            margin: 0;
          }
        }
      }
    }
  }

  .separation {
    height: 20px;
  }
}
</style>
