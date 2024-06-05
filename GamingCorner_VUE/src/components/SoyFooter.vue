<script setup lang="ts">
/* import IconFacebook from './icons/IconFacebook.vue';
import IconInstagram from './icons/IconInstagram.vue';
import IconX from './icons/IconX.vue';
 */

</script>

<template>
    <footer class="footer">
        <div class="footer__links">
            <ul>
                <li><a href="">AVISO LEGAL</a></li>
                <li><a href="">POLITICA DE PRIVACIDAD</a></li>
                <li><a href="">POLITICA DE COOKIES</a></li>
            </ul>
        </div>
        <div class="footer__links">
            <div class="footer__title">
                <h2>GAMING CORNER</h2>
            </div>
            <div class="footer__media">
                
<!--                 <IconInstagram />
                <IconFacebook />
                <IconX /> -->

            </div>
        </div>
        <div class="footer__links">
            <ul>
                <li><a href="">BLOG</a></li>
                <li><a href="">CONTACTO</a></li>
                <li><a href="">FAQS</a></li>
            </ul>
        </div>
    </footer>
</template>

<style>
@import url("https://fonts.googleapis.com/css2?family=Bebas+Neue&display=swap");
.footer {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding-top: 25px;
  background-color: #ba1313;
  color: white;
  font-family: Arial, sans-serif;
  font-size: 14px;
}
.footer .footer__links {
  flex: 1;
  margin-bottom: 20px;
}
.footer .footer__links ul {
  list-style: none;
  padding: 0;
}
.footer .footer__links ul li {
  margin-bottom: 20px;
}
.footer .footer__links ul li a {
  font-family: "Bebas Neue";
  font-size: 24px;
  text-decoration: none;
  color: white;
}
.footer .footer__links .footer__title h2 {
  font-family: "Bebas Neue";
  font-size: 48px;
  text-decoration: underline;
  margin-bottom: 10px;
}
.footer .footer__links .footer__media {
  display: flex;
  flex-direction: row;
  justify-content: center;
}
.footer .footer__links .footer__media img {
  max-width: 7%;
  height: auto;
}
@media screen and (max-width: 767px) {
  .footer {
    font-size: 12px;
  }
  .footer .footer .footer__links .footer__media img {
    max-width: 20%;
    height: auto;
  }
}

/*# sourceMappingURL=footer.css.map */

</style>
