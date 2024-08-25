using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using InformacionPublica.Server.Models;
using InformacionCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace InformacionPublica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrestopolicialController : ControllerBase
    {
        private readonly InformacionpublicaContext _dbContext;

        public ArrestopolicialController(InformacionpublicaContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [Route("Lista")]

        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<ArrestopolicialDTO>>();
            var listaArrestopolicialDTO = new List<ArrestopolicialDTO>();


            try
            {
                foreach (var item in await _dbContext.Arrestopolicials.Include(T => T.TipociudadanoNavigation).Include(C => C.CiudadanoNavigation).Include(D => D.DelitosNavigation).Include(D => D.DetencionesNavigation).Include(D => D.DenunciaNavigation).ToListAsync())
                {
                    listaArrestopolicialDTO.Add(new ArrestopolicialDTO
                    {


                        Idarrestopolicial = item.Idarrestopolicial,
                        Tipociudadano = item.Tipociudadano,
                        Ciudadano = item.Ciudadano,
                        Delitos = item.Delitos,
                        Denunciantes = item.Denunciantes,
                        Denunciados = item.Denunciados,
                        Detenciones = item.Detenciones,
                        Denuncia = item.Denuncia,
                        Estado = item.Estado,
                        Tiposciudadano = new TiposciudadanosDTO
                        {
                            Tiposciudadanos = item.TipociudadanoNavigation?.Tiposciudadanos,
                            Idtiposciudadanos = item.TipociudadanoNavigation!.Idtiposciudadanos
                        },

                        Ciudadanos = new CiudadanoDTO

                        {
                  
                        },

                        Delito = new DelitosDTO

                        {
                            Delitos = item.DelitosNavigation?.Delitos,
                            Iddelitos = item.DelitosNavigation!.Iddelitos
                        },

                        Denuncium = new DenunciaDTO

                        {
                            Denuncia = item.DenunciaNavigation?.Denuncia,
                            Iddenuncia = item.DenunciaNavigation!.Iddenuncia
                        },

                        Detencione = new DetencionesDTO

                        {
                            Detencion = item.DetencionesNavigation?.Detencion,
                            Iddetenciones = item.DetencionesNavigation!.Iddetenciones
                        },


                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaArrestopolicialDTO;
            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        
        }


        [HttpGet]
        [Route("Buscar/{id}")]

        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<ArrestopolicialDTO>();
            var ArrestopolicialDTO = new ArrestopolicialDTO();


            try
            {

               
                var dbArrestopolicial = await _dbContext.Arrestopolicials.FirstOrDefaultAsync(x => x.Idarrestopolicial == id);

                if(dbArrestopolicial != null)
                {
                    ArrestopolicialDTO.Idarrestopolicial = dbArrestopolicial.Idarrestopolicial;
                    ArrestopolicialDTO.Tipociudadano = dbArrestopolicial.Tipociudadano;
                    ArrestopolicialDTO.Ciudadano = dbArrestopolicial.Ciudadano;
                    ArrestopolicialDTO.Delitos = dbArrestopolicial.Delitos;
                    ArrestopolicialDTO.Denunciantes = dbArrestopolicial.Denunciantes;
                    ArrestopolicialDTO.Denunciados = dbArrestopolicial.Denunciados;
                    ArrestopolicialDTO.Detenciones = dbArrestopolicial.Detenciones;
                    ArrestopolicialDTO.Denuncia = dbArrestopolicial.Denuncia;
                    ArrestopolicialDTO.Estado = dbArrestopolicial.Estado;
               
                        
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = ArrestopolicialDTO;

                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = "No encontrado";
                }




                

            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);

        }



        [HttpPost]
        [Route("Guardar")]

        public async Task<IActionResult> Guardar(ArrestopolicialDTO arrestopolicial)
        {
            var responseApi = new ResponseAPI<ArrestopolicialDTO>();
           


            try
            {


                var dbArrestopolicial = new Arrestopolicial
                {

                    Idarrestopolicial = arrestopolicial.Idarrestopolicial,
                    Tipociudadano = arrestopolicial.Tipociudadano,
                    Ciudadano = arrestopolicial.Ciudadano,
                    Delitos = arrestopolicial.Delitos,
                    Denunciantes = arrestopolicial.Denunciantes,
                    Denunciados = arrestopolicial.Denunciados,
                    Detenciones = arrestopolicial.Detenciones,
                    Denuncia = arrestopolicial.Denuncia,
                    Estado = arrestopolicial.Estado

                };

                _dbContext.Arrestopolicials.Add(dbArrestopolicial);
                await _dbContext.SaveChangesAsync();


                

               




            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);

        }




    }

}
