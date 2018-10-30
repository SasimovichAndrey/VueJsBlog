<template>
    <div class="container">
      <blog-header></blog-header>
      <div class="row">
        <div class="col-sm-12">
          Welcome
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
