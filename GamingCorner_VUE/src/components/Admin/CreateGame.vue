<script setup lang="ts">
import { reactive, ref } from 'vue';
import { useGameStore } from '@/stores/GameStore';

const GameStore = useGameStore();

interface Game {
  videogameId: number;
  name: string;
  pegi: number;
  description: string;
  category: string;
  stock: number;
  available: boolean;
  requisitos1: string;
  requisitos2: string;
  platform: string;
  price: number;
  imageURL: string;
  code: string | null;
  consoleId: number | null;
}

// Inicializo un juego
const game = reactive<Game>({
  videogameId: 0,
  name: '',
  pegi: 0,
  description: '',
  category: '',
  stock: 0,
  available: false,
  requisitos1: '',
  requisitos2: '',
  platform: '',
  price: 0,
  imageURL: '',
  code: '',
  consoleId: null
});

// Variables para almacenar mensajes de error
const titleError = ref('');
const descriptionError = ref('');
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

// Función para validar el género
const validateGender = () => {
  genderError.value = game.category.trim() ? '' : 'El género es obligatorio';
};

// Función para validar el stock
const validateStock = () => {
  stockError.value = (game.stock >= 0) ? '' : 'El stock debe ser un número positivo';
};

// Función para validar la plataforma
const validatePlatform = () => {
  platformError.value = game.platform.trim() ? '' : 'La plataforma es obligatoria';
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

  // Verificar si hay errores antes de enviar el formulario
  if (titleError.value || descriptionError.value || genderError.value || priceError.value || pegiError.value || stockError.value || platformError.value) {
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
      <textarea id="descripcion" v-model="game.description" class="form-control" @input="validateDescription"></textarea>
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
      <input type="text" id="platform" v-model="game.platform" class="form-control" @input="validatePlatform">
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