<script setup>
</script>

<template>
  <div class="item">
    <div class="content">
      <h2 class="name">ACCIÓN</h2>
      <div class="cover"></div>
    </div>
  </div>
</template>

<style scoped lang="scss">
.item {
  height: 200px;
  width: 100%;
  background-image: url('../../assets/ac-4-black-flag-herobanner.jpg');
  background-size: cover;
  position: relative;
  border-radius: 30px;

  .content {
    display: flex;
    align-items: center;
    justify-content: space-between;
    position: absolute;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    z-index: 1;

    .name {
      color: white;
      margin-left: 6%;
    }

    .cover {
      background-image: url('../../assets/Assassins-Creed-PNG.png');
      background-position: 100% 0;
      background-size: contain;
      background-repeat: no-repeat;
      position: absolute;
      top: -20px;
      bottom: 0;
      right: 0;
      left: 0;
      transition: 0.3s linear;
      transform-origin: bottom right;
    }

    .cover:hover {
      scale: 1.05;
    }
  }
}

.item::after {
  content: "";
  background: black;
  display: block;
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  opacity: 0.6;
  border-radius: 30px;
}
</style>
