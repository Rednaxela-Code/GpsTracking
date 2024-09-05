<script setup>
import { reactive } from 'vue';
import router from '/Dev//GpsTracking/src/VueJsClient/src/router';
import { useToast } from 'vue-toastification';
import axios from 'axios';

const currentDateTime = reactive(new Date().toLocaleString());

const form = reactive({
  id: '',
  name: '',
  author: '',
  datePublished: '',
  subject: '',
  content: '',
  category: '',
  authorDescription: '',
  authorEmail: ''
});

const toast = useToast();

const handleSubmit = async () => {
  const newArticle = {
    name: form.name,
  author: form.author,
  // datePublished: currentDateTime,
  subject: form.subject,
  content: form.content,
  category: form.category,
  authorDescription: form.authorDescription,
  authorEmail: form.authorEmail
  };

  try {
    const url = 'http://localhost:5219/api/Article/single/';
    console.log(url);
    const response = await axios.post(url, newArticle);
    toast.success('Article Posted');
    console.log(response.data.id);
    router.push(`/articles/`);
  } catch (error) {
    console.error('Error posting article', error);
  } finally {
  }
};
</script>

<template>
    <section class="bg-green-50">
      <div class="container m-auto max-w-2xl py-24">
        <div
          class="bg-white px-6 py-8 mb-4 shadow-md rounded-md border m-4 md:m-0"
        >
          <form @submit.prevent="handleSubmit">
            <h2 class="text-3xl text-center font-semibold mb-6">Add Article</h2>

            <div class="mb-4">
              <label class="block text-gray-700 font-bold mb-2"
                >Article Name</label
              >
              <input
                type="text"
                id="name"
                name="name"
                v-model="form.name"
                class="border rounded w-full py-2 px-3 mb-2"
                placeholder="Everything you need to know about GpsTracker"
                required
              />
            </div>
            <div class="mb-4">
              <label class="block text-gray-700 font-bold mb-2"
                >Subject</label
              >
              <input
                type="text"
                id="subject"
                name="subject"
                v-model="form.subject"
                class="border rounded w-full py-2 px-3 mb-2"
                placeholder="Everything you need to know about GpsTracker"
                required
              />
            </div>
            <div class="mb-4">
              <label
                for="content"
                class="block text-gray-700 font-bold mb-2"
                >Content</label
              >
              <textarea
                id="content"
                name="content"
                v-model="form.content"
                class="border rounded w-full py-2 px-3"
                rows="6"
                placeholder="Add any job duties, expectations, requirements, etc"
              ></textarea>
            </div>

            <div class="mb-4">
              <label class="block text-gray-700 font-bold mb-2">
                Category
              </label>
              <input
                type="text"
                id="category"
                name="category"
                v-model="form.category"
                class="border rounded w-full py-2 px-3 mb-2"
                placeholder="Science"
                required
              />
            </div>

            <h3 class="text-2xl mb-5">Author Info</h3>

            <div class="mb-4">
              <label for="author" class="block text-gray-700 font-bold mb-2"
                >Name</label
              >
              <input
                type="text"
                id="author"
                name="author"
                v-model="form.author"
                class="border rounded w-full py-2 px-3"
                placeholder="Name"
              />
            </div>

            <div class="mb-4">
              <label
                for="company_description"
                class="block text-gray-700 font-bold mb-2"
                >Description</label
              >
              <textarea
                id="company_description"
                name="company_description"
                v-model="form.authorDescription"
                class="border rounded w-full py-2 px-3"
                rows="2"
                placeholder="Who are you? What do you do?"
              ></textarea>
            </div>

            <div class="mb-4">
              <label
                for="contact_email"
                class="block text-gray-700 font-bold mb-2"
                >Contact Email</label
              >
              <input
                type="email"
                id="contact_email"
                name="contact_email"
                v-model="form.authorEmail"
                class="border rounded w-full py-2 px-3"
                placeholder="Email address for administrational purposses."
                required
              />
            </div>

            <div>
              <button
                class="bg-green-500 hover:bg-green-600 text-white font-bold py-2 px-4 rounded-full w-full focus:outline-none focus:shadow-outline"
                type="submit"
              >
                Add Article
              </button>
            </div>
          </form>
        </div>
      </div>
    </section>
</template>