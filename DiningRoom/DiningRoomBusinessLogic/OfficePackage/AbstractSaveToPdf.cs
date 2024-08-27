using DiningRoomBusinessLogic.OfficePackage.HelperEnums;
using DiningRoomBusinessLogic.OfficePackage.HelperModels;

namespace DiningRoomBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToPdf
    {
        public void CreateDoc(PdfInfo info)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            CreatePdf(info);
            CreateParagraph(new PdfParagraph { Text = info.Title, Style = "NormalTitle", ParagraphAlignment = PdfParagraphAlignmentType.Center });
            CreateParagraph(new PdfParagraph { Text = $"с {info.DateFrom.ToShortDateString()} по {info.DateTo.ToShortDateString()}", Style = "Normal", ParagraphAlignment = PdfParagraphAlignmentType.Center });

            // Устанавливаем размеры колонок таблицы
            CreateTable(new List<string> { "3cm", "2cm", "6cm", "6cm" });

            // Группировка данных по ComponentName
            var groupedData = info.Components.GroupBy(c => c.ComponentName);

            foreach (var group in groupedData)
            {
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string> { "Продукт", "Цена", "", "" }, // assuming currency format
                    Style = "NormalTitle",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });
                // Добавление строки с именем компонента и его стоимостью
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string> { group.Key, group.First().ComponentCost.ToString("C"),"","" }, // assuming currency format
                    Style = "NormalTitle",
                    ParagraphAlignment = PdfParagraphAlignmentType.Left
                });

                // Добавление заголовка для элементов компонента
                CreateRow(new PdfRowParameters
                {
                    Texts = new List<string> { "","","Карта", "Блюдо" },
                    Style = "NormalTitle",
                    ParagraphAlignment = PdfParagraphAlignmentType.Center
                });

                // Добавление строк с элементами компонента
                foreach (var item in group)
                {
                    CreateRow(new PdfRowParameters
                    {
                        Texts = new List<string>
                        {
                            string.IsNullOrEmpty(item.CardName) ? "N/A" : item.CardName,
                            string.IsNullOrEmpty(item.ProductName) ? "N/A" : item.ProductName
                        },
                        Style = "Normal",
                        ParagraphAlignment = PdfParagraphAlignmentType.Left
                    });
                }
            }

            SavePdf(info);
        }


        /// <summary>
		/// Создание doc-файла
		/// </summary>
		/// <param name="info"></param>
        protected abstract void CreatePdf(PdfInfo info);

        /// <summary>
        /// Создание параграфа с текстом
        /// </summary>
        /// <param name="title"></param>
        /// <param name="style"></param>
        protected abstract void CreateParagraph(PdfParagraph paragraph);

        /// <summary>
        /// Создание таблицы
        /// </summary>
        /// <param name="title"></param>
        /// <param name="style"></param>
        protected abstract void CreateTable(List<string> columns);

        /// <summary>
        /// Создание и заполнение строки
        /// </summary>
        /// <param name="rowParameters"></param>
        protected abstract void CreateRow(PdfRowParameters rowParameters);

        /// <summary>
		/// Сохранение файла
		/// </summary>
		/// <param name="info"></param>
        protected abstract void SavePdf(PdfInfo info);
    }
}
