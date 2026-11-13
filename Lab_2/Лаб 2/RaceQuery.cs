using System;
using System.Collections.Generic;
using System.Linq;

namespace Лаб_2
{
    public static class RaceQuery
    {
        public static List<RaceResult> Apply(List<RaceResult> all, string text, string track)
        {
            var query = all.AsQueryable();

            // Фильтр по имени (без учёта регистра)
            if (!string.IsNullOrWhiteSpace(text))
            {
                text = text.Trim();
                query = query.Where(r => r.Driver.Contains(text, StringComparison.OrdinalIgnoreCase));
            }

            // Фильтр по трассе
            if (track != "Все трассы")
            {
                query = query.Where(r => r.Track == track);
            }

            return query.OrderBy(r => r.Id).ToList();
        }
    }
}