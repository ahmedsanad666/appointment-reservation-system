import router from "./router";
import store from "./store";

import { createApp } from "vue";
import App from "./App.vue";
import "./assets/tailwind.css";

const app = createApp(App);

app.use(store);
app.use(router);
app.mount("#app");
