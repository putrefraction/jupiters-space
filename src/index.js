const express = require("express")
const sessions = require("express-session")
const bodyParser = require("body-parser")
const route = require("./route")
const path = require("path")
const cookieParser = require("cookie-parser")

const server = express()

server.set("view engine", "ejs")
server.set("views", path.join(__dirname, "views"))

server.use(express.static("public"))

server.use(express.urlencoded({"extended":true}))


// 24hrs from milliseconds
const oneDay = 1000 * 60 * 60 * 24

//session middleware
server.use(sessions({
    secret:"thisisasecret",
    saveUninitialized:"true",
    cookie: {maxAge:oneDay},
    resave:"false"
}))

server.use(cookieParser())

server.use(bodyParser.json())
server.use(route)

server.listen('3000', () => console.log("RUNNING AT PORT 3000"))