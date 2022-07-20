using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gavin0720.Models
{
    public partial class TblProduct
    {
        /// <summary>
        /// 流水號
        /// </summary>
        public int CId { get; set; }
        /// <summary>
        /// 產品名稱
        /// </summary>
        [Required(ErrorMessage = "產品名稱必填")]
        [Display(Name = "產品名稱")]
        public string CName { get; set; } = null!;
        /// <summary>
        /// 產品價格
        /// </summary>
        [Required(ErrorMessage = "產品價格必填")]
        [Display(Name = "產品價格")]
        public int CPrice { get; set; }
        /// <summary>
        /// 庫存數
        /// </summary>
        [Required(ErrorMessage = "庫存數必填")]
        [Display(Name = "庫存數")]
        public int CInventory { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [Display(Name = "建立時間")]
        public DateTime CCreateDt { get; set; }
    }
}
