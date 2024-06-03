<script setup lang="ts">
import { reactive, ref } from 'vue';
import { useGameStore } from '@/stores/GameStore';

const GameStore = useGameStore();

interface Gender    {
    genderId: number,
    videogameId: number
  }

interface Game {
    videogameId: number;
    name: string;
    pegi: number;
    description: string;
    category: string;
    stock: number;
    available: boolean;
    platform: string;
    price: number;
    imageURL: string;
    listVideogameGender: Gender
}


// inicializo un juego
const game = reactive<Game>({
    videogameId: 0,
    name: '',
    pegi: 0,
    description: '',
    category: '',
    stock: 0,
    available: false,
    platform: '',
    price: 0,
    imageURL: '',
    listVideogameGender: {
        genderId: 0,
        videogameId: 0
    }
});




// Variables para almacenar mensajes de error
const titleError = ref('');
const descriptionError = ref('');
const genderError = ref('');
const priceError = ref('');
const pegiError = ref('');
const stockError = ref('');
const stockPlatform = ref('');

// Función para validar el título
const validateName = () => {
    // Validación: Título no puede estar vacío
    if (!game.name.trim()) {
        titleError.value = 'El título es obligatorio';
    } else {
        titleError.value = '';
    }
};

// Función para validar el pegi
const validatePegi = () => {
    // Validación: Precio debe ser un número positivo
    if (game.pegi < 0 || isNaN(game.pegi)) {
        pegiError.value = 'El Pegi debe ser un número positivo';
    } else {
        pegiError.value = '';
    }
};

// Función para validar la descripción
const validateDescription = () => {
    // Validación: Descripción no puede estar vacía
    if (!game.description.trim()) {
        descriptionError.value = 'La descripción es obligatoria';
    } else {
        descriptionError.value = '';
    }
};

// Función para validar el genero
const validateGender = () => {
    // Validación: Descripción no puede estar vacía
    if (!game.category.trim()) {
        genderError.value = 'El género es obligatorio';
    } else {
        genderError.value = '';
    }
};

// Función para validar el stock
const validateStock = () => {
    // Validación: Precio debe ser un número positivo
    if (game.stock < 0 || isNaN(game.stock)) {
        stockError.value = 'El stock debe ser un número positivo';
    } else {
        stockError.value = '';
    }
};

// Función para validar el genero
const validatePlatform = () => {
    // Validación: Descripción no puede estar vacía
    if (!game.platform.trim()) {
        stockPlatform.value = 'La plataforma es obligatorio';
    } else {
        stockPlatform.value = '';
    }
};

// Función para validar el precio
const validatePrice = () => {
    // Validación: Precio debe ser un número positivo
    if (game.price < 0 || isNaN(game.price)) {
        priceError.value = 'El precio debe ser un número positivo';
    } else {
        priceError.value = '';
    }
};


const submitForm = async () => {

    try {
        validateName();
        validatePegi();
        validateDescription();
        validateGender();
        validateStock();
        validatePlatform();
        validatePrice();
        // Llamada a createFunction con los datos de la obra
        await GameStore.createGame(game);
        console.log('Datos de la nueva obra enviados al servidor.');
    } catch (error) {
        console.error('Error al enviar los datos de la obra al servidor:', error);
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
            <label for="genero">Género:</label>
            <select id="genero" v-model="game.category" class="form-control" @change="validateGender">
                <option value="">Selecciona un género</option>
                <option value="Drama">Drama</option>
                <option value="Romance">Romance</option>
                <option value="Comedia">Comedia</option>
                <option value="Musical">Musical</option>
                <option value="Monologo">Monólogo</option>
                <option value="Thriller">Thriller</option>
                <!-- Agrega más opciones según tus necesidades -->
            </select> <span class="error-message">{{ genderError }}</span>
        </div>


        <div class="form-group">
            <label for="precio">Precio:</label>
            <input type="number" id="precio" v-model.number="game.price" class="form-control" @input="validatePrice">
            <span class="error-message">{{ priceError }}</span>
        </div>

        <button type="submit" class="btn btn-primary">Crear Obra</button>
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