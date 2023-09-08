<template>
  <section class="py-4">
    <h1 class="headerText">My Calendly</h1>

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
      },
    };
  },
  computed: {},
  methods: {
    getAllEvents() {
      const events = this.$store.getters.getEvents;
      this.calendarOptions.events = events;
      console.log(this.events);
    },
    clickk(en) {
      console.log(en);
    },

    handleSelect(arg) {
      console.log(arg);
      const start = arg.startStr;
      const end = arg.endStr; // Correct the variable name
      const evet = {
        title: "test",
        start,
        end, // Correct the variable name
        allDay: arg.allDay,
        color: "yellow", // an option!
        textColor: "black", // an option!
      };
      this.$store.commit("setEvents", evet);
      this.getAllEvents();
    },
  },
  created() {
    this.getAllEvents();
  },
};
</script>

<style></style>
