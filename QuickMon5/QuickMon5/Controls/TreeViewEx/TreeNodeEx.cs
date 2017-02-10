using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickMon
{
    public class TreeNodeEx : TreeNode
    {
        public TreeNodeEx() : base()
        {

        }
        public TreeNodeEx(string text, int imageIndex, int selectedImageIndex) : base(text, imageIndex, selectedImageIndex)
        {

        }
        public string DisplayValue { get; set; }
        
    }
    public static class TreeNodeExStatic
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