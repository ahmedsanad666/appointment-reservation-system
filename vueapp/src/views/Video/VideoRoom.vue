<template>
  <div>
    <h1>Room: {{ roomName }}</h1>

    <div ref="localMedia" class="local-media"></div>
    <div ref="remoteMedia" class="remote-media"></div>

    <button @click="leaveRoom">Leave Room</button>
  </div>
</template>

<script>
import TwilioVideo from "twilio-video";

export default {
  data() {
    return {
      room: null,
      token: "", // Token received from the server
      roomName: "", // Room name received from the route
    };
  },
  mounted() {
    const roomToken = localStorage.getItem("roomToken");
    this.token = roomToken;
    this.roomName = this.$route.params.roomId;

    // Connect to Twilio Video using the token
    TwilioVideo.connect(this.token, {
      video: true,
      audio: true,
      name: this.roomName,
    }).then((room) => {
      this.room = room;

      console.log(room);
      // Attach local media to a div element
      TwilioVideo.createLocalVideoTrack()
        .then((track) => {
          const localMediaContainer = this.$refs.localMedia;
          localMediaContainer.appendChild(track.attach());
        })
        .catch((error) => {
          console.error("Error connecting to the room:", error);
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
  methods: {
    leaveRoom() {
      this.room.disconnect();
      this.$router.push("/");
    },
  },
};
</script>
