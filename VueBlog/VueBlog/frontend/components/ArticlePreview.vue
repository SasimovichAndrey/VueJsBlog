<template>
    <div class="card article-preview">
        <div class="card-header bg-white">
            <router-link tag="a" class="text-primary" :to="{name: 'Article', params: {id: article.id}}">
                {{article.title}}
            </router-link>
        </div>
        <div class="card-body">
            <!-- <div class="card-title">
                <router-link tag="a" :to="{name: 'Article', params: {id: article.id}}">
                    {{article.title}}
                </router-link>
            </div> -->
            <div class="card-text">{{article.previewContent}}</div>
        </div>
    </div>
</template>
<script>
export default {
    props: ['article']
}
</script>

<style scoped lang="scss">


</style>

