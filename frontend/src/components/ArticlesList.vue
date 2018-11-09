<template>
    <div class="article-list">
        <span v-if="!articles.allLoaded">
            Loading ...
        </span>
        <article-preview
            v-for="article in articles.all"
            :key="article.id"
            :article="article"
            v-else>
        </article-preview>
    </div>
</template>
<script>
import { mapState } from 'vuex'
import articlePreview from './ArticlePreview.vue';

export default {
    computed: {
        ...mapState(['articles'])
    },
    created(){
        this.$store.dispatch('articles/loadArticles')
    },
    components: {
        articlePreview
    }
}
</script>
