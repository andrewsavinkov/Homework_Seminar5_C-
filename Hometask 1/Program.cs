/* Задача 36: Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.
[3, 7, 23, 12] -> 19
[-4, -6, 89, 6] -> 0 
*/

int[] GenerateRandomArray(int numberOfDigits, int dimension) // генерирует массив случайных чисел с заданным количеством цифр
{
    Random rnd = new Random();
    int[] arr = new int[dimension];
    int leftEdge = Convert.ToInt32(Math.Pow(10, numberOfDigits - 1));
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

int UnevenIndicesSumOfElements(int[] arr)
{
    int sum = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (i % 2 != 0)
            sum = sum + arr[i];
    }
    return sum;
}
int[] testArray = GenerateRandomArray(2, 5);
PrintArray(testArray);
int sum = UnevenIndicesSumOfElements(testArray);
Console.WriteLine($"Сумма эелементов на нечетных позициях: {sum}");