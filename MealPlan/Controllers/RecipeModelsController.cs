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
    public class RecipeModelsController : Controller
    {
        private readonly MealDbContext _context;

        public RecipeModelsController(MealDbContext context)
        {
            _context = context;
        }

        // GET: RecipeModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        // GET: RecipeModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeModel = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipeModel == null)
            {
                return NotFound();
            }

            return View(recipeModel);
        }

        // GET: RecipeModels/Create
        public IActionResult Create()
        {
            ViewData["Ingredients"] = _context?.Ingredients?.Select(i => new SelectListItem
            {
                Value = i.IngredientId.ToString(),
                Text = i.IngredientName
            }).ToList();
            return View();
        }

        // POST: RecipeModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeId,RecipeName,RecipeDescription,RecipeDuration,RecipeDifficulty,RecipePreparationMode")] RecipeModel recipeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipeModel);
                ViewData["Ingredients"] = _context?.Ingredients?.Select(i => new SelectListItem
                {
                    Value = i.IngredientId.ToString(),
                    Text = i.IngredientName
                }).ToList();
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipeModel);
        }

        // GET: RecipeModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeModel = await _context.Recipes.FindAsync(id);
            if (recipeModel == null)
            {
                return NotFound();
            }
            return View(recipeModel);
        }

        // POST: RecipeModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,RecipeName,RecipeDescription,RecipeDuration,RecipeDifficulty,RecipePreparationMode")] RecipeModel recipeModel)
        {
            if (id != recipeModel.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeModelExists(recipeModel.RecipeId))
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
            return View(recipeModel);
        }

        // GET: RecipeModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipeModel = await _context.Recipes
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipeModel == null)
            {
                return NotFound();
            }

            return View(recipeModel);
        }

        // POST: RecipeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipeModel = await _context.Recipes.FindAsync(id);
            if (recipeModel != null)
            {
                _context.Recipes.Remove(recipeModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeModelExists(int id)
        {
            return _context.Recipes.Any(e => e.RecipeId == id);
        }
    }
}
