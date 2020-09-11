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
    /// Controlador de la API de shows.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        #region Attributes

        /// <summary>
        /// Representa la instancia que gestiona los shows registrados en el sistema.
        /// </summary>
        private IShowService showsService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowsController"/> class.
        /// </summary>
        /// <param name="service">Instancia de <see cref="IDataContext"/>.</param>
        public ShowsController(IShowService service)
        {
            this.showsService = service;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Gestiona la consulta de los shows.
        /// </summary>
        /// <returns>Shows registrados.</returns>
        [HttpGet]
        public async Task<ActionResult<ICollection<Show>>> GetShows()
        {
            try
            {
                ICollection<Show> ans = await this.showsService.GetAllAsync();
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
        /// Gestiona la insersión de un nuevo show.
        /// </summary>
        /// <param name="show">Datos del show a agregar.</param>
        /// <returns>Resultado de la solicitud.</returns>
        [HttpPost]
        public IActionResult PostShow([FromBody] Show show)
        {
            try
            {
                this.showsService.Add(show);
                return this.Ok(show);
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
        /// Gestiona la actualizacion de un show existente.
        /// </summary>
        /// <param name="show">Show que será actualizado.</param>
        /// <returns>Resultado de la solicitud.</returns>
        [HttpPut]
        public async Task<IActionResult> PutShow([FromBody] Show show)
        {
            try
            {
                Show temp = await this.showsService.GetByIdAsync(show.Id);

                if (temp == null)
                {
                    return this.NotFound(new GenericResponse { Message = ErrorMessages.EntityNotFound });
                }

                this.showsService.Update(show);
                return this.Ok(show);
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
        /// Gestiona la eliminación de un show.
        /// </summary>
        /// <param name="showId">Id del show a eliminar.</param>
        [HttpDelete("{showId}")]
        public async Task<IActionResult> DeleteShow(int showId)
        {
            try
            {
                Show temp = await this.showsService.GetByIdAsync(showId);

                if (temp == null)
                {
                    return this.NotFound(new GenericResponse { Message = ErrorMessages.EntityNotFound });
                }

                this.showsService.Delete(showId);
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
