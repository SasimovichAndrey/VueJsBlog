<template>
  <div id="app">
    <router-view></router-view>
  </div>
</template>

<script>


export default {
    created(){
      this.$store.dispatch('user/restoreUserState')
    }
}
</script>

<style lang="scss">
  @import './styles/site.scss';
</style>
