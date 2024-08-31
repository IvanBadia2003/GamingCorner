<script setup lang="ts">
import { ref } from 'vue';

defineProps<{
    titleInput: string
    typeInput: string
    classInput: string
    placeholderInput: string
}>()

const emits = defineEmits(['validate']);

const inputValue = ref('');
const error = ref('');
const isValidate = ref<boolean>(false);

function validate(titleInput: string) {
    if (titleInput === "CORREO ELECTRONICO") {
        validateEmail();
        console.log(isValidate); 
    } else if (titleInput === "CONTRASEÑA") {
        validatePassword();
    } else if (titleInput === "TITULAR DE LA TARJETA") {
        validateCardholder();
    } else if (titleInput === "NUMERO DE TARJETA") {
        validateCardNumber();
    } else if (titleInput === "FECHA DE CADUCIDAD") {
        validateExpirationDate();
    } else if (titleInput === "CVV") {
        validateCVV();
    }
    emits('validate', isValidate)

}

// Función de validación para el correo electrónico
const validateEmail = () => {
    // Expresión regular para validar el formato del correo electrónico
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(inputValue.value.trim())) {
        error.value = 'Por favor, ingrese un correo electrónico válido';
        isValidate.value = false;

    } else {
        error.value = '';
        isValidate.value = true;

    }
};

// Función de validación para la contraseña
const validatePassword = () => {
    // La contraseña debe tener al menos 8 caracteres
    if (inputValue.value.trim().length < 8) {
        error.value = 'La contraseña debe tener al menos 8 caracteres';
        isValidate.value = false;

    } else {
        error.value = '';
        isValidate.value = true;

    }
};

// Función de validación para el titular de la tarjeta
const validateCardholder = () => {
    // El titular de la tarjeta debe tener al menos un nombre y un apellido
    const nameParts = inputValue.value.trim().split(' ');
    if (nameParts.length < 2) {
        error.value = 'El titular de la tarjeta debe incluir al menos un nombre y un apellido';
        isValidate.value = false;

    } else {
        error.value = '';
        isValidate.value = true;

    }
};

// Función de validación para el número de tarjeta
const validateCardNumber = () => {
    // Verificar si el número de tarjeta tiene la longitud adecuada y solo contiene números
    const cardNumber = inputValue.value.trim().replace(/\s+/g, ''); // Elimina espacios en blanco
    if (!/^\d{16}$/.test(cardNumber)) {
        error.value = 'El número de tarjeta debe tener 16 dígitos';
        isValidate.value = false;

    } else {
        error.value = '';
        isValidate.value = true;

    }
};

// Función de validación para la fecha de caducidad
const validateExpirationDate = () => {
    // Verificar si la fecha de caducidad tiene el formato adecuado (MM/AAAA)
    const expirationDate = inputValue.value.trim();
    if (!/^(0[1-9]|1[0-2])\/\d{4}$/.test(expirationDate)) {
        error.value = 'El formato de la fecha de caducidad debe ser MM/AAAA';
        isValidate.value = false;

    } else {
        error.value = '';
        isValidate.value = true;

    }
};

// Función de validación para el CVV
const validateCVV = () => {
    // Verificar si el CVV tiene exactamente 3 o 4 dígitos numéricos
    const cvv = inputValue.value.trim();
    if (!/^\d{3,4}$/.test(cvv)) {
        error.value = 'El CVV debe tener 3 o 4 dígitos numéricos';
        isValidate.value = false;

    } else {
        error.value = '';
        isValidate.value = true;

    }
};
</script>

<template>
    <div>
        <label>{{ titleInput }}</label>
        <input :type="typeInput" :class="classInput" :placeholder="placeholderInput" v-model.trim="inputValue"
            @input="validate(titleInput)">
        <span style="color: red;">{{ error }}</span>
    </div>
</template>

<style scoped lang="scss">
@import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@400;700&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Bebas+Neue&display=swap');
@import url('https://fonts.googleapis.com/css?family=Merryweather');


$primaryColor: #ba1313;
$primaryFont: 'Bebas Neue';
$secondFont: 'Montserrat';
$thirdFont: 'Merryweather';

div {

    margin: 5px;
    display: flex;
    flex-direction: column;

    font-family: $secondFont;

    input {

        border: 2px solid #000000;
        border-radius: 50px;

        padding: {
            bottom: 10px;
            top: 10px;
            right: 100px;
        }

        margin: {
            top: 5px;
            bottom: 15px;
        }
    }

}
</style>