using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace GeoDataSource
{
    public class Serialize
    {

        public enum SerializationMethods { Binary, XML };
        public static bool SerializeToDisk(object request, SerializationMethods Method, string Filename)
        {
            if (Method == SerializationMethods.XML) return SerializeXMLToDisk(request, Filename);
            return SerializeBinaryToDisk(request, Filename);

        }
        public static bool SerializeBinaryToDisk(object request, string Filename)
        {
            System.IO.File.WriteAllBytes(Filename, SerializeBinaryAsBytes(request));
            return System.IO.File.Exists(Filename);
        }

        public static MemoryStream SerializeBinary(object request)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream memoryStream1 = new MemoryStream();
            binaryFormatter.Serialize(memoryStream1, request);
            return memoryStream1;
        }
        public static byte[] SerializeBinaryAsBytes(object request)
        {
            using (MemoryStream stm = SerializeBinary(request))
            {
                return ConvertStreamToBytes(stm);
            }
            return null;
        }
        public static object DeSerializeBinary(MemoryStream memStream)
        {
            memStream.Position = (long)0;
            object local1 = new BinaryFormatter().Deserialize(memStream);
            memStream.Close();
            return local1;
        }

        public static object DeSerializeXML(MemoryStream memStream, Type type, bool ThrowException)
        {
            object local2;

            if (memStream.Position > (long)0 && memStream.CanSeek)
            {
                memStream.Position = (long)0;
            }
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                local2 = xmlSerializer.Deserialize(memStream);
            }
            catch (Exception exc)
            {
                local2 = null;
                if (ThrowException) throw exc;
            }
            return local2;
        }

        public static object DeSerializeXML(MemoryStream memStream, Type type)
        {
            object local2;

            if (memStream.Position > (long)0 && memStream.CanSeek)
            {
                memStream.Position = (long)0;
            }
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                local2 = xmlSerializer.Deserialize(memStream);
            }
            catch (Exception)
            {
                local2 = null;
            }
            return local2;
        }

        public static byte[] SerializeXMLAsBytes(object request)
        {
            using (MemoryStream stm = SerializeXML(request))
            {
                return ConvertStreamToBytes(stm);
            }
            return null;
        }
        public static bool SerializeXMLToDisk(object request, string Filename)
        {
            if (System.IO.File.Exists(Filename)) System.IO.File.Delete(Filename);
            System.IO.File.WriteAllText(Filename, SerializeXMLAsString(request));
            return System.IO.File.Exists(Filename);
        }
        public static string SerializeXMLAsString(object request)
        {
            using (MemoryStream stm = SerializeXML(request))
            {
                return ConvertStreamToString(stm);
            }
            return null;
        }

        public static MemoryStream SerializeXML(object request)
        {
            return SerializeXML(request, request.GetType());
        }

        public static MemoryStream SerializeXML(object request, Type type, bool ThrowException)
        {
            MemoryStream memoryStream2;

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                MemoryStream memoryStream1 = new MemoryStream();
                xmlSerializer.Serialize(memoryStream1, request);
                memoryStream2 = memoryStream1;
            }
            catch (Exception exc)
            {
                memoryStream2 = null;
                if (ThrowException) throw exc;
            }
            return memoryStream2;
        }
        public static MemoryStream SerializeXML(object request, Type type)
        {
            MemoryStream memoryStream2;

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                MemoryStream memoryStream1 = new MemoryStream();
                xmlSerializer.Serialize(memoryStream1, request);
                memoryStream2 = memoryStream1;
            }
            catch (Exception exc)
            {
                memoryStream2 = null;
            }
            return memoryStream2;
        }

        public static T DeserializeBinaryFromResource<T>(string Name)
        {
            using (System.IO.BinaryReader rdr = new BinaryReader(typeof(GeoData).Assembly.GetManifestResourceStream(Name)))
            {
                byte[] data = rdr.ReadBytes((int)rdr.BaseStream.Length);
                return (T)DeSerializeBinary(new MemoryStream(data));
            }
        }

        public static T DeserializeBinaryFromDisk<T>(string Filename)
        {
            byte[] data = System.IO.File.ReadAllBytes(Filename);
            return (T)DeSerializeBinary(new MemoryStream(data));
        }

        public static T DeserializeXMLFromDisk<T>(string Filename)
        {
            string contents = System.IO.File.ReadAllText(Filename);
            return DeSerializeXML<T>(contents);
        }

        public static T DeSerializeXML<T>(string envelope,  bool ThrowException)
        {
            T local2;
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(envelope));
                T local1 = (T)xmlSerializer.Deserialize(memoryStream);
                memoryStream.Close();
                local2 = local1;
            }
            catch (Exception exc)
            {
                local2 = default(T);
                if (ThrowException) throw exc;
            }
            return local2;
        }

        public static T DeSerializeXML<T>(string envelope)
        {
            T local2;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(envelope));
            T local1 = (T)xmlSerializer.Deserialize(memoryStream);
            memoryStream.Close();
            local2 = local1;

            return local2;
        }


        public static string ConvertStreamToString(System.IO.Stream Stream)
        {
            if (Stream != null && Stream.Length > 0)
            {
                if (Stream.Position > 0) Stream.Seek(0, SeekOrigin.Begin);
                byte[] data = new byte[Stream.Length];
                Stream.Read(data, 0, data.Length);
                return System.Text.Encoding.UTF8.GetString(data);
            }
            return null;
        }

        public static string ConvertStreamToString(System.IO.MemoryStream Stream)
        {
            byte[] d = ConvertStreamToBytes(Stream);
            if (d == null) return "";
            return System.Text.ASCIIEncoding.ASCII.GetString(d);
        }
        public static byte[] ConvertStreamToBytes(System.IO.MemoryStream Stream)
        {
            if (Stream == null) return null;
            if (Stream != null && Stream.CanSeek && Stream.Position > 0) Stream.Position = 0;
            byte[] d = new byte[(int)Stream.Length];
            Stream.Read(d, 0, d.Length);
            Stream.Close();
            return d;
        }
        public static System.IO.MemoryStream ConvertStringToStream(string Data)
        {
            return ConvertBytesToStream(System.Text.ASCIIEncoding.ASCII.GetBytes(Data));
        }
        public static System.IO.MemoryStream ConvertBytesToStream(byte[] Data)
        {
            return new System.IO.MemoryStream(Data);
        }
    }

}
