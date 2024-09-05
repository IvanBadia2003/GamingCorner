<script setup>
import { Bar } from 'vue-chartjs';
import { Chart as ChartJS, Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale } from 'chart.js';
import { useTransactionStore } from '@/stores/TransactionStore';
import { computed, ref, onMounted } from 'vue';

// La función fetch que obtienes desde un archivo aparte, o la puedes tener aquí
async function fetchTransactionsCount() {
  const dataConsoleCount = ref();
  const dataProductCount = ref();
  const dataVideogameCount = ref();
  
  try {
    const responseConsole = await fetch('http://gamingcornerapi.retocsv.es/Transaction/CountTransactionsByConsoleId');
    const responseProduct = await fetch('http://gamingcornerapi.retocsv.es/Transaction/CountTransactionsByProductId');
    const responseVideogame = await fetch('http://gamingcornerapi.retocsv.es/Transaction/CountTransactionsByVideogametId');
    
    console.log("Fetch de transacciones hecho desde TransactionStore.ts");

    const dataConsole = await responseConsole.json();
    const dataProduct = await responseProduct.json();
    const dataVideogame = await responseVideogame.json();

    dataConsoleCount.value = dataConsole;
    dataProductCount.value = dataProduct;
    dataVideogameCount.value = dataVideogame;

  } catch (error) {
    console.error('Error al obtener las transacciones:', error);
  }

  // Retorna las variables reactivas
  return { dataConsoleCount, dataProductCount, dataVideogameCount };
}

// Variables reactivas para almacenar los datos
const consoleCount = ref(null);
const productCount = ref(null);
const videogameCount = ref(null);

// Ejecuta la función cuando el componente se monta
onMounted(async () => {
  const { dataConsoleCount, dataProductCount, dataVideogameCount } = await fetchTransactionsCount();
  consoleCount.value = dataConsoleCount.value;
  productCount.value = dataProductCount.value;
  videogameCount.value = dataVideogameCount.value;
});
// Registrar componentes de Chart.js
ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale);

// Acceder al store de transacciones


// Definir los datos del gráfico
const chartData = computed(() => ({
  labels: [],
  datasets: [
    {
      label: 'Productos Segunda Mano',
      backgroundColor: '#FF6384',
      borderColor: '#FF6384',
      borderWidth: 2,
      hoverBackgroundColor: '#FF99A4',
      hoverBorderColor: '#FF6384',
      data: productCount,
      borderRadius: 5,
    },
    {
      label: 'Consolas',
      backgroundColor: '#42A5F5',
      borderColor: '#1E88E5',
      borderWidth: 2,
      hoverBackgroundColor: '#64B5F6',
      hoverBorderColor: '#1E88E5',
      data: consoleCount,
      borderRadius: 5,
    },
    {
      label: 'Videojuegos',
      backgroundColor: '#66BB6A',
      borderColor: '#43A047',
      borderWidth: 2,
      hoverBackgroundColor: '#81C784',
      hoverBorderColor: '#43A047',
      data: videogameCount,
      borderRadius: 5,
    },
  ],
}));

// Opciones del gráfico
const chartOptions = {
  responsive: true,
  maintainAspectRatio: false,
  plugins: {
    legend: {
      display: true,
      position: 'top',
      labels: {
        font: {
          size: 14,
          family: 'Arial, sans-serif',
        },
        color: '#333',
      },
    },
    tooltip: {
      backgroundColor: '#333',
      titleFont: { size: 16, family: 'Arial, sans-serif' },
      bodyFont: { size: 14, family: 'Arial, sans-serif' },
      padding: 10,
      displayColors: false,
    },
  },
  scales: {
    x: {
      grid: {
        display: false,
      },
      ticks: {
        color: '#555',
        font: { size: 12, family: 'Arial, sans-serif' },
      },
    },
    y: {
      grid: {
        borderDash: [5, 5],
        color: '#ddd',
      },
      ticks: {
        beginAtZero: true,
        color: '#555',
        font: { size: 12, family: 'Arial, sans-serif' },
      },
    },
  },
};

// Referencia al componente BarChart
const barChart = ref(null);

// Actualizar el gráfico después de montado

</script>

<template>
  <div class="chart-container" style="margin-top: 50px;">
    <Bar :options="chartOptions" :data="chartData" ref="barChart" />
  </div>
</template>

<style scoped>
.chart-container {
  position: relative;
  height: 50vh;
  width: 90vw;
  max-width: 800px;
  margin: auto;
  padding: 20px;
  background: #fff;
  border-radius: 10px;
  box-shadow: 0px 0px 15px rgba(0, 0, 0, 0.1);
}
</style>
