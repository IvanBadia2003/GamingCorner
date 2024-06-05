import { ref, computed, reactive } from 'vue'
import { defineStore } from 'pinia'

interface User {
    userId: number;
    name: string;
    email: string;
    password: string;
    phoneNumber: string;
    admin: boolean;
    imageURL: string;
    orders: Array<number>;
    isAuthenticated: boolean;
}
export const useUserStore = defineStore('userStore', () => {

    // State

    const user = reactive<User>({
        userId: 0,
        name: "",
        email: "",
        password: "",
        phoneNumber: "",
        admin: false,
        imageURL: "",
        orders: [],
        isAuthenticated: false
    });

    // Funciones
    // Función para enviar las credenciales de inicio de sesión al backend
    async function login(email: string, password: string) {
        const response = await fetch('http://localhost:5000/User/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });

        if (response.ok) {
            const userData = await response.json();
            user.isAuthenticated = true;
            Object.assign(user, userData);

        } else {
            const errorData = await response.json();
        }
    }

    async function register(name: string, email: string, password: string, phoneNumber: string) {
        try {
            const response = await fetch('http://localhost:5000/User', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ name, email, password, phoneNumber })
            });
    
            if (response.ok) {
                alert("Usuario registrado con éxito");
            } else {
                const errorData = await response.json();
                alert(`Error al registrar el usuario: ${errorData.message}`);
            }
        } catch (error) {
            alert(`Error de red: $}`);
        }
    }
    

    async function update(id:number, name:string, email: string, password: string, phoneNumber: string, imageURL: string) {
        const response = await fetch('http://localhost:5000/User/'+ id, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({id, name, email, password, phoneNumber, imageURL})
        });

        if (response.ok) {
            alert("Usuario modificado con exito")


        } else {
            const errorData = await response.json();
        }
    }

    function logout() {
        user.userId = 0;
        user.name = "";
        user.email = "";
        user.password = "";
        user.phoneNumber = "";
        user.admin = false;
        user.imageURL = "";
        user.orders = [];
        user.isAuthenticated = false;
        window.location.href = '/';

    }


    return { user, login, logout, register, update }
})
