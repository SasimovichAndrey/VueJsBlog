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
                <froala 
                    :tag="'textarea'" 
                    :config="htmlEditorConfig" 
                    v-model="content" 
                    :class="{'is-invalid': $v.content.$error}"
                    class="form-control">
                </froala>
                <!-- <textarea id="contentInput" class="form-control" 
                    v-model="content"
                    @blur="$v.content.$touch()"
                    :class="{'is-invalid': $v.content.$error}"
                /> -->
            </div>
            <input type="submit" class="btn btn-primary" value="Post" :disabled="$v.$invalid"/>
        </form>
    </div>
</template>

<script>

import { required } from 'vuelidate/lib/validators'

const component =  {
    data(){
        return {
            title: '',
            previewContent: '',
            content: '',
            htmlEditorConfig: {
                events:{
                    'froalaEditor.blur': function(e, editor) {
                        this.$v.content.$touch()
                        if(this.$v.content.$error){
                            console.log('add reb border to invalid html editor')
                        }
                    }.bind(this)
                }
            }
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
    created(){
        this.self = this
    }    
}

export default component
</script>

