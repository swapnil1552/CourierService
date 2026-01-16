// See https://aka.ms/new-console-template for more information
using CourierService.Application.Services;
using CourierService.Domain.Enities;
using CourierService.Infrastructure.DependencyInjection;
using CourierService.Infrastructure.Input;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

//Register Services using DI
services.AddCourierServices();

var serviceProvider = services.BuildServiceProvider();
var courierServiceProcessor = serviceProvider.GetRequiredService<CourierServiceProcessor>();
var consoleInputService = serviceProvider.GetRequiredService<ConsoleInputService>();

try
{
    ConsoleInputService.WelcomeNote();

    //Read Inputs
    int baseDeliveryCost = consoleInputService.ReadBaseDeliveryCost();
    int numberOfPackages = consoleInputService.ReadPackageCount();
    var listOfPackages = consoleInputService.ReadPackages(numberOfPackages);
    var listOfVehicle = consoleInputService.ReadVehicles();

    //Process the Packages and Delivery Estimate
    courierServiceProcessor.Process(listOfPackages, listOfVehicle, baseDeliveryCost);

    //output
    DisplayProcessedPackages(listOfPackages);
}
catch(Exception ex)
{
    PrintErrors(ex);
}

static void PrintErrors(Exception ex)
{
    Console.WriteLine("Something went wrong");
    Console.WriteLine(ex.Message);
}

static void DisplayProcessedPackages(List<Package> listOfPackages)
{
    foreach (var pkg in listOfPackages)
    {
        Console.WriteLine($"package ID: {pkg.Id}, Discount: {pkg.Discount}, Total Cost: {pkg.TotalCost}, Estimated Time: {pkg.EstimatedDeliveryTime}");
    }
}

