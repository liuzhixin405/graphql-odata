using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project.Discuss.Models;

public partial class BbsArticleCoin
{
    
    public long ArticleId { get; set; }
    [Key]
    public string CoinCode { get; set; } = null!;

    public string? CoinName { get; set; }

    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// 币种顺序，升序
    /// </summary>
    public sbyte? Sort { get; set; }

    [JsonIgnore]
    public virtual BbsArticle Article { get; set; } = null!;
}
