<script setup lang="ts">
import { defineProps, defineEmits, ref } from 'vue';

const props = defineProps({
    title: {
        type: String,
        default: 'Modal Title'
    },
    modelValue: {
        type: Boolean,
        default: false
    }
});

const emits = defineEmits(['update:modelValue']);

const isVisible = ref(props.modelValue);

const closeModal = () => {
    isVisible.value = false;
    emits('update:modelValue', false);
};
</script>

<template>
    <div v-if="isVisible" class="modal-overlay" @click="closeModal">
        <div class="modal-content" @click.stop>
            <div class="modal-header">
                <h3>{{ title }}</h3>
                <button class="close-button" @click="closeModal">&times;</button>
            </div>
            <div class="modal-body">
                <slot></slot>
            </div>

        </div>
    </div>
</template>


<style scoped lang="scss">
.modal-overlay {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.5);
    display: flex;
    justify-content: center;
    align-items: center;
    z-index: 1000;
}

.modal-content {
    background: white;
    padding: 20px;
    border-radius: 8px;
    width: 90%;
    max-width: 500px;
    box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    position: relative;
}

.modal-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 20px;
}

.close-button {
    background: none;
    border: none;
    font-size: 1.5rem;
    cursor: pointer;
}

.modal-body {
    margin-bottom: 20px;
}

.modal-footer {
    text-align: right;
}

.btn {
    padding: 10px 20px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

.btn:hover {
    background-color: #0056b3;
}
</style>