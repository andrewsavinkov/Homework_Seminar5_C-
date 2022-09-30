/* Задача 38: Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементом массива.
[3 7 22 2 78] -> 76
*/

double[] GenerateRandomArrayOfDouble(int maxRandomDouble, int dimension) // генерирует массив случайных чисел с заданным количеством цифр
{
    Random rnd = new Random();
    double[] arr = new double[dimension];
    for (int i = 0; i < dimension; i++)
    {
        arr[i] = Math.Round(rnd.NextDouble() * maxRandomDouble, 2);
    }
    return arr;
}

void PrintArray(double[] arr) // выводит массив в консоль
{
    var result = string.Join(", ", arr);
    Console.WriteLine($"{result}");
}

double DeltaMinMax(double[] arr)
{
    double min = arr[0];
    double max = arr[0];
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] > max)
            max = arr[i];
        else if (arr[i] < min)
            min = arr[i];
    }
    double result = Math.Round(max - min, 2);
    return result;
}

double[] testArr = GenerateRandomArrayOfDouble(10, 10);
PrintArray(testArr);
double delta = DeltaMinMax(testArr);
Console.WriteLine($"разница между максимальным значением и минимальным равна {delta}");
