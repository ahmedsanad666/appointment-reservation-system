<template>
  <section class="min-h-screen py-4">
    <div
      class="md:w-3/4 lg:w-1/2 border w-[95%] m-auto py-8 my-3 px-4 rounded-xl shadow-md shadow-current"
    >
      <h1
        class="py-3 my-2 md:text-2xl text-xl font-bold text-teal-600 text-center"
      >
        Add new Appointment
      </h1>
      <h2 class="text-center text-xl font-bold" v-if="error">{{ error }}</h2>
      <base-spinner v-if="isLoading"> </base-spinner>
      <form @submit.prevent="submitData" v-else class="space-y-3">
        <div class="controller">
          <label for="title">Title</label>
          <input
            type="text"
            v-model.trim="title"
            placeholder="title"
            required=""
          />
        </div>
        <div class="controller">
          <label for="des">Description</label>
          <textarea
            placeholder="description"
            v-model.trim="description"
            class="w-full"
            required=""
          ></textarea>
        </div>
        <div class="controller">
          <label for="contactType">contact Type</label>
          <select id="contactType" v-model.trim="selectedContactType">
            <option
              v-for="(type, key) in contactTypes"
              :key="key"
              :value="type"
            >
              {{ type }}
            </option>
          </select>
        </div>

        <div class="controller">
          <label for="start">Start Date</label>
          <input type="date" id="start" v-model="startDate" required="" />
        </div>

        <div class="controller">
          <label for="end">End Date</label>
          <input type="date" id="end" v-model="endDate" required="" />
        </div>
        <div class="controller">
          <label for="start">Start Time</label>
          <input type="time" id="start" v-model="startTime" required="" />
        </div>
        <div class="controller">
          <label for="end">End Time</label>
          <input type="time" id="end" v-model="endTime" required="" />
        </div>
        <div class="my-3 py-3">
          <label class="availability-form__label">Days Available:</label>
          <div class="flex gap-6 flex-wrap">
            <label
              v-for="(day, index) in days"
              :key="index"
              class="availability-form__day-label cursor-pointer"
            >
              <input
                type="checkbox"
                v-model="selectedDays"
                :value="day"
                class="availability-form__day-checkbox cursor-pointer"
              />{{ day }}
            </label>
          </div>
        </div>
        <button
          type="submit"
          class="py-1 px-6 bg-gray-600 text-white rounded-lg hover:bg-slate-500"
        >
          Submit
        </button>
      </form>
    </div>
  </section>
</template>

<script>
export default {
  data() {
    return {
      days: [
        "Sunday",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday",
      ],
      contactTypes: ["phone", "zoom", "googleMeet"],
      //.... event data
      selectedDays: [],
      title: "",
      selectedContactType: "zoom",
      description: "",
      startDate: "",
      endDate: "",
      startTime: "",
      endTime: "",
      isLoading: false,
      error: "",
      events: [],
      customId: new Date().getTime(),
    };
  },
  methods: {
    async submitData() {
      const userId = this.$store.getters["auth/userId"];
      const payload = {
        title: this.title,
        contactType: this.selectedContactType,
        description: this.description,
        startTime: this.startTime, //
        endTime: this.endTime, //
        apiUserId: userId,
      };

      console.log(this.selectedDays);
      const startDate = new Date(this.startDate);
      const endDate = new Date(this.endDate);

      while (startDate <= endDate) {
        const eventDate = new Date(startDate);
        const dayName = this.days[startDate.getDay()];
        if (this.selectedDays.includes(dayName)) {
          const event = {
            customId: this.customId +  "",
            title: this.title,
            contactType: this.selectedContactType,
            description: this.description,
            startTime:
              eventDate.toISOString().split("T")[0] + `T${this.startTime}:00`, //
            endTime:
              eventDate.toISOString().split("T")[0] + `T${this.endTime}:00`, //
            apiUserId: userId,
          };
          this.events.push(event);
        }

        startDate.setDate(startDate.getDate() + 1);
      }
      console.log(this.events);

      this.isLoading = true;
      try {
        await this.$store.dispatch("calender/addApp", this.events);
        this.$router.replace("/");
      } catch (e) {
        this.error = e.message || "failed to send data";
      }
      this.isLoading = false;
    },
  },
  created() {},
};
</script>

<style lang="scss" scoped>
.controller {
  display: flex;
  flex-direction: column;
  gap: 0.5em;

  input {
    border-radius: 0.4em;
  }
  textarea {
    border-radius: 0.4em;
    min-height: 20vh;
  }
}
</style>
