import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import GridView from '../views/GridView.vue'
import LoginView from '../views/LoginView.vue'
import DescriptionView from '../views/DescriptionView.vue'

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
    }
    ]
})

export default router
