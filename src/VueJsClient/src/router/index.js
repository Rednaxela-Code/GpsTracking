import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '../views/HomeView.vue';
import ArticlesView from '../views/ArticlesView.vue';
import AddArticleView from '../views/AddArticleView.vue';
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
            path: '/articles',
            name: 'articles',
            component: ArticlesView,
        },
        {
            path: '/article/add',
            name: 'articleAdd',
            component: AddArticleView,
        },
        {
            path: '/article/:id',
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