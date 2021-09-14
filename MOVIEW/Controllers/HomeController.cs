using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOVIEW.Authentication;
using MOVIEW.Context;
using MOVIEW.Models;
using Newtonsoft.Json;

namespace MOVIEW.Controllers
{
    public class HomeController : Controller
    {
        private readonly MoviewDbContext _context;

        public HomeController(MoviewDbContext context)
        {
            _context = context;
        }
        //[HttpGet]
        public async Task<IActionResult> Index([Optional] string search)
        {
            {
                //      POPULAR MOVIES
                var client = new HttpClient();
                var request_popular_movies = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://api.themoviedb.org/3/discover/movie?sort_by=popularity.desc&api_key=7e0768276e28e7e3f4136f2e524c7c7c"),
                };
                using (var response = await client.SendAsync(request_popular_movies))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                    dynamic jsonObj = JsonConvert.DeserializeObject(body);

                    ViewBag.popular_movies = jsonObj.results;

                    ViewBag.image = "https://image.tmdb.org/t/p/w500";

                }

            }

        

            if (search == null)
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://data-imdb1.p.rapidapi.com/genres/"),
                    Headers =
    {
        { "x-rapidapi-host", "data-imdb1.p.rapidapi.com" },
        { "x-rapidapi-key", "c21fe0f4a9msh1e2fcb6f97e0057p1a3b9fjsnf04d8e54d851" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                    dynamic jsonObj = JsonConvert.DeserializeObject(body);
                    foreach (var item in jsonObj.Genres)
                    {
                        Console.WriteLine(item.genre);
                    }
                    ViewBag.Json = jsonObj.Genres;

                }
                return View(await _context.Movies.ToListAsync());


            }
            else
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://data-imdb1.p.rapidapi.com/genres/"),
                    Headers =
    {
        { "x-rapidapi-host", "data-imdb1.p.rapidapi.com" },
        { "x-rapidapi-key", "c21fe0f4a9msh1e2fcb6f97e0057p1a3b9fjsnf04d8e54d851" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                    dynamic jsonObj = JsonConvert.DeserializeObject(body);

                    ViewBag.Json = jsonObj.Genres;


                }
                var c =  _context.Movies.Where(x => x.strMovieName.Contains(search) || x.strDescription.Contains(search)).ToList();
                ViewBag.count = c.Count();

                return View( _context.Movies.Where(x => x.strMovieName.Contains(search) || x.strDescription.Contains(search)).ToList());
            }
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int id)
        {
            string url;
            string url2;
        
            {
                //      POPULAR MOVIES
                var client = new HttpClient();
                var request_popular_movies = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://api.themoviedb.org/3/movie/"+id+"?api_key=7e0768276e28e7e3f4136f2e524c7c7c&language=en-US"),
                };
                using (var response = await client.SendAsync(request_popular_movies))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(body);
                    dynamic jsonObj = JsonConvert.DeserializeObject(body);

                    ViewBag.Single_movie = jsonObj;

                    ViewBag.image = "https://image.tmdb.org/t/p/w500";
                     url = jsonObj.poster_path;
                     url2 = jsonObj.backdrop_path;
                    
                        

                }

            }



           
            ViewBag.image = "https://image.tmdb.org/t/p/w500/"+url;
            ViewBag.backdrop_path = "https://image.tmdb.org/t/p/w500/"+url;

            return View();
        }

        private IActionResult View(Func<IActionResult> movieDetails)
        {
            throw new NotImplementedException();
        }

        public IActionResult Privacy()
        {
            return View();
        } public IActionResult Price()
        {
            return View();
        }public IActionResult MoviewDashboard()
        {
            return View();
        }
        public IActionResult Movies()
        {

            return View();
        }
        public IActionResult Login()
        {
            return View();
        } public IActionResult Add_To_Cart( string id)
        {
            return View();
        }
           public IActionResult MovieDetails(string id)
            
        {
            return View();
        }

        public IActionResult LoginUser(Register user)
        {
            if (user.Username == null || user.Password == null)
            {
               
                TempData["emptyfields"] = "Please provide your Email and Password!";          return RedirectToAction("Login", "Home");

            }
            var pass = user.Username;

            Tokens TokenProvider = new Tokens(_context);

            var userToken = TokenProvider.LoginUser(user.Username, user.Password);
            if (userToken == null)
            {
                var find_id = _context.registers.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
                HttpContext.Session.SetString("id", find_id.id.ToString());
                TempData["wrong"] = "Invalid Login Attempt! Try again.";
                return RedirectToAction("Login", "Home");

            }
            // HttpContext.Session.SetString("JWToken", "userToken");
            //var user = _context.registers.SingleOrDefault(x => x.Username == User.Identity.Name)
            //     if(user.Username=)
            //     {

            //     }
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
