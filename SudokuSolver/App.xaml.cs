using System.Windows;
using Ninject;
using SudokuSolver.Model.Digits;
using SudokuSolver.Model.Logger;
using SudokuSolver.Model.Logger.Factory;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.View;
using SudokuSolver.ViewModel.Parsing;
using SudokuSolver.ViewModel.Reading;
using SudokuSolver.ViewModel.Solving;
using SudokuSolver.ViewModel.Validation;

namespace SudokuSolver
{
    public partial class App
    {
        
        private IKernel _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow?.Show();
        }

        private void ConfigureContainer()
        {
            _container = new StandardKernel();
            _container.Bind<DigitFactory>().ToSelf();
            _container.Bind<SudokuBoard>().ToSelf();

            _container.Bind<IValidator>().To<TextFileValidator>().Named("text_file_validator");
            _container.Bind<IReader<string>>().To<TextFileReader>();
            _container.Bind<Reader<string>>().To<TextReader>();
            
            _container.Bind<IValidator>().To<StringValidator>().Named("string_validator");
            _container.Bind<IParser<string>>().To<TextFileParser>();
            _container.Bind<Parser<string>>().To<TextParser>();
            
            _container.Bind<LoggerFactoryProvider>().ToSelf();
            _container.Bind<LoggingFacade>().ToSelf();

            _container.Bind<ISolvingStrategy>().To<BacktrackingStrategy>().Named("backtracking");
        }

        private void ComposeObjects()
        {
            Current.MainWindow = _container.Get<MainWindow>();
        }
    }
}