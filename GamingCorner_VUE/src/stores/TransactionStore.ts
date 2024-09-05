import { ref, computed, reactive } from 'vue';
import { defineStore } from 'pinia';
import { useGameStore } from '@/stores/GameStore';
import { useConsoleStore } from '@/stores/ConsoleStore';
import { useProductStore } from '@/stores/ProductStore';


interface Transaction {
  transactionId: number,
  userId: number,
  productId: number,
  videogameId: number | null,
  consoleId: number | null,
  type: string,
  date: Date // Mantén como string para simplificar el manejo de fechas
}

export const useTransactionStore = defineStore('TransactionStore', () => {
  const transactions = reactive(new Array<Transaction>);
  const gameStore = useGameStore();
  const consoleStore = useConsoleStore();
  const productStore = useProductStore();

  async function fetchTransactions() {
    try {
      const response = await fetch('http://gamingcornerapi.retocsv.es/Transaction');
      console.log("Fetch de transacciones hecho desde TransactionStore.ts");
      
      const data = await response.json();
      transactions.splice(0, transactions.length);
      transactions.push(...data);
    } catch (error) {
      console.error('Error al obtener las transacciones:', error);
    }
  }

  const transactionsByMonth = computed(() => {
    const videogameCounts: { [key: string]: number } = {};
    const consoleCounts: { [key: string]: number } = {};
    const productCounts: { [key: string]: number } = {};

    transactions.forEach(transaction => {
      const date = new Date(transaction.date);
      const month = date.toLocaleString('default', { month: 'long' });

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

  async function purchaseGame(idGame: number, idUser: number) {
    debugger
    const response = await fetch('http://gamingcornerapi.retocsv.es/Transaction/compra/user/'+idUser+'/videgame/'+idGame, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    });

    if (response.ok) {
      gameStore.purchaseGame(idGame)
      console.log('compra del juego realizada con exito')

    } else {
        const errorData = await response.json();
    }
}

  async function purchaseProduct(idProducto: number, idUser: number) {
    debugger
    const response = await fetch('http://gamingcornerapi.retocsv.es/Transaction/compra/user/'+idUser+'/product/'+idProducto, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    });

    if (response.ok) {
      productStore.purchaseProduct(idProducto)
      console.log('compra del producto realizada con exito')

    } else {
        const errorData = await response.json();
    }
}

  async function purchaseConsole(idConsole: number, idUser: number) {
    debugger
    const response = await fetch('http://gamingcornerapi.retocsv.es/Transaction/compra/user/'+idUser+'/console/'+idConsole, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    });

    if (response.ok) {
      consoleStore.purchaseConsole(idConsole)
      console.log('compra del producto realizada con exito')

    } else {
        const errorData = await response.json();
    }
}

  return { fetchTransactions, transactionsByMonth, transactions, purchaseGame, purchaseProduct, purchaseConsole };
});
