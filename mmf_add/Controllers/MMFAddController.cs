using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace mmf_add.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MMFAddController: ControllerBase
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;");

        private static List<MMFAddSong> songs = new List<MMFAddSong> {
            new MMFAddSong { Title = "Goodbye Stranger", Performer = "Supertramp", Year = 1979, Mood = "blij", Youtube = "https://youtu.be/9aykOwwRf-Q" },
            new MMFAddSong { Title = "Lost on you", Performer = "LP", Year = 2017, Mood = "Triest", Youtube = "https://youtu.be/BzdWsH4nky8"   }
        };

        [HttpGet]
        public ActionResult<List<MMFAddSong>> Get()
        {
            return Ok(songs);
        }

        [HttpGet]
        [Route("{Year}")]
        public ActionResult<MMFAddSong> Get(int Year)
        {
            var song = songs.Find(x => x.Year == Year);
            return song == null ? NotFound() : Ok(song);
        }

        [HttpPost]
        public ActionResult Post(MMFAddSong NewSong)
        {
            string Query = "insert into db_songs.songs(title,performer,year,mood,youtube) values('" +NewSong.Title+ "','" +NewSong.Performer+ "','" +NewSong.Year+ "','" +NewSong.Mood+ "','" +NewSong.Youtube+ "');";
            MySqlCommand cmd = new MySqlCommand(Query, conn);
            MySqlDataReader MyReader;
            conn.Open();
            MyReader = cmd.ExecuteReader();
            while (MyReader.Read()) {
            }
            conn.Close();
            
            songs.Add(NewSong);
            var resourceUrl = Request.Path.ToString() + '/' + NewSong.Year;
            return Created(resourceUrl, NewSong);
        }
    }
}