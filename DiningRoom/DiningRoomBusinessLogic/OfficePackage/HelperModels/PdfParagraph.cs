using DiningRoomBusinessLogic.OfficePackage.HelperEnums;

namespace DiningRoomBusinessLogic.OfficePackage.HelperModels
{
    public class PdfParagraph
    {
        public string Text { get; set; } = string.Empty;

        public string Style { get; set; } = string.Empty;

        public PdfParagraphAlignmentType ParagraphAlignment { get; set; }
    }
}