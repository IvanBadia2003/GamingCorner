import { defineStore } from 'pinia';
import { reactive } from 'vue';

interface User {
    name: string;
    email: string;
    password: string;
    admin: boolean;
    phoneNumbre: number;
    isAuthenticated: boolean; 
}
const users = reactive(new Array<User>);
export const useUserStore = defineStore('UserStore', () => {
    // State
    const user: User = {
        name: '',
        email:'',
        password: '',
        admin: false,
        phoneNumbre: 0,
        isAuthenticated: false
    };

    async function fetchUsers() {
        try {
          //const response = await fetch('http://localhost:5000/User');
          console.log("Fetch de usuarios hecho desde LoginStore.ts");
    
         // const data = await response.json();
          //users.push(...data);
          // Actualiza la lista de posteos con los datos de la api
        } catch (error) {
          console.error('Error al obtener los posteos:', error);
        }
      }

    function login(username: string, password: string) {
        const user1 = users[0];
        // Aquí puedes agregar la lógica para verificar las credenciales
        if (user1.name === username && user1.password === password){
            user.name = username;
            user.isAuthenticated = true;
            user.password = password;
        }else{
            console.error('Credenciales incorrectas. Por favor, inténtelo de nuevo.');
            alert('No estas autorizado')
        }

    }

    function logout() {
        user.isAuthenticated = false;
    }

    return { user, login, logout, fetchUsers };
});