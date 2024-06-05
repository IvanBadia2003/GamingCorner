<script setup lang="ts">
import { useUserStore } from '@/stores/UserStore';

const UserStore = useUserStore();

interface User {
    userId: number;
    name: string;
    email: string;
    password: string;
    phoneNumber: number;
    admin: boolean;
    imageURL: string;
    orders: Array<number>;
    isAuthenticated: boolean;
}

function update() {
    const { user } = UserStore;
    UserStore.update(user.userId, user.name, user.email, user.password, user.phoneNumber, user.imageURL);
}

</script>

<template>

    <main class="panelD">


        <h1 class="tituloD">Bienvenido {{ UserStore.user.name }}</h1>

        <div class="formularios">
            <form @submit.prevent="update">
                <label for="name">Name:</label><br>
                <input type="text" id="name" v-model="UserStore.user.name" required><br>
                <label for="email">Email:</label><br>
                <input type="email" id="email" v-model="UserStore.user.email" required><br>
                <label for="password">Password:</label><br>
                <input type="password" id="password" v-model="UserStore.user.password" required><br>
                <label for="phoneNumber">Phone Number:</label><br>
                <input type="text" id="phoneNumber" v-model="UserStore.user.phoneNumber" required><br>
                <label for="imageURL">Image URL:</label><br>
                <input type="text" id="imageURL" v-model="UserStore.user.imageURL"><br>
                <button type="submit">Modificar</button>
            </form>
        </div>



    </main>
</template>

<style scoped lang="scss">
.panelD {
    width: 100%;
    overflow: auto;
    max-height: 100vh;
    background-color: #fefefe;
}

header {
    height: 70px;
    width: 100%;
    border-bottom: solid 1px #d1d1d1;
    background-color: #fff;
    position: sticky;
    top: 0px;
    box-shadow: 1px 2px 15px rgba(0, 0, 0, 0.1);
    z-index: 11;
}

header img {
    max-height: 30px;
    float: right;
    width: 30px;
    padding-bottom: 20px;
    padding-top: 20px;
    margin-right: 10px;
}

header img:hover {
    cursor: pointer;
}

.perfil {
    max-height: 50px;
    float: right;
    width: 50px;
    padding: 10px;
}

.tituloD {
    color: #606060;
    font-weight: 400;
    font-size: 1.3em;
    padding-left: 50px;
    padding-top: 30px;
    padding-bottom: 30px;
    padding-right: 50px;
    text-decoration: underline;
    color: #fcc728;
}

.tabla {
    display: flex;
    margin-left: 50px;
    margin-right: 50px;
    background-color: #fcc728;
    padding: 10px;
    border-radius: 10px;
    filter: drop-shadow(0px 6px 0px #e2b324);
}

.tabla table {
    text-align: center;
    padding: 40px;
    width: 100%;
    margin-left: auto;
    margin-right: auto;
    border-collapse: collapse;


}

.tabla table tr th {
    font-size: 1em;
    font-weight: 300;
    border: solid 1px #ededed;
    padding: 3px 0px 3px 0px;
    font-family: 'Muli', sans-serif;
    background-color: #fff;
}

.panelD h2 {
    font-weight: 200;
    font-size: 1.2em;
    padding-left: 50px;
    padding-top: 30px;
    padding-right: 50px;
    color: #333333;
    margin-bottom: 5px;
}

.panelD h2 i {
    color: #333333;
    padding-left: 10px;
    font-size: 0.8em;
    color: #333333;
}

.negrita {
    color: #fcc728;
}

.formularios {
    margin-left: auto;
    margin-right: auto;
}

.formularios form {
    margin: 50px;
}

.formularios form input {
    font-family: 'Muli', sans-serif;
    padding: 10px;
    margin-bottom: 10px;
    margin-top: 10px;
    border: solid 1px #d1d1d1;
    border-radius: 10px;
}

textarea:focus,
input:focus {
    outline-color: #FCC728;
    color: #FCC728;
}

.formularios form h3 {
    font-size: 1.1em;
    font-weight: 600;
}

input[type="submit"] {
    font-family: 'Muli', sans-serif;
    background-color: #fff;
    border: solid 1px #d1d1d1;
    transition: all 0.4s;
}

input[type="submit"]:hover {
    cursor: pointer;
    background-color: #FCC728;
    border: solid 1px #fff;
}

.grafico {
    margin: 50px;
    padding: 10px;
    border-radius: 10px;
    background-color: #fcc728;
    filter: drop-shadow(0px 6px 0px #e2b324);
}

.grafico img {
    width: 100%;
}

@media (max-width: 425px) {
    .tabla table tr th {
        font-size: 0.7em;
        padding: 0px;
    }

    .tabla {
        margin-left: 5px;
        margin-right: 5px;
        padding: 1px;
        border-radius: 10px;
    }

    .tabla table {
        padding: 2px;
        margin: 5px;
    }

    .tituloD {
        font-size: 0.9em;
        padding-left: 10px;
        padding-right: 10px;
        padding-top: 20px;
        padding-bottom: 20px;
    }

    .todo nav ul li {
        font-size: 0.7em;
        font-weight: 300;
        margin-left: 2px;
        padding: 10px;
    }

    .flecha {
        font-size: 0.6em;
    }

    .formularios form {
        margin: 10px;
    }

    .formularios form input {
        font-family: 'Muli', sans-serif;
        padding: 5px;
        margin-bottom: 5px;
        margin-top: 5px;
        border: solid 1px #d1d1d1;
        border-radius: 5px;
    }

    .caja {
        width: 70%;
        position: absolute;
        top: 20%;
        left: 15%;
    }

    header img {
        width: 10%;
    }

    form {
        width: 90%;
    }

    .grafico {
        margin: 5px;
        padding: 10px;
        background-color: #fff;
        border-radius: 10px;
        border: solid 1px #d1d1d1;
    }

    .panelD h2 {
        font-size: 1em;
        padding-left: 5px;
        padding-top: 10px;
        padding-right: 5px;
    }
}
</style>