<script setup lang="ts">
import { ref } from 'vue';

const productName = ref('');
const productDescription = ref('');
const productPrice = ref<number | null>(null);
const productCategory = ref('');
const productImages = ref<File[]>([]);
const formErrors = ref<string[]>([]);

const categories = ['Videojuego', 'Consola'];

const validateForm = () => {
  formErrors.value = [];

  if (!productName.value) {
    formErrors.value.push('El nombre del producto es obligatorio.');
  }

  if (!productDescription.value) {
    formErrors.value.push('La descripción del producto es obligatoria.');
  }

  if (!productPrice.value || productPrice.value <= 0) {
    formErrors.value.push('El precio del producto debe ser mayor que 0.');
  }

  if (!productCategory.value) {
    formErrors.value.push('Por favor, selecciona una categoría para el producto.');
  }

  if (productImages.value.length === 0) {
    formErrors.value.push('Por favor, sube al menos una imagen del producto.');
  }

  return formErrors.value.length === 0;
};

const handleImageUpload = (event: Event) => {
  const target = event.target as HTMLInputElement;
  if (target.files) {
    productImages.value = Array.from(target.files);
  }
};

const uploadProduct = () => {
  if (validateForm()) {
    // Aquí enviarías los datos del producto al backend
    console.log('Producto válido, subiendo...');
    console.log({
      name: productName.value,
      description: productDescription.value,
      price: productPrice.value,
      category: productCategory.value,
      images: productImages.value,
    });
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
        <input type="text" id="productName" v-model="productName" required />
      </div>

      <div class="form-field">
        <label for="productDescription">Descripción:</label>
        <textarea id="productDescription" v-model="productDescription" required></textarea>
      </div>

      <div class="form-field">
        <label for="productPrice">Precio (€):</label>
        <input type="number" id="productPrice" v-model="productPrice" min="0" step="0.01" required />
      </div>

      <div class="form-field">
        <label for="productCategory">Categoría:</label>
        <select id="productCategory" v-model="productCategory" required>
          <option value="" disabled selected>Selecciona una categoría</option>
          <option v-for="category in categories" :key="category" :value="category">{{ category }}</option>
        </select>
      </div>

      <div class="form-field">
        <label for="productImages">Imágenes del Producto:</label>
        <input type="file" id="productImages" @change="handleImageUpload" multiple accept="image/*" required />
        <small>Puedes subir hasta 5 imágenes.</small>
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
