using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Represents a collection of algorithms for optimizing the optimization process.
    /// </summary>
    public class Algorithm : DataGroupInput
    {

        /// <summary>
        /// When activated, this algorithm groups pieces into larger rectangles, which speeds up the optimization process and yields better results.
        /// </summary>
        public bool grouping { get; }

        /// <summary>
        /// When activated, this algorithm tries to predict waste during the optimization process. If the predicted waste is greater than the best solution found so far, the algorithm stops exploring the current branch and switches to another one.
        /// </summary>
        public bool deduction { get; }

        /// <summary>
        /// When activated, this algorithm speeds up the optimization process by quickly optimizing the last cuttings when there aren’t enough pieces to fill the entire area.
        /// </summary>
        public bool lastStockItem { get; }

        /// <summary>
        /// When activated, this algorithm immediately stops optimization of a single cutting as soon as it finds the first solution that fills the entire area. It may not always produce the best results for the entire optimization process.
        /// </summary>
        public bool firstHit { get; }

        /// <summary>
        /// When activated, this algorithm activates a shallow optimization process that is very fast but may produce weaker results.
        /// </summary>
        public bool fast { get; }

        /// <summary>
        /// When activated, this algorithm addresses the issue of greedy optimization by distributing small, medium, and large pieces throughout all the cuttings.
        /// </summary>
        public bool balance { get; }

        /// <summary>
        /// forking is a global optimization algorithm that checks more solutions assuming that not always the best single solution found is the best in the context of the entire optimization. This algorithm is deprecated and will most likely be removed soon.
        ///     bool ForkingEnabled - Enables or disables the forking object.
        ///     int ForkingLevel - The level property describes the maximum number of iterations that can be done for each solution.
        /// </summary>
        public Forking forking { get; }

        /// <summary>
        /// The adaptive algorithm operates by repeating the optimization process multiple times. In each subsequent iteration, problematic elements are shifted to earlier cuttings to improve the results.
        /// </summary>
        public Adaptive adaptive { get; }

        /// <summary>
        /// ai is a type of global optimization algorithm that leverages artificial intelligence to discover superior solutions. The level of the ai algorithm refers to several of its parameters, with a higher level resulting in a longer optimization process and a better solution.
        /// Properties:
        ///     bool AIEnabled - Enables or disables the ai object.
        ///     int AILevel - The level of the ai algorithm refers to several of its parameters. A higher level means a longer optimization process but also results in a better solution. Typically, levels 1 or 2 produce satisfactory results. Each algorithm is ignored if ai algorithm is enabled.
        /// </summary>
        public AI ai { get; }

        /// <summary>
        /// Constructor for Algorithm
        /// </summary>
        /// <param name="grouping">When activated, this algorithm groups pieces into larger rectangles, which speeds up the optimization process and yields better results</param>
        /// <param name="deduction">When activated, this algorithm tries to predict waste during the optimization process. If the predicted waste is greater than the best solution found so far, the algorithm stops exploring the current branch and switches to another one</param>
        /// <param name="lastStockItem">When activated, this algorithm speeds up the optimization process by quickly optimizing the last cuttings when there aren’t enough pieces to fill the entire area</param>
        /// <param name="firstHit">When activated, this algorithm immediately stops optimization of a single cutting as soon as it finds the first solution that fills the entire area. It may not always produce the best results for the entire optimization process</param>
        /// <param name="fast">When activated, this algorithm activates a shallow optimization process that is very fast but may produce weaker results</param>
        /// <param name="balance">When activated, this algorithm addresses the issue of greedy optimization by distributing small, medium, and large pieces throughout all the cuttings</param>
        /// <param name="forking">The forking object for global optimization</param>
        /// <param name="adaptive">The adaptive algorithm for repeated optimization</param>
        /// <param name="ai">The AI algorithm for leveraging artificial intelligence</param>
        public Algorithm(
                bool grouping,
                bool deduction,
                bool lastStockItem,
                bool firstHit,
                bool fast,
                bool balance,
                Forking forking,
                Adaptive adaptive,
                AI ai
                )
        {
            this.grouping = grouping;
            this.deduction = deduction;
            this.lastStockItem = lastStockItem;
            this.firstHit = firstHit;
            this.fast = fast;
            this.balance = balance;

            this.forking = forking;
            this.adaptive = adaptive;
            this.ai = ai;

        }
    }
}
