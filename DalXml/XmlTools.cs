using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Dal;
public class XmlTools
{

   // public static string dir = @"..\bin\xml\";
    static XmlTools()
    {
    //    if (!Directory.Exists(dir))
    //        Directory.CreateDirectory(dir);
    }


    #region SaveLoadWithXMLSerializer
    public static void SaveListToXMLSerializer<T>(List<T> list, string filePath)
    {
        try
        {
            FileStream file = new FileStream(filePath, FileMode.Create);
            XmlSerializer x = new XmlSerializer(list.GetType());
            x.Serialize(file, list);
            file.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            //throw new DO.XMLFileLoadCreateException(filePath, $"fail to create xml file: {filePath}", ex);
        }
    }
    public static List<T> LoadListFromXMLSerializer<T>(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                List<T> list;
                XmlSerializer x = new XmlSerializer(typeof(List<T>));
                FileStream file = new FileStream(filePath, FileMode.Open);
                list = (List<T>)x.Deserialize(file)!;
                file.Close();
                return list;
            }
            else
                return new List<T>();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message); // DO.XMLFileLoadCreateException(filePath, $"fail to load xml file: {filePath}", ex);
        }
    }
    #endregion
    #region xmlConvertor
    /// <summary>
    /// Converts an object of any type to an XElement with a specified name
    /// </summary>
    /// <typeparam name="Item">The type of the object to convert</typeparam>
    /// <param name="item">The object to convert</param>
    /// <param name="name">The name of the resulting XElement</param>
    /// <returns>An XElement representation of the input object</returns>
    [MethodImpl(MethodImplOptions.Synchronized)]
    internal static XElement itemToXelement<Item>(Item item, string name)
    {
        IEnumerable<PropertyInfo> items = item!.GetType().GetProperties();

        IEnumerable<XElement> xElements = from propInfo in items
                                          select new XElement(propInfo.Name, propInfo.GetValue(item)!.ToString());

        return new XElement(name, xElements);
    }
    #endregion
}
