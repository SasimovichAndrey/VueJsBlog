<template>
    <div class="container blog-container">
      <blog-header class="blog-header row"></blog-header>
      <div class="row blog-content-row">
        <div class="col-sm-12">
          <router-view></router-view>
        </div>
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

