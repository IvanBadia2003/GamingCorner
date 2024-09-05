<script setup lang="ts">
import { ref } from 'vue';
import { useTransactionStore } from '@/stores/TransactionStore';
import { useUserStore } from '@/stores/UserStore';

const TransactionStore = useTransactionStore();

const UserStore = useUserStore();

interface saleProduct{
  name: string,
  description: string,
  available: boolean,
  price: number,
  imageURL: string
}

const product = reactive<saleProduct>({
  name: '',
  description: '',
  available: true,
  price: 0,
  imageURL: ''
});


const formErrors = ref<string[]>([]);

const validateForm = () => {
  formErrors.value = [];

  if (!product.name) {
    formErrors.value.push('El nombre del producto es obligatorio.');
  }

  if (!product.description) {
    formErrors.value.push('La descripción del producto es obligatoria.');
  }

  if (!product.price || product.price <= 0) {
    formErrors.value.push('El precio del producto debe ser mayor que 0.');
  }

  if (!product.imageURL) {
    formErrors.value.push('Por favor, sube al menos una imagen del producto.');
  }

  return formErrors.value.length === 0;
};

const uploadProduct = () => {
  if (validateForm()) {
    console.log('Producto válido, subiendo...');
    await TransactionStore.saleProduct(UserStore.user.userId, product);
  } else {
    console.log('Errores en el formulario, no se puede subir el producto.');
  }
};
</script>

<template>
  <div class="upload-container">
    <h1>Subir un nuevo producto</h1>
    <form @submit.prevent="uploadProduct" class="upload-form">
      <div class="form-field">
        <label for="productName">Nombre del Producto:</label>
        <input type="text" id="productName" v-model="product.name" required />
      </div>

      <div class="form-field">
        <label for="productDescription">Descripción:</label>
        <textarea id="productDescription" v-model="product.description" required></textarea>
      </div>

      <div class="form-field">
        <label for="productPrice">Precio (€):</label>
        <input type="number" id="productPrice" v-model="product.price" min="0" step="0.01" required />
      </div>

      <div class="form-field">
        <label for="productImages">Imágenes del Producto:</label>
        <input type="text" id="productImages" v-model="product.imageURL"  required />
      </div>

      <div v-if="formErrors.length" class="form-errors">
        <ul>
          <li v-for="(error, index) in formErrors" :key="index">{{ error }}</li>
        </ul>
      </div>

      <button type="submit" class="upload-button">Subir Producto</button>
    </form>
  </div>
</template>

<style scoped>
.upload-container {
  max-width: 600px;
  margin: 0 auto;
  padding: 1.5rem;
  background-color: #f9f9f9;
  border-radius: 8px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
}

.upload-container h1 {
  text-align: center;
  margin-bottom: 1.5rem;
}

.upload-form {
  display: flex;
  flex-direction: column;
}

.form-field {
  margin-bottom: 1rem;
}

.form-field label {
  display: block;
  margin-bottom: 0.5rem;
  font-weight: bold;
}

.form-field input,
.form-field textarea,
.form-field select {
  width:  95%;
  padding: 0.75rem;
  border: 1px solid #ccc;
  border-radius: 4px;
  font-size: 1rem;
}

.form-field input[type="file"] {
  padding: 0.25rem;
}

.form-errors {
  margin-top: 1rem;
  color: red;
}

.form-errors ul {
  list-style: none;
  padding-left: 0;
}

.form-errors li {
  margin-bottom: 0.5rem;
}

.upload-button {
  padding: 0.75rem;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 1rem;
}

.upload-button:hover {
  background-color: #0056b3;
}
</style>
