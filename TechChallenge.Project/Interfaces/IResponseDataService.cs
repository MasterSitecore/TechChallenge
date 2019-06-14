using TechChallenge.Project.Models;

namespace TechChallenge.Project.Interfaces
{
    public interface IResponseDataService
    {
        ResponseDataModel BadRequestErrorMessage(string message);
    }
}