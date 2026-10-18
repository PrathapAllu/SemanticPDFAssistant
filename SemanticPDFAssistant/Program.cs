using SemanticPDFAssistant.Services;

namespace SemanticPDFAssistant
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            using var dialog = new OpenFileDialog
            {
                Title = "Select a PDF file",
                Filter = "PDF files (.pdf)|.pdf",
                CheckFileExists = true
            };

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                Console.WriteLine("No file selected.");
                return;
            }

            PdfExtractor.ExtractTextFromPdf(dialog.FileName);
        }
    }
}