<script setup>
import { RouterLink, useRoute } from "vue-router";
import logo from "/Dev/GpsTracking/src/VueJsClient/src/assets/vue.svg";

const isActiveLink = (routePath) => {
  const route = useRoute();
  return route.path === routePath;
};
</script>

<template>
  <nav class="bg-green-700 border-b border-green-500">
    <div class="mx-auto max-w-7xl px-2 sm:px-6 lg:px-8">
      <div class="flex h-20 items-center justify-between">
        <div class="flex flex-1 items-center justify-center md:items-stretch md:justify-start">
          <!-- Logo -->
          <img class="h-10 w-auto" :src="logo" alt="Logo" />
          <RouterLink class="flex flex-shrink-0 items-center mr-4" to="/">
            <span class="hidden md:block text-white text-2xl font-bold ml-2">Gps Tracker</span>
          </RouterLink>
          <!-- Links -->
          <div class="md:ml-auto">
            <div class="flex space-x-2">
              <RouterLink
                to="/"
                :class="[
                  isActiveLink('/')
                    ? 'bg-green-900'
                    : 'hover:bg-gray-900 hover:text-white',
                  'text-white',
                  'px-3',
                  'py-2',
                  'rounded-md',]">
                  Home
                </RouterLink>

              <RouterLink
                to="/info"
                :class="[
                  isActiveLink('/info')
                    ? 'bg-green-900'
                    : 'hover:bg-gray-900 hover:text-white',
                  'text-white',
                  'px-3',
                  'py-2',
                  'rounded-md',]">
                  Info
                  </RouterLink>

              <RouterLink
                to="/tracker"
                :class="[
                  isActiveLink('/tracker')
                    ? 'bg-green-900'
                    : 'hover:bg-gray-900 hover:text-white',
                  'text-white',
                  'px-3',
                  'py-2',
                  'rounded-md',]">
                  Tracker
                  </RouterLink>

                  <RouterLink
                to="/articles"
                :class="[
                  isActiveLink('/articles')
                    ? 'bg-green-900'
                    : 'hover:bg-gray-900 hover:text-white',
                  'text-white',
                  'px-3',
                  'py-2',
                  'rounded-md',]">
                  Articles
                  </RouterLink>

            </div>
          </div>
        </div>
      </div>
    </div>
  </nav>
</template>
