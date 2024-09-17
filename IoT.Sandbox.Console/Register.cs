using IoT.Sandbox.Console.Models;
using IoT.Sandbox.Console.Modules.Gpio;
using IoT.Sandbox.Console.Modules.Hcsr501;
using Microsoft.Extensions.DependencyInjection;

namespace IoT.Sandbox.Console;

internal class Register
{
    public static void Services(ConsoleConfiguration configuration, IServiceCollection services)
    {
        switch (configuration.Run)
        {
            case nameof(GpioV1):
                services.AddSingleton<IRun, GpioV1>();
                break;

            case nameof(Hcsr501V1):
                services.AddSingleton<IRun, Hcsr501V1>();
                break;

            case nameof(Hcsr501V2):
                services.AddSingleton<IRun, Hcsr501V2>();
                break;

            default:
                services.AddSingleton<IRun, RunMock>();
                break;
        }
    }
}