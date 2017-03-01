using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HenIT.Windows.Controls
{
    /// <summary>
    /// Interface ITreeListViewItemComparer
    /// </summary>
    public interface ITreeListViewItemComparer : System.Collections.IComparer
    {
        /// <summary>
        /// Sort order
        /// </summary>
        SortOrder SortOrder
        {
            get;
            set;
        }
        /// <summary>
        /// Column for the comparison
        /// </summary>
        int Column
        {
            get;
            set;
        }
    }
}
