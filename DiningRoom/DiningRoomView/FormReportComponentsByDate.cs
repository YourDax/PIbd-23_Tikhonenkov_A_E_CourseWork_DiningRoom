using DiningRoomBusinessLogic.OfficePackage.HelperModels;
using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DiningRoomView
{
    public partial class FormReportComponentsByDate : Form
    {

        private readonly ILogger _logger;

        private readonly IReportLogic _logic;

        public FormReportComponentsByDate(ILogger<FormReportComponentsByDate> logger, IReportLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }

        private void ButtonMake_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var dataSource = _logic.GetReportComponentsByCardDate(new ReportBindingModel
                {
                    DateFrom = DateTime.SpecifyKind(dateTimePickerFrom.Value, DateTimeKind.Utc),
                    DateTo = DateTime.SpecifyKind(dateTimePickerTo.Value, DateTimeKind.Utc)
                });

                // Группировка данных по ComponentName и преобразование в нужный формат
                var displayData = new List<GroupedComponentViewModel>();
                var groupedData = dataSource.GroupBy(c => c.ComponentName);

                foreach (var group in groupedData)
                {
                    // Добавляем строку с именем продукта и его стоимостью
                    displayData.Add(new GroupedComponentViewModel
                    {
                        ComponentName = group.Key,
                        ComponentCost = group.First().ComponentCost
                    });

                    // Добавляем только уникальные названия блюд и карт
                    var uniqueProducts = new HashSet<string>();
                    var uniqueCards = new HashSet<string>();

                    foreach (var item in group)
                    {
                        // Проверяем, есть ли название блюда и оно уникально
                        if (!string.IsNullOrEmpty(item.ProductName) && uniqueProducts.Add(item.ProductName))
                        {
                            displayData.Add(new GroupedComponentViewModel
                            {
                                ProductName = item.ProductName
                            });
                        }
                        // Проверяем, есть ли название карты и оно уникально
                        if (!string.IsNullOrEmpty(item.CardName) && uniqueCards.Add(item.CardName))
                        {
                            displayData.Add(new GroupedComponentViewModel
                            {
                                CardName = item.CardName
                            });
                        }
                    }
                }

                // Очистка предыдущих данных
                dataGridView.DataSource = null;

                // Установка нового источника данных
                dataGridView.DataSource = displayData;

                // Форматирование столбцов
                dataGridView.Columns["ComponentName"].HeaderText = "Название продукта";
                dataGridView.Columns["ComponentCost"].HeaderText = "Стоимость продукта";
                dataGridView.Columns["CardName"].HeaderText = "Название карты";
                dataGridView.Columns["ProductName"].HeaderText = "Название блюда";

                // Настройка видимости столбцов
                dataGridView.Columns["ComponentName"].Visible = true;
                dataGridView.Columns["ComponentCost"].Visible = true;
                dataGridView.Columns["CardName"].Visible = true;
                dataGridView.Columns["ProductName"].Visible = true;

                // Логирование успешной загрузки данных
                _logger.LogInformation("Загрузка списка заказов на период {From}-{To}", dateTimePickerFrom.Value.ToShortDateString(), dateTimePickerTo.Value.ToShortDateString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка заказов на период");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void ButtonToPdf_Click(object sender, EventArgs e)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logic.SaveComponentsToPdfFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName,
                        DateFrom = DateTime.SpecifyKind(dateTimePickerFrom.Value, DateTimeKind.Utc),
                        DateTo = DateTime.SpecifyKind(dateTimePickerTo.Value, DateTimeKind.Utc)
                    });
                    _logger.LogInformation("Сохранение списка заказов на период {From}-{To}", dateTimePickerFrom.Value.ToShortDateString(), dateTimePickerTo.Value.ToShortDateString());
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка сохранения списка заказов на период");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void buttonGenerateAndSendPdf_Click(object sender, EventArgs e)
        {
            try
            {
                // Получение данных для PDF
                var info = new PdfInfo
                {
                    Title = "Отчет",
                    DateFrom = dateTimePickerFrom.Value,
                    DateTo = dateTimePickerTo.Value,
                    Components = _logic.GetReportComponentsByCardDate(new ReportBindingModel
                    {
                        DateFrom = DateTime.SpecifyKind(dateTimePickerFrom.Value, DateTimeKind.Utc),
                        DateTo = DateTime.SpecifyKind(dateTimePickerTo.Value, DateTimeKind.Utc)
                    })
                };

                // Генерация PDF в памяти
                using (MemoryStream stream = new MemoryStream())
                {
                    CreateDoc(info, stream);

                    // Email пользователя
                    string userEmail = "user@example.com"; // Замените на email пользователя

                    // Отправка email с PDF вложением
                    SendEmailWithPdf(stream, userEmail);
                }

                MessageBox.Show("PDF файл успешно отправлен на почту!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateDoc(PdfInfo info, Stream stream)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, stream);
            writer.CloseStream = false;
            document.Open();

            document.Add(new Paragraph(info.Title, FontFactory.GetFont("Arial", "16", Font.Bold)));
            document.Add(new Paragraph($"с {info.DateFrom.ToShortDateString()} по {info.DateTo.ToShortDateString()}", FontFactory.GetFont("Arial", "12")));

            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 3, 2, 6, 6 });

            var groupedData = info.Components.GroupBy(c => c.ComponentName);

            foreach (var group in groupedData)
            {
                PdfPCell cell = new PdfPCell(new Phrase("Продукт", FontFactory.GetFont("Arial", "12", Font.Bold)));
                cell.Colspan = 4;
                table.AddCell(cell);

                table.AddCell(new Phrase(group.Key, FontFactory.GetFont("Arial", "12", Font.Bold)));
                table.AddCell(new Phrase(group.First().ComponentCost.ToString("C"), FontFactory.GetFont("Arial", "12", Font.Bold)));
                table.AddCell("");
                table.AddCell("");

                table.AddCell(new Phrase("", FontFactory.GetFont("Arial", "12", Font.Bold)));
                table.AddCell("");
                table.AddCell(new Phrase("Карта", FontFactory.GetFont("Arial", "12", Font.Bold)));
                table.AddCell(new Phrase("Блюдо", FontFactory.GetFont("Arial", "12", Font.Bold)));

                foreach (var item in group)
                {
                    table.AddCell("");
                    table.AddCell("");
                    table.AddCell(new Phrase(item.CardName, FontFactory.GetFont("Arial", 12)));
                    table.AddCell(new Phrase(item.ProductName, FontFactory.GetFont("Arial", 12)));
                }
            }

            document.Add(table);
            document.Close();
            writer.Close();
        }
        private void SendEmailWithPdf(MemoryStream pdfStream, string userEmail)
        {
            pdfStream.Position = 0;

            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); // Используем SMTP-сервер Gmail

            mail.From = new MailAddress("user@example.com"); // Ваш email
            mail.To.Add(userEmail);
            mail.Subject = "Отчет";
            mail.Body = "Пожалуйста, найдите прикрепленный PDF отчет.";

            // Создание вложения из потока
            Attachment attachment = new Attachment(pdfStream, "Report.pdf", "application/pdf");
            mail.Attachments.Add(attachment);

            smtpClient.Port = 587; // Порт SMTP-сервера Gmail
            smtpClient.Credentials = new NetworkCredential("user@example.com", "***REMOVED***"); // Ваш email и пароль
            smtpClient.EnableSsl = true;

            smtpClient.Send(mail);
        }




    }
}
