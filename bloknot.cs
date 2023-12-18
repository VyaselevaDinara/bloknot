using System.Diagnostics; // Код использует пространства имен System.Diagnostics и System.Timers
using System.Timers;



internal class Program
{
    public static int counter = 0;
    private static void Main(string[] args)
    {
        System.Timers.Timer timer = new(2000);  // Создание таймера с интервалом 2000 миллисекунд (2 секунды)
        timer.Elapsed += StartProcess; // Добавление обработчиков событий на срабатывание таймера
        timer.Elapsed += OnTimedEvent;
        timer.Start();   // Запуск таймера
        bool flag = true;
        while (flag)
        {
            if (counter == 10) // Если счетчик достигает 10, останавливаем таймер
            {
                flag = false;
                timer.Stop();
            }
        }
    }

    private static void StartProcess(object source, ElapsedEventArgs e)
    {
        Process myProc = null; 

        try
        {
            myProc = Process.Start("Notepad.exe"); // Запуск процесса "notepad.exe" (блокирующий вызов)
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        counter++;  // Увеличение счетчика
    }
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        Console.WriteLine("Приложение было запущено в {0:HH:mm:ss.fff}", // Вывод времени срабатывания таймера в консоль
                          e.SignalTime);
    }
}
// В данном коде создается таймер, который каждые 2 секунды запускает процесс "notepad.exe",
// при этом выводя в консоль время запуска. Таймер останавливается после 10 запусков процесса.
