using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;
using UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor;

namespace SemanticPDFAssistant.Services
{
    internal class PdfExtractor
    {

        public static void ExtractTextFromPdf(string pdfFilePath)
        {
            try
            {
                using (PdfDocument document = PdfDocument.Open(pdfFilePath))
                {
                    foreach (Page page in document.GetPages())
                    {
                        string text = ContentOrderTextExtractor.GetText(page);
                        IEnumerable<Word> words = page.GetWords(NearestNeighbourWordExtractor.Instance);
                    }
                }
            }
            catch (Exception exception)
            {
                throw new NotImplementedException("PDF text extraction Failed.");
            }
        }
    }
}