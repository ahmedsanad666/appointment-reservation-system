import { createStore } from "vuex";
import authModule from "./Modules/auth/index";
import calenderModule from './Modules/calender/index';
import availabilityModule from "./Modules/availability/index";
import availability from "./Modules/availability/index";

const store = createStore({
  state: {
   
  },

   modules: {
    auth: authModule,
    calender:calenderModule,
    availability:availabilityModule
  },
});

export default store;
