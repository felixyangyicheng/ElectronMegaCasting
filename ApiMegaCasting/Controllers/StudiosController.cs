using ApiMegaCasting.Repository.Signature;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMegaCasting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudiosController : ControllerBase
    {
        private readonly IStudioRepository _studioRepository;
        public StudiosController(IStudioRepository studioRepository)
        {
            this._studioRepository = studioRepository;
        }

        #region Liste des studios

        #endregion
        #region Liste des studios par nom

        #endregion
        #region Liste des studios par adresse

        #endregion
        #region studio par id

        #endregion
        #region studio par email

        #endregion
        #region studion par libellé
        #endregion

        #region Ajouter

        #endregion
        #region Mettre à jour

        #endregion
        #region Supprimer

        #endregion

    }
}
