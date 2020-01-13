namespace SudokuGrabber.Builders
{
    public static class  Builders
    {
       public static GrabberBuilder NewGrabberBuilder()
        {
            return new GrabberBuilder();
        }

       public static BaseSudokuGrabberBuilder NewBaseSudokuGrabberBuilder()
       {
           return new BaseSudokuGrabberBuilder();
       }

       public static StaticSizeDigitGrabberBuilder NewStaticSizeDigitGrabber()
       {
           return new StaticSizeDigitGrabberBuilder();
       }

        public static BaseDigitRecognizerBuilder NewBaseDigitRecognizerBuilder()
        {
            return new BaseDigitRecognizerBuilder();
        }
    }
}
