using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoApp.Data;
using VideoApp.Interfaces;
using VideoApp.Models;

namespace VideoApp.Controllers
{
    public class VideoController : Controller
    {
        private readonly IRepository _repository;
        private readonly ApplicationContext _context;

        public VideoController(IRepository repository, ApplicationContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            IList<Video> videos = _context.Videos.Include(g => g.Genres).ToList();
            var model = await _repository.SelectAll<Video>();
            return View(videos);
        }

        public async Task<IActionResult> CreateVideo()
        {
            ViewBag.GenreId = new SelectList(await _repository.SelectAll<Genre>(), "GenreId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(Video video)
        {
            var newVideo = new Video() { Name = video.Name, GenreId = video.GenreId };
            await _repository.CreateAsync<Video>(newVideo);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateVideo(int id)
        {
            ViewBag.GenreId = new SelectList(await _repository.SelectAll<Genre>(), "GenreId", "Name");
            var findModel = await _repository.SelectById<Video>(id);
            return View(findModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVideo(int? id, Video model)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync<Video>(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
