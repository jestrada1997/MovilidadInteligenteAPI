﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DO.Objects;
using BS;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace APIMongoCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraController : ControllerBase
    {
        private IRepository<Bitacora> db = new BS.Bitacoras();

        //Metodo que devuelve todo 
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await db.GetAll());
        }

        //Metodo que devuelve por id 
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAllDetails(string id)
        {
            return Ok(await db.GetAllById(id));
        }

        //Metodo para crear
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Bitacora Bitacora)
        {
            if (Bitacora == null)
                return BadRequest();

            await db.Insert(Bitacora);
            return Created("Created", true);
        }

        //Metodo para actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] Bitacora Bitacora, string id)
        {
            if (Bitacora == null)
                return BadRequest();

           // Bitacora.IdBitacora = new MongoDB.Bson.ObjectId(id);
            await db.Update(Bitacora);
            return Created("Created", true);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            await db.Delete(id);
            return NoContent();//Success
        }
    }
}
