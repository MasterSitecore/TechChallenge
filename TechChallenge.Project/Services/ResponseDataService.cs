using TechChallenge.Project.Interfaces;
using TechChallenge.Project.Models;

namespace TechChallenge.Project.Services
{
    public class ResponseDataService : IResponseDataService
    {
        private ResponseDataModel responseMessage;

        public ResponseDataService()
        {
            responseMessage = new ResponseDataModel();
        }

        public ResponseDataModel BadRequestErrorMessage(string message)
        {
            responseMessage.Message = message;
            responseMessage.StatusCode = (int)StatusCode.BadRequest;

            return responseMessage;
        }

        private enum StatusCode
        {
            BadRequest = 400,
        }
    }
}