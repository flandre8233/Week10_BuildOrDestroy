using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public static class RandomString 
{
    public static string Generate(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[Random.Range(0,chars.Length)]).ToArray());
    }

    public static string Generate(int minLength, int maxLength)
    {
        int length =  Random.Range(minLength, maxLength+1);
        return Generate(length);
    }

    public static string GenerateRandomName(){
        return Generate(8);
    }
}
