<script setup lang="ts">
import { ref, onMounted } from 'vue';

const props = defineProps<{
  idGame: number,
  name: string,
  pegi: number,
  description: string,
  category: string,
  stock: number,
  available: boolean,
  platform: string,
  price: number,
  image: string
}>()


const isSelected = ref(false)


</script>


<template>
  <div class="cardContainer">
    <div class="slideSup" :class="{ 'viewSup': isSelected }" style="background-color: transparent;">
      <div class="btn-close" @click="isSelected = false">
        <i class="fa-solid fa-xmark"></i>
      </div>
    </div>
    <div class="center">
      <div class="prevImage" ref="prevImage">
        <img class="cardContainer" :src="image" alt="">
        <div class="btnImg" @click="isSelected = true"><i class="fa-solid fa-plus"></i></div>
      </div>
    </div>
    <div class="slideInf" :class="{ 'viewInf': isSelected }">
      <div class="text-menu">{{ name }}</div>
      <div class="btn-menu-cont">
        <RouterLink :to="{ name: 'description', params: { id: idGame } }">
          <div class="btn1">
            <i class="fa-solid fa-shopping-cart"></i>
          </div>
        </RouterLink>
        <div class="btn3" ref="btnLike"><i class="fa-regular fa-heart"></i></div>
      </div>
    </div>
  </div>

</template>


<style scoped lang="scss">



.cardContainer {
  position: relative;

  height: auto;
  width: 100%;
  height: auto;
  overflow: hidden;
  color: #333;


}



.center {
  position: relative;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 100%;
  height: 100%;

  display: flex;
  align-items: center;
  justify-content: center;
}


.prevImage {
  background-position: center;
  background-size: contain;
  display: flex;
  position: relative;
  height: 100%;
  width: 100%;

  &:hover .btnImg {
    transform: scale(1);
    opacity: 1;
    transition: 500ms;
  }

  &::before {
    content: "";
    position: absolute;
    width: 100%;
    height: 100%;
    background-color: #0000;
  }

  &:hover::before {
    background-color: #0005;
    transition: 500ms;
  }

  .btnImg {
    position: absolute;
    top: 50%;
    left: 35%;
    transform: translateX(-50%);
    transform: translateY(-50%);
    width: 40px;
    height: 40px;
    background-color: orange;
    border-radius: 50%;
    margin: auto;
    color: #fff;
    cursor: pointer;
    display: flex;
    transform: scale(1.5);
    opacity: 0;
    transition: 500ms;

    &:hover {
      color: #4876eb;
      background-color: #fff;
      transition: 500ms;
    }

    i {
      margin: auto;
      font-size: 15px;
    }
  }
}


.slideSup {
  width: 100%;
  height: 50%;
  background-color: #333;
  position: absolute;
  z-index: 10;
  display: flex;
  justify-content: center;
  align-items: flex-end;

  &.viewSup {
    top: 0;
    transition: 1s;
  }
}

.btn-close {
  width: 40px;
  height: 40px;
  background-color: orange;
  position: absolute;
  top: 10px;
  right: 10px;
  cursor: pointer;
  border-radius: 50%;
  color: #fff;
  display: flex;

  &:hover {
    background-color: #fff;
    color: #333;
    transition: 500ms;
  }

  i {
    margin: auto;
    font-size: 16px;
  }

  &.view-btnClose {
    animation-name: view-btnClose;
    animation-duration: 1500ms;
    animation-fill-mode: both;
  }
}

.img-menu {
  width: 120px;
  height: 120px;
  border-radius: 50%;
  box-shadow: 0 0 0 2px #fff;
  position: relative;
  top: 50px;

  &.view-imgMenu {
    animation-name: view-imgMenu;
    animation-duration: 1200ms;
    animation-fill-mode: both;
  }
}

.slideInf {
  width: 100%;
  height: 50%;
  background-color: orange;
  position: absolute;
  bottom: 0;
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;
  align-items: center;

  &.viewInf {
    bottom: 0;
    transition: 1s;
  }

  .text-menu {
    color: #fff;
    margin-top: 20px;
  }

  .btn-menu-cont {
    display: flex;
    gap: 40px;

    div {
      width: 40px;
      height: 40px;
      border-radius: 50%;
      border: 1px solid #fff;
      display: flex;
      color: #fff;
      cursor: pointer;

      &:hover {
        color: #4876eb;
        background-color: #fff;
        transition: 500ms;
      }

      i {
        margin: auto;
      }
    }
  }
}

.like {
  animation-name: like;
  animation-duration: 800ms;
  animation-fill-mode: backwards;
}

@keyframes like {
  10% {
    transform: rotateY(190deg);
  }

  50% {
    transform: rotateY(-180deg) scale(1.5);
  }

  90% {
    transform: rotateY(180deg);
  }
}

/* POR DEFECTO LOS SLIDE ESTARAN OCULTOS */
.slideSup {
  top: -70%;
  transition: 1s;
}

.slideInf {
  bottom: -50%;
  transition: 1s;
}

/* ANIMACIONES APERTURA Y CIERRE */

@keyframes view-btnClose {

  0%,
  50% {
    top: -80px;
  }

  100% {
    top: 10px;
  }
}

@keyframes view-imgMenu {

  0%,
  30% {
    top: -40px;
  }

  100% {
    top: 50px;
  }
}
</style>