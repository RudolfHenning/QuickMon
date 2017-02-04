using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public static class TreeNodeEx
    {
        public static void ExpandAllParents(this TreeNode node)
        {
            if (node != null && node.Parent != null)
            {
                if (!node.Parent.IsExpanded)
                    node.Parent.Expand();
                ExpandAllParents(node.Parent);
            }
        }
    }
}