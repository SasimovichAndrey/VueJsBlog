<template>
<nav class="navbar navbar-expand-lg navbar-dark bg-gradient-primary" id="blog-header" >
    <a class="navbar-brand" href="#" @click="$router.push({path:'/'})">ANDREI SASIMOVICH</a>
    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mr-auto">
            <router-link to="/articles" active-class="active">
                <li class="nav-item">
                    <a class="nav-link" href="#">Blog <span class="sr-only">(current)</span></a>
                </li>
            </router-link>
            <router-link to="/aboutme" active-class="active">
                <li class="nav-item">
                    <a class="nav-link" href="#">About me</a>
                </li>
            </router-link>
        </ul>
    </div>
</nav>
</template>

<script>
import {
    mapState,
    mapGetters
} from "vuex";

export default {
    computed: {
        ...mapState(["user"]),
        ...mapGetters({
            isUserLoggedIn: "user/isLoggedIn"
        })
    }
};
</script>
