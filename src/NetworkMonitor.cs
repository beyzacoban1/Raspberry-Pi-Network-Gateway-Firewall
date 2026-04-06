#r "nuget: System.Device.Gpio, 3.2.0"
using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;

var gpio = new GpioController();
gpio.OpenPin(17, PinMode.Output);
gpio.OpenPin(22, PinMode.Output);
gpio.OpenPin(27, PinMode.Output);

var psi = new ProcessStartInfo
{
    FileName = "sudo",
    Arguments = "journalctl -f -k",
    RedirectStandardOutput = true,
    UseShellExecute = false
};

var process = Process.Start(psi);

while (!process.StandardOutput.EndOfStream)
{
    var line = process.StandardOutput.ReadLine();
    if (string.IsNullOrEmpty(line)) continue;
    
    Console.WriteLine(line);
    
    if (line.Contains("NEW"))
    {
        Task.Run(() => {
            gpio.Write(17, PinValue.High);
            Thread.Sleep(500);
            gpio.Write(17, PinValue.Low);
        });
    }
    else if (line.Contains("DROP"))
    {
        Task.Run(() => {
            gpio.Write(22, PinValue.High);
            Thread.Sleep(500);
            gpio.Write(22, PinValue.Low);
        });
    }
    else if (line.Contains("ACCEPT"))
    {
        Task.Run(() => {
            gpio.Write(27, PinValue.High);
            Thread.Sleep(50);
            gpio.Write(27, PinValue.Low);
        });
    }
}

Console.ReadLine();
