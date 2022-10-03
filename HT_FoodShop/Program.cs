// Создаем двумерный массив, где у каждого посетителя свой столбец, 
// в первой строке указано время входа в магазин, во второй - время выхода
// ввод в функцию: кол-во посетителей, время открытия магазина, время закрытия магазина
int[,] CreateRandomCustomers(int length, int openingHour, int closingHour)
{
    int[,] arr = new int[2, length];
    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < length; j++)
        {
            arr[i, j] = new Random().Next(openingHour, closingHour + 1); // время закрытия+1 потому что next выдает полуинтервал [...)
        }
    }
    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < length; j++)
        {
            if (arr[0, j] > arr[1, j]) // если время выхода случилось раньше входа, меняем часы местами
            {
                int temp = arr[0, j];
                arr[0, j] = arr[1, j];
                arr[1, j] = temp;
            }
            else if (arr[0, j] == arr[1, j]) // если время входа и выхода равны, прибавляем час к времени выхода
            {
                arr[1, j] = arr[1, j] + 1;
            }
        }
    }
    return arr;
}

void PrintTwoDArray(int[,] array) // выводим двухмерный массив в консоль с табуляцией по столбцам
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} \t");
        }
        Console.WriteLine();
    }
}

int[] HoursInterval(int column, int[,] inputArray) // создаем массив, заполненный часами от времени входа посетителя до времени его выхода
{
    int leftEdge = inputArray[0, column];
    int rightEdge = inputArray[1, column];
    int length = rightEdge - leftEdge;
    int[] result = new int[length];
    for (int i = 0; i < length; i++)
    {
        result[i] = leftEdge;
        leftEdge++;
    }
    return result;
}
// создаем матрицу, где столбцы - это рабочие часы магазина 
// а строки - это каждый из посетителей
// если посетитель находился в магазине в определенный час, вводим значение 1, если нет - 0
int[,] HoursMatrixAllCustomers(int customersTotal, int openingHour, int closingHour, int[,] inputArray)
{
    int[,] customersMatrix = new int[customersTotal, closingHour-openingHour+1];
    for (int i = 0; i < customersMatrix.GetLength(0); i++)
    {
        int[] arrToFill = HoursInterval(i, inputArray);
        for (int j = 0; j < arrToFill.Length; j++)
        {
            customersMatrix[i, arrToFill[j] - 8] = 1;
        }
    }
    return customersMatrix;
}

// вычисляем сумму единиц в каждом столбце
int SumInColumn(int column, int[,] matrix)
{
    int sum = 0;
    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        sum = sum + matrix[j, column];
    }
    return sum;
}

// вычисляем часы, в которые в магазине находилось наибольшее количество посетителей
void MaxFilledHours(int[,] matrix)
{
    int[] sumVector = new int[matrix.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        sumVector[i] = SumInColumn(i, matrix);
    }
    int max = 0;
    for (int j = 0; j < sumVector.Length; j++) // находим максимальное число посетителей
    {
        if (sumVector[j] > max)
        {
            max = sumVector[j];
        }
    }
    for (int j = 0; j < sumVector.Length; j++) // повторяем цикл, чтобы найти все часы работы, в которые было достигнуто пиковое число посетителей
    {
        if (sumVector[j] >= max)
        {
            Console.WriteLine($"{j + 8}-{j + 9} => {max} человек");
        }
    }
}
int numberOfCustomers = 100;
int openingHour = 8;
int closingHour = 20;
int[,] testArray = CreateRandomCustomers(numberOfCustomers, openingHour, closingHour);
PrintTwoDArray(testArray);
Console.WriteLine();
int[,] testCustomerMatrix = HoursMatrixAllCustomers(numberOfCustomers, openingHour, closingHour, testArray);
MaxFilledHours(testCustomerMatrix);
