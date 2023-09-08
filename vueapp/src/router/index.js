import { createRouter, createWebHashHistory } from "vue-router";
// pages
import HomePage from "../views/HomePage.vue";
import MyCalendly from "../views/MyCalendly.vue";
import CreateEvent from '../views/CreateEvent.vue'

const routes = [
  {
    path: "/",
    redirect: "/home",
  },
  {
    path: "/home",
    name: "home",
    component: HomePage,
    meta: {
      title: "home",
    },
  },
  {
    path: "/myCalendly",
    name: "calendly",
    component: MyCalendly,
    meta: {
      title: "myCalendly",
    },
  },
  {
    path: "/CreateEvent",
    name: "CreateEvent",
    component: CreateEvent,
    meta: {
      title: "CreateEvent",
    },
  },
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

router.beforeEach((to, _, next) => {
  document.title = to.meta.title;
  next();
});

export default router;
