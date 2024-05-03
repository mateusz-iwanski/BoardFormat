using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Config data group contains just a list of profiles to be used.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Version number of the data group.
        /// </summary>
        public int version { get ; }

        /// <summary>
        /// Default units specification as described in defaultUnits section.
        /// </summary>
        public DefaultUnitsInput defaultUnits { get; }

        /// <summary>
        /// List of profile objects.
        /// If no profiles are provided, the program will use the default ones.
        /// </summary>
        public List<Profile> profiles { get; set; }

        /// <summary>
        /// Constructor for Configuration
        /// </summary>
        /// <param name="version">Version number of the data group</param>
        /// <param name="defaultUnits">Default units specification</param>
        /// <param name="profiles">List of profile objects. If no profiles are provided, the program will use the default ones</param>
        public Configuration(int _version, DefaultUnitsInput _defaultUnits, Profile _profiles)
        {
            version = _version;
            defaultUnits = _defaultUnits;
            this.profiles = new List<Profile> { _profiles };
        }
    }

    

   



}
