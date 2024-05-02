<script setup lang="ts">

</script>

<template>

    <div>

    </div>

</template>

<style scoped>
div {
    width: 100%;
    height: 130px;
    background-color: red;
    position: fixed;
    animation: contract both;
    animation-timeline: scroll(root);
    animation-range: 0 200px;
}

@keyframes contract {
    to {
        background-color: rgba(255, 255, 255, .4);
        height: 75px;
        backdrop-filter: blur(9px);

    }
}

</style>