import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import GridView from '../views/GridView.vue'
import LoginView from '../views/LoginView.vue'
import DescriptionView from '../views/DescriptionView.vue'
import ProfileView from '../views/ProfileView.vue'
import AdminView from '../views/AdminView.vue'
import { useUserStore } from '../stores/UserStore'; // Importa el store de autenticación


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
      path: '/description',
      name: 'description',
      component: DescriptionView
    },
    {
      path: '/profile',
      name: 'profile',
      component: ProfileView
    },
    {
      path: '/admin',
      name: 'admin',
      component: AdminView
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
