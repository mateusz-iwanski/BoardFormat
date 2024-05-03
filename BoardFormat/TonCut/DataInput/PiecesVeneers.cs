using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonCut
{
    /// <summary>
    /// Specifies which veneers should be used.
    /// 2D Only
    /// </summary>
    public class Veneers : DataGroupInput
    {
        /// <summary>
        /// ID of the veneer to be used on the left edge.
        /// </summary>
        public int? leftVeneerId { get; }

        /// <summary>
        /// ID of the veneer to be used on the right edge.
        /// </summary>
        public int? rightVeneerId { get; }

        /// <summary>
        /// ID of the veneer to be used on the top edge.
        /// </summary>
        public int? topVeneerId { get; }

        /// <summary>
        /// ID of the veneer to be used on the bottom edge.
        /// </summary>
        public int? bottomVeneerId { get; }

        /// <summary>
        /// Constructor for Veneers class. 2D Only
        /// </summary>
        /// <param name="leftVeneerId">ID of the veneer to be used on the left edge.</param>
        /// <param name="rightVeneerId">ID of the veneer to be used on the right edge.</param>
        /// <param name="topVeneerId">ID of the veneer to be used on the top edge.</param>
        /// <param name="bottomVeneerId">ID of the veneer to be used on the bottom edge.</param>
        public Veneers(int? leftVeneerId, int? rightVeneerId, int? topVeneerId, int? bottomVeneerId)
        {
            this.leftVeneerId = leftVeneerId;
            this.rightVeneerId = rightVeneerId;
            this.topVeneerId = topVeneerId;
            this.bottomVeneerId = bottomVeneerId;
        }
    }
}
