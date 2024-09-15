<script setup>
import Card from './Card.vue';
</script>

<template>
    <section class="py-4">
    <div class="container-xl lg:container m-auto">
      <div class="grid grid-cols-1 md:grid-cols-2 gap-4 p-4 rounded-lg">

        <Card>
          <h2 class="text-2xl font-bold">For Enthousiasts</h2>
          <p class="mt-2 mb-4">
            Browse our Gps articles today
          </p>
          <RouterLink
            to="/articles/"
            class="inline-block bg-black text-white rounded-lg px-4 py-2 hover:bg-gray-700"
          >
            Browse Articles
          </RouterLink>
        </Card>

        <Card bg="bg-green-100">
          <h2 class="text-2xl font-bold">For Developers</h2>
          <p class="mt-2 mb-4">
            See how to use our API
          </p>
          <RouterLink
            to="/info/"
            class="inline-block bg-green-500 text-white rounded-lg px-4 py-2 hover:bg-green-600"
          >
            See Documentation
          </RouterLink>
        </Card>

      </div>
    </div>
  </section>
</template>