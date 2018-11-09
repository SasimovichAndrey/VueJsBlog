import HomePage from './Home'
import LoginPage from "./Login";
import ArticlesList from './components/ArticlesList'
import BlogArticle from './components/BlogArticle';
import NewArticle from './components/NewArticle';

export default [
    {
        path: '/login',
        component: LoginPage
    },
    {
        path: '/',
        component: HomePage,
        children: [
            { path: '', component: ArticlesList },
            { path: 'articles/new', component: NewArticle }, // the order is important - new should be defined before :id
            { path: 'articles/:id', component: BlogArticle, name: 'Article' },
        ]
    }
]