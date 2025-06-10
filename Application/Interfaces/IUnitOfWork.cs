using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoriesCatalogRepository CategoriesCatalog { get; }
        ICategoryOptionsRepository CategoryOptions { get; }
        IChaptersRepository Chapters { get; }
        IOptionQuestionsRepository OptionQuestions { get; }
        IOptionsResponseRepository OptionsResponse { get; }
        IQuestionsRepository Questions { get; }
        ISubQuestionsRepository SubQuestions { get; }
        ISumaryOptionsRepository SumaryOptions { get; }
        ISurveysRepository Surveys { get; }
        IMemberRepository Member { get; }
        IRolRepository Rol { get; }
        Task<int> SaveAsync();
    }
}