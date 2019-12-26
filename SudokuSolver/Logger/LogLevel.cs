using System;

namespace SudokuSolver.Logger
{
    [Flags]
    public enum LogLevel
    {
        None = 0,                 //        0
        Info = 1,                 //        1
        Debug = 2,                //       10
        Warning = 4,              //      100
        Error = 8,                //     1000
        All = 15                  //    11111

        //todo - remove those or make them usable
        /*FunctionalMessage = 16,   //    10000
        FunctionalError = 32,     //   100000*/
    }
}