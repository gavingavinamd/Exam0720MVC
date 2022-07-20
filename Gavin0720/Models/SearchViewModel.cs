namespace Gavin0720.Models
{
    public class SearchViewModel
    {
        public FormSearchParams? SearchParams { get; set; }
        public List<TblProduct>? ProductResult { get; set; }

        public SearchViewModel()
        {
            SearchParams = new FormSearchParams();
            ProductResult = new List<TblProduct>();
        }
    }

    public class FormSearchParams
    {
        //列表需要欄位(產品名稱、產品價格、庫存數、建立時間)
        public string? CName { get; set; }
        public string? CPrice { get; set; }
        public string? CInventory { get; set; }
        public DateTime CCreateDt { get; set; }
    }
}
