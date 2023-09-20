<template>
  <section class="min-h-screen my-7 py-4">
    <div
      class="flex border rounded-lg my-2 py-4 px-5 shadow-md shadow-current md:w-[60%] w-3/4 m-auto h-[70vh]"
    >
      <div class="py-6 px-3 w-1/2 border-r">
        <h1>Host : {{ host }}</h1>
        <h1>Title : {{ title }}</h1>
        <h1>Location : {{ location }}</h1>
        <h1>Duration : {{ duration }} min</h1>
      </div>
      <div class="w-1/2 py-4 overflow-scroll">
        <h1 class="text-center md:text-2xl text-xl font-bold">Choose Time</h1>

        <ul class="px-4 my-5 flex flex-col gap-4">
          <li v-for="(el, k) in events" :key="k" class="  text-center">
            <img
              src="../assets/imgs/loading.gif   "
              class="   "
              v-if="updating && current === key"
            />
            <button
              v-if="el.booked"
              class="py-1 px-5 bg-[#96999b] text-white rounded-lg"
              disabled
            >
              {{ showTime(el.startTime).date }} at
              {{ showTime(el.startTime).time }}
            </button>
            <button
              class="border w-3/4 py-1 m-auto text-center rounded-md cursor-pointer hover:bg-blue-700"
              v-else
              @click="BookEvent(key, el.id, el.apiUser.id)"
            >
              {{ showTime(el.startTime).date }} at
              {{ showTime(el.startTime).time }}
            </button>
          </li>
        </ul>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  data() {
    return {
      events: [],
      isLoading: false,
      error: "",
      title: "",
      location: "",
      duration: "",
      host: "",
      updating: false,
      current: 0,
    };
  },
  methods: {
    async BookEvent(key, eventId, host) {
      this.current = key;
      this.updating = true;

      const gest = this.$store.getters["auth/userId"];
      const payload = {
        apiUserId: host,
        guestId: gest,
        appointmentId: eventId,
      };
      try {
        await this.$store.dispatch("calender/AddBookedEvent", payload);
        this.getEvents();
      } catch (e) {
        alert(e.message || "filed to send ");
      }
      this.current = 0;
      this.updating = false;
    },
    showTime(el) {
      // const date = el.substring(0,10);
      // const time = el.substring(10,15);
      // return {date,time}
      const data = el.split("T");
      console.log(data[0]);

      return {
        date: data[0],
        time: data[1],
      };
    },
    async getEvents() {
      this.isLoading = true;
      const id = this.$route.params.eventId;
      try {
        await this.$store.dispatch("calender/eventToBooked");
        this.events = this.$store.getters["calender/EventsToBooked"];
        // ..............
        await this.$store.dispatch("calender/BookEvent");
        const bookedEvents = this.$store.getters["calender/BookedEvents"];
        this.events = this.events.filter((el) => el.customId == id);

        this.events = Object.values(this.events);

        this.host = this.events[0].apiUser.userName;
        this.location = this.events[0].contactType;

        this.title = this.events[0].title;

        this.events = this.events.map((el) => {
          el.booked = bookedEvents.some((e) => {
            return e.appointmentId === el.id;
          });
          return {
            ...el,
          };
        });

        console.log(this.events);

        const startTime = new Date(this.events[0].startTime);
        const endTime = new Date(this.events[0].endTime);

        const durationInMilliseconds = endTime - startTime;
        this.duration = durationInMilliseconds / 60000;
      } catch (e) {
        this.error = e.message || "failed to get data";
      }
      this.isLoading = false;
    },
  },
  created() {
    this.getEvents();
  },
};
</script>

<style lang="scss" scoped>
img {
  height: 3em;
  width: 3em;
}
</style>
