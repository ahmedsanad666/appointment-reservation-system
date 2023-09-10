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
      <h2 class="text-center text-xl font-bold" v-if="error">{{ error }}</h2>

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
            <span class="font-bold">Duration : </span> {{ event.duration }} Min
          </div>
          <div class="py-4 my-2">
            <router-link
              class="border py-1 px-5 border-[#2980b9] rounded-lg hover:bg-slate-300"
              :to="`/EvetnDetails/${event.id}`"
              >More details</router-link
            >
          </div>
        </div>
      </div>
      <hr />
      <div>
        <h2 class="my-2 md:text-xl font-bold tracking-wider">
          Your Booked Appointments
        </h2>
        <base-spinner v-if="isLoading"></base-spinner>
        <div
          class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-3 my-7"
          v-else
        >
          <div
            v-for="(event, key) in BookedAppointments"
            :key="key"
            class="border py-4 px-3 rounded-lg shadow-lg flex flex-col space-y-3"
          >
            <h2 class="text-slate-800">
              <span class="font-bold">Title : </span
              >{{ event.appointment.title }}
            </h2>
            <h3 class="font-bold">
              {{ event.appointment.contactType }} :
              <span v-if="event.appointment.contactType === 'phone'">
                {{ event.appointment.location }}</span
              >
              <span v-else>
                <a class="text-[#2980b9]" :href="event.appointment.location">
                  Event Link</a
                ></span
              >
            </h3>
            <div>
              <span class="font-bold">starts at : </span>
              {{ event.fullSrtTime }}
            </div>

            <div>
              <span class="font-bold">Duration : </span>
              {{ event.duration }} Min
            </div>
            <div class="ellipsis-text space-y-2">
              <span class="font-bold">Description</span>
              <p
                @click="toggleText(key)"
                ref="desBox"
                class="bg-slate-100 py-2 px-1 rounded-md"
              >
                {{ event.appointment.description }}
              </p>
            </div>

            <div>
              <span class="font-bold">Host : </span>
              <span> {{ event.apiUser.userName }}</span>
            </div>
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
      error: "",
      BookedAppointments: [],
    };
  },
  computed: {},
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
        await this.$store.dispatch("calender/BookEvent");
        const bookedEvents = this.$store.getters["calender/BookedEvents"];
        this.BookedAppointments = bookedEvents.filter(
          (e) => e.guestId === userId
        );
        this.BookedAppointments = this.BookedAppointments.map((el) => {
          const startTime = new Date(el.appointment.startTime);
          const endTime = new Date(el.appointment.endTime);
          const year = startTime.getFullYear();
          const month = startTime.getMonth() + 1; // Months are zero-based (0 = January)
          const day = startTime.getDate();

          // Extract time components
          const hours = startTime.getHours();
          const minutes = startTime.getMinutes();

          const fullSrtTime = `${day}/${month}/${year}-${hours} : ${minutes} Clock`;
          const durationInMilliseconds = endTime - startTime;
          const durationInMinutes = durationInMilliseconds / 60000;
          return {
            ...el,
            duration: durationInMinutes,
            fullSrtTime: fullSrtTime,
          };
        });
        console.log(this.BookedAppointments);
        // ........
        await this.$store.dispatch("calender/UserEvents", userId);
        this.events = this.$store.getters["calender/AllEvents"];

        this.events = this.events.map((el) => {
          const startTime = new Date(el.startTime);
          const endTime = new Date(el.endTime);

          const durationInMilliseconds = endTime - startTime;
          const durationInMinutes = durationInMilliseconds / 60000;

          return {
            ...el,
            duration: durationInMinutes,
          };
        });
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
</style>
