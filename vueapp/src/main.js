import router from "./router";
import store from "./store";
import { createApp } from "vue";
import App from "./App.vue";
import { library } from "@fortawesome/fontawesome-svg-core";
import { fas } from "@fortawesome/free-solid-svg-icons";

import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import BaseSpinner from "./components/bases/BaseSpinner.vue";

import "./assets/tailwind.css";
library.add(fas);

const app = createApp(App);

app.component("font-awesome-icon", FontAwesomeIcon);
app.component("base-spinner", BaseSpinner);

app.use(store);
app.use(router);
app.mount("#app");
