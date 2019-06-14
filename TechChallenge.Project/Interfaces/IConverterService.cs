using TechChallenge.Project.Models;

namespace TechChallenge.Project.Interfaces
{
    public interface IConverterService
    {
        DetailsModel ProcessConversion(DetailsModel dataModel);
    }
}