const { init } = require("express/lib/application")
const Database = require("./config")

const initDb = {
    async init(){
        const db = await Database()

        await db.exec(`CREATE TABLE IF NOT EXISTS posts (
            postId INTEGER PRIMARY KEY AUTOINCREMENT,
            title TEXT NOT NULL,
            subtitle TEXT,
            date TEXT NOT NULL
        )`)

        await db.close()
    }
}

initDb.init()