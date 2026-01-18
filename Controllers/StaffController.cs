using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class StaffController : Controller
{
    private readonly ApplicationDbContext _context;

    public StaffController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Staff
    public IActionResult Index()
    {
        var data = _context.FormDatas.ToList();
        return View(data);
    }

    // GET: Staff/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Staff/Create
    [HttpPost]
    public IActionResult Create(FormData formData)
    {
        if (ModelState.IsValid)
        {
            _context.FormDatas.Add(formData);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(formData);
    }

    // GET: Staff/Edit/5
    public IActionResult Edit(int id)
    {
        var formData = _context.FormDatas.Find(id);
        if (formData == null) return NotFound();
        return View(formData);
    }

    // POST: Staff/Edit/5
    [HttpPost]
    public IActionResult Edit(FormData formData)
    {
        if (ModelState.IsValid)
        {
            _context.FormDatas.Update(formData);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(formData);
    }

    // GET: Staff/Delete/5
    public IActionResult Delete(int id)
    {
        var formData = _context.FormDatas.Find(id);
        if (formData == null) return NotFound();
        return View(formData);
    }

    // POST: Staff/Delete/5
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var formData = _context.FormDatas.Find(id);
        _context.FormDatas.Remove(formData);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}
