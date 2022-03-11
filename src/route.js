const express = require('express')
const route = express.Router()

const PostController = require('./controllers/PostController')


route.get('/', (req, res) => {res.render("home")})

route.get('/blog/:date/:slug', PostController.open)




module.exports = route