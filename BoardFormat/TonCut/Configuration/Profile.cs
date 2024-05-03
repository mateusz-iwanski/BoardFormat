using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static TonCut.StockOrder;

namespace TonCut
{
    /// <summary>
    /// List of profile objects.
    /// If no profiles are provided, the program will use the default ones.
    /// Profile refers to an optimization profile.
    /// It describes the configuration for algorithms to be used and optimization limits, such as maximum time, maximum number of combination, etc.
    /// An optimization profile allows users to specify the parameters and constraints for an optimization process, ensuring that the algorithms used are tailored to their specific needs and requirements.
    /// The user can define up to 20 profiles, allowing them to test different optimization strategies to achieve the best results.
    /// </summary>
    public class Profile : DataGroupInput
    {
        /// <summary>
        /// The name of the optimization profile.
        /// </summary>
        public string name { get; }

        /// <summary>
        /// Set it to true, to activate the profile. It will be used only if it is active.
        /// </summary>
        public bool active { get; }

        /// <summary>
        /// Configuration of algorithms to be used by the profile.
        /// </summary>
        public Algorithm algorithms { get; }

        /// <summary>
        /// Here we can define the conditions for early termination of global and/or single optimization.
        /// </summary>
        public Limits limits { get; }

        /// <summary>
        /// Here we can specify the stock sequence strategy. This is of great importance and can significantly affect the quality of the results.
        /// These settings apply to all algorithms except ai.
        /// </summary>
        public StockOrder stockOrder { get; }

        /// <summary>
        /// Here we can change some advanced settings.
        /// Before you change anything here, make sure you understand what you are doing, as these settings may significantly change the quality of results and also time of the optimization process.
        /// </summary>
        public Advanced advanced { get; }

        /// <summary>
        /// Constructor for OptimizationProfile
        /// </summary>
        /// <param name="name">The name of the optimization profile</param>
        /// <param name="active">Set it to true, to activate the profile. It will be used only if it is active</param>
        /// <param name="algorithms">Configuration of algorithms to be used by the profile</param>
        /// <param name="limits">Here we can define the conditions for early termination of global and/or single optimization</param>
        /// <param name="stockOrder">Here we can specify the stock sequence strategy. This is of great importance and can significantly affect the quality of the results. These settings apply to all algorithms except ai</param>
        /// <param name="advanced">Here we can change some advanced settings. Before you change anything here, make sure you understand what you are doing, as these settings may significantly change the quality of results and also time of the optimization process</param>
        public Profile(string name, bool active, Algorithm algorithms, Limits limits, StockOrder stockOrder, Advanced advanced)
        {
            this.name = name;
            this.active = active;
            this.algorithms = algorithms;
            this.limits = limits;
            this.stockOrder = stockOrder;
            this.advanced = advanced;
        }

    }
    

    

    
}

