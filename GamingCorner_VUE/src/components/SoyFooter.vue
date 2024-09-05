<script setup lang="ts">
import IconLogo from './icons/IconLogo.vue';


</script>

<template>
  <footer class="footer">
    <div class="container">
      <div class="footer-content">
        <div class="footer-section">
          <h4>Acerca de Nosotros</h4>
          <IconLogo class="logo"/>
        </div>
        <div class="footer-section">
          <h4>Enlaces Útiles</h4>
          <ul>
            <li><a href="#">Inicio</a></li>
            <li><a href="#">Servicios</a></li>
            <li><a href="#">Contacto</a></li>
            <li><a href="#">Política de Privacidad</a></li>
          </ul>
        </div>
        <div class="footer-section">
          <h4>Contacto</h4>
          <p>Dirección: C/ Violeta Parra, 9</p>
          <p>Teléfono: +34 976451200</p>
          <p>Email: info@gamingcorner.com</p>
        </div>
      </div>
    </div>
  </footer>
</template>



<style lang="scss" scoped>
.footer {
  background-color: orange;
  color: #fff;
  padding: 20px 0;

  .container {
    display: flex;
    flex-wrap: wrap;
    justify-content: space-between;
    align-items: flex-start;
  }

  .footer-content {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    flex-wrap: wrap;
    width: 100%;

    .footer-section {
      flex: 1;
      min-width: 200px;
      margin: 10px 20px;

      .logo{
        width: 20%;
      }

      h4 {
        margin-bottom: 20px;
        font-size: 1.2rem;
      }

      p, ul, li {
        font-size: 0.9rem;
      }

      ul {
        list-style: none;
        padding: 0;

        li {
          margin-bottom: 5px;

          a {
            color: #fff;
            text-decoration: none;

            &:hover {
              text-decoration: underline;
            }
          }
        }
      }
    }
  }
}

@media (max-width: 768px) {
  .footer {
    .container {
      flex-direction: column;
      align-items: center;
    }

    .footer-content {
      flex-direction: column;
      align-items: center;

      .footer-section {
        margin: 20px 0;
      }
    }
  }
}

</style>
