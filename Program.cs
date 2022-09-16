/*
 Задайте массив вещественных чисел. Найдите разницу между максимальным и минимальным элементов массива.
[3 7 22 2 78] -> 76
*/
int size = 0;
double result = 0;

if (!InputControl())
    return;

double[] array = InitArray(size);

DoWorkArray(array, ref result);

PrintArray(array);

# region methods

bool InputControl()
{
    int tryCount = 3;
    string inputStr = string.Empty;
    bool resInputCheck = false;

    while (!resInputCheck)
    {
        Console.WriteLine($"\r\nЗадайте размерность массива (количество попыток: {tryCount}):");
        inputStr = Console.ReadLine() ?? string.Empty;

        resInputCheck = int.TryParse(inputStr, out size) && size > 0;

        if (!resInputCheck)
        {
            tryCount--;

            if (tryCount == 0)
            {
                Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
                return false;
            }
        }
    }

    return true;
}

double[] InitArray(int sizeArray)
{
    double[] array = new double[sizeArray];

    for (int i = 0; i < sizeArray; i++)
    {
        array[i] = new Random().NextDouble() * (100 + 0);
        Thread.Sleep(TimeSpan.FromMilliseconds(50));
    }

    return array;
}

void DoWorkArray(double[] array, ref double res)
{
    double minValue = 0, maxValue = 0;
    for (int i = 0; i < size; i++)
    {
        if (i == 0)
        {
            minValue = array[0];
            maxValue = array[0];
        }
        else
        {
            if (array[i] < minValue)
                minValue = array[i];

            if (array[i] > maxValue)
                maxValue = array[i];
        }        
    }

    res = maxValue - minValue;
}

void PrintArray(double[] array)
{    
    foreach (var elem in array)
    {
        if (elem == array.First() && elem == array.Last())        
            Console.WriteLine($"[{DoubleToString(elem)}] -> {DoubleToString(result)}");
        else
            Console.Write($"{(elem == array.First() ? "[" + DoubleToString(elem) : (elem == array.Last() ? " " + DoubleToString(elem) + "] -> " + DoubleToString(result) : " " + DoubleToString(elem)))}");
    }
}

string DoubleToString(double number)
{
    return string.Format("{0:f4}", number);
}

#endregion

