using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Utility;


public class FlattenedArray<T>
{
    public FlattenedArray() { }

    public FlattenedArray(T[,] input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));

        Rows = input.GetLength(0);
        Cols = input.GetLength(1);
        Values = new T[Rows * Cols];

        int index = 0;
        for (int r = 0; r < Rows; r++)
            for (int c = 0; c < Cols; c++)
                Values[index++] = input[r, c];
    }

    // Use private setters to protect the integrity of the flattened data
    public int Rows { get; private set; }
    public int Cols { get; private set; }
    public T[] Values { get; private set; }

    public T[,] Unpack()
    {
        if (Values == null) return new T[0, 0];

        T[,] result = new T[Rows, Cols];
        int index = 0;

        for (int r = 0; r < Rows; r++)
            for (int c = 0; c < Cols; c++)
                result[r, c] = Values[index++];

        return result;
    }

    // 1. Explicitly convert FROM a 2D array TO a FlattenedArray
    public static explicit operator FlattenedArray<T>(T[,] input)
        => input == null ? null : new FlattenedArray<T>(input);

    // 2. Implicitly convert FROM a FlattenedArray TO a 2D array
    public static implicit operator T[,](FlattenedArray<T> input)
        => input?.Unpack();

    // Implicitly convert FROM a FlattenedArray TO a 1D array
    public static implicit operator T[](FlattenedArray<T> input)
        => input?.Values;
}
