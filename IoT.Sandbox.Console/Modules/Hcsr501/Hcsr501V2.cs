using Microsoft.Extensions.Logging;

namespace IoT.Sandbox.Console.Modules.Hcsr501;

internal class Hcsr501V2 : IRun
{
    private const int Output = 21;

    private readonly ILogger<Hcsr501V2> _logger;

    public Hcsr501V2(ILogger<Hcsr501V2> logger)
    {
        _logger = logger;
    }

    public Task Run()
    {
        var hcsr501 = new Iot.Device.Hcsr501.Hcsr501(Output);
        _logger.LogInformation("Motion Start");

        while (true)
        {
            if (hcsr501.IsMotionDetected)
            {
                _logger.LogInformation("Motion Detected");
                Thread.Sleep(2000);
            }
            else
            {
                _logger.LogInformation("Motion NOT Detected");
            }
        }
        // ReSharper disable once FunctionNeverReturns
    }
}