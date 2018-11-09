import MockAdapter from 'axios-mock-adapter'


const setupFunc = (axios) => {
    const mock = new MockAdapter(axios, {delayResponse: 500});
    const articles = [
        {
            id: 1,
            title: 'Test title',
            previewContent: 'Test article preview',
            content: 'Test article content',
            comments: []
        },
        {
            id: 2,
            title: 'Test title 2 ',
            previewContent: 'Test article preview 2',
            content: 'Test article content 2',
            comments: []
        },
        {
            id: 3,
            title: 'Test title 3 ',
            previewContent: 'Test article preview 3',
            content: 'Test article content 3',
            comments: []
        }
    ]
    
    mock.onPost('/token').reply(200, {
        access_token: 'gsegse',
        expires_in: '100000',
        username: 'Fake user 2'
    })

    mock.onGet('/api/articles').reply(200, articles),
    mock.onGet(/\/api\/articles\/\d+/).reply(function(config){
        // debugger
        let reg = /\/api\/articles\/(\d+)/
        let articleId = reg.exec(config.url)[1]
        return [200, articles.find(a => a.id == articleId)]
    })

    mock.onPost(/\/api\/articles\/\d+\/comments/).reply(config => {
        let commentFromRequest = JSON.parse(config.data)
        let article = articles.find(a => a.id == commentFromRequest.articleId)
        let newCommentId = article.comments.length > 0 ? article.comments[article.comments.length - 1].id + 1 : 1


        let newComment = {
            id: newCommentId,
            content: commentFromRequest.content,
            articleId: commentFromRequest.articleId
        }
        return [200, newComment]
    })
    
    mock.onPost('/api/articles').reply(config => {
        let articleFromRequest = JSON.parse(config.data)
        let newArticle = {
            ...articleFromRequest,
            id: articles[articles.length - 1].id + 1,
            comments: []
        }

        articles.push(newArticle)

        return [200, newArticle]
    })
}

export default setupFunc;