namespace PsiTransportDataExport.View
{
    public interface IDialogService
    {
        void ShowError(string message, string title);
        void ShowInfo(string message, string title);
    }
}
