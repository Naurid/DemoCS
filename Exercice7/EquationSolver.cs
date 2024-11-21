namespace Exercice7;

public struct EquationSolver
{
    public int A;
    public int B;
    public int C;

    public bool Solve(out double? X1, out double? X2)
    { 
       // Ax²+Bx+C = 0
       //delta=  B² - 4AC
       //si delta > 0 => X1 = (-B-Racine(delta))/2A et X2 = (-B+Racine(delta))/2A
       //si delta = 0 => X0 = (-B)/2A
       //si delta < 0 => return null pr les deux
       double delta = Math.Pow(B, 2) - 4*A*C;
       switch (delta)
       {
           case > 0:
               X1 = (-B-Math.Sqrt(delta))/ (2 * A);
               X2 = (-B+Math.Sqrt(delta))/ (2 * A);
               return true;
           case 0:
               X1 = X2 = (double)-B / (2 * A);
               return true;
           default:
               X1 = X2 = null;
               return false;
       }
    }
}