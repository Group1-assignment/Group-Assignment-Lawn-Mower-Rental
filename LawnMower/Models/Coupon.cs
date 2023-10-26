using System;

public class Coupon
{
    public bool WasUsed { get; set; }
    public DateTime ExpirationDate { get; }
    public Coupon() {
        WasUsed = false;
        ExpirationDate = new DateTime(DateTime.Now.Year, 12, 31);
    }
}
