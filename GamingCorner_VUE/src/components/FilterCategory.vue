<script setup lang="ts">
var props = defineProps<{
  title: string

}>()

</script>

<template>
    <div class="category-container">
        <div class="category-name">
            {{ props.title }} 
        </div>
        <div v-if="$props.title == 'Género'" class="category-filters">
            filtros para genero

        </div>
        <div v-if="$props.title == 'Plataforma'" class="category-filters">
            filtros para plataform

        </div>
        <div v-if="$props.title == 'Sistema'" class="category-filters">
            filtros para Sistema

        </div>
        <div v-if="$props.title == 'Precio'" class="category-filters">
            filtros para Precio

        </div>
        <div v-if="$props.title == 'Mano'" class="category-filters">
            filtros para Mano

        </div>
        <div v-if="$props.title == 'Ordenar por'" class="category-filters">
            filtros para Ordenar 

        </div>
    </div>
</template>

<style scoped lang="scss">

.category-container {
    border: 1px solid red;
    width: 100%;
    height: calc(100%/6);
}

</style>