using GroupUpWeb.Helpers.Business;
using GroupUpWeb.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GroupUpWeb.Helpers
{
    public class ApiControllerBase : ApiController
    {

        protected T Resolve<T>(Func<T> action) where T : DtoResultBase, new()
        {
            try
            {
                return action();
            }
            catch (BusinessException bex)
            {
                var badRequestResult = new T()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = bex.Message
                };

                return badRequestResult;
            }
            catch (Exception ex)
            {

                var errorResult = new T()
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message
                };

                return errorResult;
            }

        }
    }
}