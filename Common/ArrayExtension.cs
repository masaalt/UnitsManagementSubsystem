using System;

namespace Common
{
    public static class ArrayExtension
    {
        public static T[] RemoveAt<T>(this T[] arr, int index)
        {
            for (int a = index; a < arr.Length - 1; a++)
            {
                arr[a] = arr[a + 1];
            }
            Array.Resize(ref arr, arr.Length - 1);
            return arr;
        }
    }
}
