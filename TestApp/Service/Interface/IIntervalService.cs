using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Model.Interface;

namespace TestApp.Service.Interface
{
    public interface IIntervalService
    {
        bool CheckInput(string input);
        IEnumerable<IInterval> GetListOfIntervals(string input);
    }
}
