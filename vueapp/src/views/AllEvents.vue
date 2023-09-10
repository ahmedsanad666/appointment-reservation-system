<template>
  <section class="w-3/4 m-auto py-4">
    <h2 class="md:text-3xl text-2xl font-bold text-center py-3 my-4">
      Book An Appointment
    </h2>

    <base-spinner v-if="isLoading"></base-spinner>
    <div
      class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-3 my-7"
      v-else
    >
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
          <span class="font-bold">starts at : </span> {{ event.fullSrtTime }}
        </div>

        <div>
          <span class="font-bold">Duration : </span> {{ event.duration }} Min
        </div>
        <div class="ellipsis-text space-y-2">
          <span class="font-bold">Description</span>
          <p
            @click="toggleText(key)"
            ref="desBox"
            class="bg-slate-100 py-2 px-1 rounded-md"
          >
            {{ event.description }}
          </p>
        </div>
        <div class="">
          <img
            src="../assets/imgs/loading.gif   "
            class="   "
            v-if="updating && current === key"
          />
          <div v-else>
          <button   class=" py-1 px-5 bg-[#96999b] text-white rounded-lg " disabled v-if="event.booked">Booked</button>
            <button
            v-else
              @click="BookEvent(key, event.id, event.apiUser.id)"
              class="border py-1 px-5 bg-[#2980b9] text-white rounded-lg hover:bg-teal-600  cursor-pointer"
            >
              Book Now
            </button>
          </div>
        </div>
        <div>
          <span class="font-bold">Host : </span>
          <span> {{ event.apiUser.userName }}</span>
        </div>
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
      updating: false,
      current: 0,
    };
  },
  methods: {
    toggleText(key) {
      const p = this.$refs.desBox[key];
      if (p.style.overflow === "hidden") {
        p.style.overflow = "visible";
        p.style.whiteSpace = "normal";
        p.style.textOverflow = "inherit";
      } else {
        p.style.overflow = "hidden";
        p.style.whiteSpace = "nowrap";
        p.style.textOverflow = "ellipsis";
      }
    },
    async getEvents() {
      const userId = this.$store.getters["auth/userId"];

      this.isLoading = true;
      try {
        await this.$store.dispatch("calender/eventToBooked");
        await this.$store.dispatch("calender/BookEvent");
        const bookedEvents = this.$store.getters["calender/BookedEvents"];
        this.events = this.$store.getters["calender/EventsToBooked"];
        this.events = this.events.map((el) => {
          const startTime = new Date(el.startTime);
          const endTime = new Date(el.endTime);

          // Extract date components
          const year = startTime.getFullYear();
          const month = startTime.getMonth() + 1; // Months are zero-based (0 = January)
          const day = startTime.getDate();

          // Extract time components
          const hours = startTime.getHours();
          const minutes = startTime.getMinutes();

          const fullSrtTime = `${day}/${month}/${year}-${hours} : ${minutes} Clock`;
          const durationInMilliseconds = endTime - startTime;
          const durationInMinutes = durationInMilliseconds / 60000;

          el.booked = bookedEvents.some((e) => {
            return e.appointmentId === el.id;
          });

          return {
            ...el,
            duration: durationInMinutes,
            fullSrtTime: fullSrtTime,
          };
        });
        this.events = this.events.filter((e) => e.apiUser.id !== userId);
      } catch (e) {
        this.error = e.message || "failed to get data";
      }
      this.isLoading = false;
    },
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
  },
  created() {
    this.getEvents();
  },
};
</script>

<style lang="scss" scoped>
.ellipsis-text p {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  cursor: pointer;
  user-select: none;
  &:hover {
    background: #ccc;
  }
}

img {
  height: 3em;
  width: 3em;
}
</style>
