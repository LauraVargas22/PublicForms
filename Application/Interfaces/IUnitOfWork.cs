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
        IMemberRepository Members { get; }
        IRolRepository Rols { get; }
        IMemberRolsRepository MemberRols { get; }
        Task<int> SaveAsync();
    }
}