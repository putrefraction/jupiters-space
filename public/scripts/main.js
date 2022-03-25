const session = require("express-session")
const Database = require("../../src/db/config")

const deleteButton = document.getElementById("delete")
deleteButton.addEventListener("click", deletePost)

function deletePost(event){
    const db = await Database()

    const postSlug = req.params.slug
    if (session.userId){
        db.exec(`DELETE FROM posts WHERE urlSlug = "${postSlug}"`)
        console.log("AAAAAAAAAAAAAAAAAA")
        window.location('/')
    }

    window.redire
}