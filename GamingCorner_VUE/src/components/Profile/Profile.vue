<script setup lang="ts">
import { useUserStore } from '@/stores/UserStore';
import { ref } from 'vue';

const UserStore = useUserStore();
const formErrors = ref<string[]>([]);

const validateForm = () => {
    formErrors.value = [];

    // Validar que las contraseñas coincidan
    if (UserStore.user.password !== UserStore.user.confirmPassword) {
        formErrors.value.push('Las contraseñas no coinciden.');
    }

    // Validar formato de email
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(UserStore.user.email)) {
        formErrors.value.push('El email no es válido.');
    }

    // Validar formato del número de teléfono
    const phoneRegex = /^[\d\s+-]+$/; // Acepta dígitos, espacios, + y -
    if (!phoneRegex.test(UserStore.user.phoneNumber)) {
        formErrors.value.push('El número de teléfono no es válido.');
    }

    return formErrors.value.length === 0;
};

function update() {
    const { user } = UserStore;
    if (validateForm()) {

        UserStore.update(user.userId, user.name, user.email, user.password, user.phoneNumber, user.imageURL);
        console.log('Formulario válido, procesando actualización...');

    } else {
        console.log('Errores en el formulario, no se puede actualizar.');

    }

}



</script>

<template>
    <div class="container">
        <h1 class="titulo">Bienvenido Ivan</h1>
        <div class="forms">
            <div class="panel">
                <div class="formularios">
                    <form>
                        <label for="name">Nombre:</label>
                        <span>{{ UserStore.user.name }}</span><br>
                        <label for="email">Email:</label>
                        <span>{{ UserStore.user.email }}</span><br>
                        <label for="phoneNumber">Número de teléfono:</label>
                        <span>{{ UserStore.user.phoneNumber }}</span>
                    </form>
                </div>
            </div>
            <div class="panel">
                <div class="formularios">
                    <form @submit.prevent="update">
                        <label for="name">Name:</label><br>
                        <input type="text" id="name" v-model="UserStore.user.name" required><br>

                        <label for="email">Email:</label><br>
                        <input type="email" id="email" v-model="UserStore.user.email" required><br>

                        <label for="password">Password:</label><br>
                        <input type="password" id="password" v-model="UserStore.user.password" required><br>

                        <label for="confirmPassword">Confirm Password:</label><br>
                        <input type="password" id="confirmPassword" required><br>

                        <label for="phoneNumber">Phone Number:</label><br>
                        <input type="text" id="phoneNumber" v-model="UserStore.user.phoneNumber" required><br>

                        <div v-if="formErrors.length">
                            <ul>
                                <li v-for="(error, index) in formErrors" :key="index" style="color: red;">
                                    {{ error }}
                                </li>
                            </ul>
                        </div>

                        <button type="submit">Modificar</button>
                    </form>

                </div>
            </div>
        </div>
    </div>
</template>

<style scoped lang="scss">
.container {
    max-width: 100%; // Ajusta el ancho máximo según tu diseño
    padding: 20px;

    .titulo {
        text-align: center; // Centra el título
        font-size: 2rem;
        margin-bottom: 40px;
        background-color: #ccc;
        border-radius: 5px;
        padding: 15px 0px;
    }

    .forms {
        width: 100%;
        display: flex;
        justify-content: space-between; // Separa los formularios a los lados
        gap: 20px; // Espacio entre los dos paneles

        .panel {
            flex: 1; // Cada panel ocupa el mismo espacio
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 8px;
            background-color: #f9f9f9;

            .formularios {
                form {
                    display: flex;
                    flex-direction: column;

                    label {
                        font-weight: bold;
                        margin-bottom: 5px;
                    }

                    input {
                        padding: 8px;
                        margin-bottom: 15px;
                        border: 1px solid #ccc;
                        border-radius: 4px;
                    }

                    button {
                        padding: 10px;
                        background-color: #007BFF;
                        color: white;
                        border: none;
                        border-radius: 4px;
                        cursor: pointer;
                        transition: background-color 0.3s ease;

                        &:hover {
                            background-color: #0056b3;
                        }
                    }
                }
            }
        }
    }
}
</style>