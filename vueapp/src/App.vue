<template>
  <div class="main">
    <nav-bar />
    <!-- navbar -->

    <router-view />
    <!-- . footer -->
  </div>
</template>

<script>
import { initFlowbite } from "flowbite";
import NavBar from "./components/layout/NavBar.vue";
export default {
  components: { NavBar },

  watch: {
    $route(to, from) {
      initFlowbite();
    },
  },
  mounted() {
    initFlowbite();
  },
};
</script>

<style src="./assets/tailwind.css"></style>
