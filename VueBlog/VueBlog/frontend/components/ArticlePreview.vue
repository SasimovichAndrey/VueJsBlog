<template>
    <div class="article">
        <router-link class="article-title" tag="div" :to="{name: 'Article', params: {id: article.id}}">
            <a>{{article.title}}</a>
        </router-link>
        <div class="article-preview-component-controls">
            <button class="delete-button" @click="deleteArticle">
                X
            </button>
        </div>
        <div class="clearfix"></div>
        <div>{{article.previewContent}}</div>
    </div>
</template>
<script>
export default {
    props: ['article'],
    methods: {
        deleteArticle(){
            this.$store.dispatch('articles/deleteArticle', this.article.id);
        }
    }
}
</script>

<style scoped lang="scss">


</style>

