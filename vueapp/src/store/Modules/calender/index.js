import actions from "./actions";
import mutations from "./mutations";
import getters from "./getters";

export default {
  namespaced: true,
  state() {
    return {
      events: [],
      EventsToBooked:[],
      BookedEvents:[],
    };
  },
  actions,
  mutations,
  getters,
};
