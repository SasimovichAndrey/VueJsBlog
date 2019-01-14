<template>
    <div id="about-me-container">
        <div class="left-column">
            <img :src="photoOfMePath" id="photoOfMe"/>
        </div>
        <div class="right-column">
            <h1> About me</h1>
            <p>
                Hi there. God knows why you might have found yourself here, on this site. Well, now that you're here, just know - this is my blog. And I am Sasimovich Andrei, a .NET developer from Belarus. 
            </p>
            <p>
                I plan to put my programming works here as well as write some blog posts about programming and my life. But, this blog is really just an another programming excercise for me. So, It's not likely that there is gonna happen something interesting here :) Anyway, if for some reason you wanna reach me - look for my contacts below.
            </p>
            <h1> Contacts :</h1>
            <i class="fa fa-envelope-o" aria-hidden="true"></i> <a href="mailto:ballack.tyta@gmail.com">ballack.tyta@gmail.com</a> </br>
            <i class="fa fa-linkedin" aria-hidden="true"></i> <a href="http://www.linkedin.com/in/andrei-sasimovich">Andrey Sasimovich</a>
        </div>
    </div>
</template>
<script>
    import photoOfMePath from '../assets/photoOfMe.jpg'
    
    export default {
        data(){
            return {
                photoOfMePath: photoOfMePath
            }
        }
    }
</script>