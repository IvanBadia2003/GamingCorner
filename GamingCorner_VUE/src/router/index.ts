import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import GridView from '../views/GridView.vue'
import LoginView from '../views/LoginView.vue'
import DescriptionView from '../views/DescriptionView.vue'
import AdminView from '../views/AdminView.vue'
import CartView from '../views/CartView.vue'


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
      path: '/description/:id',
      name: 'description',
      component: DescriptionView
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
    }
    ]
})

export default router
