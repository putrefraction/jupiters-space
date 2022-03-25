const express = require('express')
const route = express.Router()

const PostController = require('./controllers/PostController')
const SessionController = require('./controllers/SessionController')



route.get('/', (req, res) => {res.render("main", {page: "home", session:req.session})})

route.get('/blog', PostController.index)
route.get('/blog/:date/:slug', PostController.open)
route.get('/blog/:date/:slug/edit', PostController.edit)

route.get('/new-post', (req, res) => {res.render("main", {page: "new-post", session:req.session})})
route.post('/new-post/submit', PostController.new)

route.get('/admin', (req,res) => {res.render("login")})
route.post('/admin/login', SessionController.login)

module.exports = route