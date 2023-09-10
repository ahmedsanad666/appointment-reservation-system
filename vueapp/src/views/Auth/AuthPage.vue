<template>
  <section class=" min-h-screen main flex flex-col ">
    <login-form @toggle-mood="changeMood" class="test " v-if="LoginMode"></login-form>
    <signup-form  @toggle-mood="changeMood" v-else></signup-form>
    
        

  </section>
</template>

<script>
import LoginForm from '@/components/Auth/LoginForm.vue';
import SignupForm from '@/components/Auth/SignupForm.vue';
export default {

    components:{
    LoginForm,
        SignupForm,
    },

    data(){
        return{

            LoginMode:true,
        }
        
    },
    methods:{
      changeMood(){
        this.LoginMode = !this.LoginMode;
      }
    }
};
</script>

<style lang="scss" scoped>

</style>
