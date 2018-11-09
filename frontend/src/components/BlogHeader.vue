<template>
    <div id="blog-header" @click="$router.push({path:'/'})">
        <div class="col-sm-12">
            ANDREI SASIMOVICH

            <div v-if="isUserLoggedIn"> Hello, {{user.name}}</div>
        </div>
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

