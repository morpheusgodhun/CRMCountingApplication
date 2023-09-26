using System;

public class SelectionItemBase {

    public int FirmId { get; set; }
    public string CustomerName { get; set; }
    public string LoaderName { get; set; }
    public DateTime RegisterDate { get; set; }
    public int SummaryStatementNumber { get; set; }
    public int AntrepoNumber { get; set; }
    public int ContainerNumber { get; set; }
    public int GoodsNumber { get; set; }
    public string Genus { get; set; }
    public int Weight { get; set; }
    public int RequiredCount { get; set; }
    public int Count { get; set; }

    public long Barkod { get; set; }
}
