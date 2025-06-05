using Application.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Repositories;


public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly PublicDbContext _context;
    private ICategoriesCatalogRepository? _categoriesCatalog;
    private ICategoryOptionsRepository? _categoryOptions;
    private IChaptersRepository? _chapters;
    private IOptionQuestionsRepository? _optionQuestions;
    private IOptionsResponseRepository? _optionsResponse;
    private IQuestionsRepository? _questions;
    private ISubQuestionsRepository? _subQuestions;
    private ISumaryOptionsRepository? _sumaryOptions;
    private ISurveysRepository? _surveys;

    public UnitOfWork(PublicDbContext context)
    {
        _context = context;
    }

    public ICategoriesCatalogRepository CategoriesCatalog
    {
        get
        {
            if (_categoriesCatalog == null)
            {
                _categoriesCatalog = new CategoriesCatalogRepository(_context);
            }
            return _categoriesCatalog;
        }
    }

    public ICategoryOptionsRepository CategoryOptions
    {
        get
        {
            if (_categoryOptions == null)
            {
                _categoryOptions = new CategoryOptionsRepository(_context);
            }
            return _categoryOptions;
        }
    }

    public IChaptersRepository Chapters
    {
        get
        {
            if (_chapters == null)
            {
                _chapters = new ChaptersRepository(_context);
            }
            return _chapters;
        }
    }

    public IOptionQuestionsRepository OptionQuestions
    {
        get
        {
            if (_optionQuestions == null)
            {
                _optionQuestions = new OptionQuestionsRepository(_context);
            }
            return _optionQuestions;
        }
    }

    public IOptionsResponseRepository OptionsResponse
    {
        get
        {
            if (_optionsResponse == null)
            {
                _optionsResponse = new OptionsResponseRepository(_context);
            }
            return _optionsResponse;
        }
    }

    public IQuestionsRepository Questions
    {
        get
        {
            if (_questions == null)
            {
                _questions = new QuestionsRepository(_context);
            }
            return _questions;
        }
    }

    public ISubQuestionsRepository SubQuestions
    {
        get
        {
            if (_subQuestions == null)
            {
                _subQuestions = new SubQuestionRepository(_context);
            }
            return _subQuestions;
        }
    }

    public ISumaryOptionsRepository SumaryOptions
    {
        get
        {
            if (_sumaryOptions == null)
            {
                _sumaryOptions = new SumaryOptionsRepository(_context);
            }
            return _sumaryOptions;
        }
    }

    public ISurveysRepository Surveys
    {
        get
        {
            if (_surveys == null)
            {
                _surveys = new SurveysRepository(_context);
            }
            return _surveys;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
