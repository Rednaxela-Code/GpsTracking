import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '../views/HomeView.vue';
import InfoView from '../views/InfoView.vue';
import TrackerView from '../views/TrackerView.vue';

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'home',
            component: HomeView,
        },
        {
            path: '/info',
            name: 'info',
            component: InfoView,
        },
        {
            path: '/tracker',
            name: 'tracker',
            component: TrackerView,
        },
    ],
});

export default router;