import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import GridView from '../views/GridView.vue'
import LoginView from '../views/LoginView.vue'
import DescriptionGameView from '../views/DescriptionGameView.vue'
import DescriptionConsoleView from '../views/DescriptionConsoleView.vue'
import AdminView from '../views/AdminView.vue'
import CartView from '../views/CartView.vue'
import ProfileView from '../views/ProfileView.vue'
import BuyView from '../views/BuyView.vue'
import { useUserStore } from '../stores/UserStore';



const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/grid',
      name: 'grid',
      component: GridView
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView
    },
    {
      path: '/description-console/:id',
      name: 'description-console',
      component: DescriptionConsoleView
    },
    {
      path: '/description-game/:id',
      name: 'description-game',
      component: DescriptionGameView
    },
    {
      path: '/admin',
      name: 'admin',
      component: AdminView
    },
    {
      path: '/cart',
      name: 'cart',
      component: CartView
    },
    {
      path: '/profile',
      name: 'profile',
      component: ProfileView
    },
    {
      path: '/purchase',
      name: 'purchase',
      component: BuyView
    }
    ]
})

  router.beforeEach((to, from, next) => {
  const userStore = useUserStore();
  
  // Verificar si la ruta es la página de inicio de sesión y si el usuario está autenticado
  if (to.name === 'login' && userStore.user.isAuthenticated) {
      // Si el usuario ya está autenticado y trata de acceder a la página de inicio de sesión, redirigir a la página de administración
      next('/profile');
  } else if (to.name === 'profile' && !userStore.user.isAuthenticated) {
      // Si el usuario no está autenticado y trata de acceder a la página de administración, redirigir a la página de inicio de sesión
      next('/login');
  } else {
      // Permitir que la navegación continúe según la lógica actual
      next();
  }
});  

export default router
