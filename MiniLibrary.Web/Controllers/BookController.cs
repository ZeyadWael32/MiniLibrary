using Microsoft.AspNetCore.Mvc;
using MiniLibrary.DataAccess.Data;
using MiniLibrary.DataAccess.Queries;

namespace MiniLibrary.Web.Controllers;

public class BooksController : Controller
{
    private readonly CatalogQueries _catalogQueries;

    public BooksController(CatalogQueries catalogQueries)
    {
        _catalogQueries = catalogQueries;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _catalogQueries.GetAllBooks();
        return View(books);
    }
}