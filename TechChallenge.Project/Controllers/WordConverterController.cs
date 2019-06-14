using TechChallenge.Project.Models;
using TechChallenge.Project.Services;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace TechChallenge.Project.Controllers
{
    public class WordConverterController : ApiController
    {
        private ResponseDataService responseMessageService;
        private ConverterService cs;

        public WordConverterController()
        {
            responseMessageService = new ResponseDataService();
            cs = new ConverterService();
        }

        [HttpPost]
        public IHttpActionResult ConvertNumberToWords(DetailsModel detailsModel)
        {
            ValidateModel(detailsModel);

            return Ok(cs.ProcessConversion(detailsModel));
        }

        private void ValidateModel(DetailsModel detailsModel)
        {
            Regex regex = new Regex(@"^[a-zA-Z\s-]+$");
            if ((detailsModel.Name == null) || (detailsModel.Name == string.Empty))
            {

                var message = Request.CreateResponse(HttpStatusCode.BadRequest,
                responseMessageService.BadRequestErrorMessage("Name cannot be null or Model is invalid format."));
                throw new HttpResponseException(message);
            }
            else if (!regex.IsMatch(detailsModel.Name))
            {
                var message = Request.CreateResponse(HttpStatusCode.BadRequest,
                responseMessageService.BadRequestErrorMessage("Name must be alphabet and space only and cannot be null."));
                throw new HttpResponseException(message);
            }

            regex = new Regex(@"^[0-9,\.]+$");
            if (!regex.IsMatch(detailsModel.Numbers.ToString()) || detailsModel.Numbers <= 0 || detailsModel.Numbers > 9999999)
            {
                var message = Request.CreateResponse(HttpStatusCode.BadRequest,
                responseMessageService.BadRequestErrorMessage("Numbers must be numeric value from 1 up to 9,999,999 million"));
                throw new HttpResponseException(message);
            }
        }
    }
}