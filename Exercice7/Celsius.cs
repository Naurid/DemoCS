namespace Exercice7;

public struct Celsius
{
    public float ToCelsius(float fahrenheit)
    {
        return (float) (fahrenheit * 9/5) + 32;
    }

    public float FromCelsius(float celsius)
    {
        return (float) (celsius - 32) * 5/9;
    }
}