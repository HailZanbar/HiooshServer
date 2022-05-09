#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HiooshServer.Data;
using HiooshServer.Models;
using HiooshServer.Services;

namespace HiooshServer.Controllers
{
    public class RatingsController : Controller
    {
        //private readonly HiooshServerContext _context;
        private readonly IRatingsService _ratingsService;

        public RatingsController(HiooshServerContext context)
        {
            //_context = context;
            _ratingsService = new RatingService();
        }

        // GET: Ratings
        public IActionResult Index()
        {
            return View(_ratingsService.GetAllRating());
        }

        // GET: Ratings/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = _ratingsService.GetRating(id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // GET: Ratings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int id, int NumberRating, string StringRating, string Name)
        {
            Rating rating = new Rating();
            rating.Id = id;
            rating.NumberRating = NumberRating;
            rating.StringRating = StringRating;
            rating.Name = Name;
            rating.Date = DateTime.Now.ToString("MM/dd/yyyy");
            if (ModelState.IsValid)
            {
                _ratingsService.AddRating(rating);
                return RedirectToAction(nameof(Index));
            }
            return View(rating);
        }

        // GET: Ratings/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = _ratingsService.GetRating(id);
            if (rating == null)
            {
                return NotFound();
            }
            return View(rating);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, int NumberRating, string StringRating)
        {
            if (id != id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ratingsService.UpdateRating(id, NumberRating,StringRating);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(_ratingsService.GetRating(id));
        }

        // GET: Ratings/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = _ratingsService.GetRating(id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _ratingsService.DeleteRating(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RatingExists(int id)
        {
            return _ratingsService.GetAllRating().Any(e => e.Id == id);
        }
    }
}
