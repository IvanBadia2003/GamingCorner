<script setup lang="ts">

</script>

<template>
    <div class="container">
        <section class="section">

        </section>
        <section class="section">
            <div class="title-container">
                <h2>Requisitos</h2>
            </div>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Multimedia</h2>
            </div>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Descripción</h2>
            </div>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Opiniones</h2>
            </div>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Productos similares</h2>
            </div>
        </section>
        <section class="section">
            <div class="title-container">
                <h2>Consolas con las que puedes jugar</h2>
            </div>
        </section>
    </div>
</template>

<style scoped lang="scss">
    .container {
        width: 100%;
        height: auto;
        

        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;

        .section {
            width: 90%;
            height: 500px;

            margin: 20px;

            border: 1px solid black;

            .title-container{
                display: flex;

                border-bottom: 1px solid blue;
            }
        }

    }
</style>