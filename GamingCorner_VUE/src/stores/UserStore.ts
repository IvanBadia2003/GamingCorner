import { ref, computed, reactive } from 'vue'
import { defineStore } from 'pinia'
import { useRouter } from 'vue-router';

interface User {
    userId: number;
    name: string;
    email: string;
    password: string;
    confirmPassword: string;
    phoneNumber: string;
    admin: boolean;
    imageURL: string;
    orders: Array<number>;
    isAuthenticated: boolean;
}

interface Transaction {
    transactionId: number,
    userId: number,
    productId: number | null,
    videogameId: number | null,
    consoleId: number | null,
    type: string,
    date: Date
}
export const useUserStore = defineStore('userStore', () => {

    // State
    const router = useRouter(); // Obtén el router
    const transactions = reactive<Transaction[]>([]);


    const user = reactive<User>({
        userId: 0,
        name: "",
        email: "",
        password: "",
        confirmPassword: "",
        phoneNumber: "",
        admin: false,
        imageURL: "",
        orders: [],
        isAuthenticated: false
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
            const userData = await response.json();
            user.isAuthenticated = true;
            Object.assign(user, userData);
            router.push('/');

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

    async function UserTransaction(id: number) {
        try {
            debugger
            const response = await fetch('http://localhost:5000/User/'+id+'/transactions');
            console.log("Fetch de transacciones por usuario hecho desde UserStore.ts");
            const transaccionData = await response.json();
            Object.assign(transactions, transaccionData);
        } catch (error) {
            console.error('Error al obtener las transacciones:', error);
        }
    }

    const buys = computed(() => {
        return transactions.filter(transaction => transaction.type == 'Compra');
      });
    
      const sales = computed(() => {
        return transactions.filter(transaction => transaction.type == 'Venta');
      });
    

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


    return { user, login, logout, register, update, UserTransaction, transactions, buys, sales }
})
