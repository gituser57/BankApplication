// See https://aka.ms/new-console-template for more information
using ExceptionApp;

Console.WriteLine("Hello, World!");
double sum = 0;

CustomArray arr = new CustomArray(34,5);

arr = new(10, 1, 1, 1, 1, 1);


foreach (var item in arr)
{
    // string s = (string)item; // RTE
    sum += (double)item;
}

double res;
res = ExceptionExamples.SomeAction(45, 0);

Console.WriteLine("Hello, World!");