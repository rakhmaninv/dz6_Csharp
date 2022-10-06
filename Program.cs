// Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
// Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.

while (true)
{
    Console.Write("Type task number(41 or 43): ");
    string task = Console.ReadLine() ?? "0";
    if (task == "41") 
    {
        Task41();
        break;
    }
    else if (task == "43") 
    {
        Task43();
        break;
    }
        else Console.WriteLine("Incorrect task number");
}

void Task41()
{
    Console.WriteLine("Type multiple positive and negative numbers(use SPACE to separate them): ");
    string userNumbers = Console.ReadLine() ?? "0";
    int positiveCounter = GreaterThanZeroCount(UserNumbersSplit(userNumbers));
    Console.WriteLine("There are {0} numbers greater than zero", positiveCounter);
}
void Task43()
{
    int k1 = UserNumberInput("Type k1 number: ");
    int b1 = UserNumberInput("Type b1 number: ");
    int k2 = UserNumberInput("Type k2 number: ");
    int b2 = UserNumberInput("Type b2 number: ");
    if (k1 != k2)
    {
        var coord = IntersectionCoordinates(k1, b1, k2, b2);
        Console.WriteLine("Point of intersection of two lines is ({0},{1})", coord.x, coord.y);
    }
    else Console.WriteLine("Lines are parallel");
}

int[] UserNumbersSplit(string nums)
{
    string[] splited = nums.Split(" ");
    int[] array = new int[splited.Length];
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = int.Parse(splited[i]);
    }
    return array;
}
int GreaterThanZeroCount(int[] arr)
{
    int count = 0;
    int size = arr.Length;
    for (int i = 0; i < size; i++)
    {
        if (arr[i] > 0) count++;
    }
    return count;
}

int UserNumberInput(string msg)
{
    int userNumber;
    while (true)
    {
        try
        {
            Console.Write(msg);
            userNumber = int.Parse(Console.ReadLine()!);
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Incorrect data entered");
        }
    }
    return userNumber;
}

(double x, double y) IntersectionCoordinates(int l1, int m1, int l2, int m2)
{
    double xcoord = (double)(m1 - m2) / (l2 - l1);
    double ycoord = (double)((l2 * m1) - (l1 * m2)) / (l2 - l1);
    return (xcoord, ycoord);
}