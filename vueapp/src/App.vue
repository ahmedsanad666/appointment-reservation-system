<template>
  <div class="main">
    <nav-bar />
    <!-- navbar  ff-->

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
    this.$store.dispatch("auth/tryLogin");
  },
};
</script>

<style src="./assets/tailwind.css"></style>
