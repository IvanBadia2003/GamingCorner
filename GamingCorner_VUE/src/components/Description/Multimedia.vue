<script setup lang="ts">
import { useGameStore } from '@/stores/GameStore';

const gameStore = useGameStore();


</script>

<template>
<iframe width="280" height="158" src="https://www.youtube.com/embed/TVY5z_JbI9I?si=u1CLZO2mzefU6Jko" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>
<img src="https://gaming-cdn.com/images/products/14483/screenshot/little-kitty-big-city-pc-juego-steam-wallpaper-1-big.jpg?v=1715769211" alt="">
<img src="https://gaming-cdn.com/images/products/14483/screenshot/little-kitty-big-city-pc-juego-steam-wallpaper-2-thumbv2.jpg?v=1715769211" alt="">
<img src="https://gaming-cdn.com/images/products/14483/screenshot/little-kitty-big-city-pc-juego-steam-wallpaper-4-thumbv2.jpg?v=1715769211" alt="">
</template>

<style scoped lang="scss">

img{
    max-width: 280px;
}

@media screen and (min-width: 767px) {
    
}
</style>