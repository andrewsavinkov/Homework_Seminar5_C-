/* Задача 34: Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.
[345, 897, 568, 234] -> 2
*/
int[] GenerateRandomArray(int numberOfDigits, int dimension) // генерирует массив случайных чисел с заданным количеством цифр
{ 
    Random rnd = new Random();
    int[] arr = new int [dimension];
    int leftEdge = Convert.ToInt32(Math.Pow(10, numberOfDigits-1));
    int rightEdge = Convert.ToInt32(Math.Pow(10, numberOfDigits));
    for (int i = 0; i < dimension; i++)
    {
        arr[i] = rnd.Next(leftEdge, rightEdge);
    }
    return arr;
}

void PrintArray(int[] arr) // выводит массив в консоль
{
    var result = string.Join(", ", arr);
    Console.WriteLine($"{result}");
}

int CountEvenNumbers (int[] arr)
{
    int sum = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i]%2==0)
        {
            sum++;
        }
    }
    return sum;
}

int[] newArray = GenerateRandomArray(3, 10);
PrintArray(newArray);
int sum = CountEvenNumbers(newArray);
Console.WriteLine ($"количество чётных чисел в массиве равно: {sum}");
