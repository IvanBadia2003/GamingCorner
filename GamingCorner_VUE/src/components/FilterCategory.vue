<script setup lang="ts">
    import { useGenderStore } from '@/stores/GenderStore';
    import { useFilterStore } from '@/stores/FilterStore';
    import { ref } from 'vue';


var props = defineProps<{
  title: string

}>()

const GenderStore = useGenderStore();
const FilterStore = useFilterStore();

const genderSelected = ref('');
</script>

<template>
    <div class="category-container">
        <div class="category-name">
            {{ props.title }} 
        </div>
        <div v-if="$props.title == 'Género'" class="category-filters">
            filtros para {{title}}
            <select v-model="genderSelected" name="genders" id="genders">
                <option v-for="gender in GenderStore.genders">{{gender.name}}</option>
            </select>

        </div>
        <div v-if="$props.title == 'Plataforma'" class="category-filters">
            filtros para {{title}}

        </div>
        <div v-if="$props.title == 'Sistema'" class="category-filters">
            filtros para {{title}}

        </div>
        <div v-if="$props.title == 'Precio'" class="category-filters ">
            filtros para {{title}}

        </div>
        <div v-if="$props.title == 'Mano'" class="category-filters">
            filtros para {{title}}

        </div>
        <div v-if="$props.title == 'Ordenar por'" class="category-filters">
            filtros para {{title}} 

        </div>
    </div>
</template>

<style scoped lang="scss">

.category-container {
    border-bottom: 3px solid orange;
    width: 100%;
    height: auto;


    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;

    
    .category-name {
        height: 50px;
    }

    .category-filters {
        transition: .8s;
        height: 50px;
        &:hover {
            height: 100px;
        }
    }
    
    &:last-child {
        border-bottom: none;
    }


}

</style>