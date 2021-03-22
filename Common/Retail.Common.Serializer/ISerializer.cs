﻿namespace Retail.Common.Serializer
{
    public interface ISerializer
    {
        T DeserializeObject<T>(string input);
        string SerializeObject<T>(T obj);
        T DeserializeObject<T>(byte[] input);
        byte[] SerializeObjectToByteArray<T>(T obj);
    }
}
