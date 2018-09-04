using QueroUmaApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QueroUmaApi.Controllers
{
    [RoutePrefix("api/gerar")]
    public class GeradorController : ApiController
    {
        [Route("cpf")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, GeradorContexto.GerarCpf());
        }

        [Route("cnpj")]
        [HttpGet]
        public HttpResponseMessage GetCnpj()
        {
            return Request.CreateResponse(HttpStatusCode.OK, GeradorContexto.GeraCNPJ());
        }

        [Route("validar/{cpf}")]
        [HttpPost]
        public HttpResponseMessage Post(string cpf)
        {
            bool valido = GeradorContexto.ValidaCPF(cpf);
            return Request.CreateResponse(HttpStatusCode.OK, valido);
        }

        [Route("validarCnpj/{cnpj}")]
        [HttpPost]
        public HttpResponseMessage PostCnpj(string cnpj)
        {
            bool valido = GeradorContexto.ValidaCNPJ(cnpj);
            return Request.CreateResponse(HttpStatusCode.OK, valido);
        }


    }
}
