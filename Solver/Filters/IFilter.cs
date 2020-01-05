using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;

namespace Solver.Filters
{
   public interface  IFilter
   {
       void Apply(Mat image);
   }
}
