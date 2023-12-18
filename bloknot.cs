using System.Diagnostics;
using System.Timers;



internal class Program
{
    public static int counter = 0;
    private static void Main(string[] args)
    {
        System.Timers.Timer timer = new(2000);
        timer.Elapsed += StartProcess;
        timer.Elapsed += OnTimedEvent;
        timer.Start();
        bool flag = true;
        while (flag)
        {
            if (counter == 10)
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
            myProc = Process.Start("Notepad.exe");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        counter++;
    }
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        Console.WriteLine("Приложение было запущено в {0:HH:mm:ss.fff}",
                          e.SignalTime);
    }
}
