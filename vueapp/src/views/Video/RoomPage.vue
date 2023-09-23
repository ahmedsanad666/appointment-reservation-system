<template>
  <div>
    <h1>Twilio Video Chat</h1>
    <div v-if="!roomName">
      <input v-model="roomNameInput" placeholder="Enter a room name" />
      <button @click="joinRoom">Join Room</button>
    </div>
    <div v-else>
      <h2>Room: {{ roomName }}</h2>
      <button @click="leaveRoom">Leave Room</button>
      <div ref="remoteMedia" id="remote-media"></div>
      <div ref="localMedia" id="local-media"></div>
    </div>
  </div>
</template>

<script>
import TwilioVideo from "twilio-video";
import axios from "axios";

export default {
  data() {
    return {
      roomNameInput: "",
      roomName: "",
      token: "", // Store the access token here
      username: "ahmedssands",
    };
  },
  methods: {
    async joinRoom() {
      // Get the access token from your server
      await this.getAccessToken().then((data) => {
        console.log(data);
        this.roomName = this.roomNameInput;
        this.token = data.data.token; // Store the token for use later
        console.log(this.token);
      });

      // Connect to Twilio Video using the token
      TwilioVideo.connect(this.token, {
        video: true,
        audio: true,
        name: "this is room",
        // name: this.roomName,
      }).then((room) => {
        this.room = room;

        // Attach local media to a div element
        TwilioVideo.createLocalVideoTrack().then((track) => {
          const localMediaContainer = this.$refs.localMedia;
          localMediaContainer.appendChild(track.attach());
        });

        // Attach remote media to a div element
        room.on("participantConnected", (participant) => {
          const remoteMediaContainer = this.$refs.remoteMedia;
          participant.tracks.forEach((publication) => {
            if (publication.isSubscribed) {
              remoteMediaContainer.appendChild(publication.track.attach());
            }
          });

          // Subscribe to new tracks as they're published
          participant.on("trackSubscribed", (track) => {
            remoteMediaContainer.appendChild(track.attach());
          });
        });
      });
    },
    leaveRoom() {
      this.room.disconnect();
      this.roomName = "";
    },
    async getAccessToken() {
      return await axios.get("https://localhost:7063/api/ApiToken");
    },
  },
};
</script>

<style>
/* Add your styles here if needed */
</style>
