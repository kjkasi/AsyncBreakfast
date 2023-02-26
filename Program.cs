using System;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    // These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    class Program
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("кофе готово");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = ToastBreadAsync(2);

            Toast toast = await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("тосты готовы");
            Juice oj = PourOJ();
            Console.WriteLine("апельсильновый сок готов");

            Egg eggs = await eggsTask;
            Console.WriteLine("яйца готовы");
            Bacon bacon = await baconTask;
            Console.WriteLine("бекон готов");

            Console.WriteLine("Завтрак готов!");
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Наливаем апельсиновый сок");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Намазываем джем на тост");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Намазываем тост маслом");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Кладем ломтик хлеба в тостер");
            }
            Console.WriteLine("Начинайте поджаривать...");
            await Task.Delay(3000);
            Console.WriteLine("Достаем тосты из тостера");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"выкладываем  {slices} ломтики бекона на сковороду");
            Console.WriteLine("готовим первую сторону бекона...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("переворачиваем ломтик бекона");
            }
            Console.WriteLine("готовим вторую сторону бекона...");
            await Task.Delay(3000);
            Console.WriteLine("Выложите бекон на тарелку");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Разогреваем сковороду для яиц...");
            await Task.Delay(3000);
            Console.WriteLine($"разбиваем {howMany} яиц");
            Console.WriteLine("готовим яйца ...");
            await Task.Delay(3000);
            Console.WriteLine("Выложите яйца на тарелку");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Наливаем кофе");
            return new Coffee();
        }
    }
}