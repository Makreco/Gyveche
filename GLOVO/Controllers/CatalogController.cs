using GLOVO.Data;
using GLOVO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GLOVO.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Catalog
        public ActionResult Index()
        {
            List<FoodModel> products = new List<FoodModel>();
            
            FoodDAO foodDAO = new FoodDAO();

            products = foodDAO.FetchAll();

            return View("Index", products);
        }
        public ActionResult Details(int ID)
        {
            FoodDAO foodDAO = new FoodDAO();
            FoodModel food = foodDAO.FetchOne(ID);
            return View("Details", food);
        }
        public ActionResult Create()
        {
            return View("Create");
        }

        public ActionResult Edit(int ID)
        {
            FoodDAO foodDAO = new FoodDAO();
            FoodModel food = foodDAO.FetchOne(ID);
            return View("FoodForm", food);
        }
        public ActionResult Delete(int ID)
        {
            FoodDAO foodDAO = new FoodDAO();
            foodDAO.Delete(ID);
            List<FoodModel> products = foodDAO.FetchAll();
            return View("Index", products);
        }

        [HttpPost]
        public ActionResult Edit(FoodModel foodModel)
        {
            FoodDAO foodDAO = new FoodDAO();

            foodDAO.CreateOrUpdate(foodModel);

            return View("Details", foodModel);
        }

        [HttpPost]
        public ActionResult Create(FoodModel foodModel)
        {
            FoodDAO foodDAO = new FoodDAO();

            foodDAO.CreateOrUpdate(foodModel);

            return RedirectToAction("Index", "Catalog");
        }

        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }
        public ActionResult SearchForName(string searchPhrase)
        {
            FoodDAO foodDAO = new FoodDAO();
            List<FoodModel> searchResult = foodDAO.SearchForName(searchPhrase);
            return View("Index", searchResult);
        }
        public ActionResult SearchForDescription(string searchPhrase)
        {
            FoodDAO foodDAO = new FoodDAO();
            List<FoodModel> searchResult = foodDAO.SearchForDescription(searchPhrase);
            return View("Index", searchResult);
        }
    }
}