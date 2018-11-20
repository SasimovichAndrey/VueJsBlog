<template>
    <div>
        <Loader v-if="!articles.selectedArticle.isLoaded"/>
        <div v-else>
            <blog-article :article="articles.selectedArticle.article"></blog-article>
            <article-comments 
                :comments="articles.selectedArticle.article.comments" 
                :articleId="articles.selectedArticle.article.id">
            </article-comments>
        </div>
    </div>
</template>

<script>
import { mapState } from 'vuex';
import Loader from './Loader.vue'
import BlogArticle from './BlogArticle.vue';
import ArticleComments from './ArticleComments.vue'

export default {
    computed:{
        ...mapState(['articles'])
    },
    watch: {
        '$route'(to, from){
            this.loadArticle(to.params.id)
        }
    },
    created(){
        console.log('BlogArticle created')
        this.loadArticle(this.$route.params.id)
    },
    methods:{
        loadArticle(id){
            this.$store.dispatch('articles/loadArticle', id)
        }
    },
    components: {
        Loader,
        BlogArticle,
        ArticleComments
    }
}
</script>

<style>

</style>


