<template>
  <section class="py-4">
    <h1 class="headerText">My Calendly</h1>
    <h2 class="text-center text-xl font-bold" v-if="error">{{ error }}</h2>

    <div class="container px-4 py-3">
      <FullCalendar :options="calendarOptions" />
    </div>
  </section>
</template>

<script>
import FullCalendar from "@fullcalendar/vue3";
import DayGridPlugin from "@fullcalendar/daygrid";
import TimeGridPlugin from "@fullcalendar/timegrid";
import InteractionPlugin from "@fullcalendar/interaction";
import ListPlugin from "@fullcalendar/list";
export default {
  components: {
    FullCalendar,
  },
  data() {
    return {
      calendarOptions: {
        plugins: [DayGridPlugin, InteractionPlugin, ListPlugin, TimeGridPlugin],
        initialView: "dayGridMonth",
        headerToolbar: {
          left: "title",
          center: "dayGridMonth,timeGridWeek,timeGridDay,listWeek",
          right: "prev today next",
        },
        weekends: false, // initial value
        selectable: true, // Remove quotes
        select: this.handleSelect, // Use handleSelect event
        eventClick: this.clickk,
        events: [],
        error: "",
      },
    };
  },
  computed: {},
  methods: {
    async getEvents() {
      const userId = this.$store.getters["auth/userId"];

      this.isLoading = true;
      try {
        await this.$store.dispatch("calender/UserEvents", userId);
        this.calendarOptions.events = this.$store.getters["calender/AllEvents"];

        this.calendarOptions.events = this.calendarOptions.events.map((el) => {
          const start = el.startTime;
          const end = el.endTime;
          return {
            ...el,
            start: start,
            end: end, 
          };
        });
        console.log(this.calendarOptions.events);
      } catch (e) {
        this.error = e.message || "failed to get data";
      }
      this.isLoading = false;
    },

    clickk(en) {
      console.log(en);
    },

    handleSelect(arg) {
      console.log(arg);
      const start = arg.startStr;
      const end = arg.endStr; // Correct the variable name
    },
  },
  created() {
    this.getEvents();
  },
 
};
</script>

<style></style>
