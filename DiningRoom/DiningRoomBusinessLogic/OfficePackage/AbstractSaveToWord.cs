using DiningRoomBusinessLogic.OfficePackage.HelperEnums;
using DiningRoomBusinessLogic.OfficePackage.HelperModels;

namespace DiningRoomBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info);

            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            foreach (var product in info.Products)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> {
                        (product.ProductName + ": ", new WordTextProperties { Size = "24", Bold = true }),
                        (Convert.ToInt32(product.Cost).ToString(), new WordTextProperties { Size = "24", })},
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }

            SaveWord(info);
        }

        /// <summary>
		/// Создание doc-файла
		/// </summary>
		/// <param name="info"></param>
        protected abstract void CreateWord(WordInfo info);

        /// <summary>
        /// Создание абзаца с текстом
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        protected abstract void CreateParagraph(WordParagraph paragraph);

        /// <summary>
		/// Сохранение файла
		/// </summary>
		/// <param name="info"></param>
        protected abstract void SaveWord(WordInfo info);
    }
}