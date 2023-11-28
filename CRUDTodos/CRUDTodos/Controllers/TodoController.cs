using Microsoft.AspNetCore.Mvc;
using CRUDTodos.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using CRUDTodos.Filter;

namespace CRUDTodos.Controllers
{
    public class TodoController : Controller
    {
        [AuthFilter]
        public IActionResult Index()
        {
            List<TODO> Todos = new List<TODO>();
            if (HttpContext.Session.GetString("Todos") != null) { 

            Todos = JsonSerializer.Deserialize<List<TODO>>(HttpContext.Session.GetString("Todos"));
            }
            return View(Todos);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(TODO t)
        {
            if (ModelState.IsValid)
            {
                List<TODO> Todos;

                if (HttpContext.Session.GetString("Todos") == null)
                {
                    Todos = new List<TODO>();
                }
                else
                {
                    Todos = JsonSerializer.Deserialize<List<TODO>>(HttpContext.Session.GetString("Todos"));
                }

                Todos.Add(t);

                string listSerialized = JsonSerializer.Serialize(Todos);
                HttpContext.Session.SetString("Todos", listSerialized);

                return RedirectToAction("Index");
            

        }
            return View();
        }
        public IActionResult Update(int id)
        {
            if (HttpContext.Session.GetString("Produits") != null)
            {
                List<TODO> Todos = JsonSerializer.Deserialize<List<TODO>>(HttpContext.Session.GetString("Todos"));

                TODO todoExist = Todos.FirstOrDefault(t => t.Id == id);

                if (todoExist != null)
                {
                    return View(todoExist);
                }
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Update(TODO nouveauTodo)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetString("Todos") != null)
                {
                    List<TODO> Todos = JsonSerializer.Deserialize<List<TODO>>(HttpContext.Session.GetString("Todos"));

                    TODO todoExist = Todos.FirstOrDefault(t => t.Id == nouveauTodo.Id);

                    if (todoExist != null)
                    {
                        todoExist.Libelle = nouveauTodo.Libelle;
                        todoExist.Description = nouveauTodo.Description;
                        todoExist.State = nouveauTodo.State;
                        todoExist.DateLimite = nouveauTodo.DateLimite;

                        HttpContext.Session.SetString("Todos", JsonSerializer.Serialize(Todos));

                        return RedirectToAction(nameof(Index));
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(nouveauTodo);
        }
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Todos") != null)
            {
                List<TODO> Todos = JsonSerializer.Deserialize<List<TODO>>(HttpContext.Session.GetString("Todos"));

                TODO t = Todos.FirstOrDefault(tod => tod.Id == id);

                if (t != null)
                {
                    Todos.Remove(t);
                    HttpContext.Session.SetString("Todos", JsonSerializer.Serialize(Todos));
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
