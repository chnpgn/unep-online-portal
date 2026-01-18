using Microsoft.AspNetCore.Mvc;

public class FormController : Controller
{
    private readonly ApplicationDbContext _context;

    public FormController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            return RedirectToAction("Login", "Account");

        return View();
    }

    [HttpPost]
    public IActionResult Submit(FormData formData)
    {
        _context.FormDatas.Add(formData);
        _context.SaveChanges();
        ViewBag.Message = "Form submitted successfully!";
        return View("Index");
    }
}
