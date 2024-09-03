<script setup>
import Hero from '/Dev/GpsTracking/src/VueJsClient/src/components/Hero.vue';
import HomeCards from '/Dev/GpsTracking/src/VueJsClient/src/components/HomeCards.vue';
import Articles from '../components/Articles.vue';
</script>

<template>
<Hero />
<HomeCards />
<Articles :limit="3" :showButton="true"/>
</template>