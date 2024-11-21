namespace Exercice7;

public struct Fahrenheit
{
    public float ToCelsius(float fahrenheit)
    {
        return (float) (fahrenheit - 32) * 5/9;
    }

    public float FromCelsius(float celsius)
    {
        return (float) (celsius * 9/5) + 32;
    }
}