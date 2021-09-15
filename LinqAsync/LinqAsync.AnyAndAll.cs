using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LinqAsync {
  
  //-------------------------------------------------------------------------------------------------------------------
  //
  /// <summary>
  /// 
  /// </summary>
  //
  //-------------------------------------------------------------------------------------------------------------------

  public static partial class AsyncEnumerableExtensions {
    #region Public 

    /// <summary>
    /// Any
    /// </summary>
    public static async Task<bool> AnyAsync<T>(this IAsyncEnumerable<T> source, 
                                                    Func<T, bool> predicate,
                                                    CancellationToken token) {
      if (source is null)
        throw new ArgumentNullException(nameof(source));
      if (predicate is null)
        throw new ArgumentNullException(nameof(predicate));

      token.ThrowIfCancellationRequested();

      await foreach (var item in source.ConfigureAwait(false)) {
        token.ThrowIfCancellationRequested();

        if (predicate(item))
          return true;
      }

      return false;
    }

    /// <summary>
    /// Any
    /// </summary>
    public static async Task<bool> AnyAsync<T>(this IAsyncEnumerable<T> source,
                                                    Func<T, bool> predicate) =>
      await AnyAsync(source, predicate, CancellationToken.None).ConfigureAwait(false);

    /// <summary>
    /// Any
    /// </summary>
    public static async Task<bool> AnyAsync<T>(this IAsyncEnumerable<T> source,
                                                    CancellationToken token) {
      if (source is null)
        throw new ArgumentNullException(nameof(source));

      token.ThrowIfCancellationRequested();

      await foreach (var item in source.ConfigureAwait(false)) {
        token.ThrowIfCancellationRequested();

        return true;
      }

      return false;
    }

    /// <summary>
    /// Any
    /// </summary>
    public static async Task<bool> AnyAsync<T>(this IAsyncEnumerable<T> source) =>
      await AnyAsync(source, CancellationToken.None).ConfigureAwait(false);

    /// <summary>
    /// All
    /// </summary>
    public static async Task<bool> AllAsync<T>(this IAsyncEnumerable<T> source, 
                                                    Func<T, bool> predicate,
                                                    CancellationToken token) {
      if (source is null)
        throw new ArgumentNullException(nameof(source));
      if (predicate is null)
        throw new ArgumentNullException(nameof(predicate));

      token.ThrowIfCancellationRequested();

      await foreach (var item in source.ConfigureAwait(false)) {
        token.ThrowIfCancellationRequested();

        if (!predicate(item))
          return false;
      }

      return true;
    }

    /// <summary>
    /// All
    /// </summary>
    public static async Task<bool> AllAsync<T>(this IAsyncEnumerable<T> source,
                                                    Func<T, bool> predicate) =>
      await AllAsync(source, predicate, CancellationToken.None).ConfigureAwait(false);

    #endregion Public
  }

}
