using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace VectorT;

public struct Vector2<T> : IEquatable<Vector2<T>> where T: INumber<T> {
    public T X { get; set; }
    public T Y { get; set; }

    public Vector2(T x, T y) {
        X = x;
        Y = y;
    }

    public Vector2(T scalar) {
        X = scalar;
        Y = scalar;
    }

    public readonly void Deconstruct(out T x, out T y) {
        x = X;
        y = Y;
    }

    public readonly T this[int index] {
        get => index switch {
            0 => X,
            1 => Y,
            _ => throw new ArgumentOutOfRangeException(nameof(index)),
        };
    }

    /// <summary>
    /// Performs a memberwise addition
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector2<T> operator +(Vector2<T> lhs, Vector2<T> rhs) {
        return new(lhs.X + rhs.X, lhs.Y + rhs.Y);
    }

    /// <summary>
    /// Performs a memberwise subtraction
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector2<T> operator -(Vector2<T> lhs, Vector2<T> rhs) {
        return new(lhs.X - rhs.X, lhs.Y - rhs.Y);
    }
    
    /// <summary>
    /// Performs a memberwise multiplication
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector2<T> operator *(Vector2<T> lhs, Vector2<T> rhs) {
        return new(lhs.X * rhs.X, lhs.Y * rhs.Y);
    }
    /// <summary>
    /// Performs a memberwise division.
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector2<T> operator /(Vector2<T> lhs, Vector2<T> rhs) {
        return new(lhs.X / rhs.X, lhs.Y / rhs.Y);
    }
    
    /// <summary>
    /// Performs a scalar multiplication
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector2<T> operator *(Vector2<T> lhs, T rhs) {
        return new(lhs.X * rhs, lhs.Y * rhs);
    }

    /// <summary>
    /// Performs a scalar multiplication
    /// </summary>
    /// <param name="rhs"></param>
    /// <param name="lhs"></param>
    /// <returns></returns>
    public static Vector2<T> operator *(T lhs, Vector2<T> rhs) {
        return new(rhs.X * lhs, rhs.Y * lhs);
    }

    /// <summary>
    /// Performs a scalar division
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector2<T> operator /(Vector2<T> lhs, T rhs) {
        return new(lhs.X / rhs, lhs.Y / rhs);
    }

    /// <summary>
    /// Check for equality with another Vector2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static bool operator ==(Vector2<T> lhs, Vector2<T> rhs) {
        return lhs.X == rhs.X && lhs.Y == rhs.Y;
    }

    /// <summary>
    /// Check for inequality with another Vector2
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static bool operator !=(Vector2<T> lhs, Vector2<T> rhs) {
        return lhs.X != rhs.X || lhs.Y != rhs.Y;
    }

    public readonly override bool Equals([NotNullWhen(true)] object? obj) {
        if (obj is not Vector2<T> other) {
            return false;
        }
        return Equals(other);
    }
    public readonly bool Equals(Vector2<T> other) {
        return this == other;
    }

    public readonly override int GetHashCode() {
        return X.GetHashCode() ^ (Y.GetHashCode() << 4);
    }

    public readonly override string ToString() {
        return $"({X}, {Y})";
    }
}
