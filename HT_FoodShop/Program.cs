int[,] CreateRandomCustomers(int length, int openingHour, int closingHour)
{
    int[,] arr = new int[2, length];
    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < length; j++)
        {
            arr[i, j] = new Random().Next(openingHour, closingHour+1);
        }
    }
    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < length; j++)
        {
            if (arr[0, j] > arr[1, j])
            {
                int temp = arr[0, j];
                arr[0, j] = arr[1, j];
                arr[1, j] = temp;
            }
            else if (arr[0, j] == arr[1, j])
            {
                arr[1, j] = arr[1, j] + 1;
            }
        }
    }
    return arr;
}

void PrintTwoDArray(int[,] array)
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

int[] HoursInterval(int column, int[,] inputArray)
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

int[,] HoursMatrixAllCustomers(int customersTotal, int[,] inputArray)
{
    int[,] customersMatrix = new int[customersTotal/* + 1*/, 13];
    //for (int i = 0; i < 13; i++)
    //    customersMatrix[0, i] = i + 8;
    for (int i = /*1*/0; i < customersMatrix.GetLength(0); i++)
    {
        int[] arrToFill = HoursInterval(i /*- 1*/, inputArray);
        for (int j = 0; j < arrToFill.Length; j++)
        {
            customersMatrix[i, arrToFill[j] - 8] = 1;
        }
    }
    return customersMatrix;
}

int SumInColumn(int column, int[,] matrix)
{
    int sum = 0;
    for (int j = 0; j < matrix.GetLength(0); j++)
    {
        sum = sum + matrix[j, column];
    }
    return sum;
}

void MaxFilledHours(int[,] matrix)
{
    int[] sumVector = new int[matrix.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        sumVector[i] = SumInColumn(i, matrix);
    }
    int max = 0;
    for (int j = 0; j < sumVector.Length; j++)
    {
        if (sumVector[j] > max)
        {
            max = sumVector[j];
        }
    }
    for (int j = 0; j < sumVector.Length; j++)
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
int[,] testCustomerMatrix = HoursMatrixAllCustomers(numberOfCustomers, testArray);
MaxFilledHours(testCustomerMatrix);