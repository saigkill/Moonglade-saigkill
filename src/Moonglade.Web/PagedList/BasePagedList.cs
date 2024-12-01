﻿namespace Moonglade.Web.PagedList;

/// <summary>
/// Represents a subset of a collection of objects that can be individually accessed by index and containing
/// metadata about the superset collection of objects this subset was created from.
/// </summary>
/// <remarks>
/// Represents a subset of a collection of objects that can be individually accessed by index and containing
/// metadata about the superset collection of objects this subset was created from.
/// </remarks>
/// <typeparam name = "T">The type of object the collection should contain.</typeparam>
/// <seealso cref = "IPagedList{T}" />
/// <seealso cref = "List{T}" />
public class BasePagedList<T> : IPagedList<T>
{
    public int PageCount { get; protected set; }

    public int TotalItemCount { get; protected set; }

    public int PageNumber { get; protected set; }

    public int PageSize { get; protected set; }

    public bool HasPreviousPage { get; protected set; }

    public bool HasNextPage { get; protected set; }

    public bool IsFirstPage { get; protected set; }

    public bool IsLastPage { get; protected set; }

    protected readonly List<T> Subset = [];

    /// <summary>
    /// Initializes a new instance of a type deriving from <see cref = "BasePagedList{T}" /> and sets properties
    /// needed to calculate position and size data on the subset and superset.
    /// </summary>
    /// <param name="subset">The single subset this collection should represent.</param>
    /// <param name = "pageNumber">The one-based index of the subset of objects contained by this instance.</param>
    /// <param name = "pageSize">The maximum size of any individual subset.</param>
    /// <param name = "totalItemCount">The size of the superset.</param>
    public BasePagedList(IEnumerable<T> subset, int pageNumber, int pageSize, int totalItemCount)
    {
        if (pageNumber < 1)
        {
            throw new ArgumentOutOfRangeException($"pageNumber = {pageNumber}. PageNumber cannot be below 1.");
        }

        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException($"pageSize = {pageSize}. PageSize cannot be less than 1.");
        }

        if (totalItemCount < 0)
        {
            throw new ArgumentOutOfRangeException($"totalItemCount = {totalItemCount}. TotalItemCount cannot be less than 0.");
        }

        // set source to blank list if superset is null to prevent exceptions
        TotalItemCount = totalItemCount;

        PageSize = pageSize;
        PageNumber = pageNumber;
        PageCount = TotalItemCount > 0
            ? (int)Math.Ceiling(TotalItemCount / (double)PageSize)
            : 0;

        var pageNumberIsGood = PageCount > 0 && PageNumber <= PageCount;

        HasPreviousPage = pageNumberIsGood && PageNumber > 1;
        HasNextPage = pageNumberIsGood && PageNumber < PageCount;
        IsFirstPage = pageNumberIsGood && PageNumber == 1;
        IsLastPage = pageNumberIsGood && PageNumber == PageCount;

        Subset.AddRange(subset);
    }

    /// <summary>
    /// 	Returns an enumerator that iterates through the BasePagedList&lt;T&gt;.
    /// </summary>
    /// <returns>A BasePagedList&lt;T&gt;.Enumerator for the BasePagedList&lt;T&gt;.</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return Subset.GetEnumerator();
    }

    /// <summary>
    /// 	Gets the number of elements contained on this page.
    /// </summary>
    public virtual int Count => Subset.Count;
}