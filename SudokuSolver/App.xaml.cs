using System.Collections.Generic;
using System.Windows;
using Emgu.CV.CvEnum;
using Ninject;
using Ninject.Parameters;
using SudokuGrabber;
using SudokuGrabber.Builders;
using SudokuGrabber.Filters;
using SudokuGrabber.Grabber.Digit.Strategies;
using SudokuGrabber.OpenCV;
using SudokuGrabber.OpenCV.Interfaces;
using SudokuGrabber.Recognizer.Strategies;
using SudokuSolver.Model.Logger.Factory;
using SudokuSolver.Model.Sudoku;
using SudokuSolver.View;
using SudokuSolver.ViewModel;
using SudokuSolver.ViewModel.Command;
using SudokuSolver.ViewModel.Parsing;
using SudokuSolver.ViewModel.Provider;
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
            _container = new StandardKernel();

            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow?.Show();
        }

        private void ConfigureContainer()
        {
            _container.Bind<SudokuBoard>().ToSelf().InSingletonScope();
            _container.Bind<History>().ToSelf().InSingletonScope();

            _container.Bind<IValidator>().To<TextFileValidator>().InSingletonScope().Named("text_file_validator");
            _container.Bind<IReader<string>>().To<TextFileReader>().InSingletonScope();
            _container.Bind<Reader<string>>().To<TextReader>().InSingletonScope();

            _container.Bind<IValidator>().To<StringValidator>().InSingletonScope().Named("string_validator");
            _container.Bind<IParser<string>>().To<TextFileParser>().InSingletonScope();
            _container.Bind<Parser<string>>().To<TextParser>().InSingletonScope();

            _container.Bind<LoggerFactoryProvider>().ToMethod(context => new LoggerFactoryProvider())
                .InSingletonScope();
            
            _container.Bind<ISolvingStrategy>().To<BacktrackingStrategy>().InSingletonScope().Named("backtracking");
            _container.Bind<ISolvingStrategy>().To<PreSolvingStrategy>().InSingletonScope().Named("pre_solving");

            _container.Bind<ISolvingStrategyFactory>().To<SolvingStrategyFactory>().InSingletonScope();

            _container.Bind<ICommand>().To<ClearSudokuCommand>().InSingletonScope().Named("clear");
            _container.Bind<ICommand>().To<LoadSudokuCommand>().InSingletonScope().Named("load");
            _container.Bind<ICommand>().To<SolveSudokuCommand>().InSingletonScope().Named("solve");
            _container.Bind<ICommand>().To<UndoCommand>().InSingletonScope().Named("undo");

            _container.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            _container.Bind<ISpecificProvider>().To<TextProvider>().InSingletonScope();
            _container.Bind<ISpecificProvider>().To<ImageProvider>().InSingletonScope();
            _container.Bind<IFileProvider>().To<FileProvider>().InSingletonScope();

            _container.Bind<MainViewModel>().ToSelf().InSingletonScope();

            AddSudokuGrabber();
        }

        private void AddSudokuGrabber()
        {
            _container.Bind<ICalcContours>().To<GetContours>().InSingletonScope();
            _container.Bind<ICalcHull>().To<GetHull>().InSingletonScope();
            _container.Bind<ICalcCorners>().To<GetCorners>().InSingletonScope();
            _container.Bind<IDigitCleanStrategy>().To<CleanByContours>().InSingletonScope();

            var sudokuPositionGrabber = Builders.NewBaseSudokuGrabberBuilder()
                .SetCalcContours(new GetContours())
                .SetCalcHull(new GetHull())
                .SetCalcCorners(new GetCorners())
                .SetPerspectiveWrap(new StaticPerspectiveWrap(600))
                .SetPreSudokuGrabFilters(new List<IFilter>
                {
                    new GrayFilter(),
                    new FastDeNoisingFilter(100, 5, 5),
                    new AdaptiveThresholdFilter(),

                })
                .GetGrabber();


            var digitRecognizer = Builders.NewBaseDigitRecognizerBuilder().SetPreDigitRecognizeFilters(
                    new List<IFilter>()
                    {
                        new CenterImage(28),
                        new DeskewImage(28)
                    })
                .SetRecognizer(new MulticlassClassification())
                .GetDigitRecognizer();

            var digitGrabber = Builders.NewStaticSizeDigitGrabber()
                .SetDigitCleanStrategy(new CleanByContours(new GetContours()))
                .SetDigitGrabStrategy(new GrabBySize())
                .SetPreDigitGrabFilters(new List<IFilter>()
                {
                    new CLeanLineImage(new GrayFilter() ,new MedianBlurFilter(3))
                })
                .GetGrabber();


            _container.Bind<ISudokuGrabber>()
                .To<SudokuGrabber.SudokuGrabber>()
                .InSingletonScope()
                .WithParameter(new ConstructorArgument("sudokuGrabber", sudokuPositionGrabber))
                .WithParameter(new ConstructorArgument("digitGrabber", digitGrabber))
                .WithParameter(new ConstructorArgument("digitRecognizer", digitRecognizer));
        }


        private void ComposeObjects()
        {
            Current.MainWindow = _container.Get<MainWindow>();
        }
    }
}