<template>
    <div id="blog-header">
        Blog header

        <div v-if="isUserLoggedIn"> Hello, {{user.name}}</div>
    </div>
</template>

<script>
import { mapState, mapGetters } from 'vuex';

export default {
    computed:{
        ...mapState([
            'user'
        ]),
        ...mapGetters({
            isUserLoggedIn: 'user/isLoggedIn'
        })
    }
}
</script>


<style>
    #blog-header{
        width:100%;
        height:200px;
    }
</style>
