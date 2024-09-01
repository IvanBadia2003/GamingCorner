<script setup lang="ts">
import { useGenderStore } from '@/stores/GenderStore';
import { useFilterStore } from '@/stores/FilterStore';
import { ref } from 'vue';

const props = defineProps<{ title: string }>();

const GenderStore = useGenderStore();
const FilterStore = useFilterStore();

const genderSelected = ref('');

// Función para filtro 'Ordenar Por'
const selectedOption = ref<string>('');
const handleFilterChange = () => {
    if (props.title === 'Ordenar por') {
        FilterStore.setSortOption(selectedOption.value);
    }
};
</script>

<template>
    <div class="category-container">
        <div class="category-name">{{ props.title }}</div>
        <div v-if="$props.title == 'Género'" class="category-filters">
            <select v-model="genderSelected" name="genders" id="genders" class="custom-select">
                <option v-for="gender in GenderStore.genders" :key="gender.genderId">{{ gender.name }}</option>
            </select>
        </div>
        <div v-if="$props.title == 'Sistema'" class="category-filters">
            <select v-model="genderSelected" name="genders" id="genders" class="custom-select">
                <option v-for="gender in GenderStore.genders" :key="gender.genderId">{{ gender.name }}</option>
            </select>
        </div>
        <div v-if="$props.title == 'Precio'" class="category-filters">
            <select v-model="genderSelected" name="genders" id="genders" class="custom-select">
                <option v-for="gender in GenderStore.genders" :key="gender.genderId">{{ gender.name }}</option>
            </select>
        </div>
        <div v-if="$props.title == 'Producto'" class="category-filters">
            <select v-model="genderSelected" name="genders" id="genders" class="custom-select">
                <option>Consola</option>
                <option>Juego</option>
            </select>
        </div>
        <div v-if="props.title === 'Ordenar por'" class="category-filters">
            <select v-model="selectedOption" @change="handleFilterChange" class="custom-select">
                <option value="price-asc">Precio: Menor a Mayor</option>
                <option value="price-desc">Precio: Mayor a Menor</option>
            </select>
        </div>
    </div>
</template>

<style scoped lang="scss">
.category-container {
    width: 100%;
    padding: 16px 0;
    border-bottom: 1px solid #e0e0e0;
    display: flex;
    flex-direction: column;
    align-items: center;

    &:last-child {
        border-bottom: none;
    }

    .category-name {
        font-size: 1.2rem;
        font-weight: 600;
        margin-bottom: 8px;
        color: #333;
    }

    .category-filters {
        width: 100%;
        display: flex;
        flex-direction: column;
        align-items: center;

        .custom-select {
            width: 90%;
            padding: 8px 12px;
            border: 1px solid #ccc;
            border-radius: 8px;
            background-color: #fff;
            font-size: 1rem;
            color: #333;
            appearance: none;
            transition: border-color 0.3s ease;

            option {
                padding: 8px;
                background-color: #fff;
                color: #333;
            }

            &:hover,
            &:focus {
                border-color: #f77f00;
            }
        }
    }
}
</style>
