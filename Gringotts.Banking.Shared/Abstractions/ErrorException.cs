namespace Gringotts.Banking.Shared.Abstractions;

using System;

/// <summary>
///     The Places we don't use service result. We can throw serviceException.
///     This exception will be handled on api layer by exception middleware.
/// </summary>
public class ErrorException : Exception
{
    /// <summary>
    ///     When we catch this exception, we can reach service error by this property.
    /// </summary>
    public Error Error { get; }

    /// <summary>
    ///     This error Just Accept ServiceError.
    /// </summary>
    /// <param name="serviceError"></param>
    public ErrorException(Error error) : base(error.Description)
    {
        Error = error;
    }
}