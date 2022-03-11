const Database = require("../db/config")

// Reminder: create slugify function on post input, to throw into the database and use as URL reference

module.exports = {
async open(req, res){
        const db = await Database()

        
        const slug = req.params.slug

        const postContents = await db.get(`SELECT * FROM posts WHERE slug = ${slug}`)
        const title = postContents.title
        const subtitle = postContents.subtitle
        const date = postContents.date.split(" ")[0]
        const body = postContents.body
        
        res.render("post", {title: title, subtitle: subtitle, date: date, body:body})

    }
}
