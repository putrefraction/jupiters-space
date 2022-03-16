const Database = require("../db/config")

module.exports = {
    async login(req, res) {
        const db = await Database()
        const username = req.body.username
        const pass = req.body.password
        
        const loginInfo = db.get(`SELECT * FROM login where user = ${username}`)
        if(loginInfo.password === pass){
            const session = req.session
            const userId = username
            console.log(req.session)
            
            res.redirect('/')
        } else {
            res.send("<h2>Wrong Login</h2>")
        }
    }
}