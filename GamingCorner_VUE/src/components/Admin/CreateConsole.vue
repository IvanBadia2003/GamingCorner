<script setup lang="ts">
import { reactive, ref } from 'vue';
import { useConsoleStore } from '@/stores/ConsoleStore';
import { usePlatformStore } from '@/stores/PlatformStore';

const ConsoleStore = useConsoleStore();
const PlatformStore = usePlatformStore();

interface createConsole {
  name: string;
  specifications: string;
  stock: number;
  available: boolean;
  platformId: number;
  price: number;
  imageURL: string;
}

// Inicializo una consola
const consoleData = reactive<createConsole>({
  name: '',
  specifications: '',
  stock: 0,
  available: true,
  platformId: 0,
  price: 0,
  imageURL: ''
});

// Variables para almacenar mensajes de error
const titleError = ref('');
const specificationsError = ref('');
const stockError = ref('');
const platformError = ref('');
const priceError = ref('');

// Función para validar el nombre
const validateName = () => {
  titleError.value = consoleData.name.trim() ? '' : 'El nombre es obligatorio';
};

// Función para validar las especificaciones
const validateSpecifications = () => {
  specificationsError.value = consoleData.specifications.trim() ? '' : 'Las especificaciones son obligatorias';
};

// Función para validar el stock
const validateStock = () => {
  stockError.value = consoleData.stock >= 0 ? '' : 'El stock debe ser un número positivo';
};

// Función para validar la plataforma
const validatePlatform = () => {
  platformError.value = consoleData.platformId > 0 ? '' : 'La plataforma es obligatoria';
};

// Función para validar el precio
const validatePrice = () => {
  priceError.value = consoleData.price >= 0 ? '' : 'El precio debe ser un número positivo';
};

const submitForm = async () => {
  // Realizar validaciones
  validateName();
  validateSpecifications();
  validateStock();
  validatePlatform();
  validatePrice();

  // Verificar si hay errores antes de enviar el formulario
  if (titleError.value || specificationsError.value || stockError.value || platformError.value || priceError.value) {
    console.log('Errores en el formulario:', {
      titleError: titleError.value,
      specificationsError: specificationsError.value,
      stockError: stockError.value,
      platformError: platformError.value,
      priceError: priceError.value
    });
    return;
  }

  try {
    // Llamada a createConsole con los datos de la consola
    await ConsoleStore.createConsole(consoleData);
    alert('Consola creada con éxito.');
  } catch (error) {
    console.error('Error al crear la consola:', error);
  }
};
</script>

<template>
  <form @submit.prevent="submitForm" class="create-form">
    <div class="form-group">
      <label for="nombre">Nombre:</label>
      <input type="text" id="nombre" v-model="consoleData.name" class="form-control" @input="validateName">
      <span class="error-message">{{ titleError }}</span>
    </div>

    <div class="form-group">
      <label for="specifications">Especificaciones:</label>
      <textarea id="specifications" v-model="consoleData.specifications" class="form-control" @input="validateSpecifications"></textarea>
      <span class="error-message">{{ specificationsError }}</span>
    </div>

    <div class="form-group">
      <label for="stock">Stock:</label>
      <input type="number" id="stock" v-model.number="consoleData.stock" class="form-control" @input="validateStock">
      <span class="error-message">{{ stockError }}</span>
    </div>

    <div class="form-group">
      <label for="platform">Plataforma:</label>
      <select id="platform" v-model="consoleData.platformId" class="form-control" @change="validatePlatform">
        <option value="">Selecciona una plataforma</option>
        <option v-for="platform in PlatformStore.paltforms" :key="platform.platformId" :value="platform.platformId">
          {{ platform.name }}
        </option>
      </select>
      <span class="error-message">{{ platformError }}</span>
    </div>

    <div class="form-group">
      <label for="precio">Precio:</label>
      <input type="number" id="precio" v-model.number="consoleData.price" class="form-control" @input="validatePrice">
      <span class="error-message">{{ priceError }}</span>
    </div>

    <div class="form-group">
      <label for="imageURL">URL de la imagen:</label>
      <input type="text" id="imageURL" v-model="consoleData.imageURL" class="form-control">
    </div>

    <button type="submit" class="btn btn-primary">Crear Consola</button>
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