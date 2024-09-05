<script setup lang="ts">
import { ref, reactive, onMounted, onUnmounted } from 'vue';
import { useUserStore } from '@/stores/UserStore';

const UserStore = useUserStore();
const showLogin = ref(true);
const showRegister = ref(true);
const containerLeft = ref('0px');

interface createUser {
    name: string;
    address: string;
    email: string;
    password: string;
    phoneNumber: string;
    admin: boolean;
}
const user = reactive<createUser>({
    name: '',
    address: '',
    email: '',
    password: '',
    phoneNumber: '',
    admin: true,
});

const repeatPassword = ref('');

// Validaciones
const errorsLogin = ref<{ email: string; password: string }>({ email: '', password: '' });
const errorsRegister = ref<{ name: string; email: string; phoneNumber: string; password: string; address: string; repeatPassword: string }>({
  name: '',
  email: '',
  phoneNumber: '',
  password: '',
  address: '',
  repeatPassword: ''
});

// Función para validar un email
const validateEmail = (email: string): boolean => {
  const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return re.test(email);
};

// Validar formulario de login
const validateLogin = (): boolean => {
  errorsLogin.value.email = '';
  errorsLogin.value.password = '';

  if (!UserStore.user.email) {
    errorsLogin.value.email = 'El correo es obligatorio';
  } else if (!validateEmail(UserStore.user.email)) {
    errorsLogin.value.email = 'El correo no es válido';
  }

  if (!UserStore.user.password) {
    errorsLogin.value.password = 'La contraseña es obligatoria';
  }

  return !errorsLogin.value.email && !errorsLogin.value.password;
};

// Validar formulario de registro
const validateRegister = (): boolean => {
  errorsRegister.value.name = '';
  errorsRegister.value.email = '';
  errorsRegister.value.phoneNumber = '';
  errorsRegister.value.password = '';
  errorsRegister.value.address = '';
  errorsRegister.value.repeatPassword = '';

  if (!user.name) {
    errorsRegister.value.name = 'El nombre es obligatorio';
  }

  if (!user.email) {
    errorsRegister.value.email = 'El correo es obligatorio';
  } else if (!validateEmail(user.email)) {
    errorsRegister.value.email = 'El correo no es válido';
  }

  if (!user.phoneNumber) {
    errorsRegister.value.phoneNumber = 'El teléfono es obligatorio';
  }

  if (!user.address) {
    errorsRegister.value.address = 'La dirección es obligatoria';
  }

  if (!user.password) {
    errorsRegister.value.password = 'La contraseña es obligatoria';
  } else if (user.password.length < 6) {
    errorsRegister.value.password = 'La contraseña debe tener al menos 6 caracteres';
  }

  if (!repeatPassword.value) {
    errorsRegister.value.repeatPassword = 'Debes repetir la contraseña';
  } else if (repeatPassword.value !== user.password) {
    errorsRegister.value.repeatPassword = 'Las contraseñas no coinciden';
  }

  return (
    !errorsRegister.value.name &&
    !errorsRegister.value.email &&
    !errorsRegister.value.phoneNumber &&
    !errorsRegister.value.address &&
    !errorsRegister.value.password &&
    !errorsRegister.value.repeatPassword
  );
};

// Funciones para manejar el ancho de la página y mostrar formularios
const anchoPage = () => {
  if (window.innerWidth > 1050) {
    showLogin.value = true;
    showRegister.value = false;
  } else {
    showLogin.value = false;
    showRegister.value = false;
    containerLeft.value = '0px';
  }
};

const iniciarSesion = () => {
  showLogin.value = true;
  showRegister.value = false;
  containerLeft.value = window.innerWidth > 850 ? '10px' : '0px';
};

const register = () => {
  showLogin.value = false;
  showRegister.value = true;
  containerLeft.value = window.innerWidth > 850 ? '410px' : '0px';
};

// Escuchar cambios de tamaño de ventana
onMounted(() => {
  anchoPage();
  window.addEventListener('resize', anchoPage);
});

onUnmounted(() => {
  window.removeEventListener('resize', anchoPage);
});

// Submit del formulario de login
const submitLogin = () => {
  if (validateLogin()) {
    UserStore.login(UserStore.user.email, UserStore.user.password);
  }
};

// Submit del formulario de registro
const submitRegister = () => {
  if (validateRegister()) {
    UserStore.register(user);
  }
};
</script>

