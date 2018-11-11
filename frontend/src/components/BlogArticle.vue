<template>
    <div class="blog-article-container">
        <div class="blog-article-title">{{article.title}}</div>
        <div v-html="article.content" class="blog-article-content"></div>
    </div>
</template>

<script>
export default {
    props: ['article']
}
</script>

