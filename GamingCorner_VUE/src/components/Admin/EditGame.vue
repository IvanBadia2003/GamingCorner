<script setup lang="ts">
import { defineProps } from 'vue';
import { reactive, ref } from 'vue';
import { useGameStore } from '@/stores/GameStore';

const props = defineProps<{
    name: string
    videogameId: number
    available: boolean
    price: number
    description: string
}>();

const FunctionStore = useGameStore();

interface Game {
    videogameId: number;
    available: boolean;
    description: string;
    price: number;
}

const editedGame = reactive<Game>({
    videogameId: props.videogameId,
    available: props.available,
    description: props.description,
    price: props.price
});

// Variables para almacenar mensajes de error
const descriptionError = ref('');
const priceError = ref('');

// Función para validar la descripción
const validateDescription = () => {
    // Validación: Descripción no puede estar vacía
    if (!editedGame.description.trim()) {
        descriptionError.value = 'La descripción es obligatoria';
    } else {
        descriptionError.value = '';
    }
};


// Función para validar el precio
const validatePrice = () => {
    // Validación: Precio debe ser un número positivo
    if (editedGame.price < 0 || isNaN(editedGame.price)) {
        priceError.value = 'El precio debe ser un número positivo';
    } else {
        priceError.value = '';
    }
};

const submitForm = () => {
    // Validar todos los campos antes de enviar el formulario
    validateDescription();
    validatePrice();

    // Verificar si hay errores antes de enviar el formulario
    if (descriptionError.value || priceError.value) {
        // Si hay errores, no enviar el formulario
        console.log('Formulario no enviado debido a errores de validación');
        return;
    }

    // Si no hay errores, enviar el formulario
    console.log('Datos editados:', editedGame);
    FunctionStore.editGame(props.videogameId, editedGame);
};
</script>

<template>
    <form @submit.prevent="submitForm" class="edit-form">
        <input type="hidden" name="obraId" v-model="editedGame.videogameId" />
        <div class="form-group">
            <label for="title">Título: {{ props.name }}</label>
        </div>
        <div class="form-group">
            <label for="description">Descripción:</label>
            <textarea id="description" v-model="editedGame.description" class="form-control"></textarea>
            <span class="error-message">{{ descriptionError }}</span>
        </div>
        <div class="form-group">
            <label for="price">Precio:</label>
            <input type="number" id="price" v-model.number="editedGame.price" class="form-control" />
            <span class="error-message">{{ priceError }}</span>
        </div>
        <button type="submit" class="btn btn-primary">Guardar cambios</button>
    </form>
</template>

<style>
/* Estilos para el mensaje de error */
.error-message {
    color: red;
    font-size: 14px;
}
</style>


<style scoped lang="scss">
@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700&display=swap');

$secondlyFont: 'Montserrat';

.edit-form {
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

        &:focus {
            outline: none;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.7); // Estilo de enfoque
        }
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
