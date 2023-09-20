<template>
  <div class="availability-form">
    <base-spinner v-if="isLoading"></base-spinner>
    <form
      @submit.prevent="addAvailability"
      class="availability-form__form rounded-lg md:w-[60%] w-[90%] border"
    >
      <div class="py-3 rounded-md">
        <h2 class="md:text-3xl text-2xl text-slate-400 px-3">
          Set Your availability
        </h2>

        <hr class="my-3 w-[98%] m-auto" />
        <p class="py-3 px-5 text-left text-lg text-slate-700 max-w-lg">
          let Calendly know when your are typically available to accept mettings
        </p>
      </div>
      <label for="start-time" class="availability-form__label"
        >Start Time:</label
      >
      <input
        type="time"
        id="start-time"
        v-model="startTime"
        required
        class="availability-form__input"
      />

      <label for="end-time" class="availability-form__label">End Time:</label>
      <input
        type="time"
        id="end-time"
        v-model="endTime"
        required
        class="availability-form__input"
      />

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
        class="availability-form__submit"
        v-if="mood === 'submit'"
      >
        {{ mood }}
      </button>
      <button type="submit" class="availability-form__submit" v-else>
        {{ mood }}
      </button>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      isLoading: false,
      startTime: "",
      endTime: "",
      days: [
        "Sunday",
        "Monday",
        "Tuesday",
        "Wednesday",
        "Thursday",
        "Friday",
        "Saturday",
      ],
      selectedDays: [],
      mood: "submit",
      error: "",
      id: 0,
    };
  },
  methods: {
    async addAvailability() {
      const userId = this.$store.getters["auth/userId"];

      const days = [];
      this.selectedDays.forEach((el) => {
        days.push(this.days.indexOf(el));
      });
      const daysString = [];
      for (let i = 0; i < days.length; i++) {
        daysString.push(days[i].toString());
      }

      this.isLoading = true;
      try {
        if (this.mood === "submit") {
          const payload = {
            apiUserId: userId,
            startTime: this.startTime,
            endTime: this.endTime,
            days: daysString,
          };
          await this.$store.dispatch("availability/setAvailableTimes", payload);
        } else {
          const payload = {
            id: this.id,
            apiUserId: userId,
            startTime: this.startTime,
            endTime: this.endTime,
            days: daysString,
          };
          await this.$store.dispatch(
            "availability/updateAvailableTimes",
            payload
          );
        }

        document.location.reload();
      } catch (e) {
        this.error = e.message || "failed to send data";
      }
    },
    async checkAvailableTimes() {
      const userId = this.$store.getters["auth/userId"];
      try {
        await this.$store.dispatch("availability/UserAvailability", userId);
        const data = this.$store.getters["availability/avaibaleTimes"];
        if (!data.availableTimes) {
          this.mood = "submit";
        } else {
          this.id = data.result.id;
          this.mood = "update";
          this.startTime = data.result.startTime;
          this.endTime = data.result.endTime;

          this.days.forEach((el) => {
            data.result.days.forEach((j) => {
              if (this.days.indexOf(el) == j) {
                this.selectedDays.push(el);
              }
            });
          });
        }
      } catch (e) {
        this.error = e.message || "failed to get data";
      }
    },
  },
  created() {
    this.checkAvailableTimes();
  },
};
</script>
<style scoped>
.availability-form {
  display: flex;
  flex-direction: column;
  align-items: center;
}

.availability-form__form {
  margin: 20px;
  padding: 20px;
  border: 1px solid #ccc;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.availability-form__label {
  display: block;
  margin-bottom: 5px;
  font-weight: bold;
}

.availability-form__input {
  width: 100%;
  padding: 5px;
  margin-bottom: 10px;
  border: 1px solid #ccc;
  border-radius: 3px;
}

.availability-form__day-label {
  display: flex;
  align-items: center;
  margin-bottom: 5px;
}

.availability-form__day-checkbox {
  margin-right: 5px;
}

.availability-form__submit {
  background-color: #007bff;
  color: #fff;
  border: none;
  padding: 10px 15px;
  border-radius: 3px;
  cursor: pointer;
  transition: background-color 0.2s;
}

.availability-form__submit:hover {
  background-color: #0056b3;
}
</style>
