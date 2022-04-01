const Database = require("../db/config")
module.exports = {
    // Selects and renders a specific post from the database, based on its slug
    async open(req, res){
        const db = await Database()     

        const postSlug = req.params.slug
        const postDate = req.params.date
        const postContents = await db.get(`SELECT * FROM posts WHERE "urlSlug" = "${postSlug}"`)

        const title = postContents.title
        const urlSlug = postContents.urlSlug
        const subtitle = postContents.subtitle
        const date = postContents.date
        const body = postContents.body
        
        if (date == postDate && postSlug == urlSlug){
            res.render("main", {page:"post",title: title, subtitle: subtitle, date:date, body:body, slug:urlSlug, session:req.session})
        } else {
            res.status(404)
            res.render("not-found")
        }

    },

    // Selects all posts from the database in order to create an index view at /blog
    async index(req, res){
        const db = await Database()


        
        const posts = await db.all("SELECT * FROM posts") 
        const isPosts = posts.length > 0

        res.render("main", {page:"post-index", posts: posts, isPosts: isPosts, session:req.session})

    },
    // creates new post 
    async new(req, res){
        const db = await Database()

        function slugify(str){
            str = str.replace(/^\s+|\s+$/g, '');

            // Make the string lowercase
            str = str.toLowerCase();

            // Remove accents, swap ñ for n, etc
            var from = "ÁÄÂÀÃÅČÇĆĎÉĚËÈÊẼĔȆÍÌÎÏŇÑÓÖÒÔÕØŘŔŠŤÚŮÜÙÛÝŸŽáäâàãåčçćďéěëèêẽĕȇíìîïňñóöòôõøðřŕšťúůüùûýÿžþÞĐđßÆa·/_,:;";
            var to   = "AAAAAACCCDEEEEEEEEIIIINNOOOOOORRSTUUUUUYYZaaaaaacccdeeeeeeeeiiiinnooooooorrstuuuuuyyzbBDdBAa------";
            for (var i=0, l=from.length ; i<l ; i++) {
                str = str.replace(new RegExp(from.charAt(i), 'g'), to.charAt(i));
            }

            // Remove invalid chars
            str = str.replace(/[^a-z0-9 -]/g, '') 
            // Collapse whitespace and replace by -
            .replace(/\s+/g, '-') 
            // Collapse dashes
            .replace(/-+/g, '-'); 

            return str;
        }

        const postTitle = req.body.post_title
        const postSlug = slugify(postTitle)
        const postSubtitle = req.body.post_subtitle
        const postBody = markdown.toHTML(req.body.post_body)

        await db.exec(`INSERT INTO posts(title, urlSlug, subtitle, date, body) VALUES (
            "${postTitle}",
            "${postSlug}",
            "${postSubtitle}",
            date("now","localtime"),
            "${postBody}"
        )`)

        res.redirect("/blog")

    },

    async delete(req, res) {
        const db = await Database()

        const postSlug = req.params.slug
        // delete post based on slug
        await db.exec(`DELETE FROM posts WHERE urlSlug = "${postSlug}"`)

        //copying the index function because I can't reference it, lmao
        const posts = await db.all("SELECT * FROM posts")
        const isPosts = posts.length > 0

        res.render("main", {page:"post-index", posts: posts, isPosts: isPosts, session:req.session})

    }


}
