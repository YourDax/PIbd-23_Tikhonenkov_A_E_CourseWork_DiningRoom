using DiningRoomBusinessLogic.OfficePackage.HelperEnums;
using DiningRoomBusinessLogic.OfficePackage.HelperModels;

namespace DiningRoomBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info);

            // Добавляем заголовок
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            // Группируем компоненты по имени компонента
            var groupedComponents = info.ProductComponents
                .GroupBy(item => item.ComponentName)
                .ToList();

            // Перебираем группы компонентов и добавляем их в документ
            foreach (var group in groupedComponents)
            {
                // Добавляем строку с названием компонента
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> { ("Продукт - " + group.Key + ":", new WordTextProperties { Size = "24", Bold = true }) },
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });

                // Перебираем продукты внутри группы компонентов
                foreach (var product in group)
                {
                    // Добавляем информацию о продукте
                    CreateParagraph(new WordParagraph
                    {
                        Texts = new List<(string, WordTextProperties)> {
                    ("Присутствует в заказе - "+product.OrderName, new WordTextProperties { Size = "24"})
                },
                        TextProperties = new WordTextProperties
                        {
                            Size = "24",
                            JustificationType = WordJustificationType.Both
                        }
                    });
                }
                // Добавляем пустые абзацы для создания отступа
                for (int i = 0; i < 2; i++)
                {
                    CreateParagraph(new WordParagraph
                    {
                        Texts = new List<(string, WordTextProperties)> { ("", new WordTextProperties { Size = "24" }) },
                        TextProperties = new WordTextProperties
                        {
                            Size = "24",
                            JustificationType = WordJustificationType.Both
                        }
                    });
                }
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