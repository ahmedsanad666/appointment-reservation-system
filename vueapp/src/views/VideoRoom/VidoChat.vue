<template>
  <div v-if="!joined" class="text-center my-8">
    <button   class="py-1 px-4 bg-sky-800 text-white rounded-md" @click="join">join meeting</button>
  </div>
  <section class="gap-5 border">
    <div id="stream-wrapper border w-full">
      <div id="video-streams" class="flex gap-5 md:flex-row flex-col"></div>

      <div
        id="stream-controls "
        v-if="joined"
        class="flex text-center w-1/2 m-auto my-4 border gap-4"
      >
        <button
          class="px-4 py-1 bg-slate-400 text-red-950"
          @click="leaveAndRemoveLocalStream"
        >
          End Call
        </button>
        <button class="px-4 py-1 bg-slate-400 text-red-950" @click="toggleMic">
          Mic
        </button>
        <button
          @click="toggleCamera"
          class="px-4 py-1 bg-slate-400 text-red-950"
        >
          camera
        </button>
      </div>
    </div>
  </section>
</template>

<script>
import AgoraRTC from "agora-rtc-sdk-ng";
import { markRaw } from "vue"; // Import markRaw from Vue

export default {
  data() {
    return {
      appId: "f4502f04da9d4a51a439141d140772b7",

      channelName: "mainChannel",
      client: null,
      token:
        "007eJxTYJD42ZyZ2L7RaCNTl+b8R7qHZZ7Uvi1Vqvy9+vTtmvrDK3sVGNJMTA2M0gxMUhItU0wSTQ0TTYwtDU0MUwxNDMzNjZLMPz1WSW0IZGT4GrOaiZEBAkF8bobcxMw854zEvLzUHAYGAL9OJCg=",
      localTracks: [],
      remoteUsers: {},
      joined: false,
      userId: "sdjafklafjakfhsdakfhkadsdsfa",
    };
  },
  methods: {
    async join() {
      this.client = markRaw(
        AgoraRTC.createClient({ mode: "rtc", codec: "vp8" })
      );
      this.client.on("user-published", this.handleUserJoined);
      this.client.on("user-left", this.handleUserLeft);

      //...................
      try {
        // const response = await fetch("https://localhost:7063/api/Token", {
        //   method: "POST",
        //   body: JSON.stringify({
        //     channelName: this.channelName,
        //     Uid: this.userId,
        //   }),
        //   headers: {
        //     "Content-Type": "application/json",
        //   },
        // });

        // if (!response.ok) {
        //   console.log("failed");
        //   throw new Error("Failed to fetch Agora token");
        // }

        // const { token } = await response.json();

        // console.log(token, this.appId, this.channelName, null);

        const uid = await this.client.join(
          // token,
          this.appId,
          this.channelName,
          this.token,
          // this.userId
          null
        );

        console.error(uid);
        console.log("...................................");
        // Rest of your Agora SDK integration code here

        //...........
        // let uid = await this.client.join(
        //   this.appId,
        //   this.channelName,
        //   this.token,
        //   null
        // );
        this.localTracks = await AgoraRTC.createMicrophoneAndCameraTracks();

        let player = `<div class="video-container" id="user-container-${uid}">
                        <div class="video-player" id="user-${uid}"></div>
                  </div>`;
        document
          .getElementById("video-streams")
          .insertAdjacentHTML("beforeend", player);

        this.localTracks[1].play(`user-${uid}`);

        await this.client.publish([this.localTracks[0], this.localTracks[1]]);
        this.joined = true;
      } catch (error) {
        console.error("Error:", error);
      }
    },
    async handleUserJoined(user, mediaType) {
      this.remoteUsers[user.uid] = user;
      await this.client.subscribe(user, mediaType);
      if (mediaType === "video") {
        let player = document.getElementById(`user-container-${user.uid}`);
        if (player != null) {
          player.remove();
        }
        player = `<div class="video-container" id="user-container-${user.uid}">
                        <div class="video-player" id="user-${user.uid}"></div> 
                 </div>`;
        document
          .getElementById("video-streams")
          .insertAdjacentHTML("beforeend", player);

        user.videoTrack.play(`user-${user.uid}`);
      }
      if (mediaType === "audio") {
        user.audioTrack.play();
      }
    },
    async handleUserLeft(user) {
      delete remoteUsers[user.uid];
      document.getElementById(`user-container-${user.uid}`).remove();
    },
    async leaveAndRemoveLocalStream() {
      for (let i = 0; this.localTracks.length > i; i++) {
        this.localTracks[i].stop();
        this.localTracks[i].close();
      }

      await this.client.leave();
      this.$router.push("/");
    },
    async toggleMic(e) {
      if (this.localTracks[0].muted) {
        await this.localTracks[0].setMuted(false);
        e.target.innerText = "Mic on";
        e.target.style.backgroundColor = "cadetblue";
      } else {
        await this.localTracks[0].setMuted(true);
        e.target.innerText = "Mic off";
        e.target.style.backgroundColor = "#EE4B2B";
      }
    },
    async toggleCamera(e) {
      if (this.localTracks[1].muted) {
        await this.localTracks[1].setMuted(false);
        e.target.innerText = "Camera on";
        e.target.style.backgroundColor = "cadetblue";
      } else {
        await this.localTracks[1].setMuted(true);
        e.target.innerText = "Camera off";
        e.target.style.backgroundColor = "#EE4B2B";
      }
    },
  },
};
</script>

<style>
#join-btn {
  position: fixed;
  top: 50%;
  left: 50%;
  margin-top: -50px;
  margin-left: -100px;
  font-size: 18px;
  padding: 20px 40px;
}

#video-streams {
  /* display: grid; */
  /* grid-template-columns: repeat(auto-fit, minmax(500px, 1fr)); */
  height: 70vh;
  width: 1400px;
  margin: 0 auto;
}

.video-container {
  max-height: 100%;
  height: 100%;
  width: 70%;
  border: 2px solid black;
  background-color: #203a49;
}

.video-player {
  height: 100%;
  width: 100%;
}

button {
  border: none;
  background-color: cadetblue;
  color: #fff;
  padding: 10px 20px;
  font-size: 16px;
  margin: 2px;
  cursor: pointer;
}

@media screen and (max-width: 1400px) {
  #video-streams {
    grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
    width: 95%;
  }
}
</style>
