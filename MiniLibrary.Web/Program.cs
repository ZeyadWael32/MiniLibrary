using Microsoft.EntityFrameworkCore;
using MiniLibrary.DataAccess.Data;
using MiniLibrary.DataAccess.Repositories;
using MiniLibrary.DataAccess.Queries;
using MiniLibrary.Models.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CatalogQueries>();
builder.Services.AddScoped<BookRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default Connection"));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope()) // testing
{
    var catalogQueries = scope.ServiceProvider.GetRequiredService<CatalogQueries>();
    // await catalogQueries.GetAllBooks();

    var bookRepository = scope.ServiceProvider.GetRequiredService<BookRepository>();

    // await bookRepository.TestCreateBookAsync(new Book
    // {
    //     Title = "Test Book",
    //     ISBN = "1234567890",
    //     Description = "This is a test book.",
    //     Price = 19.99m,
    //     CategoryId = 1,
    //     PublisherId = 1
    // }, new List<int> { 1, 2 });

    // var book = await bookRepository.TestGetBookByIdAsync(9);
    // Console.WriteLine($"Book Title: {book?.Title}");

    // await bookRepository.TestUpdateBookAsync(new Book
    // {
    //     Id = 1,
    //     Title = "Updated Test Book",
    //     ISBN = "0987654321",
    //     Description = "This is an updated test book.",
    //     Price = 29.99m,
    //     CategoryId = 2,
    //     PublisherId = 2
    // }, new List<int> { 2, 3 });

    // await bookRepository.TestDeleteBookByIdAsync(6);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
