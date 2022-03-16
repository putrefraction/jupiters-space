const Database = require("../db/config")

module.exports = {
    async login(req, res) {
        const session = req.session
        console.log(session)

        const db = await Database()
        const username = req.body.username
        const pass = req.body.password
        const loginInfo = await db.get(`SELECT * FROM login where user = "${username}"`)

        if(loginInfo.password === pass){
            session.userId = loginInfo.user
            
            res.redirect('/blog')
        } else { 
            res.send("<h2>Wrong Login</h2>")
        }
    }
}