<template>
    <div class="blog-article-container">
        <div class="blog-article-title">{{article.title}}</div>
        <div v-html="article.content" class="blog-article-content"></div>
    </div>
</template>

<script>
import hljs from 'highlight.js';
import 'highlight.js/styles/github.css'

export default {
    props: ['article'],
    mounted(){
        $('pre code').each((i, el) => {
            hljs.highlightBlock(el);
        })
    }
}
</script>

