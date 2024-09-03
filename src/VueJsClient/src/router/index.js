import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '../views/HomeView.vue';
import TrackerView from '../views/TrackerView.vue';
import ArticlesView from '../views/ArticlesView.vue';
import NotFoundView from '../components/NotFoundView.vue';
import ArticleView from '../views/ArticleView.vue';

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'home',
            component: HomeView,
        },
        {
            path: '/tracker',
            name: 'tracker',
            component: TrackerView,
        },
        {
            path: '/articles',
            name: 'articles',
            component: ArticlesView,
        },
        {
            path: '/articles/:id',
            name: 'article',
            component: ArticleView,
        },
        {
            path: '/:catchAll(.*)',
            name: 'not-found',
            component: NotFoundView,
        },
    ],
});

export default router;