using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZuvoPetApiAzure.Helpers;
using ZuvoPetApiAzure.Repositories;
using ZuvoPetNuget.Models;
using ZuvoPetNuget.Dtos;

namespace ZuvoPetApiAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Refugio")]
    public class RefugioController : ControllerBase
    {
        private IRepositoryZuvoPet repo;
        private HelperUsuarioToken helper;
        public RefugioController(IRepositoryZuvoPet repo, HelperUsuarioToken helper)
        {
            this.repo = repo;
            this.helper = helper;
        }

        [HttpGet("ObtenerRefugioByUsuarioId")]
        public async Task<ActionResult<Refugio>>
        GetRefugioByUsuarioId()
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.GetRefugioByUsuarioIdAsync(idUsuario);
        }

        [HttpGet("ObtenerMascotasByRefugioId/{idrefugio}")]
        public async Task<ActionResult<IEnumerable<Mascota>>>
        GetMascotasByRefugioId(int idrefugio)
        {
            var mascotas = await this.repo.GetMascotasByRefugioIdAsync(idrefugio);
            return Ok(mascotas);
        }

        [HttpGet("ObtenerSolicitudesByEstadoAndRefugio")]
        public async Task<ActionResult<int>>
        GetSolicitudesByEstadoAndRefugio([FromQuery] SolicitudRefugioDTO solicitud)
        {
            return await this.repo.GetSolicitudesByEstadoAndRefugioAsync(solicitud.IdRefugio, solicitud.Estado);
        }

        [HttpGet("ObtenerMascotasRefugio")]
        public async Task<ActionResult<List<MascotaCard>>>
        GetObtenerMascotasRefugio()
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.ObtenerMascotasRefugioAsync(idUsuario);
        }

        [HttpGet("ObtenerRefugio")]
        public async Task<ActionResult<Refugio>> GetObtenerRefugio()
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.GetRefugio(idUsuario);
        }

        [HttpPost("CrearMascotaRefugio")]
        public async Task<ActionResult<bool>> CrearMascotaRefugio([FromBody] Mascota mascota)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            var resultado = await this.repo.CrearMascotaRefugioAsync(mascota, idUsuario);
            return Ok(resultado);
        }

        [HttpGet("ObtenerMascotaById/{idmascota}")]
        public async Task<ActionResult<Mascota>>
        GetMascotaById(int idmascota)
        {
            return await this.repo.GetMascotaByIdAsync(idmascota);
        }

        [HttpPut("UpdateMascota")]
        public async Task<ActionResult<bool>> 
        UpdateMascota([FromBody] Mascota mascota)
        {
            var resultado = await this.repo.UpdateMascotaAsync(mascota);
            return Ok(resultado);
        }

        [HttpDelete("DeleteMascota/{idmascota}")]
        public async Task<ActionResult<bool>> 
        DeleteMascota(int idmascota)
        {
            return await this.repo.DeleteMascotaAsync(idmascota);
        }

        [HttpGet("ObtenerSolicitudesRefugio")]
        public async Task<ActionResult<List<SolicitudAdopcion>>>
        GetSolicitudesRefugio()
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.GetSolicitudesRefugioAsync(idUsuario);
        }

        [HttpGet("ObtenerSolicitudesById/{idsolicitud}")]
        public async Task<ActionResult<SolicitudAdopcion>>
        GetSolicitudesById(int idsolicitud)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.GetSolicitudByIdAsync(idUsuario, idsolicitud);
        }

        [HttpPut("ProcesarSolicitudAdopcion")]
        public async Task<ActionResult<bool>>
        ProcesarSolicitudAdopcion([FromBody] SolicitudAdopcionDTO solicitud)
        {
            return await this.repo.ProcesarSolicitudAdopcionAsync(solicitud.IdSolicitud, solicitud.NuevoEstado);
        }

        [HttpGet("ObtenerDetallesMascota/{idmascota}")]
        public async Task<ActionResult<Mascota>>
        GetDetallesMascota(int idmascota)
        {
            return await this.repo.GetDetallesMascotaAsync(idmascota);
        }

        [HttpGet("ObtenerHistoriasExito")]
        public async Task<ActionResult<List<HistoriaExito>>>
        GetHistoriasExito()
        {
            return await this.repo.ObtenerHistoriasExitoAsync();
        }

        [HttpGet("ObtenerLikeHistoria/{idhistoria}")]
        public async Task<ActionResult<List<LikeHistoria>>>
        GetLikeHistoria(int idhistoria)
        {
            return await this.repo.ObtenerLikeHistoriaAsync(idhistoria);
        }

        [HttpGet("ObtenerLikeUsuarioHistoria/{idhistoria}")]
        public async Task<ActionResult<LikeHistoria>>
        GetLikeUsuarioHistoria(int idhistoria)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.ObtenerLikeUsuarioHistoriaAsync(idhistoria, idUsuario);
        }

        [HttpDelete("EliminarLikeHistoria/{idhistoria}")]
        public async Task<ActionResult<bool>>
        DeleteLikeHistoria(int idhistoria)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.EliminarLikeHistoriaAsync(idhistoria, idUsuario);
        }

        [HttpPost("CrearLikeHistoria")]
        public async Task<ActionResult<bool>>
        CrearLikeHistoria([FromBody] LikeHistoriaDTO like)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.CrearLikeHistoriaAsync(like.IdHistoria, idUsuario, like.TipoReaccion);
        }

        [HttpPut("ActualizarLikeHistoria")]
        public async Task<ActionResult<bool>>
        ActualizarLikeHistoria([FromBody] LikeHistoriaDTO like)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.ActualizarLikeHistoriaAsync(like.IdHistoria, idUsuario, like.TipoReaccion);
        }

        [HttpGet("ObtenerContadoresReacciones/{idhistoria}")]
        public async Task<ActionResult<Dictionary<string, int>>>
        GetContadoresReacciones(int idhistoria)
        {
            return await this.repo.ObtenerContadoresReaccionesAsync(idhistoria);
        }

        [HttpGet("ObtenerNotificacionesUsuario")]
        public async Task<ActionResult<List<Notificacion>>>
        GetNotificacionesUsuario([FromQuery] int pagina = 1, [FromQuery] int tamanopagina = 10)
        {
            if (pagina <= 0)
            {
                return BadRequest("El número de página debe ser mayor que cero");
            }

            if (tamanopagina <= 0)
            {
                return BadRequest("El tamaño de página debe ser mayor que cero");
            }
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.GetNotificacionesUsuarioAsync(idUsuario, pagina, tamanopagina);
        }

        [HttpGet("ObtenerTotalNotificacionesUsuario")]
        public async Task<ActionResult<int>>
        GetTotalNotificacionesUsuario()
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.GetTotalNotificacionesUsuarioAsync(idUsuario);
        }

        [HttpGet("ObtenerTotalNotificacionesNoLeidas")]
        public async Task<ActionResult<int>>
        GetTotalNotificacionesNoLeidas()
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.GetTotalNotificacionesNoLeidasAsync(idUsuario);
        }

        [HttpGet("ObtenerNotificacionesNuevasDesde")]
        public async Task<ActionResult<bool>>
        GetNotificacionesNuevasDesde([FromQuery] DateTime desde)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.HayNotificacionesNuevasDesdeAsync(idUsuario, desde);
        }

        [HttpPut("ActualizarNotificacionComoLeida/{idnotificacion}")]
        public async Task<ActionResult<bool>>
        ActualizarNotificacionComoLeida(int idnotificacion)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.MarcarNotificacionComoLeidaAsync(idnotificacion, idUsuario);
        }

        [HttpPut("ActualizarTodasNotificacionesComoLeidas")]
        public async Task<ActionResult<bool>>
        ActualizarTodasNotificacionesComoLeidas()
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.MarcarTodasNotificacionesComoLeidasAsync(idUsuario);
        }

        [HttpDelete("EliminarNotificacion/{idnotificacion}")]
        public async Task<ActionResult<bool>>
        EliminarNotificacion(int idnotificacion)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.EliminarNotificacionAsync(idnotificacion, idUsuario);
        }

        [HttpGet("ObtenerPerfilRefugio")]
        public async Task<ActionResult<VistaPerfilRefugio>>
        GetPerfilRefugio()
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.GetPerfilRefugio(idUsuario);
        }

        [HttpGet("ObtenerFotoPerfil")]
        public async Task<ActionResult<string>>
        GetFotoPerfil()
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.GetFotoPerfilAsync(idUsuario);
        }

        [HttpGet("ObtenerConversacionesRefugio")]
        public async Task<ActionResult<List<ConversacionViewModel>>>
        GetConversacionesRefugio()
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.GetConversacionesRefugioAsync(idUsuario);
        }

        [HttpGet("ObtenerMensajesConversacion/{idotrousuario}")]
        public async Task<ActionResult<List<Mensaje>>>
        GetMensajesConversacion(int idotrousuario)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.GetMensajesConversacionAsync(idUsuario, idotrousuario);
        }

        [HttpPost("CrearMensaje")]
        public async Task<ActionResult<Mensaje>>
        CrearMensaje([FromBody] MensajeCreacionDTO mensajeDTO)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.AgregarMensajeAsync(idUsuario, mensajeDTO.IdReceptor, mensajeDTO.Contenido);
        }

        [HttpPut("ActualizarDescripcionRefugio")]
        public async Task<ActionResult<bool>>
        ActualizarDescripcionRefugio([FromBody] string descripcion)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.ActualizarDescripcionAsync(idUsuario, descripcion);
        }

        [HttpPut("ActualizarDetallesRefugio")]
        public async Task<ActionResult<bool>> 
        ActualizarDetallesRefugio([FromBody] DetallesRefugioDTO datos)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.ActualizarDetallesRefugioAsync(idUsuario, datos.Contacto, datos.CantidadAnimales, datos.CapacidadMaxima);
        }

        [HttpPut("ActualizarUbicacionRefugio")]
        public async Task<ActionResult<bool>>
        ActualizarUbicacionRefugio([FromBody] UbicacionRefugioDTO datos)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.ActualizarUbicacionRefugioAsync(idUsuario, datos.Latitud, datos.Longitud);
        }

        [HttpPut("ActualizarPerfilRefugio")]
        public async Task<ActionResult<bool>>
        ActualizarPerfilRefugio([FromBody] PerfilRefugioDTO datos)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.ActualizarPerfilRefugioAsync(idUsuario, datos.Email, datos.NombreRefugio, datos.ContactoRefugio);
        }

        [HttpPut("ActualizarFotoPerfil")]
        public async Task<ActionResult<string>>
        ActualizarFotoPerfil([FromBody] FotoPerfilDTO datos)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.ActualizarFotoPerfilAsync(idUsuario, datos.NombreArchivo);
        }

        [HttpPut("ActualizarMensajesComoLeidos/{idotrousuario}")]
        public async Task<ActionResult<bool>>
        ActualizarMensajesComoLeidos(int idotrousuario)
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.MarcarMensajesComoLeidosAsync(idUsuario, idotrousuario);
        }

        [HttpGet("ObtenerAdoptanteByUsuarioId")]
        public async Task<ActionResult<Adoptante>>
        GetAdoptanteChatByUsuarioid()
        {
            int idUsuario = this.helper.GetAuthenticatedUserId();
            return await this.repo.GetAdoptanteChatByUsuarioId(idUsuario);
        }
    }
}
