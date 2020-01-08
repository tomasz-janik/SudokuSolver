using System.Windows;
using Ninject;
using SudokuSolver.Model.Digits;
using SudokuSolver.Model.Logger;
using SudokuSolver.Model.Logger.Factory;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.View;
using SudokuSolver.ViewModel;
using SudokuSolver.ViewModel.Command;
using SudokuSolver.ViewModel.Parsing;
using SudokuSolver.ViewModel.Reading;
using SudokuSolver.ViewModel.Solving;
using SudokuSolver.ViewModel.Solving.Factory;
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
            _container.Bind<DigitFactory>().ToSelf().InSingletonScope();
            _container.Bind<SudokuBoard>().ToSelf().InSingletonScope();

            _container.Bind<IValidator>().To<TextFileValidator>().InSingletonScope().Named("text_file_validator");
            _container.Bind<IReader<string>>().To<TextFileReader>().InSingletonScope();
            _container.Bind<Reader<string>>().To<TextReader>().InSingletonScope();
            
            _container.Bind<IValidator>().To<StringValidator>().InSingletonScope().Named("string_validator");
            _container.Bind<IParser<string>>().To<TextFileParser>().InSingletonScope();
            _container.Bind<Parser<string>>().To<TextParser>().InSingletonScope();
            
            _container.Bind<LoggerFactoryProvider>().ToSelf().InSingletonScope();
            _container.Bind<LoggingFacade>().ToSelf().InSingletonScope();

            _container.Bind<ISolvingStrategy>().To<BacktrackingStrategy>().InSingletonScope().Named("backtracking");
            _container.Bind<ISolvingStrategy>().To<PreSolvingStrategy>().InSingletonScope().Named("pre_solving");

            _container.Bind<ISolvingStrategyFactory>().To<SolvingStrategyFactory>().InSingletonScope();
            
            _container.Bind<ICommand>().To<ClearSudokuCommand>().InSingletonScope().Named("clear");
            _container.Bind<ICommand>().To<LoadSudokuCommand>().InSingletonScope().Named("load");
            _container.Bind<ICommand>().To<SolveSudokuCommand>().InSingletonScope().Named("solve");

            _container.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            _container.Bind<System.Windows.Input.ICommand>().To<FactoryCommand>().InSingletonScope();

            _container.Bind<MainViewModel>().ToSelf().InSingletonScope();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = _container.Get<MainWindow>();
        }
    }
}