<template>
    <div class="new-article-page">
        <form no-validate @submit.prevent="addArticle" v-show="!showingPreview">
            <div class="form-group">
                <label for="titleInput">Title:</label>
                <input type="text" id="titleInput" class="form-control" 
                    v-model="title" 
                    @blur="$v.title.$touch()"
                    :class="{'is-invalid': $v.title.$error}"
                />
            </div>
            <div class="form-group">
                <label for="previewInput">Preview:</label>
                <textarea id="previewInput" class="form-control" 
                    v-model="previewContent" 
                    @blur="$v.previewContent.$touch()"
                    :class="{'is-invalid': $v.previewContent.$error}"
                />
            </div>
            <div class="form-group">
                <label for="contentInput">Content:</label>
                <div id="article-content-summernote" ref="contentInput"></div>
            </div>
            <input type="submit" class="btn btn-primary" value="Post" :disabled="$v.$invalid"/>
        </form>
        <div v-show="showingPreview">
            <div>Preview:</div>
            <article-preview :article="newArticle"></article-preview>
            <div>Full:</div>
            <blog-article :article="newArticle"></blog-article>
        </div>
        <div class="preview-controls">
            <input type="button" class="btn" @click="showingPreview = !showingPreview" value="Show / Hide preview"/>
        </div>
    </div>
</template>

<script>
import BlogArticle from './BlogArticle.vue';
import ArticlePreview from './ArticlePreview';
import { required } from 'vuelidate/lib/validators'
import constants from './../constants'

const component =  {
    data(){
        return {
            title: '',
            previewContent: '',
            content: '',
            showingPreview: false
        }
    },
    methods:{
        addArticle(){
            this.$store.dispatch('articles/addArticle', { newArticle: this.newArticle, router: this.$router })
        }
    },
    computed:{
        newArticle(){
            return {
                title: this.title,
                previewContent: this.previewContent,
                content: this.content,
                comments: []
            }
        }
    },
    validations: {
        title: {
            required
        },
        previewContent: {
            required
        },
        content: {
            required
        }
    },
    mounted(){
        var input = $(this.$refs.contentInput)
        input.summernote()
        input.on('summernote.change', function(e, contents){
                this.content = contents
            }.bind(this))
    },
    components:{
        BlogArticle,
        ArticlePreview
    }
}

export default component
</script>

