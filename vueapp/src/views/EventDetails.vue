<template>
  <section class="min-h-screen py-4">
    <div
      class="lg:w-1/2 md:w-[80%] w-[93%] border rounded-lg shadow-current shadow-lg py-3 px-4 m-auto h-[70vh]"
    >
      <h1 class="my-4 py-5 text-center md:text-3xl text-xl">
        Appointment Detials
      </h1>
      <div class="space-y-4">
        <div>Title : {{ event.title }}</div>
        {{ event.contactType }} :
          <span v-if="event.contactType === 'phone'">
            {{ event.location }}</span
          >
          <span v-else>
            <a class="text-[#2980b9]" :href="event.location">
              Event Link</a
            ></span
          >
        <div>
          <span class="font-bold">Description</span>
          <br />
          <p>{{ event.description }}</p>
        </div>
        <div class="flex gap-4">
          <span> start at : {{ event.startTime }}</span>
          <span> End at: {{ event.endTime }}</span>
        </div>
       
      </div>
    </div>
  </section>
</template>

<script>
export default {
  data() {
    return {
      event: [],
      error: "",
    };
  },
  methods: {
    async getEvent() {
      const userId = this.$store.getters["auth/userId"];
      const id = +this.$route.params.id;
      this.isLoading = true;
      try {
        await this.$store.dispatch("calender/UserEvents", userId);
        const events = this.$store.getters["calender/AllEvents"];
        const all = events.map((el) => {
          const startTime = new Date(el.startTime);
          const endTime = new Date(el.endTime);

          const durationInMilliseconds = endTime - startTime;
          const durationInMinutes = durationInMilliseconds / 60000;

          return {
            ...el,
            duration: durationInMinutes,
          };
        });

        this.event = all.find((e) => e.id == id);
        console.log(this.event);
      } catch (e) {
        this.error = e.message || "failed to get data";
        console.log("fi");
      }
      this.isLoading = false;
    },
  },
  created() {
    this.getEvent();
  },
};
</script>

<style></style>
