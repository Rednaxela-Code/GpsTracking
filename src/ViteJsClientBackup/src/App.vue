<script setup>
import Modal from './components/Modal.vue'
import L from 'leaflet';
import { ref } from 'vue'

const showJsonModal = ref(false)





</script>

<template>
  <div class="header-container">
    <div class="header-content">
      <h1 class="header-title">Modern GPS Tracker</h1>
      <p class="header-subtitle">Track your devices with precision and ease</p>
    </div>
  </div>

  <div class="container">
    <div class="card">
      <h2>Explanation of this SPA</h2>
      <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Error officia iste quaerat molestias earum voluptate
        corporis, officiis doloribus odit deserunt doloremque commodi placeat quibusdam dolores, atque distinctio
        provident adipisci beatae?</p>
    </div>

    <div class="card">
      <h2>Functionality buttons</h2>
      <p>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae placeat, expedita non dignissimos dolore
        earum corporis eaque totam? Enim, ea. Exercitationem perferendis tempora ea excepturi similique rem id.
        Consectetur, sapiente!</p>
      <div class="btn-container">
        <button id="show-modal" @click="showJsonModal = true" class="btn">JSON</button>
        <button class="btn">CSV</button>
        <button class="btn">Manual Input</button>
      </div>

      <Teleport to="body">
        <!-- use the modal component, pass in the prop -->
        <modal :show="showJsonModal" @close="showJsonModal = false">
          <template #header>
            <h3>JSON Input</h3>
          </template>
          <template #body>
            <span>Multiline message is:</span>
            <p style="white-space: pre-line;">{{ message }}</p>
            <textarea v-model="message" placeholder="add GPS JSON"></textarea>
          </template>
        </modal>
      </Teleport>
    </div>

    <div class="card">
      <h2>Plotted route on map</h2>
      <p>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Repudiandae placeat, expedita non dignissimos dolore
        earum corporis eaque totam? Enim, ea. Exercitationem perferendis tempora ea excepturi similique rem id.
        Consectetur,
        sapiente!</p>
      <img class="placeholder-map-img" src="./assets/wmap.jpg" />
    </div>

  </div>
</template>

<style scoped></style>
