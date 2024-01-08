using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MVC_Gato_Coffee.Models;

namespace MVC_Gato_Coffee.Controllers
{
    public class AccountController : Controller
    {
        //Temporary Database
        private IMemoryCache _cache;
        public AccountController(IMemoryCache cache)
        {
            _cache = cache;
            if (!_cache.TryGetValue("accounts", out List<Account> accounts))
            {
                accounts = new List<Account>();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(5));

                _cache.Set("accounts", accounts, cacheEntryOptions);
            }

            if(!_cache.TryGetValue("ids" ,out int ids))
            {
                ids = 0;

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(5));

                _cache.Set("ids", ids, cacheEntryOptions);

            }

        }

        public IActionResult List()
        {

            var accountViewModel = _cache.Get("accounts");
            return View(accountViewModel);


        }
        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAccount(Account account)
        {
            try
            {
                int ids = (int)_cache.Get("ids");

                if(_cache.TryGetValue("accounts", out List<Account> accounts))

                {

                    account.Id = ids++;
                    accounts.Add(account);

                    _cache.Set("ids", ids);



                }

                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
