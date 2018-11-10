<template>
    <div class="new-article-page">
        <form no-validate @submit.prevent="addArticle">
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
    </div>
</template>

<script>

import { required } from 'vuelidate/lib/validators'
import constants from './../constants'

const component =  {
    data(){
        return {
            title: '',
            previewContent: '',
            content: ''
        }
    },
    methods:{
        addArticle(){
            debugger
            let newArticle = {
                title: this.title,
                previewContent: this.previewContent,
                content: this.content
            }

            this.$store.dispatch('articles/addArticle', { newArticle, router: this.$router })
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
    }    
}

export default component
</script>

