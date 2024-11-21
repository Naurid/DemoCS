namespace Exercice7;
class Program
{
    static void Main(string[] args)
    {
        EquationSolver solver = new EquationSolver{A = 2,B = 0,C = 0};
        
        Console.WriteLine(solver.Solve(out double? x1, out double? x2)? 
            $"The solutions to the equation [{solver.A}x²{(solver.B < 0 ? $"{solver.B}" : $"+ {solver.B}")}x+{solver.C} = 0] are : x1 => {x1}, x2 => {x2}" 
            : "delta was negative and I was to lazy to implement the last possibility :) (it's I M A G I N A R Y)");
    }

    enum Eenum
    {
        neum1,
        neum2
    }
}