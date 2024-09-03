<script setup>
import { ref, defineProps, onMounted, reactive } from 'vue'
import Article from './Article.vue';
import { RouterLink } from 'vue-router';
import PulseLoader from 'vue-spinner/src/PulseLoader.vue'
import axios from 'axios';

defineProps({
    limit: Number,
    showButton: {
        type: Boolean,
        default: false
    }
});

const state = reactive({
  articles: [],
  isLoading: true
});

onMounted(async () => {
  try {
    const response = await axios.get('http://localhost:5500/articles');
    state.articles = response.data;
  } catch (error) {
    console.error('Error fetching articles', error);
  } finally {
    state.isLoading = false;
  }
});
</script>

<template>
    <section class="bg-green-50 px-4 py-10">
      <div class="container-xl lg:container m-auto">
        <h2 class="text-3xl font-bold text-green-500 mb-6 text-center">
          Articles
        </h2>
        <div v-if="state.isLoading" class="text-center text-gray-500 py-6"><PulseLoader /></div>
        <div v-if="!state.isLoading" class="grid grid-cols-1 md:grid-cols-3 gap-6">
           <Article v-for="article in state.articles.slice(0, limit || state.articles.length)" :key="article.Id" :article="article" />
        </div>
      </div>
    </section>

    <section v-if="showButton" class="m-auto max-w-lg my-10 px-6">
      <RouterLink
        to="/articles/"
        class="block bg-black text-white text-center py-4 px-6 rounded-xl hover:bg-gray-700"
        >View All Articless</RouterLink>
    </section>
</template>