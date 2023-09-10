export default {
  setEvents(state, payload) {
    state.events = payload;
  },
  setEventsToBooked(state, payload) {
    state.EventsToBooked = payload;
  },
  setBookedEvents(state, payload) {
    state.BookedEvents = payload;
  },
};
