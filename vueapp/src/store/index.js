import { createStore } from "vuex";
import authModule from "./Modules/auth/index";
import calenderModule from './Modules/calender/index';

const store = createStore({
  state: {
   
  },

   modules: {
    auth: authModule,
    calender:calenderModule
  },
});

export default store;
