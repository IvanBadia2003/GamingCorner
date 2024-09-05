<script setup lang="ts">
import { useGenderStore } from '@/stores/GenderStore';
import { useFilterStore } from '@/stores/FilterStore';
import { useGameStore } from '@/stores/GameStore';
import { usePlatformStore } from '@/stores/PlatformStore';
import { ref } from 'vue';

const props = defineProps<{ title: string }>();

const GenderStore = useGenderStore();
const FilterStore = useFilterStore();
const GameStore = useGameStore();
const PlatformStore = usePlatformStore();

const genderSelected = ref(0);
const platformSelected = ref(0);

// Función para filtro 'Ordenar Por'
const selectedOption = ref<string>('');
const handleFilterChange = () => {
    if (props.title === 'Ordenar por') {
        FilterStore.setSortOption(selectedOption.value);
    }
};
const selectedPriceRange = ref(0);

// Función para manejar el filtro de precios
const handlePriceFilterChange = () => {
    FilterStore.setPriceRange(Number(selectedPriceRange.value)); // Actualiza el rango de precios en el FilterStore
};

// Nueva función para manejar la entrada de la búsqueda
const handleSearchInput = (event: Event) => {
    const target = event.target as HTMLInputElement;
    FilterStore.setSearchTerm(target.value);
};

</script>

<template>
    <div class="category-container">
        <div class="category-name">{{ props.title }}</div>
        <div v-if="$props.title == 'Género'" class="category-filters">
            <select v-model="genderSelected" name="genders" id="genders" class="custom-select"
                @change="GameStore.filterGamesByGenre(genderSelected)">
                <option value="0">Selecciona una opción...</option>
                <option v-for="gender in GenderStore.genders" :key="gender.genderId" :value="gender.genderId">{{
                    gender.name }}</option>
            </select>
        </div>
        <div v-if="$props.title == 'Plataforma'" class="category-filters">
            <select v-model="platformSelected" name="genders" id="genders" class="custom-select"
                @change="GameStore.filterGamesByPlatform(platformSelected)">
                <option value="0">Selecciona una opción...</option>
                <option v-for="platform in PlatformStore.paltforms" :key="platform.platformId"
                    :value="platform.platformId">{{ platform.name }}</option>
            </select>
        </div>
        <div v-if="$props.title == 'Precio'" class="category-filters">
            <select v-model="selectedPriceRange" @change="handlePriceFilterChange" class="custom-select">
                <option value="0">Selecciona una opción...</option>
                <option value="20">Hasta 20€</option>
                <option value="50">Hasta 50€</option>
                <option value="150">Hasta 150€</option>
                <option value="300">Hasta 300€</option>
            </select>
        </div>

        <div v-if="props.title === 'Ordenar por'" class="category-filters">
            <select v-model="selectedOption" @change="handleFilterChange" class="custom-select">
                <option value="">Selecciona una opción...</option>
                <option value="price-asc">Precio: Menor a Mayor</option>
                <option value="price-desc">Precio: Mayor a Menor</option>
            </select>
        </div>
        <div class="category-filters" v-if="props.title === 'Buscar'">
            <input type="text" placeholder="Buscar..." @input="handleSearchInput" class="custom-select" />
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
    a{
    font-family: 'Montserrat';
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
