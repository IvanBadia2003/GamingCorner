import { ref, computed, reactive } from 'vue'
import { defineStore } from 'pinia'

interface User{
    userId: number,
    name: string,
    email: string,
    password: string,
    phoneNumber: number,
    admin: boolean,
    imageURL: string,
    orders: Array<number>
}
export const useUserStore = defineStore('userStore', () => {

    // State
    const user = reactive<User>({
        userId: 2,
        name: "",
        email: "",
        password: "",
        phoneNumber: 123456789,
        admin: true,
        imageURL: "",
        orders: []
      });

    // Funciones
    // Función para enviar las credenciales de inicio de sesión al backend
    async function login(email: string, password: string) {
        debugger
        const response = await fetch('http://localhost:5000/User/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });

        if (response.ok) {
            const user:User = await response.json();


            window.location.href = '/';
            alert(user.userId)
        } else {
            const errorData = await response.json();
        }
    }

    function logout(){

    }


    return {login}
})
