<script setup>

import { ref, defineProps } from 'vue'
import articleData from '/Dev/GpsTracking/src/VueJsClient/src/assets/articles.json'
import Article from './Article.vue';

defineProps({
    limit: Number,
    showButton: {
        type: Boolean,
        default: false
    }
});

const articles = ref(articleData);
</script>

<template>
    <section class="bg-green-50 px-4 py-10">
      <div class="container-xl lg:container m-auto">
        <h2 class="text-3xl font-bold text-green-500 mb-6 text-center">
          Articles
        </h2>
        <div class="grid grid-cols-1 md:grid-cols-3 gap-6">
           <Article v-for="article in articles.slice(0, limit || articles.length)" :key="article.Id" :article="article" />
        </div>
      </div>
    </section>

    <section v-if="showButton" class="m-auto max-w-lg my-10 px-6">
      <a
        href="/articles/"
        class="block bg-black text-white text-center py-4 px-6 rounded-xl hover:bg-gray-700"
        >View All Articless</a
      >
    </section>
</template>