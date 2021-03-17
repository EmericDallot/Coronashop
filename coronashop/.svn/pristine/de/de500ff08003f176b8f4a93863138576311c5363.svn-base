using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace IDATA
{
    /// <summary>
    /// Cette classe permet de sérialiser un Object en binaire
    /// et de désérialiser le binaire en Object
    /// </summary>
    public static class ToBin
    {
        /// <summary>
        /// Cette méthode sérialize un Object en binaire
        /// </summary>
        /// <param name="obj">Object à sérialiser</param>
        /// <returns>Object en byte[]</returns>
        public static byte[] Serializer(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            bf.Serialize(stream, obj);
            return stream.ToArray();
        }
        /// <summary>
        /// Cette méthode déserialize du binaire en Object 
        /// </summary>
        /// <param name="obj">byte[] à désérialiser</param>
        /// <returns> byte[] en Object</returns>
        public static Object Deserializer(byte[] obj)
        {
            MemoryStream stream = new MemoryStream();
            var bf = new BinaryFormatter();
            stream.Write(obj, 0, obj.Length);
            stream.Seek(0, SeekOrigin.Begin);
            return bf.Deserialize(stream);
        }
    }
}
