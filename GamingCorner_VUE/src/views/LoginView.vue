<script setup lang="ts">
import { useUserStore } from '@/stores/UserStore';
import { computed, ref } from 'vue';


const userStore = useUserStore();
const emailLogin = ref('');
const passwordLogin = ref('');

const emailRegister = ref('');
const nameRegister = ref('');
const passwordRegister = ref('');
const phoneNumberRegister = ref('');

</script>

<template>
  <div class="content">
    <div class="container">
      <div class="form-container">
        <h2>Iniciar Sesión</h2>
        <form @submit.prevent="userStore.login(emailLogin, passwordLogin)">
          <div class="campo">
            <label for="email">Email</label>
            <input type="email" id="email" v-model="emailLogin" required>
          </div>

          <div class="campo">
            <label for="password">Contraseña</label>
            <input type="password" id="password" v-model="passwordLogin" required>
          </div>

          <button type="submit">Registrarse</button>
        </form>
      </div>

      <div class="separation">

      </div>

      <div class="form-container">
        <h2>Iniciar Sesión</h2>
        <form class="signin-form" @submit.prevent="userStore.register(nameRegister, emailRegister, passwordRegister, phoneNumberRegister)">
          <div class="campo">
            <label for="email">Email</label>
            <input type="email" id="email" v-model="emailRegister" required>
          </div>

          <div class="campo">
            <label for="name">Nombre</label>
            <input type="text" id="name" v-model="nameRegister" required>
          </div>

          <div class="campo">
            <label for="phone">Teléfono</label>
            <input type="text" id="phone" v-model="phoneNumberRegister">
          </div>

          <div class="campo">
            <label for="password">Contraseña</label>
            <input type="password" id="password" v-model="passwordRegister" required>
          </div>

          <div class="campo">
            <label for="repeatPassword">Repetir contraseña</label>
            <input type="password" id="repeatPassword" required>
          </div>

          <button type="submit">Registrarse</button>
        </form>
      </div>
    </div>

  </div>
</template>



<style scoped lang="scss">
.content {
  width: 100%;
  text-align: start;
  .container {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin: 50px;
    
    .form-container {
      width: 100%;
      max-width: 400px;
      margin-bottom: 20px;
      padding: 20px;
      border: 1px solid #ccc;
      border-radius: 5px;
  
      h2 {
        font-size: 1.5rem;
        margin-bottom: 20px;
        text-align: center;
      }
  
      form {
        display: flex;
        flex-direction: column;
  
        .campo {
          margin-bottom: 15px;
          max-width: 90%;
          position: relative;
  
          label {
            font-weight: bold;
            margin-bottom: 5px;
          }
  
          input[type='email'],
          input[type='password'],
          input[type='text'],
          input[type='number'] {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 1rem;
          }
        }
  
        button[type='submit'] {
          width: 100%;
          padding: 10px;
          border: none;
          border-radius: 5px;
          background-color: #007bff;
          color: #fff;
          font-size: 1rem;
          cursor: pointer;
          transition: background-color 0.3s;
  
          &:hover {
            background-color: #0056b3;
          }
        }
      }
    }
  }



}

</style>