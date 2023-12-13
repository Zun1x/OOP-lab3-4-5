using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab3
{
    internal interface IRateAndCopy
    {
        Double Rating { get; }
        object DeepCopy();

    }
}
