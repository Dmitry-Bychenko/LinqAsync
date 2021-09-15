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
    /// Count
    /// </summary>
    public static async Task<int> CountAsync<T>(this IAsyncEnumerable<T> source, 
                                                     Func<T, bool> predicate, 
                                                     CancellationToken token) {
      if (source is null)
        throw new ArgumentNullException(nameof(source));
      if (predicate is null)
        throw new ArgumentNullException(nameof(predicate));

      token.ThrowIfCancellationRequested();

      int count = 0;

      await foreach (var item in source.ConfigureAwait(false)) {
        token.ThrowIfCancellationRequested();

        if (predicate(item))
          Interlocked.Increment(ref count);
      }

      return count;
    }

    /// <summary>
    /// Count
    /// </summary>
    public static async Task<int> CountAsync<T>(this IAsyncEnumerable<T> source,
                                                     Func<T, bool> predicate) =>
      await CountAsync(source, predicate, CancellationToken.None).ConfigureAwait(false);

    /// <summary>
    /// Count
    /// </summary>
    public static async Task<int> CountAsync<T>(this IAsyncEnumerable<T> source,
                                                     CancellationToken token) {
      if (source is null)
        throw new ArgumentNullException(nameof(source));

      token.ThrowIfCancellationRequested();

      int count = 0;

      await foreach (var item in source.ConfigureAwait(false)) {
        token.ThrowIfCancellationRequested();

        Interlocked.Increment(ref count);
      }

      return count;
    }

    /// <summary>
    /// Count
    /// </summary>
    public static async Task<int> CountAsync<T>(this IAsyncEnumerable<T> source) =>
      await CountAsync(source, CancellationToken.None).ConfigureAwait(false);

    /// <summary>
    /// Count
    /// </summary>
    public static async Task<long> CountLongAsync<T>(this IAsyncEnumerable<T> source, 
                                                          Func<T, bool> predicate,
                                                          CancellationToken token) {
      if (source is null)
        throw new ArgumentNullException(nameof(source));
      if (predicate is null)
        throw new ArgumentNullException(nameof(predicate));

      token.ThrowIfCancellationRequested();

      long count = 0;

      await foreach (var item in source.ConfigureAwait(false)) {
        token.ThrowIfCancellationRequested();

        if (predicate(item))
          Interlocked.Increment(ref count);
      }

      return count;
    }

    /// <summary>
    /// Count
    /// </summary>
    public static async Task<long> CountLongAsync<T>(this IAsyncEnumerable<T> source,
                                                          Func<T, bool> predicate) =>
      await CountLongAsync(source, predicate, CancellationToken.None).ConfigureAwait(false);

    /// <summary>
    /// Count
    /// </summary>
    public static async Task<long> CountLongAsync<T>(this IAsyncEnumerable<T> source, 
                                                          CancellationToken token) {
      if (source is null)
        throw new ArgumentNullException(nameof(source));

      token.ThrowIfCancellationRequested();

      long count = 0;

      await foreach (var item in source.ConfigureAwait(false)) {
        token.ThrowIfCancellationRequested();

        Interlocked.Increment(ref count);
      }

      return count;
    }

    /// <summary>
    /// Count
    /// </summary>
    public static async Task<long> CountLongAsync<T>(this IAsyncEnumerable<T> source) =>
      await CountLongAsync(source, CancellationToken.None).ConfigureAwait(false);

    #endregion Public
  }

}
