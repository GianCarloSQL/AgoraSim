using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using InnerJoinWebApi.Models;

namespace InnerJoinWebApi.Controllers
{
    public class VendasController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Vendas
        public IQueryable<Vendas> GetVendas()
        {
            return db.Vendas;
        }


        [HttpGet]
        [Route("api/sells")]
        public object GetAllSellsYear(int ano)
        {
            var cars = db.Carros;
            var sels = db.Vendas.Where(x => x.DatInc.Year == ano).AsQueryable();
            var marcas = db.Marcas;
            var retorno = from c in cars
                          join v in sels
                          on c.Id equals v.Carro
                          join m in marcas
                          on c.Marca equals m.Id
                          select new
                          {
                              MarcaVeiculo = m.Nome,
                              Modelo = c.Modelo,
                              ValorVenda = v.Valor,
                              AnoVenda = v.DatInc
                          };
            return retorno;
        }

        [HttpGet]
        [Route("api/sells")]
        public object GetAllSells()
        {
            var cars = db.Carros;
            var sels = db.Vendas;
            var marcas = db.Marcas;
            var usu = db.Usuarios;
            var retorno = from c in cars
                          join v in sels
                          on c.Id equals v.Carro
                          join m in marcas
                          on c.Marca equals m.Id
                          join u in usu
                          on v.UsuInc equals u.Id
                          orderby v.DatInc
                          select new
                          {
                              MarcaVeiculo = m.Nome,
                              Modelo = c.Modelo,
                              ValorVenda = v.Valor,
                              AnoVenda = v.DatInc,
                              UsuarioRealizouVenda = u.Usuario
                          };
            return retorno;
        }

        [HttpGet]
        [Route("api/sells/marca")]
        public object GetMostSellMarca(string marca)
        {
            //informar a marca
            var sels = db.Vendas;
            var marcas = db.Marcas.Where(x => x.Nome == marca);
            var cars = db.Carros;
            var usu = db.Usuarios;
            var retorno = from s in sels
                          join c in cars
                          on s.Carro equals c.Id
                          join m in marcas
                          on c.Marca equals m.Id
                          join u in usu
                          on s.UsuInc equals u.Id
                          orderby s.DatInc
                          group new { s } by new { s.DatInc.Year, u.Usuario }
                          into grp
                          select new
                          {
                              Quantidade = grp.Sum(x => x.s.Quantidade),
                              AnoVenda = grp.Key.Year,
                              Usuario = grp.Key.Usuario
                          };
            return retorno;
        }
        // GET: api/Vendas/5
        [ResponseType(typeof(Vendas))]
        public IHttpActionResult GetVendas(int id)
        {
            Vendas vendas = db.Vendas.Find(id);
            if (vendas == null)
            {
                return NotFound();
            }

            return Ok(vendas);
        }

        // PUT: api/Vendas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVendas(int id, Vendas vendas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vendas.Id)
            {
                return BadRequest();
            }

            db.Entry(vendas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Vendas
        [ResponseType(typeof(Vendas))]
        public IHttpActionResult PostVendas(Vendas vendas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vendas.Add(vendas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vendas.Id }, vendas);
        }

        // DELETE: api/Vendas/5
        [ResponseType(typeof(Vendas))]
        public IHttpActionResult DeleteVendas(int id)
        {
            Vendas vendas = db.Vendas.Find(id);
            if (vendas == null)
            {
                return NotFound();
            }

            db.Vendas.Remove(vendas);
            db.SaveChanges();

            return Ok(vendas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VendasExists(int id)
        {
            return db.Vendas.Count(e => e.Id == id) > 0;
        }
    }
}