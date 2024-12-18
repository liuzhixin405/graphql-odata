using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Project.Discuss.Models;

public partial class BbsArticleContent
{
    [Key]
    /// <summary>
    /// 文章id
    /// </summary>
    public long ArticleId { get; set; }

    /// <summary>
    /// 文章内容带html
    /// </summary>
    public string ContentHtml { get; set; } = null!;
    // 导航属性：与 BbsArticle 关联
    [JsonIgnore]
    public virtual BbsArticle BbsArticle { get; set; }
}
