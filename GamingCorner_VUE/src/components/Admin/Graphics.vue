<script>
import { Bar } from 'vue-chartjs'
import { Chart as ChartJS, Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale } from 'chart.js'

ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale)

export default {
  name: 'BarChart',
  components: { Bar },
  data() {
    return {
      chartData: {
        labels: ['January', 'February', 'March'],
        datasets: [
          {
            label: 'Consolas',
            backgroundColor: '#42A5F5', // Color de las barras
            borderColor: '#1E88E5', // Color del borde de las barras
            borderWidth: 2,
            hoverBackgroundColor: '#64B5F6', // Color de las barras al pasar el mouse
            hoverBorderColor: '#1E88E5', // Color del borde de las barras al pasar el mouse
            data: [40, 20, 12],
            borderRadius: 5, // Esquinas redondeadas
          },
          {
            label: 'Videojuegos',
            backgroundColor: '#42A5F5', // Color de las barras
            borderColor: '#1E88E5', // Color del borde de las barras
            borderWidth: 2,
            hoverBackgroundColor: '#64B5F6', // Color de las barras al pasar el mouse
            hoverBorderColor: '#1E88E5', // Color del borde de las barras al pasar el mouse
            data: [40, 20, 12],
            borderRadius: 5, // Esquinas redondeadas
          },
        ],
      },
      chartOptions: {
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
              color: '#333', // Color del texto de la leyenda
            },
          },
          tooltip: {
            backgroundColor: '#333', // Fondo del tooltip
            titleFont: { size: 16, family: 'Arial, sans-serif' },
            bodyFont: { size: 14, family: 'Arial, sans-serif' },
            padding: 10,
            displayColors: false,
          },
        },
        scales: {
          x: {
            grid: {
              display: false, // Oculta la línea de la cuadrícula en el eje X
            },
            ticks: {
              color: '#555', // Color de las etiquetas del eje X
              font: { size: 12, family: 'Arial, sans-serif' },
            },
          },
          y: {
            grid: {
              borderDash: [5, 5], // Líneas de cuadrícula con guiones
              color: '#ddd',
            },
            ticks: {
              beginAtZero: true,
              color: '#555', // Color de las etiquetas del eje Y
              font: { size: 12, family: 'Arial, sans-serif' },
            },
          },
        },
      },
    }
  },
}
</script>

<template>
  <div class="chart-container">
    <Bar :options="chartOptions" :data="chartData" />
  </div>
</template>

<style scoped>
.chart-container {
  position: relative;
  height: 50vh; /* Ajusta la altura del gráfico según el viewport */
  width: 90vw; /* Ajusta el ancho del gráfico según el viewport */
  max-width: 800px; /* Máximo ancho del gráfico */
  margin: auto; /* Centra el gráfico horizontalmente */
  padding: 20px;
  background: #fff;
  border-radius: 10px;
  box-shadow: 0px 0px 15px rgba(0, 0, 0, 0.1);
}
</style>
