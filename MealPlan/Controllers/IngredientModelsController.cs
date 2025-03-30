using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MealPlan.Models;

namespace MealPlan.Controllers
{
    public class IngredientModelsController : Controller
    {
        private readonly MealDbContext _context;

        public IngredientModelsController(MealDbContext context)
        {
            _context = context;
        }

        // GET: IngredientModels
        public async Task<IActionResult> Index()
        {
            var mealDbContext = _context.Ingredients.Include(i => i.Nutrition);
            return View(await mealDbContext.ToListAsync());
        }

        // GET: IngredientModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredientModel = await _context.Ingredients
                .Include(i => i.Nutrition)
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredientModel == null)
            {
                return NotFound();
            }

            return View(ingredientModel);
        }

        // GET: IngredientModels/Create
        public IActionResult Create()
        {
            ViewData["NutritionId"] = new SelectList(_context.Nutritions, "NutritionId", "NutritionId");
            return View();
        }

        // POST: IngredientModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId,IngredientName,IngredientQuantity,IngredientMeasurement,NutritionId")] IngredientModel ingredientModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredientModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NutritionId"] = new SelectList(_context.Nutritions, "NutritionId", "NutritionId", ingredientModel.NutritionId);
            return View(ingredientModel);
        }

        // GET: IngredientModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredientModel = await _context.Ingredients.FindAsync(id);
            if (ingredientModel == null)
            {
                return NotFound();
            }
            ViewData["NutritionId"] = new SelectList(_context.Nutritions, "NutritionId", "NutritionId", ingredientModel.NutritionId);
            return View(ingredientModel);
        }

        // POST: IngredientModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngredientId,IngredientName,IngredientQuantity,IngredientMeasurement,NutritionId")] IngredientModel ingredientModel)
        {
            if (id != ingredientModel.IngredientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredientModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientModelExists(ingredientModel.IngredientId))
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
            ViewData["NutritionId"] = new SelectList(_context.Nutritions, "NutritionId", "NutritionId", ingredientModel.NutritionId);
            return View(ingredientModel);
        }

        // GET: IngredientModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredientModel = await _context.Ingredients
                .Include(i => i.Nutrition)
                .FirstOrDefaultAsync(m => m.IngredientId == id);
            if (ingredientModel == null)
            {
                return NotFound();
            }

            return View(ingredientModel);
        }

        // POST: IngredientModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredientModel = await _context.Ingredients.FindAsync(id);
            if (ingredientModel != null)
            {
                _context.Ingredients.Remove(ingredientModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientModelExists(int id)
        {
            return _context.Ingredients.Any(e => e.IngredientId == id);
        }
    }
}
