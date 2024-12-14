using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace VectorT;

public struct Vector3<T> : IEquatable<Vector3<T>> where T: INumber<T> {
    public T X { get; set; }
    public T Y { get; set; }
    public T Z { get; set; }

    public Vector3(T x, T y, T z) {
        X = x;
        Y = y;
        Z = z;
    }

    public Vector3(T scalar) {
        X = scalar;
        Y = scalar;
        Z = scalar;
    }

    public Vector3(Vector2<T> vector, T z) {
        X = vector.X; 
        Y = vector.Y;
        Z = z;
    }

    public readonly void Deconstruct(out T x, out T y, out T z) {
        x = X;
        y = Y;
        z = Z;
    }

    public readonly T this[int index] {
        get => index switch {
            0 => X,
            1 => Y,
            2 => Z,
            _ => throw new ArgumentOutOfRangeException(nameof(index)),
        };
    }

    /// <summary>
    /// Performs a memberwise addition
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector3<T> operator +(Vector3<T> lhs, Vector3<T> rhs) {
        return new(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
    }

    /// <summary>
    /// Performs a memberwise subtraction
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector3<T> operator -(Vector3<T> lhs, Vector3<T> rhs) {
        return new(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
    }
    
    /// <summary>
    /// Performs a memberwise multiplication
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector3<T> operator *(Vector3<T> lhs, Vector3<T> rhs) {
        return new(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z);
    }
    /// <summary>
    /// Performs a memberwise division.
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector3<T> operator /(Vector3<T> lhs, Vector3<T> rhs) {
        return new(lhs.X / rhs.X, lhs.Y / rhs.Y, lhs.Z / rhs.Z);
    }
    
    /// <summary>
    /// Performs a scalar multiplication
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector3<T> operator *(Vector3<T> lhs, T rhs) {
        return new(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs);
    }

    /// <summary>
    /// Performs a scalar multiplication
    /// </summary>
    /// <param name="rhs"></param>
    /// <param name="lhs"></param>
    /// <returns></returns>
    public static Vector3<T> operator *(T lhs, Vector3<T> rhs) {
        return new(rhs.X * lhs, rhs.Y * lhs, rhs.Z * lhs);
    }

    /// <summary>
    /// Performs a scalar division
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static Vector3<T> operator /(Vector3<T> lhs, T rhs) {
        return new(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs);
    }

    /// <summary>
    /// Check for equality with another Vector3
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static bool operator ==(Vector3<T> lhs, Vector3<T> rhs) {
        return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
    }

    /// <summary>
    /// Check for inequality with another Vector3
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static bool operator !=(Vector3<T> lhs, Vector3<T> rhs) {
        return lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z;
    }

    public readonly override bool Equals([NotNullWhen(true)] object? obj) {
        if (obj is not Vector3<T> other) {
            return false;
        }
        return Equals(other);
    }
    public readonly bool Equals(Vector3<T> other) {
        return this == other;
    }

    public readonly override int GetHashCode() {
        return X.GetHashCode() ^ (Y.GetHashCode() << 4) ^ (Z.GetHashCode() << 8);
    }

    public readonly override string ToString() {
        return $"({X}, {Y}, {Z})";
    }
}
