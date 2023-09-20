import { createRouter, createWebHashHistory } from "vue-router";
// pages
import HomePage from "../views/HomePage.vue";
import MyCalendly from "../views/MyCalendly.vue";
import CreateEvent from "../views/CreateEvent.vue";
import WaitingAppointments from "../views/WaitingAppointments.vue";
import AllEvents from "../views/AllEvents.vue";
import AuthPage from "../views/Auth/AuthPage.vue";
import AvailableTimes from "../views/AvailableTimes.vue";
import store from "../store/index.js";
import EventDetails from "../views/EventDetails.vue";
import ChooseTime from '../views/ChooseTime.vue';

const routes = [
  {
    path: "/",
    redirect: "/home",
  },
  {
    path: "/Auth",
    name: "Auth",
    component: AuthPage,
    meta: {
      title: "Auth",
      requiresUnauth: true,
    },
  },
  {
    path: "/home",
    name: "home",
    component: HomePage,
    meta: {
      title: "home",
      requiresAuth: true,
    },
  },
  {
    path: "/ChooseTime/:eventId",
    name: "ChooseTime",
    component: ChooseTime,
    meta: {
      title: "ChooseTime",
      requiresAuth: true,
    },
  },
  {
    path: "/BookEvent",
    name: "BookEvent",
    component: AllEvents,
    meta: {
      title: "BookEvent",
      requiresAuth: true,
    },
  },
  {
    path: "/waitingAppointments",
    name: "waitingAppointments",
    component: WaitingAppointments,
    meta: {
      title: "waitingAppointments",
      requiresAuth: true,
    },
  },
  {
    path: "/myCalendly",
    name: "calendly",
    component: MyCalendly,
    meta: {
      title: "myCalendly",
      requiresAuth: true,
    },
  },
  {
    path: "/availableTimes",
    name: "availability",
    component: AvailableTimes,
    meta: {
      title: "availability",
    },
  },
  {
    path: "/EvetnDetails/:id",
    name: "EvetnDetails",
    component: EventDetails,
    meta: {
      title: "EventDetails",
      requiresAuth: true,
    },
  },
  {
    path: "/CreateEvent",
    name: "CreateEvent",
    component: CreateEvent,
    meta: {
      title: "CreateEvent",
      requiresAuth: true,
    },
  },
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

router.beforeEach((to, _, next) => {
  document.title = to.meta.title;
  if (to.meta.requiresAuth && !store.getters["auth/isAuthenticated"]) {
    next("/auth");
  } else if (to.meta.requiresUnauth && store.getters["auth/isAuthenticated"]) {
    next("/");
  } else {
    next();
  }
});

export default router;
