<!-- views/Profile.vue -->
<script setup lang="ts">
import { ref } from 'vue';
import { useUserStore } from '@/stores/UserStore';
import MyProducts from '../components/Profile/MyProducts.vue';
import Profile from '../components/Profile/Profile.vue';

const UserStore = useUserStore();


const activeTab = ref('games');

</script>

<template>

    <div class="todo">

      <nav>
        <ul>
          <li @click="activeTab='profile'">Mi Perfil</li>
          <li @click="activeTab='products'">Mis Productos<i class="fas fa-chevron-right flecha"></i></li>
          <ul class="subboton">
            <li>Comprados</li>
            <li>Vendidos</li>
          </ul>
        </ul>

        <button @click="UserStore.logout()">Desconectarse</button>
      </nav>

      <Profile v-if="activeTab == 'profile'"/>
      <MyProducts v-if="activeTab == 'products'"/>

      

    </div>

</template>

<style scoped>
* {
  padding: 0px;
  margin: 0px;
  font-family: 'Muli', sans-serif;
}

.todo {
  display: flex;
  flex-wrap: nowrap;
}



nav {
  display: flex;
  min-width: 30%;
  overflow: hidden;
  flex-direction: column;
  height: 83vh;
  border-right: solid 1px #d1d1d1;
  box-shadow: 2px 1px 15px rgba(0, 0, 0, 0.1);
  z-index: 10;
}




.todo nav ul li {
  padding: 20px;
  margin-bottom: 6px;
  color: #606060;
  border-left: solid 4px rgba(0, 0, 0, 0.1);
  margin-left: 4px;
  cursor: pointer;
  transition: all 0.3s;
}

.todo nav ul li:hover {
  border-left: solid 4px #fcc728;
  color: #fcc728;
}

.todo nav ul li:hover+.subboton {
  transition: height 0.3s;
  height: 150px;
}

.todo nav ul li:hover .flecha {
  transform: rotate(90deg);
  color: #fcc728;
}

.flecha {
  float: right;
  transition: all 0.3s;
}

.subboton {
  padding: 0px;
  margin-left: 5px;
  list-style: none;
  height: 0px;
  overflow: hidden;
  transition: all 0.3s;
  max-height: 100%;
}

.subboton:hover {
  height: 60px;
}




</style>