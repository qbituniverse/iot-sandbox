using System.Device.Gpio;
using Iot.Device.Hcsr501;
using Microsoft.Extensions.Logging;

namespace IoT.Sandbox.Console.Hcsr501;

internal class Hcsr501V1 : IRun
{
    private const int Output = 21;

    private readonly ILogger<Hcsr501V1> _logger;

    public Hcsr501V1(ILogger<Hcsr501V1> logger)
    {
        _logger = logger;
    }

    public Task Run()
    {
        var hcsr501 = new Iot.Device.Hcsr501.Hcsr501(Output);
        hcsr501.Hcsr501ValueChanged += SensorValueChanged;
        _logger.LogInformation("Motion Start");

        void SensorValueChanged(object sender, Hcsr501ValueChangedEventArgs args)
        {
            if (args.PinValue == PinValue.High)
            {
                _logger.LogInformation("Motion Detected");
                Thread.Sleep(2000);
            }
            else
            {
                _logger.LogInformation("Motion NOT Detected");
            }
        }

        while (true)
        {
        }
        // ReSharper disable once FunctionNeverReturns
    }
}