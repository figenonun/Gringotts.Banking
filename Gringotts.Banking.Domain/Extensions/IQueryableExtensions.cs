namespace Gringotts.Banking.Domain.Extensions;
using Gringotts.Banking.Shared.Abstractions;
using Microsoft.EntityFrameworkCore;


public static class IQueryableExtensions
{
    public static async Task<PagedResult<T>> GetPagedResult<T>(
        this IQueryable<T> query,
        int page, 
        int pageSize,
        CancellationToken cancellationToken = default) 
        where T : class
    {
        var result = new PagedResult<T>();
        result.CurrentPage = page;
        result.PageSize = pageSize;
        result.TotalPageCount = await query.CountAsync(cancellationToken);

        var pageCount = (double)result.TotalItemCount / pageSize;
        result.TotalPageCount = (int)Math.Ceiling(pageCount);

        var skip = (page - 1) * pageSize;
        result.Items = await query.Skip(skip).Take(pageSize).ToListAsync(cancellationToken);

        return result;
    }
}