using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZuvoPetApiAzure.DTO;
using ZuvoPetApiAzure.Repositories;
using ZuvoPetNuget;

namespace ZuvoPetApiAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefugioController : ControllerBase
    {
        private IRepositoryZuvoPet repo;
        public RefugioController(IRepositoryZuvoPet repo)
        {
            this.repo = repo;
        }

        [HttpGet("ObtenerRefugioByUsuarioId/{idusuario}")]
        public async Task<ActionResult<Refugio>>
        GetRefugioByUsuarioId(int idusuario)
        {
            return await this.repo.GetRefugioByUsuarioIdAsync(idusuario);
        }

        [HttpGet("ObtenerMascotasByRefugioId/{idrefugio}")]
        public async Task<ActionResult<IEnumerable<Mascota>>>
        GetMascotasByRefugioId(int idrefugio)
        {
            var mascotas = await this.repo.GetMascotasByRefugioIdAsync(idrefugio);
            return Ok(mascotas);
        }

        [HttpGet("ObtenerSolicitudesByEstadoAndRefugio/{idrefugio}/{estado}")]
        public async Task<ActionResult<int>>
        GetSolicitudesByEstadoAndRefugio(int idrefugio, string estado)
        {
            return await this.repo.GetSolicitudesByEstadoAndRefugioAsync(idrefugio, estado);
        }

        [HttpGet("ObtenerMascotasRefugio/{idusuario}")]
        public async Task<ActionResult<List<MascotaCard>>>
        GetObtenerMascotasRefugio(int idusuario)
        {
            return await this.repo.ObtenerMascotasRefugioAsync(idusuario);
        }

        [HttpGet("ObtenerRefugio/{idusuario}")]
        public async Task<ActionResult<Refugio>>
        GetObtenerRefugio(int idusuario)
        {
            return await this.repo.GetRefugio(idusuario);
        }

        [HttpPost("CrearMascotaRefugio/{idusuario}")]
        public async Task<ActionResult<bool>> CrearMascotaRefugio([FromBody] Mascota mascota, int idusuario)
        {
            var resultado = await this.repo.CrearMascotaRefugioAsync(mascota, idusuario);
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

        [HttpGet("ObtenerSolicitudesRefugio/{idusuario}")]
        public async Task<ActionResult<List<SolicitudAdopcion>>>
        GetSolicitudesRefugio(int idusuario)
        {
            return await this.repo.GetSolicitudesRefugioAsync(idusuario);
        }

        [HttpGet("ObtenerSolicitudesById/{idusuario}/{idsolicitud}")]
        public async Task<ActionResult<SolicitudAdopcion>>
        GetSolicitudesById(int idusuario, int idsolicitud)
        {
            return await this.repo.GetSolicitudByIdAsync(idusuario, idsolicitud);
        }

        [HttpPut("ProcesarSolicitudAdopcion/{idsolicitud}/{nuevoestado}")]
        public async Task<ActionResult<bool>> 
        ProcesarSolicitudAdopcion(int idsolicitud, string nuevoestado)
        {
            return await this.repo.ProcesarSolicitudAdopcionAsync(idsolicitud, nuevoestado);
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

        [HttpGet("ObtenerLikeUsuarioHistoria/{idhistoria}/{idusuario}")]
        public async Task<ActionResult<LikeHistoria>>
        GetLikeUsuarioHistoria(int idhistoria, int idusuario)
        {
            return await this.repo.ObtenerLikeUsuarioHistoriaAsync(idhistoria, idusuario);
        }

        [HttpDelete("EliminarLikeHistoria/{idhistoria}/{idusuario}")]
        public async Task<ActionResult<bool>>
        DeleteLikeHistoria(int idhistoria, int idusuario)
        {
            return await this.repo.EliminarLikeHistoriaAsync(idhistoria, idusuario);
        }

        [HttpPost("CrearLikeHistoria/{idhistoria}/{idusuario}/{tiporeaccion}")]
        public async Task<ActionResult<bool>>
        CrearLikeHistoria(int idhistoria, int idusuario, string tiporeaccion)
        {
            return await this.repo.CrearLikeHistoriaAsync(idhistoria, idusuario, tiporeaccion);
        }

        [HttpPut("ActualizarLikeHistoria/{idhistoria}/{idusuario}/{tiporeaccion}")]
        public async Task<ActionResult<bool>>
        ActualizarLikeHistoria(int idhistoria, int idusuario, string tiporeaccion)
        {
            return await this.repo.ActualizarLikeHistoriaAsync(idhistoria, idusuario, tiporeaccion);
        }

        [HttpGet("ObtenerContadoresReacciones/{idhistoria}")]
        public async Task<ActionResult<Dictionary<string, int>>>
        GetContadoresReacciones(int idhistoria)
        {
            return await this.repo.ObtenerContadoresReaccionesAsync(idhistoria);
        }

        [HttpGet("ObtenerNotificacionesUsuario/{idusuario}/{pagina}/{tamanopagina}")]
        public async Task<ActionResult<List<Notificacion>>>
        GetNotificacionesUsuario(int idusuario, int pagina, int tamanopagina)
        {
            return await this.repo.GetNotificacionesUsuarioAsync(idusuario, pagina, tamanopagina);
        }

        [HttpGet("ObtenerTotalNotificacionesUsuario/{idusuario}")]
        public async Task<ActionResult<int>>
        GetTotalNotificacionesUsuario(int idusuario)
        {
            return await this.repo.GetTotalNotificacionesUsuarioAsync(idusuario);
        }

        [HttpGet("ObtenerTotalNotificacionesNoLeidas/{idusuario}")]
        public async Task<ActionResult<int>>
        GetTotalNotificacionesNoLeidas(int idusuario)
        {
            return await this.repo.GetTotalNotificacionesNoLeidasAsync(idusuario);
        }

        [HttpGet("ObtenerNotificacionesNuevasDesde/{idusuario}/{desde}")]
        public async Task<ActionResult<bool>>
        GetNotificacionesNuevasDesde(int idusuario, DateTime desde)
        {
            return await this.repo.HayNotificacionesNuevasDesdeAsync(idusuario, desde);
        }

        [HttpPut("ActualizarNotificacionComoLeida/{idnotificacion}/{idusuario}")]
        public async Task<ActionResult<bool>>
        ActualizarNotificacionComoLeida(int idnotificacion, int idusuario)
        {
            return await this.repo.MarcarNotificacionComoLeidaAsync(idnotificacion, idusuario);
        }

        [HttpPut("ActualizarTodasNotificacionesComoLeidas/{idusuario}")]
        public async Task<ActionResult<bool>>
        ActualizarTodasNotificacionesComoLeidas(int idusuario)
        {
            return await this.repo.MarcarTodasNotificacionesComoLeidasAsync(idusuario);
        }

        [HttpDelete("EliminarNotificacion/{idnotificacion}/{idusuario}")]
        public async Task<ActionResult<bool>>
        EliminarNotificacion(int idnotificacion, int idusuario)
        {
            return await this.repo.EliminarNotificacionAsync(idnotificacion, idusuario);
        }

        [HttpGet("ObtenerPerfilRefugio/{idusuario}")]
        public async Task<ActionResult<VistaPerfilRefugio>>
        GetPerfilRefugio(int idusuario)
        {
            return await this.repo.GetPerfilRefugio(idusuario);
        }

        [HttpGet("ObtenerFotoPerfil/{idusuario}")]
        public async Task<ActionResult<string>>
        GetFotoPerfil(int idusuario)
        {
            return await this.repo.GetFotoPerfilAsync(idusuario);
        }

        [HttpGet("ObtenerConversacionesRefugio/{idusuario}")]
        public async Task<ActionResult<List<ConversacionViewModel>>>
        GetConversacionesRefugio(int idusuario)
        {
            return await this.repo.GetConversacionesRefugioAsync(idusuario);
        }

        [HttpGet("ObtenerMensajesConversacion/{idusuarioactual}/{idotrousuario}")]
        public async Task<ActionResult<List<Mensaje>>>
        GetMensajesConversacion(int idusuarioactual, int idotrousuario)
        {
            return await this.repo.GetMensajesConversacionAsync(idusuarioactual, idotrousuario);
        }

        [HttpPost("CrearMensaje/{idemisor}/{idreceptor}")]
        public async Task<ActionResult<Mensaje>>
        CrearMensaje(int idemisor, int idreceptor, [FromBody] string contenido)
        {
            return await this.repo.AgregarMensajeAsync(idemisor, idreceptor, contenido);
        }

        [HttpPut("ActualizarDescripcionRefugio/{idusuario}")]
        public async Task<ActionResult<bool>>
        ActualizarDescripcionRefugio(int idusuario, [FromBody] string descripcion)
        {
            return await this.repo.ActualizarDescripcionAsync(idusuario, descripcion);
        }

        [HttpPut("ActualizarDetallesRefugio/{idusuario}")]
        public async Task<ActionResult<bool>> 
        ActualizarDetallesRefugio(int idusuario, [FromBody] DetallesRefugioDTO datos)
        {
            return await this.repo.ActualizarDetallesRefugioAsync(
                idusuario,
                datos.Contacto,
                datos.CantidadAnimales,
                datos.CapacidadMaxima);
        }

        [HttpPut("ActualizarUbicacionRefugio/{idusuario}")]
        public async Task<ActionResult<bool>>
        ActualizarUbicacionRefugio(int idusuario, [FromBody] UbicacionRefugioDTO datos)
        {
            return await this.repo.ActualizarUbicacionRefugioAsync(
                idusuario,
                datos.Latitud,
                datos.Longitud);
        }

        [HttpPut("ActualizarPerfilRefugio/{idusuario}")]
        public async Task<ActionResult<bool>>
        ActualizarPerfilRefugio(int idusuario, [FromBody] PerfilRefugioDTO datos)
        {
            return await this.repo.ActualizarPerfilRefugioAsync(
                idusuario,
                datos.Email,
                datos.NombreRefugio,
                datos.ContactoRefugio);
        }

        [HttpPut("ActualizarFotoPerfil/{idusuario}")]
        public async Task<ActionResult<string>>
        ActualizarFotoPerfil(int idusuario, [FromBody] FotoPerfilDTO datos)
        {
            return await this.repo.ActualizarFotoPerfilAsync(
                idusuario,
                datos.NombreArchivo);
        }

        [HttpPut("ActualizarMensajesComoLeidos/{idusuarioactual}/{idotrousuario}")]
        public async Task<ActionResult<bool>>
        ActualizarMensajesComoLeidos(int idusuarioactual, int idotrousuario)
        {
            return await this.repo.MarcarMensajesComoLeidosAsync(idusuarioactual, idotrousuario);
        }

        [HttpGet("ObtenerAdoptanteByUsuarioId/{idusuario}")]
        public async Task<ActionResult<Adoptante>>
        GetAdoptanteChatByUsuarioid(int idusuario)
        {
            return await this.repo.GetAdoptanteChatByUsuarioId(idusuario);
        }
    }
}
