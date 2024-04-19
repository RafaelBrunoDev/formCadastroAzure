using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace formCadastroAzure.Controllers
{
    public class HomeController : Controller
    {
        private readonly string connectionString = "Banco de Dados";

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(tbl_Cadastro model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO tbl_Cadastro (Nome, Celular, Pais, Cidade, Estado) VALUES (@Nome, @Celular, @Pais, @Cidade, @Estado)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Nome", model.Nome);
                        command.Parameters.AddWithValue("@Celular", model.Celular);
                        command.Parameters.AddWithValue("@Pais", model.Pais);
                        command.Parameters.AddWithValue("@Cidade", model.Cidade);
                        command.Parameters.AddWithValue("@Estado", model.Estado);
                        command.ExecuteNonQuery();
                    }

                    return RedirectToAction("About");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocorreu um erro ao salvar os dados: " + ex.Message);
                }
            }

            return View(model);
        }



        public ActionResult About()
        {

            List<tbl_Cadastro> cadastros = new List<tbl_Cadastro>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Nome, Celular, Pais, Cidade, Estado FROM tbl_Cadastro";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tbl_Cadastro cadastro = new tbl_Cadastro
                        {
                            Nome = reader["Nome"].ToString(),
                            Celular = reader["Celular"].ToString(),
                            Pais = reader["Pais"].ToString(),
                            Cidade = reader["Cidade"].ToString(),
                            Estado = reader["Estado"].ToString()
                        };
                        cadastros.Add(cadastro);
                    }
                }
            }
            catch (Exception ex)
            {
                // Tratar erros de consulta, se necessário.
            }

            return View(cadastros);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}