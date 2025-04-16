using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ZuvoPetApiAzure.DTO;
using ZuvoPetApiAzure.Helpers;
using ZuvoPetApiAzure.Repositories;
using ZuvoPetNuget;

namespace ZuvoPetApiAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Adoptante")]
    public class AdoptanteController : ControllerBase
    {
        private IRepositoryZuvoPet repo;
        private HelperUsuarioToken helper;
        public AdoptanteController(IRepositoryZuvoPet repo, HelperUsuarioToken helper)
        {
            this.repo = repo;
            this.helper = helper;
        }

        [HttpGet("ObtenerMascotasDestacadas")]
        public async Task<ActionResult<List<MascotaCard>>>
        GetMascotasDestacadas()
        {
            return await this.repo.ObtenerMascotasDestacadasAsync();
        }

        [HttpGet("ObtenerHistoriasExito")]
        public async Task<ActionResult<List<HistoriaExito>>>
        GetHistoriasExito()
        {
            return await this.repo.ObtenerHistoriasExitoAsync();
        }

        [HttpGet("ObtenerLikesHistoria/{idhistoria}")]
        public async Task<ActionResult<List<LikeHistoria>>>
        GetLikesHistoria(int idhistoria)
        {
            return await this.repo.ObtenerLikeHistoriaAsync(idhistoria);
        }

        [HttpGet("ObtenerRefugios")]
        public async Task<ActionResult<List<Refugio>>>
        GetRefugios()
        {
            return await this.repo.ObtenerRefugiosAsync();
        }

        [HttpGet("ObtenerDetallesRefugio/{idrefugio}")]
        public async Task<ActionResult<Refugio>>
        GetDetallesRefugio(int idrefugio)
        {
            return await this.repo.GetDetallesRefugioAsync(idrefugio);
        }

        [HttpGet("ObtenerMascotasRefugio/{idrefugio}")]
        public async Task<ActionResult<List<Mascota>>>
        GetMascotasRefugio(int idrefugio)
        {
            return await this.repo.GetMascotasPorRefugioAsync(idrefugio);
        }

        [HttpGet("ObtenerLikeUsuarioHistoria/{idhistoria}/{idusuario}")]
        public async Task<ActionResult<LikeHistoria>>
        GetLikeUsuarioHistoria(int idhistoria, int idusuario)
        {
            return await this.repo.ObtenerLikeUsuarioHistoriaAsync(idhistoria, idusuario);
        }

        [HttpDelete("EliminarLikeHistoria/{idhistoria}/{idusuario}")]
        public async Task<ActionResult<bool>>
        EliminarLikeHistoria(int idhistoria, int idusuario)
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

        //[HttpGet("ObtenerPerfilAdoptante/{idusuario}")]
        //public async Task<ActionResult<VistaPerfilAdoptante>>
        //GetPerfilAdoptante(int idusuario)
        //{
        //    return await this.repo.GetPerfilAdoptante(idusuario);
        //}

        // Ejemplo de cómo modificar un endpoint para usar el helper
        [HttpGet("ObtenerPerfilAdoptante")]
        public async Task<ActionResult<VistaPerfilAdoptante>> GetPerfilAdoptante()
        {
            // Obtener el usuario del token
            var usuario = this.helper.GetUsuario();
            if (usuario == null)
            {
                return Unauthorized();
            }

            return await this.repo.GetPerfilAdoptante(usuario.IdUsuario);
        }

        //[HttpGet("ObtenerMascotasFavoritas/{idusuario}")]
        //public async Task<ActionResult<List<MascotaCard>>>
        //GetMascotasFavoritas(int idusuario)
        //{
        //    return await this.repo.ObtenerMascotasFavoritas(idusuario);
        //}

        [HttpGet("ObtenerMascotasFavoritas")]
        public async Task<ActionResult<List<MascotaCard>>> GetMascotasFavoritas()
        {
            var usuario = this.helper.GetUsuario();
            return await this.repo.ObtenerMascotasFavoritas(usuario.IdUsuario);
        }

        [HttpGet("ObtenerMascotasAdoptadas/{idusuario}")]
        public async Task<ActionResult<List<MascotaAdoptada>>>
        GetMascotasAdoptadas(int idusuario)
        {
            return await this.repo.ObtenerMascotasAdoptadas(idusuario);
        }

        [HttpGet("ObtenerFotoPerfil/{idusuario}")]
        public async Task<ActionResult<string>>
        GetFotoPerfil(int idusuario)
        {
            return await this.repo.GetFotoPerfilAsync(idusuario);
        }

        [HttpGet("ObtenerMascotas")]
        public async Task<ActionResult<List<MascotaCard>>>
        GetMascotas()
        {
            return await this.repo.ObtenerMascotasAsync();
        }

        [HttpGet("ObtenerUltimaAccionFavorito/{idusuario}/{idmascota}")]
        public async Task<ActionResult<DateTime?>>
        GetUltimaAccionFavorito(int idusuario, int idmascota)
        {
            return await this.repo.ObtenerUltimaAccionFavorito(idusuario, idmascota);
        }

        [HttpGet("ObtenerEsFavorito/{idusuario}/{idmascota}")]
        public async Task<ActionResult<bool>>
        GetEsFavorito(int idusuario, int idmascota)
        {
            return await this.repo.EsFavorito(idusuario, idmascota);
        }

        [HttpDelete("EliminarFavorito/{idusuario}/{idmascota}")]
        public async Task<ActionResult<bool>>
        EliminarFavorito(int idusuario, int idmascota)
        {
            return await this.repo.EliminarFavorito(idusuario, idmascota);
        }

        [HttpPost("CrearMascotaFavorita/{idusuario}/{idmascota}")]
        public async Task<ActionResult<bool>>
        CrearMascotaFavorita(int idusuario, int idmascota)
        {
            return await this.repo.InsertMascotaFavorita(idusuario, idmascota);
        }

        [HttpGet("ObtenerDetallesMascota/{idmascota}")]
        public async Task<ActionResult<Mascota>>
        GetDetallesMascota(int idmascota)
        {
            return await this.repo.GetDetallesMascotaAsync(idmascota);
        }

        [HttpGet("ObtenerExisteSolicitudAdopcion/{idusuario}/{idmascota}")]
        public async Task<ActionResult<bool>>
        GetExisteSolicitudAdopcion(int idusuario, int idmascota)
        {
            return await this.repo.ExisteSolicitudAdopcionAsync(idusuario, idmascota);
        }

        [HttpPost("CrearSolicitudAdopcion/{idusuario}/{idmascota}")]
        public async Task<ActionResult<SolicitudAdopcion>>
        CrearSolicitudAdopcion(int idusuario, int idmascota)
        {
            return await this.repo.CrearSolicitudAdopcionAsync(idusuario, idmascota);
        }

        [HttpGet("ObtenerNombreMascota/{idmascota}")]
        public async Task<ActionResult<string>>
        GetNombreMascota(int idmascota)
        {
            return await this.repo.GetNombreMascotaAsync(idmascota);
        }

        [HttpGet("ObtenerIdRefugioPorMascota/{idmascota}")]
        public async Task<ActionResult<int?>>
        GetIdRefugioPorMascota(int idmascota)
        {
            return await this.repo.IdRefugioPorMascotaAsync(idmascota);
        }

        [HttpPost("CrearNotificacion/{idsolicitud}/{idrefugio}/{nombremascota}")]
        public async Task<ActionResult<bool>>
        CrearNotificacion(int idsolicitud, int idrefugio, string nombremascota)
        {
            return await this.repo.CrearNotificacionAsync(idsolicitud, idrefugio, nombremascota);
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

        [HttpGet("ObtenerHayNotificacionesNuevasDesde/{idusuario}/{desde}")]
        public async Task<ActionResult<bool>>
        GetHayNotificacionesNuevasDesde(int idusuario, DateTime desde)
        {
            return await this.repo.HayNotificacionesNuevasDesdeAsync(idusuario, desde);
        }

        [HttpPut("ActualizarMarcarNotificacionComoLeida/{idnotificacion}/{idusuario}")]
        public async Task<ActionResult<bool>>
        GetMarcarNotificacionComoLeida(int idnotificacion, int idusuario)
        {
            return await this.repo.MarcarNotificacionComoLeidaAsync(idnotificacion, idusuario);
        }

        [HttpPut("ActualizarMarcarTodasNotificacionesComoLeidas/{idusuario}")]
        public async Task<ActionResult<bool>>
        GetMarcarTodasNotificacionesComoLeidas(int idusuario)
        {
            return await this.repo.MarcarTodasNotificacionesComoLeidasAsync(idusuario);
        }

        [HttpDelete("EliminarNotificacion/{idnotificacion}/{idusuario}")]
        public async Task<ActionResult<bool>>
        EliminarNotificacion(int idnotificacion, int idusuario)
        {
            return await this.repo.EliminarNotificacionAsync(idnotificacion, idusuario);
        }

        [HttpGet("ObtenerMascotasAdoptadasSinHistoria/{idusuario}")]
        public async Task<ActionResult<List<Mascota>>>
        GetMascotasAdoptadasSinHistoria(int idusuario)
        {
            return await this.repo.GetMascotasAdoptadasSinHistoria(idusuario);
        }

        [HttpGet("ObtenerAdoptanteByUsuarioId/{idusuario}")]
        public async Task<ActionResult<Adoptante>>
        GetAdoptanteByUsuarioId(int idusuario)
        {
            return await this.repo.GetAdoptanteByUsuarioId(idusuario);
        }

        [HttpPost("CrearHistoriaExito/{historiaexito}/{idusuario}")]
        public async Task<ActionResult<bool>>
        CrearHistoriaExito(HistoriaExito historiaexito, int idusuario)
        {
            return await this.repo.CrearHistoriaExito(historiaexito, idusuario);
        }

        [HttpGet("ObtenerConversacionesAdoptante/{idusuario}")]
        public async Task<ActionResult<List<ConversacionViewModel>>>
        GetConversacionesAdoptante(int idusuario)
        {
            return await this.repo.GetConversacionesAdoptanteAsync(idusuario);
        }

        [HttpGet("ObtenerMensajesConversacion/{idusuarioactual}/{idotrousuario}")]
        public async Task<ActionResult<List<Mensaje>>>
        GetMensajesConversacion(int idusuarioactual, int idotrousuario)
        {
            return await this.repo.GetMensajesConversacionAsync(idusuarioactual, idotrousuario);
        }

        [HttpPost("CrearMensaje/{idemisor}/{idreceptor}/{contenido}")]
        public async Task<ActionResult<Mensaje>>
        CrearMensaje(int idemisor, int idreceptor, string contenido)
        {
            return await this.repo.AgregarMensajeAsync(idemisor, idreceptor, contenido);
        }

        [HttpPut("ActualizarDescripcionAdoptante/{idusuario}")]
        public async Task<ActionResult<bool>>
        ActualizarDescripcionAdoptante(int idusuario, [FromBody] string descripcion)
        {
            return await this.repo.ActualizarDescripcionAdoptante(idusuario, descripcion);
        }

        [HttpPut("ActualizarDetallesAdoptante/{idusuario}")]
        public async Task<ActionResult<bool>>
        ActualizarDetallesAdoptante(int idusuario, [FromBody] DetallesAdoptanteUpdateDTO detallesDTO)
        {
            VistaPerfilAdoptante modelo = new VistaPerfilAdoptante
            {
                TipoVivienda = detallesDTO.TipoVivienda,
                RecursosDisponibles = detallesDTO.RecursosDisponibles,
                TiempoEnCasa = detallesDTO.TiempoEnCasa,
                TieneJardin = detallesDTO.TieneJardin,
                OtrosAnimales = detallesDTO.OtrosAnimales
            };
            return await this.repo.ActualizarDetallesAdoptante(
                idusuario,
                modelo);
        }

        [HttpPut("ActualizarPerfilAdoptante/{idusuario}")]
        public async Task<ActionResult<bool>>
        ActualizarPerfilAdoptante(int idusuario, [FromBody] PerfilAdoptanteDTO datos)
        {
            return await this.repo.ActualizarPerfilAdoptante(
                idusuario,
                datos.Email,
                datos.Nombre);
        }

        [HttpPut("ActualizarFotoPerfil/{idusuario}")]
        public async Task<ActionResult<bool>>
        ActualizarFotoPerfil(int idusuario, [FromBody] FotoPerfilDTO datos)
        {
            return await this.repo.ActualizarFotoPerfilAdoptante(
                idusuario,
                datos.NombreArchivo);
        }

        [HttpPut("ActualizarVistasMascota/{idmascota}")]
        public async Task<ActionResult<bool>>
        IncrementarVistasMascota(int idmascota)
        {
            return await this.repo.IncrementarVistasMascota(idmascota);
        }

        [HttpPut("ActualizarMensajesComoLeidos/{idusuarioactual}/{idotrousuario}")]
        public async Task<ActionResult<bool>>
        ActualizarMensajesComoLeidos(int idusuarioactual, int idotrousuario)
        {
            return await this.repo.MarcarMensajesComoLeidosAsync(idusuarioactual, idotrousuario);
        }

        [HttpGet("ObtenerAdoptanteByUsuarioIdAsync/{idusuario}")]
        public async Task<ActionResult<Adoptante>>
        GetAdoptanteByUsuarioIdAsync(int idusuario)
        {
            return await this.repo.GetAdoptanteByUsuarioIdAsync(idusuario);
        }

        [HttpGet("ObtenerRefugioChatById/{idrefugio}")]
        public async Task<ActionResult<Refugio>>
        GetRefugioChatById(int idrefugio)
        {
            return await this.repo.GetRefugioChatByIdAsync(idrefugio);
        }

        [HttpGet("ObtenerRefugioChatDosById/{idusuario}")]
        public async Task<ActionResult<Refugio>>
        GetRefugioChatDosById(int idusuario)
        {
            return await this.repo.GetRefugioChatDosByIdAsync(idusuario);
        }
    }
}
