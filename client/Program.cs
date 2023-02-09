// See https://aka.ms/new-console-template for more information
using client;

Console.WriteLine("Rolling Some Dice");
swaggerClient client = new("https://localhost:7168/", new());
var result = await client.RollDiceAsync("6d6");
Console.WriteLine($"Result: {result.Total}");