using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Models;

namespace NetCoreApi.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientControler : ControllerBase
    {
        //Listar Mediante Metodo Get
        [HttpGet]
        [Route("Listar")]
        public dynamic listClients()
        {
            List<Client> client = new List<Client>
            {
                new Client
                {
                  id = "1",
                  name = "Jhon",
                  edad = "20",
                  correo = "Jhon43769@gmail.com"
                },
                  new Client
                {
                  id = "2",
                  name = "pedro",
                  edad = "20",
                  correo = "pedro@gmail.com"
                }
            };
            return client;
        }

        //Listar los Clientes por Id con fin de mejor manipulacion
        [HttpGet]
        [Route("ListarPorId")]
        public dynamic listClientsforId(int codigo)
        {
            //Obtencion de cliente de la Base de datos
            return new Client
            {
                id = codigo.ToString(),
                name = "test",
                edad = "52",
                correo = "pepebotella@gmail.com"
            };
        }


        //Metodo de guardado Post
        [HttpPost]
        [Route("save")]
        public dynamic saveClients(Client client)
        {
            client.id = "3";

            return new
            {
                succes = true,
                message = "Cliente registrado",
                Results = client
            };
        }

        //Metodo de Borrado mediante un post y Un Header y Tokken
        [HttpPost]
        [Route("Delete")]
        public dynamic DeleteClient(Client client)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

            if(token != "Admin123.")
            {
                return new
                {
                    succes = false,
                    message = "Token Incorrento",
                    Results = client
                };
            }
            
            return new
            {
                succes = true,
                message = "Cliente Eliminado",
                Results = client
            };
        }

    }
}