<template>
  <div class="container">
    <div class="image-section">
      <img src="@/assets/loginIMG.png" alt="imagen de fondo" />
    </div>
    <div class="contenedor__todo">
      <div class="caja__trasera">
        <div class="caja__trasera-login">
          <h3>¿Ya tienes una cuenta?</h3>
          <p>Inicia sesión para entrar en la página</p>
          <button @click="iniciarSesion">Iniciar Sesión</button>
        </div>
        <div class="caja__trasera-register">
          <h3>¿Aún no tienes una cuenta?</h3>
          <p>Regístrate para que puedas iniciar sesión</p>
          <button @click="register">Registrarse</button>
        </div>
      </div>
      <div class="contenedor__login-register" :style="{ left: containerLeft }">
        <!-- Formulario de login -->
        <form v-if="showLogin" class="formulario__login" @submit.prevent="submitLogin">
          <h2>Iniciar Sesión</h2>
          <input type="text" placeholder="Correo Electrónico" v-model="UserStore.user.email" />
          <span v-if="errorsLogin.email" class="error-message">{{ errorsLogin.email }}</span>
          <input type="password" placeholder="Contraseña" v-model="UserStore.user.password"/>
          <span v-if="errorsLogin.password" class="error-message">{{ errorsLogin.password }}</span>
          <button>Entrar</button>
        </form>

        <!-- Formulario de registro -->
        <form v-if="showRegister" class="formulario__register" @submit.prevent="submitRegister">
          <h2>Registrarse</h2>
          <input type="text" placeholder="Nombre completo" v-model="user.name" />
          <span v-if="errorsRegister.name" class="error-message">{{ errorsRegister.name }}</span>
          <input type="text" placeholder="Correo Electrónico" v-model="user.email" />
          <span v-if="errorsRegister.email" class="error-message">{{ errorsRegister.email }}</span>
          <input type="text" placeholder="Teléfono" v-model="user.phoneNumber" />
          <span v-if="errorsRegister.phoneNumber" class="error-message">{{ errorsRegister.phoneNumber }}</span>
          <input type="text" placeholder="Dirección" v-model="user.address"/>
          <span v-if="errorsRegister.address" class="error-message">{{ errorsRegister.address }}</span>
          <input type="password" placeholder="Contraseña" v-model="user.password"/>
          <span v-if="errorsRegister.password" class="error-message">{{ errorsRegister.password }}</span>
          <input type="password" placeholder="Repetir Contraseña" v-model="repeatPassword"/>
          <span v-if="errorsRegister.repeatPassword" class="error-message">{{ errorsRegister.repeatPassword }}</span>
          <button>Registrarse</button>
        </form>
      </div>
    </div>
  </div>
</template>

<style scoped>
.error-message {
  color: red;
  font-size: 0.8em;
  margin-top: 5px;
}
</style>



<style scoped lang="scss">
.container {
  display: flex;
  height: 100vh;

  .image-section {
    width: 50%;
    display: flex;
    justify-content: center;
    align-items: center;

    img {
      width: 80%;
      mask-image: linear-gradient(black 80%, transparent);
    }
  }

  .contenedor__todo {
    width: 100%;
    max-width: 800px;
    margin: auto;
    position: relative;
  }

  .caja__trasera {
    width: 100%;
    padding: 10px 20px;
    display: flex;
    justify-content: center;
    -webkit-backdrop-filter: blur(10px);
    backdrop-filter: blur(10px);
    background-color: rgba(255, 158, 12, 0.877);
  }

  .caja__trasera div {
    margin: 100px 40px;
    color: white;
    transition: all 500ms;
  }

  .caja__trasera div p,
  .caja__trasera button {
    margin-top: 30px;
  }

  .caja__trasera div h3 {
    font-weight: 400;
    font-size: 26px;
  }

  .caja__trasera div p {
    font-size: 16px;
    font-weight: 300;
  }

  .caja__trasera button {
    padding: 10px 40px;
    border: 2px solid #fff;
    font-size: 14px;
    background: transparent;
    font-weight: 600;
    cursor: pointer;
    color: white;
    outline: none;
    transition: all 300ms;
  }

  .caja__trasera button:hover {
    background: #fff;
    color: rgba(255, 158, 12, 0.877);
  }

  .contenedor__login-register {
    display: flex;
    align-items: center;
    justify-content: center;
    width: 100%;
    max-width: 380px;
    position: relative;
    top: -185px;
    left: 10px;
    transition: left 500ms cubic-bezier(0.175, 0.885, 0.32, 1.275);
  }

  .contenedor__login-register form {
    width: 100%;
    padding: 80px 20px;
    background: white;
    position: absolute;
    border-radius: 20px;
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  .contenedor__login-register form h2 {
    font-size: 30px;
    text-align: center;
    margin-bottom: 20px;
    color: rgba(255, 158, 12, 0.877);
  }

  .contenedor__login-register form input {
    width: 100%;
    margin-top: 20px;
    padding: 10px;
    border: none;
    background: #f2f2f2;
    font-size: 16px;
    outline: none;
  }

  .contenedor__login-register form button {
    padding: 10px 40px;
    margin-top: 40px;
    border: none;
    font-size: 14px;
    background: rgba(255, 158, 12, 0.877);
    font-weight: 600;
    cursor: pointer;
    color: white;
    outline: none;
  }

  .formulario__login {
    opacity: 1;
    display: block;
    top: -240px;

  }

  .error-message {
  color: red;
  font-size: 0.8em;
  margin-top: 5px;
}


  @media screen and (max-width: 950px) {
    main {
      margin-top: 50px;
    }

    .caja__trasera {
      max-width: 350px;
      height: 300px;
      flex-direction: column;
      margin: auto;
    }

    .caja__trasera div {
      margin: 0px;
      position: absolute;
    }

    .contenedor__login-register {
      top: -10px;
      left: -5px;
      margin: auto;
    }

    .contenedor__login-register form {
      position: relative;
    }
  }

  @media screen and (max-width: 1250px) {
    .image-section {
      display: none;
    }

  }


}
</style>
