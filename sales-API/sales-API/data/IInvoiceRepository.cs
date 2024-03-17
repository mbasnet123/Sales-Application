namespace sales_API.data
{
    public interface IInvoiceRepository
    {
        int? GenerateInvoice(int customerId, DateTime date);
    }
}
