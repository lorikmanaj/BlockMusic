using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlockMusicAPI.FreshDbC;
using BlockMusicAPI.ViewModels;
using System.IO;
using BlockMusicAPI.Extensions;

namespace BlockMusicAPI.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("AllowCors"), Route("api/[controller]/[action]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly BMContext _context;

        public SongsController(BMContext context)
        {
            _context = context;
        }

        #region Auto-Generated API Methods
        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Songs>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Songs>> GetSongs(int id)
        {
            var songs = await _context.Songs.FindAsync(id);

            if (songs == null)
            {
                return NotFound();
            }

            return songs;
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongs(int id, Songs songs)
        {
            if (id != songs.SongId)
            {
                return BadRequest();
            }

            _context.Entry(songs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Songs
        [HttpPost]
        public async Task<ActionResult<Songs>> PostSongs(Songs songs)
        {
            _context.Songs.Add(songs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongs", new { id = songs.SongId }, songs);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Songs>> DeleteSongs(int id)
        {
            var songs = await _context.Songs.FindAsync(id);
            if (songs == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(songs);
            await _context.SaveChangesAsync();

            return songs;
        }

        private bool SongsExists(int id)
        {
            return _context.Songs.Any(e => e.SongId == id);
        }
        #endregion

        #region Custom API Methods
        [HttpGet, Route("usersongs")]
        public async Task<ActionResult<UserSongsViewModel>> GetUserSongs(int usrID)
        {
            var userSongs = new UserSongsViewModel { User = _context.Users.Where(_ => _.UserId == usrID).FirstOrDefault() };

            foreach (var prch in _context.Purchases)
                if(prch.UserId == userSongs.User.UserId)
                    userSongs.Purchases.Add(prch);

            foreach (var sng in _context.Songs)
                foreach (var userPrchs in userSongs.Purchases)
                    if (userPrchs.SongId == sng.SongId)
                        userSongs.Songs.Add(sng);

            return userSongs;
        }

        [HttpGet]
        public async Task<string> DownloadSong([FromQuery]int songID)//IActionResult
        {
            if (songID == null)
                return "filename not present";

            var songs = _context.Songs.ToList();
            var songToDL = songs.Where(_ => _.SongId == songID).FirstOrDefault();
            string serverLocation = @"h:\root\home\lorikmanaj-001\www\blockmusicapi\songs\";

            var songName = Path.GetFileName(songToDL.PathToFile);

            serverLocation += (songName);
            //var path = Path.Combine(
            //               Directory.GetCurrentDirectory(),
            //               "wwwroot", songToDL.PathToFile);

            //var memory = new MemoryStream();
            //using (var stream = new FileStream(path, FileMode.Open))
            //{
            //    await stream.CopyToAsync(memory);
            //}
            //memory.Position = 0;
            //return File(memory, ExtensionMethods.GetContentType(path), Path.GetFileName(path));
            //return songToDL.PathToFile;
            return serverLocation;
        }
        #endregion
    }
}
