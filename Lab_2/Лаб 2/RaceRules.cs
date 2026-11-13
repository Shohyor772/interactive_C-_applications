using System;
using System.Collections.Generic;
using Лаб_2;

namespace Лаб_2
{
    public static class RaceRules
    {
        public const int MinLapSeconds = 30;
        public const int MaxLapSeconds = 600;

        public static void Validate(RaceResult row)
        {
            if (string.IsNullOrWhiteSpace(row.Driver))
                throw new ArgumentException("Имя пилота не может быть пустым.");

            string[] allowedCars = { "Street", "Sport", "Prototype" };
            if (Array.IndexOf(allowedCars, row.Car) == -1)
                throw new ArgumentException("Недопустимый автомобиль.");

            string[] allowedTracks = { "Учебный овал", "Городское кольцо", "Спринт" };
            if (Array.IndexOf(allowedTracks, row.Track) == -1)
                throw new ArgumentException("Недопустимая трасса.");

            if (row.LapSeconds < MinLapSeconds || row.LapSeconds > MaxLapSeconds)
                throw new ArgumentException($"Время должно быть от {MinLapSeconds} до {MaxLapSeconds} секунд.");
        }

        public static void ValidateImport(List<RaceResult> list)
        {
            if (list == null)
                throw new ArgumentException("Список записей пуст или повреждён.");

            var seenIds = new List<long>();

            foreach (var row in list)
            {
                Validate(row);

                if (row.Id <= 0)
                    throw new ArgumentException($"Некорректный Id: {row.Id}. Он должен быть положительным.");

                if (seenIds.Contains(row.Id))
                    throw new ArgumentException($"Повторяющийся Id: {row.Id}.");

                seenIds.Add(row.Id);
            }
        }
    }
}