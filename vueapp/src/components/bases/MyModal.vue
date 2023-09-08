<!-- MyModal.vue -->
<template>
    <div>
      <h2>{{ title }}</h2>
      <p>{{ content }}</p>
      <button @click="closeModal">Close</button>
    </div>
  </template>
  
  <script>
  export default {
    props: {
      title: String,
      content: String,
    },
    methods: {
      closeModal() {
        this.$modal.hide('my-modal'); // Hide the modal when the close button is clicked
      },
    },
  };
  </script>
  