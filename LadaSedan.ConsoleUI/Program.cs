using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LadaSedan.Models;
using System.Drawing;

namespace LadaSedan.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Автосалон приобретает машину Лада категории D...");
            var lada= new Car("Лада", DrivingLicenseCategory.D);
            Console.WriteLine("и красит её в баклажановый цвет...");
            lada.Color = Color.Purple;
            Console.WriteLine($"Владелец Лады: {lada.CarPassport.Owner?.Name ?? "нет владельца"}");
            Console.WriteLine("Автосалон нанимает Вольдемара с категориями прав BC");
            var voldemar = new Driver("Вольдемар", DateTime.Today.AddYears(-20));
            voldemar.Category.Add(DrivingLicenseCategory.B);
            voldemar.Category.Add(DrivingLicenseCategory.C);
            Console.WriteLine("Автосалон назначает Вольдемара на машину Лада с госномером о777оо...");
            try
            {
                lada.ChangeOwner(voldemar, "о777оо");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Не удалось назначить Вольдемара на машину Лада с госномером о777оо и категорией {lada.Category}");
                Console.WriteLine($"Сообщение: {e.Message}");
            }
            Console.WriteLine("Автосалон обучает Вольдемара на вождение автомобилей категории D...");
            voldemar.Category.Add(DrivingLicenseCategory.D);
            Console.WriteLine("Автосалон назначает Вольдемара на машину Лада с госномером о777оо...");
            lada.ChangeOwner(voldemar, "о777оо");
            Console.WriteLine($"У Вольдемара машина с №{voldemar.Car.CarNumber}");
            Console.WriteLine($"У Лады владелец { lada.CarPassport.Owner.Name}.");
            Console.ReadKey();
        }
    }
}
