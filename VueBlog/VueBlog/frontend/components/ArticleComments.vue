<template>
    <div class="article-comments-section">
        <div v-show="comments.length > 0">
            <div>Comments: </div>
            <transition-group name="article-comment-transition" tag="div">
                <div class="article-comment-container" v-for="comment in comments" :key="comment.id">
                    <div class="article-comment-author">
                        {{comment.commentatorName}}
                    </div>
                    <div class="article-comment-content">
                        {{comment.content}}
                    </div>
                </div>
            </transition-group>
        </div>
        <div v-show="comments.length == 0">
            No comments yet
        </div>
        <div class="comment-form">
            <form no-validate @submit.prevent="postComment">
                <div class="form-group">
                    <label for="commentInput">Name:</label>
                    <input type="text" id="commentInput" class="form-control" 
                        v-model="commentatorName" 
                    />
                </div>
                <div class="form-group">
                    <label for="commentInput">Comment:</label>
                    <textarea id="commentInput" class="form-control" 
                        v-model="comment" 
                    />
                </div>
                <input type="submit" class="btn btn-primary" value="Comment" :disabled="$v.$invalid"/>
            </form>
        </div>
    </div>
</template>
<script>
import { mapGetters } from 'vuex'
import { required } from 'vuelidate/lib/validators'

export default {
    props: ['comments', 'articleId'],
    data(){
        return {
            comment: '',
            commentatorName: ''
        }
    },
    computed: {
        ...mapGetters({
            isUserLoggedIn: 'user/isLoggedIn'
        })
    },
    methods: {
        postComment(){
            var newComment = {
                comment: this.comment,
                commentatorName: this.commentatorName,
                articleId: this.articleId
            }

            this.$store.dispatch('articles/commentArticle', newComment)

            this.comment = ''
            this.commentatorName = ''
        }
    },
    validations: {
        comment:{
            required
        },
        commentatorName: {
            required
        }
    }
}
</script>

<style>
    .article-comment-transition-enter{
        opacity: 0;
    }

    .article-comment-transition-enter-active{
        transition: opacity 1s ease-in;
    }
</style>
