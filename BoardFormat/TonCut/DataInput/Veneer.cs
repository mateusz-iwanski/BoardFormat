using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// List of veneer objects.
    /// </summary>
    /// <summary>
    /// The Veneer object specifies characteristics of a veneer.
    /// </summary>
    public class Veneer : DataGroupInput, IDataGroupRoot
    {
        /// <summary>
        /// Unique id of the veneer.
        /// Mandatory
        /// </summary>
        public int id { get; }

        /// <summary>
        /// Title of the veneer.
        /// Mandatory
        /// </summary>
        public string title { get; }

        /// <summary>
        /// width of the veneer.
        /// Mandatory
        /// </summary>
        public int width { get; }

        /// <summary>
        /// Thickness of the veneer.
        /// Mandatory
        /// </summary>
        public double thickness { get; }

        /// <summary>
        /// The maximum thickness of the material for which this veneer can be used.
        /// Mandatory
        /// </summary>
        public double maxMaterialThickness { get; }

        /// <summary>
        /// Creates a new Veneer object.
        /// </summary>
        /// <param name="id">Unique id of the veneer. Mandatory.</param>
        /// <param name="title">Title of the veneer. Mandatory.</param>
        /// <param name="width">width of the veneer. Mandatory.</param>
        /// <param name="thickness">Thickness of the veneer. Mandatory.</param>
        /// <param name="maxMaterialThickness">The maximum thickness of the material for which this veneer can be used. Mandatory.</param>
        public Veneer(int id, string title, int width, double thickness, double maxMaterialThickness)
        {
            this.id = id;
            this.title = title;
            this.width = width;
            this.thickness = thickness;
            this.maxMaterialThickness = maxMaterialThickness;            
        }
    }
}
