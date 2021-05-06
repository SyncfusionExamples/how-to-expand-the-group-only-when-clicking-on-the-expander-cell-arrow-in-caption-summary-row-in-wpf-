using System;
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System.Windows;
using System.Windows.Input;

namespace SfDataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            sfDataGrid.GroupCollapsing += SfDataGrid_GroupCollapsing;
            sfDataGrid.GroupExpanding += SfDataGrid_GroupExpanding;
            sfDataGrid.SelectionChanging += SfDataGrid_SelectionChanging;
        }

        private void SfDataGrid_SelectionChanging(object sender, GridSelectionChangingEventArgs e)
        {
            var visualcontainer = this.sfDataGrid.GetVisualContainer();
            var point = Mouse.GetPosition(visualcontainer);
            //Here you can get the row and column index based on the pointer position by using PointToCellRowColumnIndex() method 
            var rowColumnIndex = visualcontainer.PointToCellRowColumnIndex(point);

            //When the rowindex is zero , the row will be header row  
            if (!rowColumnIndex.IsEmpty)
            {
                //Get the RecordEntry by passing the RowIndex 
                var rowData = this.sfDataGrid.GetRecordEntryAtRowIndex(rowColumnIndex.RowIndex);
                if (rowData == null)
                    return;

                //Check retrieved RecordEntry is group 
                if (rowData.IsGroups && rowColumnIndex.ColumnIndex > 0)
                {
                    e.Cancel = true;
                }
            }
        }

        private void SfDataGrid_GroupExpanding(object sender, GroupChangingEventArgs e)
        {
            var visualcontainer = this.sfDataGrid.GetVisualContainer();
            var point = Mouse.GetPosition(visualcontainer);
            //Here you can get the row and column index based on the pointer position by using PointToCellRowColumnIndex() method
            var rowColumnIndex = visualcontainer.PointToCellRowColumnIndex(point);
            //When the rowindex is zero , the row will be header row 
            if (!rowColumnIndex.IsEmpty)
            {
                if (rowColumnIndex.ColumnIndex > 0)
                {
                    e.Cancel = true;
                }
            }
        }

        private void SfDataGrid_GroupCollapsing(object sender, GroupChangingEventArgs e)
        {
            var visualcontainer = this.sfDataGrid.GetVisualContainer();
            var point = Mouse.GetPosition(visualcontainer);
            //Here you can get the row and column index based on the pointer position by using PointToCellRowColumnIndex() method
            var rowColumnIndex = visualcontainer.PointToCellRowColumnIndex(point);
            //When the rowindex is zero , the row will be header row 
            if (!rowColumnIndex.IsEmpty)
            {
                if (rowColumnIndex.ColumnIndex > 0)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
         
   

