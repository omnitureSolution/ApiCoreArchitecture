//using System;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;

//namespace Omniture.Db.Shared.Paging
//{
//    public class SearchPage
//    {
//        public int PageIndex { get; set; }
//        public int PageSize { get; set; } = 50;
//        public int IndexFrom { get; set; }
//        public string SearchText { get; set; }
//    }
//    public static class IQueryablePageListExtensions
//    {
//        /// <summary>
//        /// Converts the specified source to <see cref="IPagedList{T}"/> by the specified <paramref name="pageIndex"/> and <paramref name="pageSize"/>.
//        /// </summary>
//        /// <typeparam name="T">The type of the source.</typeparam>
//        /// <param name="source">The source to paging.</param>
//        /// <param name="pageIndex">The index of the page.</param>
//        /// <param name="pageSize">The size of the page.</param>
//        /// <param name="cancellationToken">
//        ///     A <see cref="CancellationToken" /> to observe while waiting for the task to complete.
//        /// </param>
//        /// <param name="indexFrom">The start index value.</param>
//        /// <returns>An instance of the inherited from <see cref="IPagedList{T}"/> interface.</returns>
//        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, SearchPage searchPage, CancellationToken cancellationToken = default)
//        {
//            if (searchPage.IndexFrom > searchPage.PageIndex)
//            {
//                throw new ArgumentException($"indexFrom: {searchPage.IndexFrom} > pageIndex: {searchPage.PageIndex}, must indexFrom <= pageIndex");
//            }

//            var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
//            var items = await source.Skip((searchPage.PageIndex - searchPage.IndexFrom) * searchPage.PageSize)
//                                    .Take(searchPage.PageSize).ToListAsync(cancellationToken).ConfigureAwait(false);

//            var pagedList = new PagedList<T>()
//            {
//                PageIndex = searchPage.PageIndex,
//                PageSize = searchPage.PageSize,
//                IndexFrom = searchPage.IndexFrom,
//                TotalCount = count,
//                Items = items,
//                TotalPages = (int)Math.Ceiling(count / (double)searchPage.PageSize)
//            };

//            return pagedList;
//        }
//    }
//}
