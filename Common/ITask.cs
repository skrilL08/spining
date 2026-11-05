using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Tasks;

public interface ITask
{
    string Title { get; }
    string Description { get; }
    string[] Requirements { get; }
    void Run();
}
