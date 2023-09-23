<template>
  <div class="box">
    <h1 class="text-center">videon box</h1>
    <div class="roomTitle">
      <span v-if="loading"> Loading... {{ roomName }}</span>
      <span v-else-if="!loading && roomName"> Connected to {{ roomName }}</span>
      <span v-else>Select a room to get started</span>
    </div>
    <div class="row remote_video_container">
      <div id="remoteTrack"></div>
    </div>
    <div class="spacing"></div>
    <div class="row">
      <div id="localTrack"></div>
    </div>
  </div>
</template>

<script>
import Twilio, {
  connect,
  createLocalTracks,
  createLocalVideoTrack,
} from "twilio-video";
import axios from "axios";

export default {
  name: "Video",
  data() {
    return {
      loading: false,
      data: {},
      localTrack: false,
      remoteTrack: "",
      activeRoom: "",
      previewTracks: "",
      identity: "",
      roomName: null,
      username:'ahmed'
    };
  },
  // props: ["username"], // props that will be passed to this component
  created() {},
  methods: {

    // Generate access token
    async getAccessToken() {
      return await axios.get(
        `https://localhost:5174/token?identity=${this.username}`
      );
    },

    // Trigger log events
    dispatchLog(message) {},

    // Attach the Tracks to the DOM.
    attachTracks(tracks, container) {},

    // Attach the Participant's Tracks to the DOM.
    attachParticipantTracks(participant, container) {},

    // Detach the Tracks from the DOM.
    detachTracks(tracks) {},

    // Detach the Participant's Tracks from the DOM.
    detachParticipantTracks(participant) {},

    // Leave Room.
    leaveRoomIfJoined() {},

    // Create a new chat
    createChat(room_name) {
      this.loading = true;
      this.roomName = room_name;
      Twilio.connect()
    },
  },
};
</script>

<style>
.remote_video_container {
  left: 0;
  margin: 0;
  border: 1px solid rgb(124, 129, 124);
}
#localTrack video {
  border: 3px solid rgb(124, 129, 124);
  margin: 0px;
  max-width: 50% !important;
  background-repeat: no-repeat;
}
.spacing {
  padding: 20px;
  width: 100%;
}
.roomTitle {
  border: 1px solid rgb(124, 129, 124);
  padding: 4px;
  color: dodgerblue;
}
</style>
