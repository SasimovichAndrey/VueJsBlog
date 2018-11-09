import axios from 'axios'

export default {
    state: {
        allLoaded: false,
        all: [],
        selectedArticle: {
            isLoaded: false,
            article: null
        }
    },
    mutations: {
        loadArticles(state, articles){
            state.all = articles,
            state.allLoaded = true
        },
        articleIsBeingLoaded(state, isBeingLoaded){
            state.selectedArticle.isLoaded = !isBeingLoaded
        },
        loadArticle(state, article){
            state.selectedArticle.article = article
        },
        commentAdded(state, comment){
            var article = state.selectedArticle.article
            article.comments.push(comment)
        }
    },
    actions: {
        loadArticles(context){
            axios.get('/api/articles')
                .then(response => {
                    context.commit('loadArticles', response.data)
                })
        },
        loadArticle(context, id){
            context.commit('articleIsBeingLoaded', true)

            axios.get(`/api/articles/${id}`)
                .then(response => {
                    context.commit('loadArticle', response.data)
                    context.commit('articleIsBeingLoaded', false)
                })
        },
        commentArticle(context, newComment){
            const { comment, commentatorName, articleId } = newComment
            axios.post(`/api/articles/comments`, {articleId, content: comment, commentatorName })
                .then(response => {
                    context.commit('commentAdded', response.data)
                })
        },
        addArticle(context, { newArticle, router} ){
            axios.post(`/api/articles`, newArticle)
                .then(response => {
                    router.push({path: '/'})
                })
        }
    }
}