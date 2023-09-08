<template>
  <section class="py-3 min-h-screen">
    <div class="md:w-[70%] w-3/4 m-auto px-7 py-5">
      <div class="flex justify-between border-b-2 border-gray-500 py-2">
        <h2 class="md:text-3xl text-2xl font-bold">MyBrand</h2>
        <router-link
          class="border rounded-full py-3 px-4 bg-[#1b679a] text-white"
          :to="(name = 'CreateEvent')"
        >
          <font-awesome-icon :icon="['fas', 'plus']" class="mx-1" />
          New Appointment
        </router-link>
      </div>
      <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-3 my-7 ">
        <div
          v-for="(event, key) in events"
          :key="key"
          class="border py-4 px-3 rounded-lg shadow-lg flex flex-col space-y-3"
        >
          <h2 class="text-slate-800">
            <span class="font-bold">Title : </span>{{ event.title }}
          </h2>
          <h3 class="font-bold">
            {{ event.contactType }} :
            <span v-if="event.contactType === 'phone'">
              {{ event.location }}</span
            >
            <span v-else>
              <a class="text-[#2980b9]" :href="event.location">
                Event Link</a
              ></span
            >
          </h3>
          <div>
            <span class="font-bold">Duration : </span> {{ event.duration }} Min
          </div>
          <div class="py-4 my-2">
            <router-link class="border py-1 px-5 border-[#2980b9] rounded-lg  hover:bg-slate-300" to="/"
              >More details</router-link
            >
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  data() {
    return {
      isLoading: false,
      events: [],
    };
  },
  computed: {},
  methods: {
    getEvents() {
      const userId = this.$store.getters["auth/userId"];
      const evets = this.$store.getters["calender/AllEvents"];
      this.events = evets.filter((e) => e.userId === userId);
      this.events = this.events.map((el) => {
        const startTime = new Date(el.start);
        const endTime = new Date(el.end);

        const durationInMilliseconds = endTime - startTime;
        const durationInMinutes = durationInMilliseconds / 60000;

        return {
          ...el,
          duration: durationInMinutes,
        };
      });
      console.log(this.events);
    },
  },

  created() {
    this.getEvents();
  },
};
</script>

<style></style>
