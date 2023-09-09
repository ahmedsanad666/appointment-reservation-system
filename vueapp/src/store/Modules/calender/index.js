import actions from "./actions";
import mutations from "./mutations";
import getters from "./getters";

export default {
  namespaced: true,
  state() {
    return {
      events: [
        {
          userId: "sadfasf",
          id: 1,
          title: "new event ",
          contactType: "phone",
          location: "01062013864",
          decription:
            "this is the desction of the event and is need to be done eraly ",
          start: "2023-08-15T10:00:00",
          end: "2023-08-15T12:00:00",
       
          booked: false,
        },
        {
          userId: "asdf",
          id: 1,
          title: "new event ",
          contactType: "phone",
          location: "01062013864",
          decription:
            "this is the desction of the event and is need to be done eraly ",
          start: "2023-08-15T10:00:00",
          end: "2023-08-15T12:00:00",
          
          booked: false,
        },
        {
          userId: "asdf",
          id: 2,
          title: "the new world of technology ",
          contactType: "zoom",
          location: "http//zoomlink",
          decription:
            "this is  the new world of technology des and the new world how the phase will be sith an d ",
          end: "2023-09-08T06:30:00+03:00",
          start: "2023-09-08T05:00:00+03:00",
          
          booked: false,
        },
        {
          userId: "asdf",
          id: 3,
          title: "the ai technologies ",
          contactType: "googleMeet",
          location: "https://gogolemeetzon.com",
          decription:
            "how the world will be with ai technologies what is the new requirements need to be is thie jkdsfj  ",
          end: "2023-09-12T13:30:00+03:00",
          start: "2023-09-12T10:30:00+03:00",
          color: "yellow",
          booked: false,
        },
      ],
    };
  },
  actions,
  mutations,
  getters,
};
