using DiningRoomBusinessLogic.OfficePackage.HelperEnums;
using DiningRoomBusinessLogic.OfficePackage.HelperModels;
using DiningRoomContracts.ViewModels;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DiningRoomBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToExcel
    {
        /// <summary>
        /// Создание отчета
        /// </summary>
        /// <param name="info"></param>
        public void CreateReport(ExcelInfo info)
        {
            CreateExcel(info);

            // Добавляем заголовок
            InsertCellInWorksheet(new ExcelCellParameters
            {
                ColumnName = "A",
                RowIndex = 1,
                Text = "Продукт",
                StyleInfo = ExcelStyleInfoType.Title
            });

            InsertCellInWorksheet(new ExcelCellParameters
            {
                ColumnName = "B",
                RowIndex = 1,
                Text = "Имя заказа",
                StyleInfo = ExcelStyleInfoType.Title
            });

            InsertCellInWorksheet(new ExcelCellParameters
            {
                ColumnName = "C",
                RowIndex = 1,
                Text = "Количество блюд в заказе",
                StyleInfo = ExcelStyleInfoType.Title
            });

            uint rowIndex = 2;

            // Группируем компоненты по названию
            var groupedComponents = info.ProductComponents
                .GroupBy(item => item.ComponentName)
                .ToList();

            // Перебираем данные и добавляем их в Excel
            foreach (var group in groupedComponents)
            {
                // Добавляем строку для названия компонента
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = group.Key, // Название компонента
                    StyleInfo = ExcelStyleInfoType.Text
                });
                rowIndex++;

                // Перебираем заказы внутри группы компонентов
                foreach (var item in group)
                {
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "B",
                        RowIndex = rowIndex,
                        Text = item.OrderName,
                        StyleInfo = ExcelStyleInfoType.TextWithBroder
                    });

                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "C",
                        RowIndex = rowIndex,
                        Text = item.ProductCount.ToString(),
                        StyleInfo = ExcelStyleInfoType.TextWithBroder
                    });

                    rowIndex++;
                }

                rowIndex++;
            }

            SaveExcel(info);
        }



        /// <summary>
        /// Создание excel-файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void CreateExcel(ExcelInfo info);

		/// <summary>
		/// Добавляем новую ячейку в лист
		/// </summary>
		/// <param name="cellParameters"></param>
		protected abstract void InsertCellInWorksheet(ExcelCellParameters excelParams);

		/// <summary>
		/// Объединение ячеек
		/// </summary>
		/// <param name="mergeParameters"></param>
		protected abstract void MergeCells(ExcelMergeParameters excelParams);

		/// <summary>
		/// Сохранение файла
		/// </summary>
		/// <param name="info"></param>
		protected abstract void SaveExcel(ExcelInfo info);
	}
}