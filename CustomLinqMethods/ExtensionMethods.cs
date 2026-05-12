namespace CustomLinqMethods
{
    public static class ExtensionMethods
    {

        public static IEnumerable<TSource> Paginate<TSource>(this IEnumerable<TSource> source, int page = 1, int pageSize = 10)
        {
            if (source == null)
                throw new ArgumentNullException($"{nameof(source)}");
            if (page <= 0)
                // page =1
                throw new ArgumentOutOfRangeException($"{nameof(page)}");
            if (pageSize <= 0)
                // pageSize = 10
                throw new ArgumentOutOfRangeException($"{nameof(pageSize)}");
            if (!source.Any())
                return Enumerable.Empty<TSource>();
            return source.Skip((page - 1) * 10).Take(pageSize);
        }

        public static IEnumerable<T> Paginate2<T>(this IEnumerable<T> source, int? page, int? pageSize, Func<T, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException($"{nameof(source)}");
            if (!page.HasValue)
                page = 1;
            if (!pageSize.HasValue) pageSize = 10;
            if (!source.Any())
                return Enumerable.Empty<T>();
            //var result = source.Where(predicate);
            var result = Enumerable.Where(source, predicate);
            //return result.Skip(((int)page-1)*10).Take((int)pageSize);
            //return result.Skip((page.Value-1)*10).Take(pageSize.Value);
            return Paginate(result, page.Value, pageSize.Value);
        }
        public static T Random<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException($"{nameof(source)}");

            if (predicate == null)
                throw new ArgumentNullException($"{nameof(predicate)}");

            if (!source.Any())
                return default;
            Random random = new Random();
            //var result = source.Where(predicate).ElementAt(random.Next(0,source.Where(predicate).Count()));
            var result = source.Where(predicate);

            return Enumerable.ElementAt(result, random.Next(0, result.Count()));
        }
    }
}
