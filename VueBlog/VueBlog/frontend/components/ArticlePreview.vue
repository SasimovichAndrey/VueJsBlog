<template>
    <div class="article">
        <router-link class="article-title" tag="div" :to="{name: 'Article', params: {id: article.id}}">
            <a>{{article.title}}</a>
        </router-link>
        <div>{{article.previewContent}}</div>
    </div>
</template>
<script>
export default {
    props: ['article']
}
</script>

<style scoped lang="scss">


</style>

