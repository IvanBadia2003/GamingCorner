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
        <form v-if="showLogin" class="formulario__login">
          <h2>Iniciar Sesión</h2>
          <input type="text" placeholder="Correo Electrónico" />
          <input type="password" placeholder="Contraseña" />
          <button>Entrar</button>
        </form>
        <form v-if="showRegister" class="formulario__register">
          <h2>Registrarse</h2>
          <input type="text" placeholder="Nombre completo" />
          <input type="text" placeholder="Correo Electrónico" />
          <input type="text" placeholder="Usuario" />
          <input type="password" placeholder="Contraseña" />
          <button>Registrarse</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { ref, onMounted, defineComponent } from 'vue';

export default defineComponent({
  setup() {
    const showLogin = ref(true);
    const showRegister = ref(true);
    const containerLeft = ref('0px');

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

    onMounted(() => {
      anchoPage();
      window.addEventListener('resize', anchoPage);
    });

    return {
      showLogin,
      showRegister,
      containerLeft,
      iniciarSesion,
      register,
    };
  },
});
</script>

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
