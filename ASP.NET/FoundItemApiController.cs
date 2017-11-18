using LostandFound.Models;
using LostandFound.Models.Domain;
using LostandFound.Models.Requests;
using LostandFound.Models.Responses;
using LostandFound.Services;
using LostandFound.Services.Interfaces;
using LostandFound.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;


namespace GSwap.Web.Controllers
{
    [RoutePrefix("api/founditems")]
    public class FoundItemApiController : ApiController
    {
        private IFoundItemService _foundItemService;
        private IUserAuthData _currentUser;
        public IPrincipal _principal = null;


        public FoundItemApiController(IFoundItemService FoundItemService, IPrincipal user)
        {
            _principal = user;
            _foundItemService = FoundItemService;
            _currentUser = _principal.Identity.GetCurrentUser();
        }

        [Route(), HttpGet]
        public HttpResponseMessage GetAll()
        {

            HttpStatusCode code = HttpStatusCode.OK;

            ItemsResponse<FoundItem> response = new ItemsResponse<FoundItem>();
            response.Items = _foundItemService.GetAll();

            if (response.Items == null)
            {
                ErrorResponse error = new ErrorResponse("no message was found");

                code = HttpStatusCode.NotFound;
                return Request.CreateResponse(code, error);
            }
            return Request.CreateResponse(code, response);
        }

        [Route(), HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Add(FoundItemAddRequest model)

        {
            if (!ModelState.IsValid)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();
            int newId = 0;
            if (_currentUser == null)
            {
                newId = _foundItemService.Add(model, 0);

            }
            else
            {
                newId = _foundItemService.Add(model, _currentUser.Id);
            }


            response.Item = newId;

            return Request.CreateResponse(HttpStatusCode.OK, response);

        }
    }
}

