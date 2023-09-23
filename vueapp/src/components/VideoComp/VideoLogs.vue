<template>
    <div class=" box">
        <h1 class="text-center"> videon logs</h1>

        <div class="log"  v-for="log in logs" v-bind:key="log.id">
            {{log.message}}
        </div>
    </div>
</template>

<script>

import axios from 'axios'

export default {
  name: "Logs",
  data() {
    return {
        logs: [],
        logCount: 0
    }
  },
  created() {
    // EventBus.$on('new_log', (message) => {
    //     this.logs.push( {id: this.logCount, message: message} );

    //     this.logCount += 1; 
    // })
  },
}
</script>

<style scoped>
    .log {
        border: 1px solid rgb(124, 129, 124);
        padding: 13px;
        margin: 3px 0px;
        color: ghostwhite;
    }
</style>