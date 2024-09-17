using System.Device.Gpio;
using Microsoft.Extensions.Logging;

namespace IoT.Sandbox.Console.Gpio;

internal class GpioV1 : IRun
{
    private const int Pin = 21;

    private readonly ILogger<GpioV1> _logger;

    public GpioV1(ILogger<GpioV1> logger)
    {
        _logger = logger;
    }

    public Task Run()
    {
        var gpio = new GpioController();
        _logger.LogInformation("Gpio Start");

        gpio.OpenPin(Pin, PinMode.Output);
        gpio.Write(Pin, PinValue.High);
        Thread.Sleep(1000);
        gpio.Write(Pin, PinValue.Low);
        gpio.ClosePin(Pin);

        while (true)
        {
        }
        // ReSharper disable once FunctionNeverReturns
    }
}