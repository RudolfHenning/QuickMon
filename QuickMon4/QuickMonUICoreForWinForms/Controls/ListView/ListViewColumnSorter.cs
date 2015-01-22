using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace QuickMon.Controls
{
    /// <summary>
    /// IComparer class to provide sorting for ListView controls
    /// </summary>
    public class ListViewColumnSorter : IComparer, ICloneable, IDisposable
    {
        #region " Constructors and destructors "
        public ListViewColumnSorter()
        {
            ColumnToSort = 0; //Initialize the column to '0'.
            OrderOfSort = SortOrder.None; // Initialize the sort order to 'none'.
            ObjectCompare = new CaseInsensitiveComparer(); // Initialize the CaseInsensitiveComparer object.
            ColtypesCollection.Clear();
            ColtypesCollection.Add(new hitColumnHeader(SortColumnType.StringType)); //Add at least one column
            ColtypesCollection[0].SortType = SortColumnType.StringType;
            SorterEnabled = true;
        }
        public ListViewColumnSorter(int iCols)
        {
            ColumnToSort = 0; //Initialize the column to '0'.
            OrderOfSort = SortOrder.None; //Initialize the sort order to 'none'.
            ObjectCompare = new CaseInsensitiveComparer(); //Initialize the CaseInsensitiveComparer object.
            SetCols(iCols);
            SorterEnabled = true;
        }
        public ListViewColumnSorter(ListView ListViewControl)
        {
            int I;
            ColumnToSort = 0; //Initialize the column to '0'.
            OrderOfSort = SortOrder.None; //Initialize the sort order to 'none'.
            ObjectCompare = new CaseInsensitiveComparer(); //Initialize the CaseInsensitiveComparer object.
            _ListViewAppliedOn = ListViewControl;
            ListViewControl.ListViewItemSorter = this;
            AddColumnHeaderImages();

            ColtypesCollection.Clear();
            for (I = 0; I < _ListViewAppliedOn.Columns.Count; I++)
            {
                ColtypesCollection.Add(new hitColumnHeader(SortColumnType.StringType));
                ColtypesCollection[I].SortType = SortColumnType.StringType;
            }

            SorterEnabled = true;
        }
        public ListViewColumnSorter(ListView ListViewControl, bool AttachColumnClickEventHandler)
        {
            int I;
            ColumnToSort = 0; //Initialize the column to '0'.
            SorterEnabled = false;
            _ListViewAppliedOn = ListViewControl;
            ListViewControl.ListViewItemSorter = this;
            OrderOfSort = SortOrder.None; //Initialize the sort order to 'none'.
            ObjectCompare = new CaseInsensitiveComparer(); //Initialize the CaseInsensitiveComparer object.

            ColtypesCollection.Clear();
            for (I = 0; I < _ListViewAppliedOn.Columns.Count; I++)
            {
                ColtypesCollection.Add(new hitColumnHeader(SortColumnType.StringType));
                ColtypesCollection[I].SortType = SortColumnType.StringType;
            }

            AddColumnHeaderImages();
            this.SetColSortImage();
            if (AttachColumnClickEventHandler) { AddColumnClickEventHandler(); }
            SorterEnabled = true;
        }
        public ListViewColumnSorter(ListView ListViewControl, bool AttachColumnClickEventHandler, params SortColumnType[] iColType)
        {
            ColumnToSort = 0; //Initialize the column to '0'.
            SorterEnabled = false;
            _ListViewAppliedOn = ListViewControl;
            ListViewControl.ListViewItemSorter = this;
            OrderOfSort = SortOrder.None; //Initialize the sort order to 'none'.
            ObjectCompare = new CaseInsensitiveComparer(); //Initialize the CaseInsensitiveComparer object.

            ColtypesCollection.Clear();
            SetColType(iColType); //Set column types

            AddColumnHeaderImages();
            this.SetColSortImage();
            if (AttachColumnClickEventHandler) { AddColumnClickEventHandler(); }

            SorterEnabled = true;
        }

        ~ListViewColumnSorter() //Destructor
        {
            ColtypesCollection.Clear();
        }
        public void Dispose()
        {
            ColtypesCollection = null;
        }
        #endregion

        #region " private variables "
        private int ColumnToSort;
        private SortOrder OrderOfSort;
        private CaseInsensitiveComparer ObjectCompare;
        private bool SorterEnabled;
        private hitColumnHeaderCollection ColtypesCollection = new hitColumnHeaderCollection();
        private bool _SortTotalLine = false;
        private string _TotalLineText = "TOTALS";
        private ListView _ListViewAppliedOn;
        #endregion

        #region " Sorting up/down images "
        #region " Declarations for Sorting up/down images "
        private const int LVM_GETHEADER = 4127;
        private const int HDM_SETIMAGELIST = 4616;
        private const int LVM_SETCOLUMN = 4122;
        private const int LVCF_FMT = 1;
        private const int LVCFMT_LEFT = 0x0;
        private const int LVCFMT_RIGHT = 0x0001;
        private const int LVCFMT_CENTER = 0x0002;
        private const int LVCFMT_JUSTIFYMASK = 0x0003;
        private const int LVCF_IMAGE = 16;
        private const int LVCFMT_IMAGE = 2048;
        private const int LVCFMT_BITMAP_ON_RIGHT = 4096;
        private ImageList SortingImgList = new ImageList();

        private enum ArrowType
        {
            Transparent = 0,
            Ascending = 1,
            Descending = 2
        }

        //Define the LVCOLUMN for use with Interop.
        [StructLayout(LayoutKind.Sequential, Pack = 8, CharSet = CharSet.Auto)]
        private struct LVCOLUMN
        {
            public int mask;
            public int fmt;
            public int cx;
            public IntPtr pszText;
            public int cchTextMax;
            public int iSubItem;
            public int iImage;
            public int iOrder;
        }
        #endregion

        #region " SendMessage overloaded functions "
        //Declare three overloaded SendMessage functions. The
        //difference is in the parameter types.
        [DllImport("User32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("User32", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, ref LVCOLUMN lParam);

        [DllImport("User32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
        #endregion

        #region " Sorting up/down images "
        //function to Draw an image at run time
        private Bitmap GetArrowBitmap(ArrowType type)
        {
            Bitmap bmp = new Bitmap(16, 16);
            Graphics gfx = Graphics.FromImage(bmp);
            Pen lightPen = SystemPens.ControlLightLight;
            Pen shadowPen = SystemPens.ControlDark;
            gfx.FillRectangle(System.Drawing.Brushes.Transparent, 0, 0, 16, 16);

            if (type == ArrowType.Ascending)
            { // Up arrow
                Point[] myPoints = new Point[3];
                myPoints[0] = new Point(2, 12);
                myPoints[1] = new Point(12, 12);
                myPoints[2] = new Point(7, 3);
                gfx.FillPolygon(System.Drawing.Brushes.LightGray, myPoints);
                gfx.DrawLine(lightPen, 2, 12, 12, 12);
                gfx.DrawLine(lightPen, 12, 12, 7, 3);
                gfx.DrawLine(shadowPen, 7, 3, 2, 12);
            }
            else
            {
                if (type == ArrowType.Descending)
                { //Down Arrow
                    Point[] myPoints = new Point[3];
                    myPoints[0] = new Point(2, 3);
                    myPoints[1] = new Point(12, 3);
                    myPoints[2] = new Point(7, 12);
                    gfx.FillPolygon(System.Drawing.Brushes.LightGray, myPoints);
                    gfx.DrawLine(shadowPen, 2, 3, 12, 3);
                    gfx.DrawLine(lightPen, 12, 3, 7, 12);
                    gfx.DrawLine(shadowPen, 7, 12, 2, 3);
                }
            }

            gfx.Dispose();
            return bmp;
        }
        /// <summary>
        /// Draws the triangle images indicating the sorting direction
        /// </summary>
        public void SetColSortImage()
        {
            SetColSortImage(ColumnToSort, (int)OrderOfSort);
        }
        /// <summary>
        /// Draws the triangle images indicating the sorting direction
        /// </summary>
        /// <param name="Column">Column number currently sorting on (0 based)</param>
        /// <param name="SortDirection">Ascending or Descending</param>
        public void SetColSortImage(int Column, int SortDirection)
        {
            if (_ListViewAppliedOn == null)
            {
                throw new Exception("ListView control not set for ListViewColSorter!");
            }
            SetColSortImage(ref _ListViewAppliedOn, Column, SortDirection);
        }
        /// <summary>
        /// Draws the triangle images indicating the sorting direction
        /// </summary>
        /// <param name="theListView">ListView control</param>
        /// <param name="Column">Column number currently sorting on (0 based)</param>
        /// <param name="SortDirection">Ascending or Descending</param>
        public void SetColSortImage(ref ListView theListView, int Column, int SortDirection)
        {
            IntPtr hwnd;
            IntPtr lret;
            int I;
            LVCOLUMN col;
            HorizontalAlignment colAlignment;
            //Assign the ImageList to the header control.
            //The header control includes all columns.
            //Get a handle to the header control.
            hwnd = SendMessage(theListView.Handle, LVM_GETHEADER, 0, 0);
            //Add the ImageList to the header control.
            //lret = SendMessage(hwnd, HDM_SETIMAGELIST, 0, (ImageList1.Handle).ToInt32)
            lret = SendMessage(hwnd, HDM_SETIMAGELIST, 0, SortingImgList.Handle);
            //The code to follow uses successive images in the ImageList to loop  'through all columns and place successive columns in the ColumnHeader.
            //This code uses LVCOLUMN to define alignment. By using LVCOLUMN here, 
            //you reset the alignment if it was defined in the designer. 
            //if you need to set the alignment, you must change the code below to set it here.
            for (I = 0; I <= theListView.Columns.Count - 1; I++)
            {
                colAlignment = theListView.Columns[I].TextAlign;
                if (Column == I)
                {
                    if (SortDirection == (int)SortOrder.Ascending)
                    {
                        col.iImage = 1;
                    }
                    else
                    {
                        if (SortDirection == (int)SortOrder.Descending)
                        {
                            col.iImage = 2;
                        }
                        else
                        {
                            col.iImage = 0;
                        }
                    }
                    //Use the LVM_SETCOLUMN message to set the column's image index. 
                    col.fmt = 0;
                    if (colAlignment == HorizontalAlignment.Right)
                    {
                        col.fmt = LVCFMT_RIGHT;
                    }
                    if (colAlignment == HorizontalAlignment.Center)
                    {
                        col.fmt = LVCFMT_CENTER;
                    }
                    col.mask = (LVCF_FMT + LVCF_IMAGE);
                    col.fmt += LVCFMT_IMAGE + LVCFMT_BITMAP_ON_RIGHT;
                    col.cchTextMax = 0;
                    col.cx = 0;
                    col.iOrder = 0;
                    col.iSubItem = 0;
                    col.pszText = IntPtr.Zero;//.op_Explicit[0];
                    //Send the LVM_SETCOLUMN message.
                    //The column to which you are assigning the image is defined in the third parameter.
                    lret = SendMessage(theListView.Handle, LVM_SETCOLUMN, I, ref col);
                }
                else
                {
                    theListView.Columns[I].TextAlign = colAlignment;
                }
            }
        }
        /// <summary>
        /// Initializing column sorting icons
        /// </summary>
        public void AddColumnHeaderImages()
        {
            if (_ListViewAppliedOn == null)
            {
                throw new Exception("ListView control not set for ListViewColSorter!");
            }
            AddColumnHeaderImages(ref _ListViewAppliedOn);
        }
        /// <summary>
        /// Initializing column sorting icons
        /// </summary>
        /// <param name="theListView">Relevant ListView</param>
        public void AddColumnHeaderImages(ref ListView theListView)
        {
            try
            {
                SortingImgList.ImageSize = new Size(16, 16);
                SortingImgList.TransparentColor = System.Drawing.Color.Magenta;
                SortingImgList.Images.Add(GetArrowBitmap(ArrowType.Transparent));
                SortingImgList.Images.Add(GetArrowBitmap(ArrowType.Ascending));
                SortingImgList.Images.Add(GetArrowBitmap(ArrowType.Descending));
                IntPtr hHeader = SendMessage(theListView.Handle, LVM_GETHEADER, 0, 0);
                IntPtr iRet = SendMessage(hHeader, HDM_SETIMAGELIST, 0, SortingImgList.Handle);
            }
            catch (Exception ex)
            {
                throw new Exception("Error initializing column header icons: " + ex.Message);
            }
        }
        #endregion
        #endregion

        #region " Properties "
        public int ColumnCount
        {
            get
            {
                if (ColtypesCollection != null)
                {
                    return ColtypesCollection.Count;
                }
                else
                {
                    return 0;
                }
            }
        }
        public int SortColumn
        {
            get
            {
                return ColumnToSort;
            }
            set
            {
                ColumnToSort = value;
            }
        }
        public SortOrder Order
        {
            get
            {
                return OrderOfSort;
            }
            set
            {
                OrderOfSort = value;
            }
        }
        public bool Enabled
        {
            get
            {
                return SorterEnabled;
            }
            set
            {
                SorterEnabled = value;
            }

        }
        public bool SortTotalLine
        {
            get
            {
                return _SortTotalLine;
            }
            set
            {
                _SortTotalLine = value;
            }
        }
        public string TotalLineText
        {
            get
            {
                return _TotalLineText;
            }
            set
            {
                _TotalLineText = value;
            }
        }
        public hitColumnHeaderCollection ColumnType
        {
            get
            {
                return ColtypesCollection;
            }
        }
        public ListView GetListViewAppliedOn()
        {
            return _ListViewAppliedOn;
        }
        public void SetListViewAppliedOn(ref ListView ListViewControl)
        {
            _ListViewAppliedOn = ListViewControl;
        }
        #endregion
        #region " Enable/Disable "
        public void Disable()
        {
            SorterEnabled = false;
        }
        public void Enable()
        {
            SorterEnabled = true;
        }
        #endregion

        #region " Set column count and types "
        public void SetCols(int iColCount)
        {
            int I;
            ColtypesCollection.Clear();
            for (I = 1; I <= iColCount; I++)
            {
                ColtypesCollection.Add(new hitColumnHeader(SortColumnType.StringType));
            }
        }
        public void SetColType(int iColumn, SortColumnType iColType)
        {
            int I;
            try
            {
                if (ColtypesCollection.Count < iColumn)
                {
                    for (I = ColtypesCollection.Count; I < iColumn; I++)
                    {
                        ColtypesCollection.Add(new hitColumnHeader(SortColumnType.StringType));
                    }
                }
                ColtypesCollection[iColumn - 1].SortType = iColType;
            }
            catch (Exception ex)
            {
                throw new Exception("SetColType:" + ex.Message);
            }
        }
        public void SetColType(params SortColumnType[] iColType)
        {
            int I;
            try
            {
                for (I = 0; I <= iColType.Length - 1; I++)
                {
                    SetColType((I + 1), iColType[I]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SetColType:" + ex.Message);
            }
        }
        #endregion
        #region " Compare function "
        public int Compare(object x, object y)
        {
            #region Local variables
            int compareResult;
            ListViewItem listviewX;
            ListViewItem listviewY;
            int iSortType;
            string sText1, sText2;
            #endregion
            if (!(SorterEnabled)) //If sorting is disabled don't bother going on
            {
                compareResult = 0;
                return compareResult;
            }
            //Cast the objects to be compared to ListViewItem objects.
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            #region Some validality test
            //Some validality tests
            try
            {
                iSortType = (byte)ColtypesCollection[ColumnToSort].SortType;
                if (listviewX.SubItems.Count > ColumnToSort)
                {
                    sText1 = listviewX.SubItems[ColumnToSort].Text;
                }
                else
                {
                    return 0;
                }
                if (listviewY.SubItems.Count > ColumnToSort)
                {
                    sText2 = listviewY.SubItems[ColumnToSort].Text;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
            #endregion
            #region Total line sorting
            //Avoiding sorting total lines
            if ((!SortTotalLine)) // && ColumnToSort == 0 ) //Avoiding sorting total lines
            {
                if (listviewX.SubItems[0].Text == _TotalLineText) { return 0; }
                if (listviewY.SubItems[0].Text == _TotalLineText) { return 0; }
            }
            #endregion
            //Compare the two items.
            if (iSortType == (int)SortColumnType.StringType) //String types
            {
                #region String Type sorting
                try
                {
                    compareResult = ObjectCompare.Compare(sText1, sText2);
                }
                catch
                {
                    compareResult = 0;
                }
                #endregion
            }
            else
            {
                if (iSortType == (int)SortColumnType.NumberType) //Number types
                {
                    #region Number Type sorting
                    try
                    {
                        if (IsNumeric(listviewX.SubItems[ColumnToSort].Text) && IsNumeric(listviewY.SubItems[ColumnToSort].Text))
                        {
                            compareResult = ObjectCompare.Compare(double.Parse(listviewX.SubItems[ColumnToSort].Text), Double.Parse(listviewY.SubItems[ColumnToSort].Text));
                        }
                        else //do a string compare
                        {
                            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
                        }
                    }
                    catch
                    {
                        compareResult = 0;
                    }
                    #endregion
                }
                else if (iSortType == (int)SortColumnType.DateType) //Date types
                {
                    try
                    {
                        #region Date Type sorting
                        if ((listviewX.SubItems[ColumnToSort].Text.Length == 0) || (listviewY.SubItems[ColumnToSort].Text.Length == 0))
                        {
                            if (listviewX.SubItems[ColumnToSort].Text.Length == 0)
                            {
                                compareResult = -1;
                            }
                            else
                            {
                                compareResult = 1;
                            }
                        }
                        else
                        {
                            if (IsDate(listviewX.SubItems[ColumnToSort].Text) && IsDate(listviewY.SubItems[ColumnToSort].Text))
                            {
                                compareResult = ObjectCompare.Compare(DateTime.Parse(listviewX.SubItems[ColumnToSort].Text), DateTime.Parse(listviewY.SubItems[ColumnToSort].Text));
                            }
                            else  //do a string compare
                            {
                                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
                            }
                        }
                        #endregion
                    }
                    catch
                    {
                        compareResult = 0;
                    }
                }
                else
                {
                    if (iSortType == (int)SortColumnType.StringInvertType) //Inverted string types
                    {
                        #region Inverted Type sorting
                        try
                        {
                            compareResult = ObjectCompare.Compare(InvertString(listviewX.SubItems[ColumnToSort].Text), InvertString(listviewY.SubItems[ColumnToSort].Text));
                        }
                        catch
                        {
                            compareResult = 0;
                        }
                        #endregion
                    }
                    else
                    {
                        if (iSortType == (int)SortColumnType.NumberStringMix) //Mixed string/number types
                        {
                            #region Mixed string/number Type sorting
                            if (!IsNumeric(listviewX.SubItems[ColumnToSort].Text) || !IsNumeric(listviewY.SubItems[ColumnToSort].Text))
                            {
                                try
                                {
                                    compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
                                }
                                catch
                                {
                                    compareResult = 0;
                                }
                            }
                            else
                            {
                                try
                                {
                                    compareResult = ObjectCompare.Compare(Double.Parse(listviewX.SubItems[ColumnToSort].Text), Double.Parse(listviewY.SubItems[ColumnToSort].Text));
                                }
                                catch
                                {
                                    compareResult = 0;
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            if (iSortType == (int)SortColumnType.ByteSize)
                            {
                                #region ByteSize Type sorting
                                try
                                {
                                    //Byte/Kilobyte/Megabyte etc types
                                    //byte(s), KB, MB, GB
                                    Int64 n1, n2;
                                    n1 = FormatToBytes(sText1);
                                    n2 = FormatToBytes(sText2);
                                    if ((n1 == -1) || (n2 == -1))
                                    {
                                        compareResult = 0;
                                    }
                                    else
                                    {
                                        compareResult = ObjectCompare.Compare(n1, n2);
                                    }
                                }
                                catch
                                {
                                    compareResult = 0;
                                }
                                #endregion
                            }
                            else  //else unknown
                            {
                                compareResult = 0;
                            }
                        }
                    }
                }
            }

            #region Setting the sort direction
            //Calculate the correct return value based on the object comparison.
            if (OrderOfSort == SortOrder.Ascending)
            {
                //Ascending sort is selected, return typical result of compare operation.
                return compareResult;
            }
            else
            {
                if (OrderOfSort == SortOrder.Descending)
                {
                    //Descending sort is selected, return negative result of compare operation.
                    return (-compareResult);
                }
                else
                {
                    //return 0 to indicate that they are equal.
                    return 0;
                }
            }
            #endregion
        }
        private Int64 FormatToBytes(string Text)
        {
            double Bytes;
            Int64 Result;
            string Scale;
            try
            {
                if (Text.IndexOf("Byte(s)") > -1)
                {
                    Bytes = double.Parse(Text.Substring(0, Text.Length - 8));
                }
                else
                {
                    Scale = Text.Substring(Text.Length - 2, 2);
                    Bytes = double.Parse(Text.Substring(0, Text.Length - 3));
                    if (Scale == "KB")
                    {
                        Bytes = Bytes * 1024;
                    }
                    if (Scale == "MB")
                    {
                        Bytes = Bytes * 1048576;
                    }
                    if (Scale == "GB")
                    {
                        Bytes = Bytes * 1073741824;
                    }
                }
            }
            catch
            {
                Bytes = -1;
            }
            Result = Int64.Parse(Math.Round(Bytes, 0).ToString());
            return Result;
        }

        #endregion

        #region " Helper functions "
        private string InvertString(string Str)
        {
            System.Text.StringBuilder myStrBuild = new System.Text.StringBuilder();
            int I;
            for (I = 1; I <= (Str.Length); I++)
            {
                myStrBuild.Append(Str.Substring(Str.Length - I, 1));
            }
            return myStrBuild.ToString();
        }
        private static System.Text.RegularExpressions.Regex isInt32 = new System.Text.RegularExpressions.Regex(@"^[-]?\d+$");
        private static System.Text.RegularExpressions.Regex isNumeric = new System.Text.RegularExpressions.Regex(@"^[-]?\d+.\d+$");
        private bool IsNumeric(string theValue)
        {
            System.Text.RegularExpressions.Match m;
            m = isInt32.Match(theValue);
            if (m.Success)
            {
                return m.Success;
            }
            else
            {
                double tmp;
                return double.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out tmp);
                //m = isNumeric.Match(theValue); 
                //return m.Success; 
            }
        }
        private bool IsDate(string Date)
        {
            try
            {
                DateTime.Parse(Date);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region ICloneable Members

        public object Clone()
        {
            ListViewColumnSorter newListViewColumnSorter = new ListViewColumnSorter();
            newListViewColumnSorter.ColumnToSort = ColumnToSort;
            newListViewColumnSorter.OrderOfSort = OrderOfSort;
            newListViewColumnSorter.ObjectCompare = ObjectCompare;
            newListViewColumnSorter.ColtypesCollection = (hitColumnHeaderCollection)ColtypesCollection.Clone();
            newListViewColumnSorter._SortTotalLine = _SortTotalLine;
            newListViewColumnSorter._TotalLineText = _TotalLineText;
            return newListViewColumnSorter;
        }

        #endregion

        #region Adding eventhandler to ListView Control
        public void AddColumnClickEventHandler()
        {
            if (_ListViewAppliedOn != null)
            {
                _ListViewAppliedOn.ColumnClick += new ColumnClickEventHandler(this.ColumnClick);
            }
        }
        private void ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (_ListViewAppliedOn != null)
            {
                // Determine if the clicked column is already the column that is being sorted.
                if (e.Column == this.SortColumn)
                {
                    // Reverse the current sort direction for this column.
                    if (this.Order == SortOrder.Ascending)
                    {
                        this.Order = SortOrder.Descending;
                    }
                    else
                    {
                        this.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    this.SortColumn = e.Column;
                    this.Order = SortOrder.Ascending;
                }

                // Perform the sort with these new sort options.
                _ListViewAppliedOn.Sort();
                this.SetColSortImage();
                if (_ListViewAppliedOn.SelectedItems.Count > 0)
                {
                    _ListViewAppliedOn.SelectedItems[0].EnsureVisible();
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// ColumnHeader class with SortColumnType added
    /// </summary>
    public class hitColumnHeader
    {
        private SortColumnType _SortType;
        private HorizontalAlignment _Alignment;
        #region Constructors
        public hitColumnHeader() { }
        public hitColumnHeader(SortColumnType SortType)
        {
            _SortType = SortType;
            _Alignment = HorizontalAlignment.Left;
        }
        public hitColumnHeader(SortColumnType SortType, HorizontalAlignment Alignment)
        {
            _SortType = SortType;
            _Alignment = Alignment;
        }

        #endregion
        #region properties
        [DescriptionAttribute("Set the sort type of the column.")]
        public SortColumnType SortType
        {
            get
            {
                return _SortType;
            }
            set
            {
                _SortType = value;
            }
        }
        [DescriptionAttribute("Set the alignment of the column.")]
        public HorizontalAlignment Alignment
        {
            get
            {
                return _Alignment;
            }
            set
            {
                _Alignment = value;
            }
        }
        #endregion
    }
    public class hitColumnHeaderCollection : System.Collections.CollectionBase, ICloneable
    {
        public hitColumnHeaderCollection() { }
        public hitColumnHeader Add(hitColumnHeader value)
        {
            base.List.Add(value);
            return value;
        }
        public void hitColumnHeader(hitColumnHeader[] values)
        {
            // Use existing method to add each array entry
            foreach (hitColumnHeader ColumnHeader in values)
                Add(ColumnHeader);
        }
        public void Remove(hitColumnHeader value)
        {
            // Use base class to process actual collection operation
            base.List.Remove(value as object);
        }
        public void Insert(int index, hitColumnHeader value)
        {
            // Use base class to process actual collection operation
            base.List.Insert(index, value as object);
        }
        public bool Contains(hitColumnHeader value)
        {
            // Use base class to process actual collection operation
            return base.List.Contains(value as object);
        }
        public hitColumnHeader this[int index]
        {
            // Use base class to process actual collection operation
            get
            {
                if (base.Count >= 1)
                {
                    return (base.List[index] as hitColumnHeader);
                }
                else
                {
                    return null;
                }
            }
        }

        public int IndexOf(hitColumnHeader value)
        {
            // Find the 0 based index of the requested entry
            return base.List.IndexOf(value);
        }
        public object Clone()
        {
            hitColumnHeaderCollection newcol = new hitColumnHeaderCollection();
            foreach (hitColumnHeader Itm in this.List)
            {
                newcol.Add(Itm);
            }
            return newcol;
        }

    }

    /// <summary>
    /// Types of sorting allowed
    /// </summary>
    public enum SortColumnType : int
    {
        StringType = 1,
        NumberType = 2,
        DateType = 3,
        StringInvertType = 4,
        NumberStringMix = 5,
        ByteSize = 6
    }
}
