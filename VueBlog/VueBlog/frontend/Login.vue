<template>
    <form class="container" @submit.prevent="login" novalidate>
        <div class="form-group">
            <label for="userEmailInput">Email</label>
            <input type="text" id="userEmailInput" class="form-control" 
                v-model="email" 
                @blur="$v.email.$touch()"
                :class="{'is-invalid': $v.email.$error}"
            />
        </div>
        <div class="form-group">
            <label for="passwordInput">Password</label>
            <input type="password" id="passwordInput" class="form-control" 
                v-model="password" 
                @blur="$v.password.$touch()"
                :class="{'is-invalid': $v.email.$error}"
            />
        </div>
        
        <div v-if="loginForm.loginError" class="alert alert-danger" role="alert">
            {{loginForm.loginError}}
        </div>

        <input type="submit" class="btn btn-primary" value="Login" :disabled="$v.$invalid"/>
    </form>
</template>

<script>

import {mapState} from 'vuex';
import {required, email} from 'vuelidate/lib/validators'

export default {
    data(){
        return{
            email: '',
            password: ''
        }
    },
    validations: {
        email: {
            required
        },
        password: {
            required
        }
    },
    computed: {
        ...mapState(['loginForm'])
    },
    methods: {
        login(){
            this.$store.dispatch('loginForm/userLogin', {
                email: this.email,
                password: this.password,
                router: this.$router
            })
        }
    }
}
</script>
