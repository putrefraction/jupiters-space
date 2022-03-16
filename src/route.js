const express = require('express')
const route = express.Router()

const PostController = require('./controllers/PostController')
const SessionController = require('./controllers/SessionController')

route.get('/', (req, res) => {res.render("main", {page: "home"})})

route.get('/blog', PostController.index)
route.get('/blog/:date/:slug', PostController.open)

route.get('/admin', (req,res) => {res.render("login")})
route.post('/admin/login', SessionController.login)


module.exports = route