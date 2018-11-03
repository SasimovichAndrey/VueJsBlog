<template>
    <form class="container" @submit.prevent="login">
        <div class="form-group">
            <label for="userEmailInput">Email</label>
            <input type="email" id="userEmailInput" class="form-control" required v-model="email"/>
        </div>
        <div class="form-group">
            <label for="passwordInput">Password</label>
            <input type="password" id="passwordInput" class="form-control" required v-model="password"/>
        </div>
        <input type="submit" class="btn btn-primary" value="Login"/>
    </form>
</template>

<script>

export default {
    data(){
        return{
            email: '',
            password: '',
            error: null
        }
    },
    methods: {
        login(){
            if(this.email.trim() != '' && this.password.trim() != ''){

                this.$store.dispatch('user/userLogin', {
                    email: this.email,
                    password: this.password
                })

                this.$router.push({path: '/'})
            }
        }
    }
}
</script>
