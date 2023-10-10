<template>
  <section class="w-3/4 m-auto py-4">
    <h2 class="md:text-3xl text-2xl font-bold text-center py-3 my-4">
      Your Waiting Appointments
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
          <span class="font-bold">Title : </span>{{ event.appointment.title }}
        </h2>
        <h3 class="font-bold">
          <span class="font-bold">Location : </span
          >{{ event.appointment.contactType }}
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
            {{ event.appointment.description }}
          </p>
        </div>

        <div>
          <span class="font-bold">Host : </span>
          <span> {{ event.apiUser.userName }}</span>
        </div>
        <div>
          <span class="font-bold">Guest : </span>
          <span> {{ event.guestData.userName }}</span>
        </div>
        <div>
          <router-link
        
        :to="`/VideoChat/${userId}`"
         class="py-1 px-4 bg-sky-800 text-white rounded-md"
       >
         Start Metting
       </router-link>
        </div>
       
      </div>
    </div>
  </section>
</template>

<script>
export default {
  data() {
    return {
      link: "",
      mood: "",
      events: [],
      isLoading: false,
      error: "",
      updating: false,
      current: 0,
      current: 0,
      userId:'',
    };
  },
  computed(){
   
  },
  methods: {
    async sendEmail(eventId) {
      const payload = {
        meetingLink: this.link,
        eventId: eventId,
      };
      this.isLoading = true;
      try {
        await this.$store.dispatch("calender/sendEmail", payload);
        window.location = this.link;
      } catch (e) {
        this.error = e.message || "failed to get email";
      }
      this.isLoading = false;
    },
    showInput(k) {
      this.current = k;
      this.mood = "showInput";
    },
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
        this.events = bookedEvents.filter(
          (el) => el.appointment.apiUserId === userId
        );
        this.events = this.events.map((el) => {
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
        console.log(this.events);
      } catch (e) {
        this.error = e.message || "failed to get data";
      }
      this.isLoading = false;
    },
  },
  created() {
    this.getEvents();
    this.userId  = this.$store.getters["auth/userId"];
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
