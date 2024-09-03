<script setup>
import { ref, computed } from 'vue';
import { RouterLink } from 'vue-router';

const props = defineProps({ 
    article: {
        type: Object,
    },
});

const showFullContent = ref(false);

const toggleContent = () => {
  showFullContent.value = !showFullContent.value;
}

const truncatedContent = computed(() => {
  let content = props.article.content;
  if (!showFullContent.value){
    content = content.substring(0, 90) + '...';
}
return content;
});
</script>

<template>
     <div v-if="article" class="bg-white rounded-xl shadow-md relative">
            <div class="p-4">
              <div class="mb-6">
                  <h3 class="text-xl font-bold">{{ article.name }}</h3>
                  <div class="text-gray-600 my-2">{{ article.datePublished }}</div>
              </div>

              <div class="mb-5">
                <div>
                  {{ truncatedContent }}
                </div>
                <button @click="toggleContent" class="text-green-500 hover:text-green-60 mb-5">
                  {{ showFullContent ? "more" : "less" }}
                </button>
              </div>

              <h3 class="text-green-500 mb-2"> {{ article.author }} </h3>

              <div class="border border-gray-100 mb-5"></div>

              <div class="flex flex-col lg:flex-row justify-between mb-4">
                <div class="text-orange-700 mb-3">
                  <i class="pi pi-receipt text-lg"></i>
                  {{ article.subject }}
                </div>
                <RouterLink
                  :to="'/article/' + article.id"
                  class="h-[36px] bg-green-500 hover:bg-green-600 text-white px-4 py-2 rounded-lg text-center text-sm"
                >
                  Read More
                </RouterLink>
              </div>
            </div>
        </div>
</template>