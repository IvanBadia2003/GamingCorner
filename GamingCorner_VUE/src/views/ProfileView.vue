<script setup lang="ts">
import { ref } from 'vue';
import { useUserStore } from '@/stores/UserStore';
import Profile from '../components/Profile/Profile.vue';
import Sales from '../components/Profile/Sales.vue';
import Buys from '../components/Profile/Buys.vue';
import UploadProduct from '../components/Profile/UploadProduct.vue';

const UserStore = useUserStore();
UserStore.UserTransaction(UserStore.user.userId);

const toogleMenu = ref(false);
const activeTab = ref('profile');

const toggleMenu = () => {
  toogleMenu.value = !toogleMenu.value;
};
</script>

<template>
  <div class="todo">
    <nav>
      <ul>
        <li @click="activeTab = 'profile'; toogleMenu = false">Mi Perfil</li>
        <li @click="toggleMenu">
          Mis Productos
        </li>
        <ul v-if="toogleMenu" class="subboton subboton-open">
          <li @click="activeTab = 'buys'">Comprados</li>
          <li @click="activeTab = 'sales'">Vendidos</li>
          <li @click="activeTab = 'upload'">Vender</li>
        </ul>
      </ul>
      <button @click="UserStore.logout()">Desconectarse</button>
    </nav>
    <section class="content">
      <Profile v-if="activeTab == 'profile'" />
      <Buys v-if="activeTab == 'buys'"/>
      <Sales v-if="activeTab == 'sales'"/>
      <UploadProduct v-if="activeTab == 'upload'"/>
    </section>
</div>
</template>


<style scoped lang="scss">


.todo {
  margin-top: 100px;
  display: flex;
  height: auto;
}

nav {height: 85vh;
  min-width: 250px;
  background-color: #f8f9fa;
  display: flex;
  flex-direction: column;
  padding: 20px;
}

nav ul {
  list-style-type: none;
}

nav ul li {
  padding: 15px 20px;
  margin-bottom: 10px;
  color: #606060;
  cursor: pointer;
  border-left: 4px solid transparent;
  transition: all 0.3s;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

nav ul li:hover {
  color: #fcc728;
  border-left: 4px solid #fcc728;
}

.content{
  width: 100%;
  height: auto;
  display: flex;
  justify-content: center;
}

.subboton {
  list-style: none;
  padding-left: 20px;
  overflow: hidden;
  max-height: 0;
  transition: max-height 0.3s ease-in-out;
}

.subboton-open {
  max-height: 150px; /* Ajusta según la cantidad de elementos en el submenú */
}

.subboton li {
  padding: 10px;
  color: #606060;
  cursor: pointer;
  transition: color 0.3s;
}

.subboton li:hover {
  color: #fcc728;
}

button {
  margin-top: auto;
  padding: 10px 15px;
  background-color: #fcc728;
  color: white;
  border: none;
  cursor: pointer;
  transition: background-color 0.3s;
}

button:hover {
  background-color: #c0392b;
}

.product-grid{
  background-color: #fff;
}
</style>
