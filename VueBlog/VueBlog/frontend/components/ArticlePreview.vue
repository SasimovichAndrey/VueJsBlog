<template>
    <div class="article">
        <router-link class="article-title" tag="div" :to="{name: 'Article', params: {id: article.id}}">
            <a>{{article.title}}</a>
        </router-link>
        <div class="article-preview-component-controls">
            <button 
                class="delete-button" 
                @click="deleteArticle" 
                v-if="isCurrentUserAdmin()">
                X
            </button>
        </div>
        <div class="clearfix"></div>
        <div v-html="article.previewContent"></div>
    </div>
</template>
<script>
import hljs from 'highlight.js';
import 'highlight.js/styles/github.css'

export default {
    props: ['article'],
    methods: {
        deleteArticle(){
            this.$store.dispatch('articles/deleteArticle', this.article.id);
        },
        isCurrentUserAdmin(){
            return this.$store.getters["user/isCurrentUserAdmin"];
        }
    },
    mounted(){
        $('pre code').each((i, el) => {
            hljs.highlightBlock(el);
        })
    }
}
</script>

<style scoped lang="scss">


</style>

