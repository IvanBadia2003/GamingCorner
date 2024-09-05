<script setup lang="ts">
import { reactive, ref } from 'vue';
import { useGameStore } from '@/stores/GameStore';
import { useGenderStore } from '@/stores/GenderStore';
import { usePlatformStore } from '@/stores/PlatformStore';

const GameStore = useGameStore();
const GenderStore = useGenderStore();
const PlatformStore = usePlatformStore();

interface createGame {
    name: string,
    pegi: number,
    code: string,
    description: string,
    requisitos1: string,
    requisitos2: string,
    stock: number,
    available: boolean,
    price: number,
    platformId: number,
    genderId: number,
    imageURL: string
}

// Inicializo un juego
const game = reactive<createGame>({
    name: '',
    pegi: 0,
    code: '',
    description: '',
    requisitos1: '',
    requisitos2: '',
    stock: 0,
    available: true,
    price: 0,
    platformId: 0,
    genderId: 0,
    imageURL: ''
});

// Variables para almacenar mensajes de error
const titleError = ref('');
const descriptionError = ref('');
const requirements1Error = ref('');
const requirements2Error = ref('');
const genderError = ref('');
const priceError = ref('');
const pegiError = ref('');
const stockError = ref('');
const platformError = ref('');

// Función para validar el título
const validateName = () => {
    titleError.value = game.name.trim() ? '' : 'El título es obligatorio';
};

// Función para validar el pegi
const validatePegi = () => {
    pegiError.value = (game.pegi >= 0) ? '' : 'El Pegi debe ser un número positivo';
};

// Función para validar la descripción
const validateDescription = () => {
    descriptionError.value = game.description.trim() ? '' : 'La descripción es obligatoria';
};

// Función para validar los requisitos mínimos
const validateRequerements = () => {
    requirements1Error.value = game.requisitos1.trim() ? '' : 'Los requisitos mínimos son obligatorios';
};

// Función para validar los requisitos mínimos
const validateRequerements2 = () => {
    requirements2Error.value = game.requisitos2.trim() ? '' : 'Los requisitos recomendados son obligatorios';
};

// Función para validar el género
const validateGender = () => {
    genderError.value = (game.genderId > 0) ? '' : 'El género es obligatorio';
};

// Función para validar el stock
const validateStock = () => {
    stockError.value = (game.stock >= 0) ? '' : 'El stock debe ser un número positivo';
};

// Función para validar la plataforma
const validatePlatform = () => {
    platformError.value = (game.platformId > 0) ? '' : 'La plataforma es obligatoria';
};

// Función para validar el precio
const validatePrice = () => {
    priceError.value = (game.price >= 0) ? '' : 'El precio debe ser un número positivo';
};

const submitForm = async () => {
    // Realizar validaciones
    validateName();
    validatePegi();
    validateDescription();
    validateGender();
    validateStock();
    validatePlatform();
    validatePrice();
    validateRequerements();
    validateRequerements2();

    // Verificar si hay errores antes de enviar el formulario
    if (titleError.value || descriptionError.value || genderError.value || priceError.value || pegiError.value || stockError.value || platformError.value || requirements1Error.value || requirements2Error.value) {
        console.log('Errores en el formulario:', {
            titleError: titleError.value,
            descriptionError: descriptionError.value,
            genderError: genderError.value,
            priceError: priceError.value,
            pegiError: pegiError.value,
            stockError: stockError.value,
            platformError: platformError.value
        });
        return;
    }

    try {
        // Llamada a createGame con los datos del juego
        await GameStore.createGame(game);
        console.log('Juego creado con éxito.');
    } catch (error) {
        console.error('Error al crear el juego:', error);
    }
};
</script>

<template>
    <form @submit.prevent="submitForm" class="create-form">
        <div class="form-group">
            <label for="titulo">Título:</label>
            <input type="text" id="titulo" v-model="game.name" class="form-control" @input="validateName">
            <span class="error-message">{{ titleError }}</span>
        </div>

        <div class="form-group">
            <label for="descripcion">Descripción:</label>
            <textarea id="descripcion" v-model="game.description" class="form-control"
                @input="validateDescription"></textarea>
            <span class="error-message">{{ descriptionError }}</span>
        </div>

        <div class="form-group">
            <label for="descripcion">Requisitos Mínimos:</label>
            <textarea id="descripcion" v-model="game.requisitos1" class="form-control"
                @input="validateRequerements"></textarea>
            <span class="error-message">{{ requirements1Error }}</span>
        </div>

        <div class="form-group">
            <label for="descripcion">Requisitos Máximos:</label>
            <textarea id="descripcion" v-model="game.requisitos2" class="form-control"
                @input="validateRequerements2"></textarea>
            <span class="error-message">{{ requirements2Error }}</span>
        </div>

        <div class="form-group">
            <label for="genero">Género:</label>
            <select id="genero" v-model="game.genderId" class="form-control" @change="validateGender">
                <option value="">Selecciona un género</option>
                <option v-for="gender in GenderStore.genders" :key="gender.genderId" :value="gender.genderId">{{ gender.name }}</option>
                <!-- Agrega más opciones según tus necesidades -->
            </select>
            <span class="error-message">{{ genderError }}</span>
        </div>

        <div class="form-group">
            <label for="precio">Precio:</label>
            <input type="number" id="precio" v-model.number="game.price" class="form-control" @input="validatePrice">
            <span class="error-message">{{ priceError }}</span>
        </div>

        <div class="form-group">
            <label for="platform">Plataforma:</label>
            <select id="genero" v-model="game.platformId" class="form-control" @change="validatePlatform">
                <option value="">Selecciona una plataforma</option>
                <option v-for="platform in PlatformStore.paltforms" :key="platform.platformId"
                    :value="platform.platformId">{{ platform.name }}</option>
                <!-- Agrega más opciones según tus necesidades -->
            </select>
            <span class="error-message">{{ platformError }}</span>
        </div>

        <div class="form-group">
            <label for="pegi">PEGI:</label>
            <input type="number" id="pegi" v-model.number="game.pegi" class="form-control" @input="validatePegi">
            <span class="error-message">{{ pegiError }}</span>
        </div>

        <div class="form-group">
            <label for="stock">Stock:</label>
            <input type="number" id="stock" v-model.number="game.stock" class="form-control" @input="validateStock">
            <span class="error-message">{{ stockError }}</span>
        </div>

        <button type="submit" class="btn btn-primary">Crear Juego</button>
    </form>
</template>



<style scoped lang="scss">
@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700&display=swap');

$secondlyFont: 'Montserrat';

.create-form {
    max-width: 400px;
    margin: 0 auto;

    .form-group {
        margin-bottom: 20px;

        label {
            display: block;
            margin-bottom: 5px;
        }

        .form-control {
            width: 100%;
            padding: 8px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        span {
            color: red;
            font-family: $secondlyFont;
        }
    }

    .btn {
        padding: 10px 20px;
        font-size: 16px;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

    .btn-primary {
        background-color: #007bff;
        color: #fff;

        &:hover {
            background-color: #0056b3;
        }
    }
}
</style>