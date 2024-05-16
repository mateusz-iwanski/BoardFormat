using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    public abstract class DataGroupInput
    {
        /// <summary>
        /// Checks if the properties of the Input object are within the specified range.
        /// </summary>
        /// <typeparam name="T">The type of the Input object.</typeparam>
        /// <param name="_object">The Input object with properties to check.</param>
        /// <returns>True if all properties in object are within range, otherwise throws an ArgumentException.</returns>
        public bool RangeValueCheckAttribute<T>(T _object)
        {
            // Get all properties of the Input object
            PropertyInfo[] props = typeof(T).GetProperties();

            // Iterate through each property
            foreach (PropertyInfo prop in props)
            {
                // Check if the property has a RangeAttribute
                var attrs = prop.GetCustomAttribute(typeof(RangeAttribute), true) as RangeAttribute;

                if (attrs != null)
                {
                    // Convert the property value to double
                    var propertyValue = Convert.ToDouble(prop.GetValue(_object));

                    // Check if property value is within the specified range
                    if (propertyValue < Convert.ToDouble(attrs.Minimum) || propertyValue > Convert.ToDouble(attrs.Maximum))
                    {
                        // Throw an exception if property value is out of range
                        throw new ArgumentException($"Property {_object.GetType().ToString()}.{prop.Name} is set to \"{prop.GetValue(_object).ToString()}\" " +
                            $"but range is set to [{attrs.Minimum}-{attrs.Maximum}]");
                    }
                }
            }

            return true;
        }



        /// <summary>
        /// Checks if the string value of properties in the specified object match the allowed values defined by the StringValueAssignableAttribute.
        /// Throws an ArgumentException if any property value does not match the allowed values.
        /// </summary>
        /// <typeparam name="T">The type of the object to check.</typeparam>
        /// <param name="_object">The Input object with properties to check.</param>
        /// <returns>True if all property values match the allowed values, otherwise false.</returns>
        public bool StringValueCheckAttribute<T>(T _object)
        {
            // Get all properties of the specified object
            PropertyInfo[] props = typeof(T).GetProperties();

            // Iterate through each property and check for StringValueAssignableAttribute
            foreach (PropertyInfo prop in props)
            {
                // Get the StringValueAssignableAttribute for the property
                var attrs = prop.GetCustomAttribute(typeof(StringValueAssignableAttribute), true) as StringValueAssignableAttribute;
                if (attrs != null)
                {
                    // Check if the property value is in the allowed values
                    if (!attrs.Values().Any(x => x == prop.GetValue(_object).ToString()))
                    {
                        // Throw an ArgumentException if the property value is not in the allowed values
                        throw new ArgumentException($"Property {_object.GetType().ToString()}.{prop.Name} is set to \"{prop.GetValue(_object).ToString()}\" " +
                            $"but must be set to one of [\"{string.Join("\" | \"", attrs.Values())}\"]");
                    }
                }
            }

            return true;
        }



        /// <summary>
        /// Check if the properties of an object have values that match the names of a specified enum type
        /// Use EnumValueCheckAttribute(typeof(Enum object with value represented as name of TonCut property variable))
        /// </summary>
        /// <typeparam name="T">The type of the object</typeparam>
        /// <param name="_object">The object to be checked</param>
        /// <returns>True if all properties are valid, otherwise throws an ArgumentException</returns>
        public bool EnumValueCheckAttribute<T>(T _object)
        {
            PropertyInfo[] props = typeof(T).GetProperties();

            foreach (PropertyInfo prop in props)
            {
                var attrs = prop.GetCustomAttribute(typeof(EnumValueAssignableAttribute), true) as EnumValueAssignableAttribute;

                if (attrs != null)
                {
                    string[] attributeValue;
                    try
                    {
                        attributeValue = Enum.GetNames(attrs.Values());
                    }
                    catch
                    {
                        throw new ArgumentException($"EnumValueAssignableAttribute only accept Enum type");
                    }

                    if (attributeValue.Any(x => x == prop.GetValue(_object).ToString()))
                    {
                        throw new ArgumentException($"Property {_object.GetType().ToString()}.{prop.Name} is set to \"{prop.GetValue(_object).ToString()}\" " +
                            $"but must be set to one of [\"{string.Join("\" | \"", attributeValue)}\"]");
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the StockItem structure is compatible with the structure in Piece, and cheks if the material exist with materialId from Piece.
        /// </summary>
        /// <param name="piece">List of Piece</param>
        /// <param name="stockItem">List od StockItem</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public bool CheckMaterialCompatible(List<IDataGroupRoot> pieces, List<IDataGroupRoot> stockItems)
        {
            List<Piece> piece = pieces.Cast<Piece>().ToList();
            List<StockItem> stockItem = stockItems.Cast<StockItem>().ToList();

            foreach (Piece p in piece)
            {
                StockItem stock = stockItem.Find(x => x.materialId == p.materialId);
                if (stock == null)
                    throw new ArgumentException($"Piece \"{p.identifier}\" has no corresponding with list of StockItem with materialId - {p.materialId}");

                if (
                    stock.structure == "none" && p.structure == "byLength"
                    || stock.structure == "none" && p.structure == "byWidth")
                {
                    throw new ArgumentException($"StockItem with identifier \"{stock.identifier}\" is not compatible with Piece identifier \"{p.identifier}\". StockItem structure " +
                        $"is set to \"{stock.structure}\" so Piece structure can't be set to \"byLength\" or \"byWidth\"");
                }

            }
            return true;
        }

        public bool CheckDeviceCompatible(List<IDataGroupRoot> device, List<IDataGroupRoot> material)
        {
            List<Device> devices = device.Cast<Device>().ToList();
            List<Material> materials = material.Cast<Material>().ToList();

            foreach (Material _material in materials)
                if (devices.Find(x => x.id == _material.deviceId) == null)
                    throw new ArgumentException($"Material \"{_material.title}\" has set deviceId to - {_material.deviceId} which is not in the list of devices");
            return true;
        }

        public bool CheckPieceSizeWithMaterialSize(List<Piece> piece, List<StockItem> stockItem)
        {
            foreach (Piece _piece in piece)
            {
                StockItem stockWithMaterial = stockItem.Find(x => x.materialId == _piece.materialId);

                Console.WriteLine(stockWithMaterial.SizeReal().Length);
                Console.WriteLine(_piece.SizeReal().Length);

                if (stockWithMaterial.SizeReal().Length <= _piece.SizeReal().Length || stockWithMaterial.SizeReal().Width <= _piece.SizeReal().Width)
                    // if Piece can't rotate
                    if (_piece.structure != "none,byLength,byWidth")
                        throw new ArgumentException($"Piece \"{_piece.identifier}\" has bad size {_piece.SizeReal().Length}x{_piece.SizeReal().Width}");
                    else
                      // Check size for rotated _piece
                      if (stockWithMaterial.SizeReal().Length <= _piece.SizeReal().Width || stockWithMaterial.SizeReal().Width <= _piece.SizeReal().Length)
                        throw new ArgumentException($"Piece \"{_piece.identifier}\" has bad size {_piece.SizeReal().Length}x{_piece.SizeReal().Width}");
            }
            return true;
        }

    }
}
