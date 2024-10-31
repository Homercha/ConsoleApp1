using System;

class Triangle
{
    // Закриті поля для сторін трикутника
    private double a, b, c;

    // Конструктор з параметрами для ініціалізації сторін трикутника
    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    // Метод для перевірки існування трикутника
    public bool Correct()
    {
        return (a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a);
    }

    // Метод для обчислення кутів трикутника
    public (double, double, double) Corners()
    {
        // Використовуємо теорему косинусів для обчислення кутів
        double cosA = (b * b + c * c - a * a) / (2 * b * c);
        double cosB = (a * a + c * c - b * b) / (2 * a * c);
        double cosC = (a * a + b * b - c * c) / (2 * a * b);

        // Переводимо косинуси в кути в радіанах, а потім в градуси
        double angleA = Math.Acos(cosA) * (180 / Math.PI);
        double angleB = Math.Acos(cosB) * (180 / Math.PI);
        double angleC = Math.Acos(cosC) * (180 / Math.PI);

        return (angleA, angleB, angleC);
    }

    // Метод для обчислення периметра трикутника
    public double Perimeter()
    {
        return a + b + c;
    }

    // Метод для виведення значень сторін трикутника
    public void Print()
    {
        Console.WriteLine($"Сторони трикутника: a = {a}, b = {b}, c = {c}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Введення значень сторін трикутника з клавіатури
            Console.WriteLine("Введiть сторону a:");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введiть сторону b:");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введiть сторону c:");
            double c = Convert.ToDouble(Console.ReadLine());

            // Створюємо об'єкт класу Triangle
            Triangle triangle = new Triangle(a, b, c);

            // Викликаємо метод Print для виведення значень полів
            triangle.Print();

            // Перевіряємо, чи може існувати такий трикутник
            if (triangle.Correct())
            {
                // Якщо трикутник існує, виводимо периметр та кути
                Console.WriteLine("Трикутник iснує.");

                double perimeter = triangle.Perimeter();
                Console.WriteLine($"Периметр трикутника: {perimeter}");

                var (angleA, angleB, angleC) = triangle.Corners();
                Console.WriteLine($"Кути трикутника: A = {angleA:F2}°, B = {angleB:F2}°, C = {angleC:F2}°");
            }
            else
            {
                // Якщо трикутник не може існувати, виводимо повідомлення
                Console.WriteLine("Трикутник з такими сторонами не може iснувати.");
            }
        }
        catch (Exception ex)
        {
            // Загальне повідомлення про помилки
            Console.WriteLine("вводiть будь-ласка числа: " + ex.Message);
        }
    }
}
