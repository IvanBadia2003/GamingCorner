<script>
import { Bar } from 'vue-chartjs'
import { Chart as ChartJS, Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale } from 'chart.js'
import { useTransactionStore } from '@/stores/TransactionStore'
import { computed } from 'vue'

ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale)

export default {
  name: 'BarChart',
  components: { Bar },
  setup() {
    const transactionStore = useTransactionStore();
    
    // Obtener transacciones y procesarlas
    const transactionsByMonth = computed(() => transactionStore.transactionsByMonth);
    
    return {
      transactionsByMonth,
      chartData: computed(() => ({
        labels: Object.keys(transactionsByMonth.value.productCounts),
        datasets: [
          {
            label: 'Total de Productos',
            backgroundColor: '#FF6384',
            borderColor: '#FF6384',
            borderWidth: 2,
            hoverBackgroundColor: '#FF99A4',
            hoverBorderColor: '#FF6384',
            data: Object.values(transactionsByMonth.value.productCounts),
            borderRadius: 5,
          },
          {
            label: 'Consolas',
            backgroundColor: '#42A5F5',
            borderColor: '#1E88E5',
            borderWidth: 2,
            hoverBackgroundColor: '#64B5F6',
            hoverBorderColor: '#1E88E5',
            data: Object.values(transactionsByMonth.value.consoleCounts),
            borderRadius: 5,
          },
          {
            label: 'Videojuegos',
            backgroundColor: '#66BB6A',
            borderColor: '#43A047',
            borderWidth: 2,
            hoverBackgroundColor: '#81C784',
            hoverBorderColor: '#43A047',
            data: Object.values(transactionsByMonth.value.videogameCounts),
            borderRadius: 5,
          },
        ],
      })),
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
      },
    }
  },
  mounted() {
    this.$nextTick(() => {
      this.$refs.barChart.update();
    });
  },
}
</script>

<template>
  <div class="chart-container">
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
