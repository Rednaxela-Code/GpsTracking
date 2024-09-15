<script setup>
import PulseLoader from 'vue-spinner/src/PulseLoader.vue'
import BackButton from '../components/BackButton.vue';
import { reactive, onMounted } from 'vue';
import { useRoute, RouterLink} from 'vue-router';
import router from '/Dev//GpsTracking/src/VueJsClient/src/router';
import { useToast } from 'vue-toastification';
import axios from 'axios';

const route = useRoute();
const articleId = route.params.id;

const toast = useToast();

const state = reactive({
  Article: {},
  isLoading: true,
});

onMounted(async () => {
  try {
    const url = `	http://localhost:5219/api/Article/${articleId}`;
    const response = await axios.get(url);
    state.Article = response.data;
  } catch (error) {
    console.error('Error fetching article', error);
  } finally {
    state.isLoading = false;
  }
});

const onDelete = async () => {
  state.isLoading = true;
  try {
    const url = `http://localhost:5219/api/Article/${articleId}`;
    const response = await axios.delete(url);
    router.push(`/articles/`);
    toast.success('Article Deleted');
  } catch (error) {
    console.error('Error deleting article', error);
    toast.error('Error Deleting Article');
  } finally {
    state.isLoading = false;
  }
};
</script>

<template>
  <BackButton />
    <section v-if="!state.isLoading" class="bg-green-50">
      <div class="container m-auto py-10 px-6">
        <div class="grid grid-cols-1 md:grid-cols-70/30 w-full gap-6">
          <main>
            <div
              class="bg-white p-6 rounded-lg shadow-md text-center md:text-left"
            >
              <h1 class="text-3xl font-bold mb-4">{{ state.Article.name }}</h1>
              <div class="text-gray-500 mb-4">{{ state.Article.datePublished }}</div>
              <div class="text-gray-500 mb-4 flex align-middle justify-center md:justify-start">
                <p class="text-orange-700">{{state.Article.author}}</p>
              </div>
            </div>

            <div class="bg-white p-6 rounded-lg shadow-md mt-6">
              <p class="mb-4">
                {{state.Article.content}}
              </p>
              <br />
              <p class="mb-4">
                {{state.Article.content}}
              </p>
              <br />
              <p class="mb-4">
                {{state.Article.content}}
              </p>
              <br />
              <p class="mb-4">
                {{state.Article.content}}
              </p>
              <br />
              <p class="mb-4">
                {{state.Article.content}}
              </p>
              <br />
              <p class="mb-4">
                {{state.Article.content}}
              </p>
              <br />
            </div>
          </main>

          <aside>
            <div class="bg-white p-6 rounded-lg shadow-md">
              <h3 class="text-xl font-bold mb-6">Author Info</h3>

              <h2 class="text-2xl">{{state.Article.author}}</h2>

              <p class="my-2">
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Accusantium debitis corporis officiis enim aspernatur provident facere officia tempora, sit ab? Explicabo, dolor. Similique enim est rerum quo harum doloribus deserunt.
              </p>

              <hr class="my-4" />

              <h3 class="text-xl">Contact:</h3>

              <p class="my-2 bg-green-100 p-2 font-bold">
                contact@newteksolutions.com
              </p>
            </div>

            <div class="bg-white p-6 rounded-lg shadow-md mt-6">
              <h3 class="text-xl font-bold mb-6">Manage Article</h3>
              <RouterLink
                :to="`/article/edit/${state.Article.id}`"
                class="bg-green-500 hover:bg-green-600 text-white text-center font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block"
                >Edit Article
                </RouterLink>
              <button class="bg-red-500 hover:bg-red-600 text-white font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline mt-4 block" @click="onDelete">
                Delete Article
              </button>
            </div>
          </aside>
        </div>
      </div>
    </section>
    <div v-if="state.isLoading" class="text-center text-gray-500 py-6"><PulseLoader /></div>
</template>