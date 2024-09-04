import { ref, computed, reactive } from 'vue'
import { defineStore } from 'pinia'

interface Transaction {
  transactionId: number,
  userId: number,
  productId: number,
  videogameId: number | null,
  consoleId: number | null,
  type: string,
  date: string // Mantén como string para simplificar el manejo de fechas
}

export const useTransactionStore = defineStore('TransactionStore', () => {

  const transactions = reactive(new Array<Transaction>);

  async function fetchTransactions() {
    try {
      const response = await fetch('http://localhost:5000/Transaction');
      console.log("Fetch de transacciones hecho desde TransactionStore.ts");
      
      const data = await response.json();
      transactions.splice(0, transactions.length)
      transactions.push(...data);
    } catch (error) {
      console.error('Error al obtener las transacciones:', error);
    }
  }

  // Contar transacciones por mes y tipo
  const transactionsByMonth = computed(() => {
    const videogameCounts: { [key: string]: number } = {};
    const consoleCounts: { [key: string]: number } = {};
    const productCounts: { [key: string]: number } = {};

    transactions.forEach(transaction => {
      const date = new Date(transaction.date);
      const month = date.toLocaleString('default', { month: 'long' });

      // Cuenta productos basados en productId, sin importar si son videojuegos o consolas
      productCounts[month] = (productCounts[month] || 0) + 1;

      if (transaction.videogameId !== null) {
        videogameCounts[month] = (videogameCounts[month] || 0) + 1;
      }
      if (transaction.consoleId !== null) {
        consoleCounts[month] = (consoleCounts[month] || 0) + 1;
      }
    });

    return { videogameCounts, consoleCounts, productCounts };
  });

  return { fetchTransactions, transactionsByMonth, transactions }
});
