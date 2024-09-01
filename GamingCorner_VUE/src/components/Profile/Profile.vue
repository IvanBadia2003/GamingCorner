<script setup lang="ts">
import { useUserStore } from '@/stores/UserStore';
import { ref } from 'vue';

const UserStore = useUserStore();
const formErrors = ref<string[]>([]);
const isEditing = ref(false); // Variable para controlar el estado de edición

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
        UserStore.update(
            user.userId,
            user.name,
            user.email,
            user.password,
            user.phoneNumber,
            user.imageURL
        );
        console.log('Formulario válido, procesando actualización...');
        isEditing.value = false; // Desactivar edición tras enviar el formulario
    } else {
        console.log('Errores en el formulario, no se puede actualizar.');
    }
}

function toggleEdit() {
    if (isEditing.value) {
        // Si está en modo "Modificar", intentamos enviar el formulario
        update();
    } else {
        // Si está en modo "Editar", activamos los inputs
        isEditing.value = true;
    }
}
</script>

<template>
    <div class="container">
        <h1 class="titulo">Bienvenido {{ UserStore.user.name }}</h1>
        <div class="forms">
            <div class="panel">
                <div class="formularios">
                    <form class="info">
                        <div class="info__field">
                            <label for="name">Nombre:</label>
                            <span>{{ UserStore.user.name }}</span>
                        </div>
                        <div class="info__field">
                            <label for="email">Email:</label>
                            <span>{{ UserStore.user.email }}</span>
                        </div>
                        <div class="info__field">
                            <label for="phoneNumber">Número de teléfono:</label>
                            <span>{{ UserStore.user.phoneNumber }}</span>
                        </div>
                        <div class="info__field">
                            <label for="address">Dirección:</label>
                            <span>{{ UserStore.user.phoneNumber }}</span>
                        </div>
                    </form>
                </div>
            </div>
            <div class="panel">
                <div class="formularios">
                    <form @submit.prevent="update" class="update">
                        <div class="editForm">
                            <div class="update__field">
                                <label for="name">Nombre:</label>
                                <input type="text" id="name" v-model="UserStore.user.name" :disabled="!isEditing"
                                    required />
                            </div>

                            <div class="update__field">
                                <label for="email">Email:</label>
                                <input type="email" id="email" v-model="UserStore.user.email" :disabled="!isEditing"
                                    required />
                            </div>

                            <div class="update__field">
                                <label for="password">Contraseña:</label>
                                <input type="password" id="password" v-model="UserStore.user.password"
                                    :disabled="!isEditing" required />
                            </div>

                            <div class="update__field">
                                <label for="confirmPassword">Confirmar Contraseña:</label>
                                <input type="password" id="confirmPassword" :disabled="!isEditing" required />
                            </div>

                            <div class="update__field">
                                <label for="phoneNumber">Número de Teléfono:</label>
                                <input type="text" id="phoneNumber" v-model="UserStore.user.phoneNumber"
                                    :disabled="!isEditing" required />
                            </div>

                            <div class="update__field">
                                <label for="address">Dirección:</label>
                                <input type="text" id="phoneNumber" v-model="UserStore.user.phoneNumber"
                                    :disabled="!isEditing" required />
                            </div>



                            <button type="button" class="update__button" @click="toggleEdit">
                                {{ isEditing ? 'Modificar' : 'Editar' }}
                            </button>
                        </div>

                        <div v-if="formErrors.length" class="update__errors">
                            <ul>
                                <li v-for="(error, index) in formErrors" :key="index">
                                    {{ error }}
                                </li>
                            </ul>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>


<style scoped lang="scss">
.container {
    width: 100%;
    padding: 20px;
    display: flex;
    flex-direction: column;


    .titulo {
        text-align: center;
        font-size: 2rem;
        margin-bottom: 40px;
        background-color: #ccc;
        border-radius: 5px;
        padding: 15px 0px;
    }

    .forms {
        width: 100%;
        display: flex;
        justify-content: center;
        gap: 20px;

        .panel {
            width: auto;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 8px;
            background-color: #f9f9f9;

            .formularios {

                .info {
                    display: flex;
                    flex-direction: column;
                    background-color: #f9f9f9;
                    padding: 20px;
                    border-radius: 8px;
                    max-width: 400px;
                    margin: 20px auto;
                    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                    font-family: 'Montserrat', sans-serif;

                    .info__field {
                        margin-bottom: 15px;
                    }

                    label {
                        display: block;
                        font-weight: 600;
                        color: #333;
                        margin-bottom: 5px;
                    }

                    span {
                        display: block;
                        font-weight: 400;
                        color: #666;
                        background-color: #fff;
                        padding: 10px;
                        border-radius: 4px;
                        border: 1px solid #ddd;
                    }

                    .info__field:last-child {
                        margin-bottom: 0;
                    }
                }

                .update {
                    display: flex;
                    flex-direction: row;
                    background-color: #ffffff;
                    padding: 20px;
                    gap: 20px;
                    border-radius: 8px;
                    max-width: 450px;
                    margin: 30px auto;
                    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
                    font-family: 'Montserrat', sans-serif;

                    .editForm {
                        .update__field {
                            margin-bottom: 20px;
                        }

                        input {
                            width: 100%;
                            padding: 10px 0;
                            border: 1px solid #ddd;
                            border-radius: 4px;
                            font-size: 14px;
                            font-family: inherit;
                            color: #555;
                            transition: border-color 0.3s ease;
                        }

                        input:focus {
                            border-color: #ba1313;
                            outline: none;
                        }

                        .update__button {
                        padding: 12px;
                        background-color: #ba1313;
                        color: white;
                        border: none;
                        border-radius: 4px;
                        font-size: 16px;
                        cursor: pointer;
                        transition: background-color 0.3s ease;
                    }

                    .update__button:hover {
                        background-color: #a10f0f;
                    }
                    }


                    .update__errors {
                        margin-bottom: 20px;
                    }

                    .update__errors ul {
                        padding-left: 20px;
                        color: #d9534f;
                    }

                    
                }



            }
        }
    }
}
</style>