namespace TvCatalog.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TvCatalog.Business;
    using TvCatalog.Common;
    using TvCatalog.Data;
    using TvCatalog.Entities;

    /// <summary>
    /// Controlador de la API de episodios.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        #region Attributes

        /// <summary>
        /// Representa la instancia que gestiona los episodios registrados en el sistema.
        /// </summary>
        private IEpisodeService episodeService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EpisodesController"/> class.
        /// </summary>
        /// <param name="service">Instancia de <see cref="IDataContext"/>.</param>
        public EpisodesController(IEpisodeService service)
        {
            this.episodeService = service;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Gestiona la consulta de los episodios.
        /// </summary>
        /// <returns>Episodes registrados.</returns>
        [HttpGet("show/{showId}")]
        public async Task<ActionResult<ICollection<Episode>>> GetEpisodes(int showId)
        {
            try
            {
                ICollection<Episode> ans = await this.episodeService.GetAllByAsync(x => x.ShowId == showId);
                return this.Ok(ans);
            }
            catch (BusinessException ex)
            {
                return this.BadRequest(new GenericResponse { Message = ex.Message });
            }
            catch (TechnicalException ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new GenericResponse { Message = ex.Message });
            }
            catch (GeneralException ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new GenericResponse { Message = ex.Message });
            }
        }

        /// <summary>
        /// Gestiona la insersión de un nuevo episodio.
        /// </summary>
        /// <param name="episode">Datos del episodio a agregar.</param>
        /// <returns>Resultado de la solicitud.</returns>
        [HttpPost]
        public IActionResult PostEpisode([FromBody] Episode episode)
        {
            try
            {
                this.episodeService.Add(episode);
                return this.Ok(episode);
            }
            catch (BusinessException ex)
            {
                return this.BadRequest(new GenericResponse { Message = ex.Message });
            }
            catch (TechnicalException ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new GenericResponse { Message = ex.Message });
            }
            catch (GeneralException ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new GenericResponse { Message = ex.Message });
            }
        }

        /// <summary>
        /// Gestiona la actualizacion de un episodio existente.
        /// </summary>
        /// <param name="episode">Episodio que será actualizado.</param>
        /// <returns>Resultado de la solicitud.</returns>
        [HttpPut]
        public async Task<IActionResult> PutShow([FromBody] Episode episode)
        {
            try
            {
                Episode temp = await this.episodeService.GetByIdAsync(episode.Id);

                if (temp == null)
                {
                    return this.NotFound(new GenericResponse { Message = ErrorMessages.EntityNotFound });
                }

                this.episodeService.Update(episode);
                return this.Ok(episode);
            }
            catch (BusinessException ex)
            {
                return this.BadRequest(new GenericResponse { Message = ex.Message });
            }
            catch (TechnicalException ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new GenericResponse { Message = ex.Message });
            }
            catch (GeneralException ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new GenericResponse { Message = ex.Message });
            }
        }

        /// <summary>
        /// Gestiona la eliminación de un episodio.
        /// </summary>
        /// <param name="showId">Id del show a eliminar.</param>
        [HttpDelete("{showId}")]
        public async Task<IActionResult> DeleteShow(int showId)
        {
            try
            {
                Episode temp = await this.episodeService.GetByIdAsync(showId);

                if (temp == null)
                {
                    return this.NotFound(new GenericResponse { Message = ErrorMessages.EntityNotFound });
                }

                this.episodeService.Delete(showId);
                return this.Ok();
            }
            catch (BusinessException ex)
            {
                return this.BadRequest(new GenericResponse { Message = ex.Message });
            }
            catch (TechnicalException ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new GenericResponse { Message = ex.Message });
            }
            catch (GeneralException ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new GenericResponse { Message = ex.Message });
            }
        }

        #endregion
    }
}
