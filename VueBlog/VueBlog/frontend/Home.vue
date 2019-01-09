<template>
    <div class="container blog-container">
      <blog-header class="blog-header row"></blog-header>
      <div class="row blog-content-row">
        <div class="col-sm-12">
          <transition name="site-content-transition" mode="out-in">
            <router-view></router-view>
          </transition>
        </div>
      </div>
      <div id="blog-footer" class="bg-gradient-primary row">
      </div>
    </div>
</template>

<script>
import BlogHeader from "./components/BlogHeader.vue";

export default {

    components:{
        'blog-header': BlogHeader
    }
}
</script>

<style>
  .site-content-transition-enter{
    opacity: 0;
  }

  .site-content-transition-enter-active{
    transition: opacity 0.5s ease;
  }

  .site-content-transition-leave-active{
    transition: opacity 0.5s ease;
  }

  .site-content-transition-leave-to{
    opacity: 0;
  }
</style>
